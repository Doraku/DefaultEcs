using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Serialization.TextSerializer
{
    internal sealed class StreamWriterWrapper : IDisposable
    {
        private int _indentation;

        public InvariantCultureStreamWriter Stream { get; }

        public TextSerializationContext Context { get; }

        public StreamWriterWrapper(Stream stream, TextSerializationContext context)
        {
            _indentation = 0;

            Stream = new InvariantCultureStreamWriter(stream, new UTF8Encoding(false, true), 1024, true);
            Context = context;
        }

        public void AddIndentation() => ++_indentation;

        public void RemoveIndentation() => --_indentation;

        public void WriteIndentation()
        {
            for (int i = _indentation; i > 0; --i)
            {
                Stream.Write('\t');
            }
        }

        public void WriteSpace() => Stream.Write(' ');

        public void Write(string value) => Stream.Write(value);

        public void WriteLine(string value) => Stream.WriteLine(value);

        public void WriteValue<T>(in T value)
        {
            if (Context?.TypeMarshalling != null)
            {
                Stream.Write("$type ");
                Stream.WriteLine(Context.TypeMarshalling);
                WriteIndentation();
                Context.TypeMarshalling = null;
            }

            if (value is null)
            {
                Stream.WriteLine("null");
            }
            else if (Converter<T>.IsSealed || typeof(T) == value.GetType())
            {
                Converter<T>.WriteAction(this, value);
            }
            else
            {
                Type type = value.GetType();
                WriteTypeMarshalling(TypeNames.Get(type));
                Converter.GetWriteAction(type)(this, value);
            }
        }

        public void WriteTypeMarshalling(string typeMarshalling)
        {
            if (Context is null)
            {
                Stream.Write("$type ");
                Stream.WriteLine(typeMarshalling);
                WriteIndentation();
            }
            else
            {
                Context.TypeMarshalling = typeMarshalling;
            }
        }

        #region IDisposable

        public void Dispose() => Stream.Dispose();

        #endregion
    }

    internal sealed class StreamReaderWrapper : IDisposable
    {
        private readonly StreamReader _stream;

        private char[] _buffer;
        private int _length;
        private bool _isQuotedString;
        private bool _isEndOfLine;

        public bool EndOfStream => _stream.EndOfStream && _length == 0;

        public TextSerializationContext Context { get; }
        public int LineNumber { get; private set; }

        public StreamReaderWrapper(Stream stream, TextSerializationContext context)
        {
            _stream = new StreamReader(stream, Encoding.UTF8, true, 1024, true);

            _buffer = ArrayPool<char>.Shared.Rent(4096);
            _length = 0;
            _isQuotedString = false;
            _isEndOfLine = false;

            Context = context;
            LineNumber = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exception GetException<T>() => new EndOfStreamException($"Could not deserialize type {typeof(T).FullName}");

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Throw<T>() => throw GetException<T>();

        private void InnerPeek(bool readString)
        {
            if ((_length == 0 && !_isQuotedString) || (readString && !_isQuotedString && !_isEndOfLine))
            {
                if (readString && _length > 0 && !_isEndOfLine && !_isQuotedString)
                {
                    ++_length;
                }

                _isEndOfLine = false;
                bool skipLine = false;

                while (!_stream.EndOfStream)
                {
                    int value = _stream.Read();
                    if (value < 0)
                    {
                        break;
                    }

                    char c = (char)value;

                    if (c == '"')
                    {
                        if (_length == 0 && !_isQuotedString)
                        {
                            readString = true;
                            _isQuotedString = true;
                            continue;
                        }

                        if (_isQuotedString)
                        {
                            if (_stream.Peek() != '"')
                            {
                                break;
                            }

                            _stream.Read();
                        }
                    }

                    if (c == '/' && !_isQuotedString && _stream.Peek() == '/')
                    {
                        skipLine = true;
                    }

                    if (!readString && (c == ' ' || c == '\t' || c == '=' || c == ':'))
                    {
                        if (_length > 0)
                        {
                            ArrayExtension.EnsureLength(ref _buffer, _length);
                            _buffer[_length] = c;
                            break;
                        }

                        continue;
                    }

                    if ((c == '\r' || c == '\n') && !_isQuotedString)
                    {
                        if (c == '\r' && _stream.Peek() == '\n')
                        {
                            _stream.Read();
                        }

                        skipLine = false;
                        ++LineNumber;

                        if (_length > 0)
                        {
                            _isEndOfLine = true;
                            break;
                        }

                        continue;
                    }

                    if (skipLine)
                    {
                        continue;
                    }

                    ArrayExtension.EnsureLength(ref _buffer, _length);
                    _buffer[_length++] = c;
                }
            }
        }

        public bool TryPeek(string value)
        {
            InnerPeek(false);

            return new Span<char>(_buffer, 0, _length).SequenceEqual(value.AsSpan());
        }

        public bool TryReadUntil(string value)
        {
            do
            {
                if (TryPeek(value))
                {
                    _length = 0;
                    _isQuotedString = false;
                    return true;
                }

                _length = 0;
                _isQuotedString = false;
            } while (!_stream.EndOfStream);

            return false;
        }

        public ReadOnlySpan<char> ReadAsSpan()
        {
            InnerPeek(false);

            int length = _length;
            _length = 0;
            _isQuotedString = false;

            return new ReadOnlySpan<char>(_buffer, 0, length);
        }

#if NETSTANDARD2_1_OR_GREATER
        public ReadOnlySpan<char> Read() => ReadAsSpan();
#else
        public string Read()
        {
            InnerPeek(false);

            int length = _length;
            _length = 0;
            _isQuotedString = false;

            return length > 0 ? new string(_buffer, 0, length) : string.Empty;
        }
#endif

        public ReadOnlySpan<char> ReadFromLineAsSpan()
        {
            if (!_isEndOfLine)
            {
                InnerPeek(false);
            }

            int length = _length;
            _length = 0;
            _isQuotedString = false;

            return new ReadOnlySpan<char>(_buffer, 0, length);
        }

        public string ReadFromLine()
        {
            if (!_isEndOfLine)
            {
                InnerPeek(false);
            }

            int length = _length;
            _length = 0;
            _isQuotedString = false;

            return length > 0 ? new string(_buffer, 0, length) : string.Empty;
        }

        public string ReadString()
        {
            InnerPeek(true);

            int length = _length;
            _length = 0;
            _isQuotedString = false;

            return length > 0 ? new string(_buffer, 0, length) : string.Empty;
        }

        public void EndLine()
        {
            while (!_stream.EndOfStream && !_isEndOfLine)
            {
                _length = 1;
                _isQuotedString = false;
                InnerPeek(true);
            }

            _length = 0;
            _isQuotedString = false;
            _isEndOfLine = false;
        }

        public T ReadValue<T>()
        {
            if (TryPeek("null") && !_isQuotedString)
            {
                _length = 0;
                return default;
            }

            if (TryPeek("$type") && !_isQuotedString)
            {
                _length = 0;
                return Converter.GetReadAction<T>(Type.GetType(ReadString(), true), Context)(this);
            }

            return Converter<T>.ReadAction(this);
        }

        #region IDisposable

        public void Dispose()
        {
            ArrayPool<char>.Shared.Return(_buffer);
            _stream.Dispose();
        }

        #endregion
    }
}
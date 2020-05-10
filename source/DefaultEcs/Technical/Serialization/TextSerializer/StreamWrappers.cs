using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal sealed class StreamWriterWrapper : IDisposable
    {
        private int _indentation;

        public StreamWriter Stream { get; }
        public TextSerializationContext Context { get; }

        public StreamWriterWrapper(Stream stream, TextSerializationContext context)
        {
            _indentation = 0;

            Stream = new StreamWriter(stream, new UTF8Encoding(false, true), 1024, true);
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

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public void WriteValue<T>(in T value)
        {
            if (Context?.TypeMarshalling != null)
            {
                Stream.Write("$type ");
                Stream.WriteLine(Context.TypeMarshalling);
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
        private bool _endOfLine;
        private bool _previouslyEndOfLine;
        private bool _mayBeComment;

        public bool EndOfStream => _stream.EndOfStream && _length == 0;

        public TextSerializationContext Context { get; }
        public int LineNumber { get; private set; }

        public StreamReaderWrapper(Stream stream, TextSerializationContext context)
        {
            _stream = new StreamReader(stream, Encoding.UTF8, true, 1024, true);

            _buffer = ArrayPool<char>.Shared.Rent(4096);
            _length = 0;
            _endOfLine = false;
            _mayBeComment = false;
            _previouslyEndOfLine = false;

            Context = context;
            LineNumber = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exception GetException<T>() => new EndOfStreamException($"Could not deserialize type {typeof(T).FullName}");

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Throw<T>() => throw GetException<T>();

        private void InnerPeek(bool readLine, bool stayOnLine)
        {
            if ((_length == 0 && (!stayOnLine || !_endOfLine)) || (readLine && !_endOfLine))
            {
                if (readLine && _length > 0 && !_endOfLine)
                {
                    ++_length;
                }

                bool skipLine = false;
                _previouslyEndOfLine = false;

                while (!_stream.EndOfStream)
                {
                    int value = _stream.Read();
                    if (value < 0)
                    {
                        break;
                    }

                    char c = (char)value;

                    if (c == '/')
                    {
                        if (_mayBeComment)
                        {
                            _length = 0;
                            skipLine = true;
                        }
                        else
                        {
                            _mayBeComment = true;
                        }
                    }

                    _mayBeComment = false;

                    if (!readLine && (c == ' ' || c == '\t' || c == '=' || c == ':'))
                    {
                        if (_length > 0)
                        {
                            _buffer[_length] = c;
                            break;
                        }

                        continue;
                    }

                    if (c == '\r' || c == '\n')
                    {
                        if (c == '\r' && _stream.Peek() == '\n')
                        {
                            _stream.Read();
                        }

                        _endOfLine = true;
                        _previouslyEndOfLine = true;
                        skipLine = false;
                        ++LineNumber;

                        if (_length > 0 || stayOnLine)
                        {
                            break;
                        }

                        continue;
                    }

                    if (skipLine)
                    {
                        continue;
                    }

                    if (_buffer.Length < _length)
                    {
                        char[] newBuffer = ArrayPool<char>.Shared.Rent(_buffer.Length * 2);
                        Array.Copy(_buffer, newBuffer, _buffer.Length);
                        ArrayPool<char>.Shared.Return(_buffer);
                        _buffer = newBuffer;
                    }

                    _endOfLine = false;
                    _buffer[_length++] = c;
                }
            }
        }

        public bool TryPeek(string value)
        {
            InnerPeek(false, false);

            return new Span<char>(_buffer, 0, _length).SequenceEqual(value.AsSpan());
        }

        public bool TryReadUntil(string value)
        {
            do
            {
                if (TryPeek(value))
                {
                    _length = 0;
                    return true;
                }

                _length = 0;
            } while (!EndOfStream);

            return false;
        }

        public string Read()
        {
            InnerPeek(false, false);

            int length = _length;
            _length = 0;

            return length > 0 ? new string(_buffer, 0, length) : string.Empty;
        }

        public string ReadFromLine()
        {
            InnerPeek(false, true);

            int length = _length;
            _length = 0;

            return length > 0 ? new string(_buffer, 0, length) : string.Empty;
        }

        public string ReadLine()
        {
            InnerPeek(true, true);

            int length = _length;
            _endOfLine = false;
            _length = 0;

            return length > 0 ? new string(_buffer, 0, length) : string.Empty;
        }

        public void EndLine()
        {
            if (!_previouslyEndOfLine)
            {
                InnerPeek(true, true);
            }
            _endOfLine = false;
            _length = 0;
        }

        public T ReadValue<T>()
        {
            if (TryPeek("null"))
            {
                _length = 0;
                return default;
            }

            if (TryPeek("$type"))
            {
                _length = 0;
                return Converter.GetReadAction<T>(Type.GetType(ReadLine(), true), Context)(this);
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
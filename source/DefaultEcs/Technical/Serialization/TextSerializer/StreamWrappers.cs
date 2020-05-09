using System;
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

        private string _currentLine;
        private int _currentIndex;
        private string _peekedValue;

        public bool EndOfStream => _stream.EndOfStream && _peekedValue is null && string.IsNullOrEmpty(_currentLine);

        public TextSerializationContext Context { get; }
        public int LineNumber { get; private set; }

        public StreamReaderWrapper(Stream stream, TextSerializationContext context)
        {
            _stream = new StreamReader(stream, Encoding.UTF8, true, 1024, true);

            Context = context;
            LineNumber = -1;
        }

        private void AdvanceStream()
        {
            if (_currentLine is null)
            {
                if (_stream.EndOfStream)
                {
                    _currentLine = string.Empty;
                }
                else
                {
                    _currentLine = _stream.ReadLine();
                    ++LineNumber;
                }

                _currentIndex = 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exception GetException<T>() => new EndOfStreamException($"Could not deserialize type {typeof(T).FullName}");

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Throw<T>() => throw GetException<T>();

        public bool TryReadUntil(string value)
        {
            if (_peekedValue == value)
            {
                _peekedValue = null;

                return true;
            }

            while (!EndOfStream)
            {
                if (Read() == value)
                {
                    return true;
                }
            }

            return false;
        }

        public string Peek() => _peekedValue ?? (_peekedValue = Read());

        public string Read()
        {
            if (_peekedValue != null)
            {
                string value = _peekedValue;
                _peekedValue = null;

                return value;
            }

            if (!EndOfStream)
            {
                AdvanceStream();

                int startIndex = -1;
                int length = 0;
                bool _previousWasComment = false;
                for (; _currentIndex < _currentLine.Length; ++_currentIndex)
                {
                    char c = _currentLine[_currentIndex];
                    if (c == ' ' || c == '\t' || c == '=' || c == ':')
                    {
                        if (length > 0)
                        {
                            return _currentLine.Substring(startIndex, length);
                        }
                    }
                    else
                    {
                        if (length > 0)
                        {
                            ++length;
                        }
                        else
                        {
                            startIndex = _currentIndex;
                            length = 1;
                        }

                        if (c == '/')
                        {
                            if (_previousWasComment)
                            {
                                _currentLine = null;
                                return string.Empty;
                            }
                            else
                            {
                                _previousWasComment = true;
                            }
                        }
                        else
                        {
                            _previousWasComment = false;
                        }
                    }
                }

                if (length > 0)
                {
                    return _currentLine.Substring(startIndex, length);
                }

                _currentLine = null;
            }

            return string.Empty;
        }

        public string ReadLine()
        {
            string line;

            if (_peekedValue != null)
            {
                line = _currentLine.Substring(_currentIndex - _peekedValue.Length);
                _peekedValue = null;
            }
            else
            {
                AdvanceStream();

                line = _currentLine.Substring(_currentIndex);
            }

            _currentLine = null;

            return line;
        }

        public T ReadValue<T>()
        {
            while (!EndOfStream && string.IsNullOrEmpty(Peek()))
            {
                Read();
            }

            switch (Peek())
            {
                case "null":
                    Read();
                    return default;

                case "$type":
                    Read();
                    return Converter.GetReadAction<T>(Type.GetType(ReadLine(), true), Context)(this);

                default:
                    return Converter<T>.ReadAction(this);
            }
        }

        #region IDisposable

        public void Dispose() => _stream.Dispose();

        #endregion
    }
}
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal sealed class StreamWriterWrapper : IDisposable
    {
        private int _indentation;

        public readonly StreamWriter Stream;

        public StreamWriterWrapper(Stream stream)
        {
            _indentation = 0;

            Stream = new StreamWriter(stream, new UTF8Encoding(false, true), 1024, true);
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

        public int LineNumber { get; private set; }

        public StreamReaderWrapper(Stream stream)
        {
            _stream = new StreamReader(stream, Encoding.UTF8, true, 1024, true);

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
                if (ReadValue() == value)
                {
                    return true;
                }
            }

            return false;
        }

        public string PeekValue() => _peekedValue ?? (_peekedValue = ReadValue());

        public string ReadValue()
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

                if (startIndex >= 0)
                {
                    return _currentLine.Substring(startIndex, length);
                }

                _currentLine = null;
                return string.Empty;
            }

            return string.Empty;
        }

        public string ReadLine()
        {
            string line;

            if (_peekedValue != null)
            {
                line = _currentLine.Substring(_currentIndex - _peekedValue.Length);
            }
            else
            {
                AdvanceStream();

                line = _currentLine.Substring(_currentIndex);
            }
            _currentLine = null;

            return line;
        }

        #region IDisposable

        public void Dispose() => _stream.Dispose();

        #endregion
    }
}
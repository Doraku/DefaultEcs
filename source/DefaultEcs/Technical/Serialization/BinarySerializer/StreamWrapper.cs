using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal unsafe readonly struct StreamWriterWrapper : IDisposable
    {
        private readonly Stream _stream;
#if NETSTANDARD1_1 || NETSTANDARD2_0
        private readonly byte[] _buffer;
        private readonly GCHandle _handle;
        private readonly byte* _bufferP;
#endif

        public StreamWriterWrapper(Stream stream)
        {
            _stream = stream;
#if NETSTANDARD1_1 || NETSTANDARD2_0
            _buffer = new byte[1024];
            _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            _bufferP = (byte*)_handle.AddrOfPinnedObject().ToPointer();
#endif
        }

        public void WriteByte(byte value) => _stream.WriteByte(value);

        public void WriteString(string value)
        {
#if NETSTANDARD1_1 || NETSTANDARD2_0
            int* lengthP = (int*)_bufferP;
            *lengthP++ = value.Length;
            char* valueP = (char*)lengthP;

            int count = sizeof(int);

            foreach (char c in value)
            {
                if (count + sizeof(char) > _buffer.Length)
                {
                    _stream.Write(_buffer, 0, count);
                    valueP = (char*)_bufferP;
                    count = 0;
                }

                *valueP++ = c;
                count += sizeof(char);
            }

            _stream.Write(_buffer, 0, count);
#else
            Write(value.Length);
            _stream.Write(MemoryMarshal.AsBytes(value.AsSpan()));
#endif
        }

        public void Write<T>(in T value)
            where T : unmanaged
        {
#if NETSTANDARD1_1 || NETSTANDARD2_0
            if (sizeof(T) <= _buffer.Length)
            {
                *(T*)_bufferP = value;

                _stream.Write(_buffer, 0, sizeof(T));
            }
            else
            {
                int count = 0;
                T valueCopy = value;
                byte* valueP = (byte*)&valueCopy;
                byte* destination = _bufferP;

                for (int i = 0; i < sizeof(T); ++i)
                {
                    *destination++ = *valueP++;
                    if (++count >= _buffer.Length)
                    {
                        _stream.Write(_buffer, 0, count);
                        count = 0;
                        destination = _bufferP;
                    }
                }

                _stream.Write(_buffer, 0, count);
            }
#else
            fixed (T* valueP = &value)
            {
                _stream.Write(MemoryMarshal.AsBytes(new ReadOnlySpan<T>(valueP, 1)));
            }
#endif
        }

        #region IDisposable

        public void Dispose()
        {
#if NETSTANDARD1_1 || NETSTANDARD2_0
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
#endif
        }

        #endregion
    }

    internal unsafe readonly ref struct StreamReaderWrapper
    {
        private readonly Stream _stream;
#if NETSTANDARD1_1 || NETSTANDARD2_0
        private readonly byte[] _buffer;
        private readonly GCHandle _handle;
        private readonly byte* _bufferP;
#endif

        public StreamReaderWrapper(Stream stream)
        {
            _stream = stream;
#if NETSTANDARD1_1 || NETSTANDARD2_0
            _buffer = new byte[1024];
            _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            _bufferP = (byte*)_handle.AddrOfPinnedObject().ToPointer();
#endif
        }

        public int ReadByte() => _stream.ReadByte();

        public string ReadString()
        {
            string value = null;

#if NETSTANDARD1_1 || NETSTANDARD2_0
            if (_stream.Read(_buffer, 0, sizeof(int)) == sizeof(int))
            {
                int totalLength = *(int*)_bufferP * sizeof(char);

                while (totalLength > 0)
                {
                    int length = _stream.Read(_buffer, 0, Math.Min(_buffer.Length, totalLength));

                    if (length <= 0)
                    {
                        throw new EndOfStreamException($"Could not deserialize type {typeof(string).FullName}");
                    }

                    totalLength -= length;
                    value += new string((char*)_bufferP, 0, length / sizeof(char));
                }
            }
#else
            value = string.Create(Read<int>(), _stream, (buffer, stream) => stream.Read(MemoryMarshal.AsBytes(buffer)));
#endif

            return value;
        }

        public T Read<T>()
            where T : unmanaged
        {
#if NETSTANDARD1_1 || NETSTANDARD2_0
            if (sizeof(T) <= _buffer.Length)
            {
                if (_stream.Read(_buffer, 0, sizeof(T)) != sizeof(T))
                {
                    throw new EndOfStreamException($"Could not deserialize type {typeof(T).FullName}");
                }

                return MemoryMarshal.Read<T>(_buffer);
            }

            T value = default;

            byte* valueP = (byte*)&value;

            int totalLength = sizeof(T);

            while (totalLength > 0)
            {
                int length = _stream.Read(_buffer, 0, Math.Min(_buffer.Length, totalLength));

                if (length <= 0)
                {
                    throw new EndOfStreamException($"Could not deserialize type {typeof(T).FullName}");
                }

                totalLength -= length;

                byte* destination = _bufferP;
                for (int i = 0; i < length; ++i)
                {
                    *valueP++ = *destination++;
                }
            }
#else
            T value = default;

            if (_stream.Read(MemoryMarshal.AsBytes(new Span<T>(&value, 1))) != sizeof(T))
            {
                throw new EndOfStreamException($"Could not deserialize type {typeof(T).FullName}");
            }
#endif

            return value;
        }

        #region IDisposable

        public void Dispose()
        {
#if NETSTANDARD1_1 || NETSTANDARD2_0
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
#endif
        }

        #endregion
    }
}
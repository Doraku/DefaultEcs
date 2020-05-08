using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DefaultEcs.Serialization;
using DefaultEcs.Technical.Helper;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal unsafe readonly struct StreamWriterWrapper : IDisposable
    {
        private readonly Stream _stream;
#if NETSTANDARD1_1 || NETSTANDARD2_0
        private readonly byte[] _buffer;
#endif

        public readonly BinarySerializationContext Context;

        public StreamWriterWrapper(Stream stream, BinarySerializationContext context)
        {
            _stream = stream;
#if NETSTANDARD1_1 || NETSTANDARD2_0
            _buffer = ArrayPool<byte>.Shared.Rent(4096);
#endif

            Context = context;
        }

#if NETSTANDARD1_1 || NETSTANDARD2_0
        private void Write(ReadOnlySpan<byte> bytes)
        {
            int byteToWrite = bytes.Length;

            while (byteToWrite > 0)
            {
                int byteCount = Math.Min(byteToWrite, _buffer.Length);
                bytes.Slice(bytes.Length - byteToWrite, byteCount).CopyTo(_buffer.AsSpan(0, byteCount));
                _stream.Write(_buffer, 0, byteCount);
                byteToWrite -= byteCount;
            }
        }
#endif

        public void WriteByte(byte value) => _stream.WriteByte(value);

        public void WriteString(string value)
        {
            Write(value.Length);
            if (value.Length > 0)
            {
                fixed (char* valueP = value)
                {
#if NETSTANDARD1_1 || NETSTANDARD2_0
                    Write(new ReadOnlySpan<byte>(valueP, value.Length * sizeof(char)));
#else
                    _stream.Write(new ReadOnlySpan<byte>(valueP, value.Length * sizeof(char)));
#endif
                }
            }
        }

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public void Write<T>(in T value)
            where T : unmanaged
        {
            fixed (T* valueP = &value)
            {
#if NETSTANDARD1_1 || NETSTANDARD2_0
                Write(new ReadOnlySpan<byte>(valueP, sizeof(T)));
#else
                _stream.Write(new ReadOnlySpan<byte>(valueP, sizeof(T)));
#endif
            }
        }

        public void WriteArray<T>(T[] value)
            where T : unmanaged
        {
            Write(value.Length);
            if (value.Length > 0)
            {
                fixed (T* valueP = value)
                {
#if NETSTANDARD1_1 || NETSTANDARD2_0
                    Write(new ReadOnlySpan<byte>(valueP, value.Length * sizeof(T)));
#else
                    _stream.Write(new ReadOnlySpan<byte>(valueP, value.Length * sizeof(T)));
#endif
                }
            }
        }

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public void WriteValue<T>(in T value)
        {
            if (Context?.TypeMarshalling != null)
            {
                WriteByte(2);
                WriteString(Context.TypeMarshalling);
                Context.TypeMarshalling = null;
            }

            if (value is null)
            {
                WriteByte(0);
            }
            else if (Converter<T>.IsSealed || value.GetType() == typeof(T))
            {
                WriteByte(1);
                Converter<T>.WriteAction(this, value);
            }
            else
            {
                string typeName = TypeNames.Get(value.GetType());
                WriteTypeMarshalling(typeName);
                Converter.GetWriteAction(typeName)(this, value);
            }
        }

        public void WriteTypeMarshalling(string typeMarshalling)
        {
            if (Context is null)
            {
                WriteByte(2);
                WriteString(typeMarshalling);
            }
            else
            {
                Context.TypeMarshalling = typeMarshalling;
            }
        }

        #region IDisposable

        public void Dispose()
        {
#if NETSTANDARD1_1 || NETSTANDARD2_0
            ArrayPool<byte>.Shared.Return(_buffer);
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

        public readonly BinarySerializationContext Context;

        public StreamReaderWrapper(Stream stream, BinarySerializationContext context)
        {
            _stream = stream;
#if NETSTANDARD1_1 || NETSTANDARD2_0
            _buffer = ArrayPool<byte>.Shared.Rent(4096);
            _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            _bufferP = (byte*)_handle.AddrOfPinnedObject().ToPointer();
#endif

            Context = context;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Exception GetException<T>() => new EndOfStreamException($"Could not deserialize type {typeof(T).FullName}");

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool Throw<T>() => throw GetException<T>();

        public int ReadByte() => _stream.ReadByte();

        public string ReadString()
        {
            string value = string.Empty;

            int stringLength = Read<int>();
            if (stringLength > 0)
            {
#if NETSTANDARD1_1 || NETSTANDARD2_0
                int byteToRead = stringLength * sizeof(char);
                if (byteToRead <= _buffer.Length)
                {
                    if (_stream.Read(_buffer, 0, byteToRead) < byteToRead)
                    {
                        Throw<string>();
                    }

                    value = new string((char*)_bufferP, 0, stringLength);
                }
                else
                {
                    byte[] valueBytes = new byte[byteToRead];
                    if (_stream.Read(valueBytes, 0, byteToRead) < byteToRead)
                    {
                        Throw<string>();
                    }

                    fixed (byte* valueP = valueBytes)
                    {
                        value = new string((char*)valueP, 0, stringLength);
                    }
                }
#else
                value = string.Create(stringLength, _stream, (buffer, stream) =>
                {
                    fixed (char* bufferP = buffer)
                    {
                        if (stream.Read(new Span<byte>(bufferP, buffer.Length * sizeof(char))) != buffer.Length * sizeof(char))
                        {
                            Throw<string>();
                        }
                    }
                });
#endif
            }

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
                    Throw<T>();
                }

                return *(T*)_bufferP;
            }

            byte[] value = new byte[sizeof(T)];
            if (_stream.Read(value, 0, value.Length) != value.Length)
            {
                Throw<T>();
            }

            fixed (byte* valueP = value)
            {
                return *(T*)valueP;
            }
#else
            T value = default;
            if (_stream.Read(new Span<byte>(&value, sizeof(T))) != sizeof(T))
            {
                Throw<T>();
            }

            return value;
#endif
        }

        public T[] ReadArray<T>()
            where T : unmanaged
        {
            int length = Read<int>();
            if (length == 0)
            {
                return EmptyArray<T>.Value;
            }

            T[] values = new T[length];
#if NETSTANDARD1_1 || NETSTANDARD2_0
            for (int i = 0; i < values.Length; ++i)
            {
                values[i] = Read<T>();
            }
#else
            length *= sizeof(T);
            fixed (T* valueP = values)
            {
                if (_stream.Read(new Span<byte>(valueP, length)) != length)
                {
                    Throw<T[]>();
                }
            }
#endif

            return values;
        }

        public T ReadValue<T>() => ReadByte() switch
        {
            0 => default,
            1 => Converter<T>.ReadAction(this),
            2 => Converter.GetReadAction<T>(ReadString(), Context)(this),
            _ => throw GetException<T>(),
        };

        #region IDisposable

        public void Dispose()
        {
#if NETSTANDARD1_1 || NETSTANDARD2_0
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
            ArrayPool<byte>.Shared.Return(_buffer);
#endif
        }

        #endregion
    }
}
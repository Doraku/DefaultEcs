using System;
using System.Collections.Generic;
using System.IO;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal sealed unsafe class ComponentTypeWriter : IComponentTypeReader
    {
        #region Fields

        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly byte* _bufferP;
        private readonly Dictionary<Type, ushort> _types;
        private readonly int _maxEntityCount;

        private ushort _currentType;

        #endregion

        #region Initialisation

        public ComponentTypeWriter(Stream stream, byte[] buffer, byte* bufferP, Dictionary<Type, ushort> types, int maxEntityCount)
        {
            _stream = stream;
            _buffer = buffer;
            _bufferP = bufferP;
            _types = types;
            _maxEntityCount = maxEntityCount;
        }

        #endregion

        #region IComponentTypeReader

        void IComponentTypeReader.OnRead<T>(int maxComponentCount)
        {
            _types.Add(typeof(T), _currentType);

            *_bufferP = (byte)EntryType.ComponentType;
            ushort* entryType = (ushort*)(_bufferP + 1);
            *(entryType++) = _currentType;
            _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort));
            Converter<string>.Write(typeof(T).AssemblyQualifiedName, _stream, _buffer, _bufferP);

            if (maxComponentCount != _maxEntityCount)
            {
                *_bufferP = (byte)EntryType.MaxComponentCount;
                entryType = (ushort*)(_bufferP + 1);
                *(entryType++) = _currentType;
                *(int*)entryType = maxComponentCount;

                _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort) + sizeof(int));
            }

            ++_currentType;
        }

        #endregion
    }
}

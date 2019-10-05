using System;
using System.Collections.Generic;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal sealed class ComponentTypeWriter : IComponentTypeReader
    {
        #region Fields

        private readonly StreamWriterWrapper _writer;
        private readonly Dictionary<Type, ushort> _types;
        private readonly int _maxEntityCount;

        private ushort _currentType;

        #endregion

        #region Initialisation

        public ComponentTypeWriter(in StreamWriterWrapper writer, Dictionary<Type, ushort> types, int maxEntityCount)
        {
            _writer = writer;
            _types = types;
            _maxEntityCount = maxEntityCount;
        }

        #endregion

        #region IComponentTypeReader

        void IComponentTypeReader.OnRead<T>(int maxComponentCount)
        {
            _types.Add(typeof(T), _currentType);

            _writer.WriteByte((byte)EntryType.ComponentType);
            _writer.Write(_currentType);
            _writer.WriteString(typeof(T).AssemblyQualifiedName);

            if (maxComponentCount != _maxEntityCount)
            {
                _writer.WriteByte((byte)EntryType.MaxComponentCount);
                _writer.Write(_currentType);
                _writer.Write(maxComponentCount);
            }

            ++_currentType;
        }

        #endregion
    }
}

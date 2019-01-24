using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal sealed class ComponentTypeWriter : IComponentTypeReader
    {
        #region Fields

        private readonly StreamWriter _writer;
        private readonly Dictionary<Type, string> _types;
        private readonly int _maxEntityCount;

        #endregion

        #region Initialisation

        public ComponentTypeWriter(StreamWriter writer, Dictionary<Type, string> types, int maxEntityCount)
        {
            _writer = writer;
            _types = types;
            _maxEntityCount = maxEntityCount;
        }

        #endregion

        #region IComponentTypeReader

        void IComponentTypeReader.OnRead<T>(int maxComponentCount)
        {
            string shortName = typeof(T).Name;

            int repeatCount = 1;
            while (_types.ContainsValue(shortName))
            {
                shortName = $"{typeof(T).Name}_{repeatCount++}";
            }

            _types.Add(typeof(T), shortName);

            _writer.WriteLine($"{nameof(EntryType.ComponentType)} {shortName} {typeof(T).FullName}, {typeof(T).GetTypeInfo().Assembly.GetName().Name}");
            if (maxComponentCount != _maxEntityCount)
            {
                _writer.WriteLine($"{nameof(EntryType.MaxComponentCount)} {shortName} {maxComponentCount}");
            }
        }

        #endregion
    }
}

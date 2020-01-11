using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DefaultEcs.Serialization;
using DefaultEcs.Technical.Helper;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal sealed class ComponentTypeWriter : IComponentTypeReader
    {
        #region Fields

        private readonly StreamWriter _writer;
        private readonly Dictionary<Type, string> _types;
        private readonly int _worldMaxCapacity;

        #endregion

        #region Initialisation

        public ComponentTypeWriter(StreamWriter writer, Dictionary<Type, string> types, int worldMaxCapacity)
        {
            _writer = writer;
            _types = types;
            _worldMaxCapacity = worldMaxCapacity;
        }

        #endregion

        #region IComponentTypeReader

        void IComponentTypeReader.OnRead<T>(int maxCapacity)
        {
            string shortName = typeof(T).Name;

            int repeatCount = 1;
            while (_types.ContainsValue(shortName))
            {
                shortName = $"{typeof(T).Name}_{repeatCount++}";
            }

            _types.Add(typeof(T), shortName);

            _writer.WriteLine($"{nameof(EntryType.ComponentType)} {shortName} {typeof(T).FullName}, {typeof(T).GetTypeInfo().Assembly.GetName().Name}");
            if (maxCapacity != _worldMaxCapacity && !typeof(T).GetTypeInfo().IsFlagType())
            {
                _writer.WriteLine($"{nameof(EntryType.ComponentMaxCapacity)} {shortName} {maxCapacity}");
            }
        }

        #endregion
    }
}

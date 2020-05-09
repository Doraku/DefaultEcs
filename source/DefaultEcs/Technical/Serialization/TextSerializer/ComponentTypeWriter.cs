using System;
using System.Collections.Generic;
using System.Reflection;
using DefaultEcs.Serialization;
using DefaultEcs.Technical.Helper;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal sealed class ComponentTypeWriter : IComponentTypeReader
    {
        #region Fields

        private readonly StreamWriterWrapper _writer;
        private readonly Dictionary<Type, string> _types;
        private readonly int _worldMaxCapacity;
        private readonly Predicate<Type> _componentFilter;

        #endregion

        #region Initialisation

        public ComponentTypeWriter(StreamWriterWrapper writer, Dictionary<Type, string> types, int worldMaxCapacity, Predicate<Type> componentFilter)
        {
            _writer = writer;
            _types = types;
            _worldMaxCapacity = worldMaxCapacity;
            _componentFilter = componentFilter;
        }

        #endregion

        #region Methods

        public void WriteComponent<T>(int maxCapacity)
        {
            string shortName = typeof(T).Name;

            int repeatCount = 1;
            while (_types.ContainsValue(shortName))
            {
                shortName = $"{typeof(T).Name}_{repeatCount++}";
            }

            _types.Add(typeof(T), shortName);

            _writer.Stream.WriteLine($"{nameof(EntryType.ComponentType)} {shortName} {TypeNames.Get(typeof(T))}");
            if (maxCapacity != _worldMaxCapacity && !typeof(T).GetTypeInfo().IsFlagType())
            {
                _writer.Stream.WriteLine($"{nameof(EntryType.ComponentMaxCapacity)} {shortName} {maxCapacity}");
            }
        }

        #endregion

        #region IComponentTypeReader

        void IComponentTypeReader.OnRead<T>(int maxCapacity)
        {
            if (_componentFilter(typeof(T)))
            {
                Action<ComponentTypeWriter, int> action = _writer.Context?.GetWorldWrite<T>();
                if (action is null)
                {
                    WriteComponent<T>(maxCapacity);
                }
                else
                {
                    action(this, maxCapacity);
                }
            }
        }

        #endregion
    }
}

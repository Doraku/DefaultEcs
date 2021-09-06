using System;
using System.Collections.Generic;
using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Serialization.BinarySerializer
{
    internal sealed class ComponentTypeWriter : IComponentTypeReader
    {
        #region Fields

        private readonly World _world;
        private readonly StreamWriterWrapper _writer;
        private readonly Dictionary<Type, ushort> _types;
        private readonly int _worldMaxCapacity;
        private readonly Predicate<Type> _componentFilter;

        private ushort _currentType;

        #endregion

        #region Initialisation

        public ComponentTypeWriter(World world, in StreamWriterWrapper writer, Dictionary<Type, ushort> types, int worldMaxCapacity, Predicate<Type> componentFilter)
        {
            _world = world;
            _writer = writer;
            _types = types;
            _worldMaxCapacity = worldMaxCapacity;
            _componentFilter = componentFilter;
        }

        #endregion

        #region Methods

        public void WriteComponent<T>(int maxCapacity, bool hasComponent, Func<World, T> getter)
        {
            _types.Add(typeof(T), _currentType);

            _writer.WriteByte((byte)EntryType.ComponentType);
            _writer.Write(_currentType);
            _writer.WriteString(TypeNames.Get(typeof(T)));

            if (maxCapacity != _worldMaxCapacity)
            {
                _writer.WriteByte((byte)EntryType.ComponentMaxCapacity);
                _writer.Write(_currentType);
                _writer.Write(maxCapacity);
            }

            if (hasComponent)
            {
                _writer.WriteByte((byte)EntryType.Component);
                _writer.Write(_currentType);
                Converter<T>.Write(_writer, getter(_world));
            }

            ++_currentType;
        }

        #endregion

        #region IComponentTypeReader

        void IComponentTypeReader.OnRead<T>(int maxCapacity)
        {
            if (_componentFilter(typeof(T)))
            {
                Action<ComponentTypeWriter, int, bool> action = _writer.Context?.GetWorldWrite<T>();
                if (action is null)
                {
                    WriteComponent(maxCapacity, _world.Has<T>(), w => w.Get<T>());
                }
                else
                {
                    action(this, maxCapacity, _world.Has<T>());
                }
            }
        }

        #endregion
    }
}

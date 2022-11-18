using System;
using System.Collections.Generic;
using System.Reflection;

namespace DefaultEcs.Internal.Command
{
    internal static class ComponentCommands
    {
        #region Types

        public unsafe delegate void WriteComponent<T>(List<object> objects, byte* memory, in T component);

        public unsafe delegate int WorldSetComponent(World world, List<object> objects, byte* memory);

        public unsafe delegate int EntitySetComponent(in Entity entity, List<object> objects, byte* memory);

        public sealed unsafe class ComponentCommand<T> : IComponentCommand
        {
            #region Fields

            private static readonly WriteComponent<T> _writeComponentAction;
            private static readonly WorldSetComponent _worldSetAction;
            private static readonly EntitySetComponent _entitySetAction;

            public static readonly int Index;
            public static readonly int SizeOfT;

            #endregion

            #region Initialisation

            static ComponentCommand()
            {
                lock (_componentCommands)
                {
                    Index = _componentCommands.Count;
                    _componentCommands.Add(new ComponentCommand<T>());
                }

                if (typeof(T).IsUnmanaged())
                {
                    TypeInfo typeInfo = typeof(UnmanagedComponentCommand<>).MakeGenericType(typeof(T)).GetTypeInfo();

                    SizeOfT = (int)typeInfo.GetDeclaredField(nameof(UnmanagedComponentCommand<bool>.SizeOfT)).GetValue(null);

                    _writeComponentAction = (WriteComponent<T>)typeInfo
                        .GetDeclaredMethod(nameof(UnmanagedComponentCommand<bool>.WriteComponent))
                        .CreateDelegate(typeof(WriteComponent<T>));
                    _worldSetAction = (WorldSetComponent)typeInfo
                        .GetDeclaredMethod(nameof(UnmanagedComponentCommand<bool>.SetWorldComponent))
                        .CreateDelegate(typeof(WorldSetComponent));
                    _entitySetAction = (EntitySetComponent)typeInfo
                        .GetDeclaredMethod(nameof(UnmanagedComponentCommand<bool>.SetEntityComponent))
                        .CreateDelegate(typeof(EntitySetComponent));
                }
                else
                {
                    SizeOfT = sizeof(int);

                    _writeComponentAction = ManagedComponentCommand<T>.WriteComponent;
                    _worldSetAction = ManagedComponentCommand<T>.Set;
                    _entitySetAction = ManagedComponentCommand<T>.Set;
                }
            }

            #endregion

            #region Methods

            public static void WriteComponent(List<object> objects, byte* memory, in T component) => _writeComponentAction(objects, memory, component);

            #endregion

            #region IComponentCommand

            public int Set(World world, List<object> objects, byte* memory) => _worldSetAction(world, objects, memory);

            public void Remove(World world) => world.Remove<T>();

            public void Enable(in Entity entity) => entity.Enable<T>();

            public void Disable(in Entity entity) => entity.Disable<T>();

            public int Set(in Entity entity, List<object> objects, byte* memory) => _entitySetAction(entity, objects, memory);

            public void SetSameAs(in Entity entity, in Entity reference) => entity.SetSameAs<T>(reference);

            public void SetSameAsWorld(in Entity entity) => entity.SetSameAsWorld<T>();

            public void Remove(in Entity entity) => entity.Remove<T>();

            public void NotifyChanged(in Entity entity) => entity.NotifyChanged<T>();

            #endregion
        }

        #endregion

        #region Fields

        private static readonly List<IComponentCommand> _componentCommands;

        #endregion

        #region Initialisation

        static ComponentCommands()
        {
            _componentCommands = new List<IComponentCommand>();
        }

        #endregion

        #region Methods

        public static IComponentCommand GetCommand(int index) => _componentCommands[index];

        #endregion
    }
}

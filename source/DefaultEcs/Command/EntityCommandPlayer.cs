//using System.Collections.Generic;
//using DefaultEcs.Technical.Command;

//namespace DefaultEcs.Command
//{
//    internal sealed class EntityCommandPlayer
//    {
//        #region Fields

//        private readonly byte[] _memory;
//        private readonly List<object> _objects;

//        #endregion

//        #region Initialisation

//        internal EntityCommandPlayer(byte[] memory, object[] objects)
//        {
//            _memory = memory;
//            _objects = new List<object>(objects);
//        }

//        #endregion

//        #region Methods

//        public void Execute(World world) => Executer.Execute(_memory, _memory.Length, _objects, world);

//        #endregion
//    }
//}

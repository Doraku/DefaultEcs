namespace DefaultEcs.Internal
{
    internal readonly struct ComponentFlag
    {
        #region Fields

        private static readonly object _lockObject;

        private static ComponentFlag _lastFlag;

        public readonly int Index;
        public readonly uint Bit;

        #endregion

        #region Initialisation

        static ComponentFlag()
        {
            _lockObject = new object();

            _lastFlag = new ComponentFlag(0, 1u);
        }

        private ComponentFlag(int index, uint bit)
        {
            Index = index;
            Bit = bit;
        }

        #endregion

        #region Methods

        public static ComponentFlag GetNextFlag()
        {
            lock (_lockObject)
            {
                ComponentFlag flag = _lastFlag;
                _lastFlag = _lastFlag.Bit != 0x8000_0000 ? new ComponentFlag(_lastFlag.Index, _lastFlag.Bit << 1) : new ComponentFlag(_lastFlag.Index + 1, 1u);

                return flag;
            }
        }

        #endregion
    }
}

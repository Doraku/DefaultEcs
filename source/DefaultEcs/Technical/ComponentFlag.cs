namespace DefaultEcs.Technical
{
    internal readonly struct ComponentFlag
    {
        #region Fields

        private static ComponentFlag _lastFlag;

        public readonly short Index;
        public readonly short Bit;

        #endregion

        #region Initialisation

        public ComponentFlag(short index, short bit)
        {
            Index = index;
            Bit = bit;
        }

        #endregion

        #region Methods

        public static ComponentFlag GetNextFlag()
        {
            lock (typeof(ComponentFlag))
            {
                ComponentFlag flag = _lastFlag;
                _lastFlag = _lastFlag.Bit < 31 ? new ComponentFlag(_lastFlag.Index, (short)(_lastFlag.Bit + 1)) : new ComponentFlag((short)(_lastFlag.Index + 1), 0);

                return flag;
            }
        }

        #endregion
    }
}

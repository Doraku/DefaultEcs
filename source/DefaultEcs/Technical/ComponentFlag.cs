namespace DefaultEcs.Technical
{
    internal readonly struct ComponentFlag
    {
        #region Fields

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

        public ComponentFlag GetNextFlag() => Bit < 31 ? new ComponentFlag(Index, (short)(Bit + 1)) : new ComponentFlag((short)(Index + 1), 0);

        #endregion
    }
}

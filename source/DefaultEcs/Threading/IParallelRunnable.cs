namespace DefaultEcs.Threading
{
    /// <summary>
    /// Exposes a method to run a process in parallel.
    /// </summary>
    public interface IParallelRunnable
    {
        /// <summary>
        /// Runs the part <paramref name="index"/> out of <paramref name="maxIndex"/> of the process.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="maxIndex"></param>
        void Run(int index, int maxIndex);
    }
}

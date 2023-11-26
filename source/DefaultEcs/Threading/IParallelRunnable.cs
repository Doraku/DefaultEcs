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
        /// <param name="index">
        ///     Index of given ecs worker. <para/> 
        ///     Using same index as <paramref name="maxIndex"/> for main thread is preferable to process leftover entities there.
        /// </param>
        /// <param name="maxIndex">Max index for ecs workers</param>
        void Run(int index, int maxIndex);
    }
}

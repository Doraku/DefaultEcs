using System.Reflection;
using BenchmarkDotNet.Running;

namespace DefaultEcs.Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).RunAll();
        }
    }
}

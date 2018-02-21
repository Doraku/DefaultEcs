using BenchmarkDotNet.Running;

namespace DefaultEcs.Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkSwitcher.FromTypes(new[]
            {
                typeof(DefaultEcs.EntitySetEnumeration),
            }).RunAll();

            //BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).RunAll();
        }
    }
}

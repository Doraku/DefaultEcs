using BenchmarkDotNet.Running;

namespace DefaultEcs.Benchmark
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkSwitcher.FromTypes(new[]
            {
                //typeof(DefaultEcs.CreateEntity),
                //typeof(DefaultEcs.EntitySetEnumeration),
                //typeof(DefaultEcs.EntitySetWithComponentEnumeration),
                typeof(DefaultEcs.System),
                //typeof(DefaultEcs.Serialization),
                //typeof(Performance.SingleComponentEntityEnumeration),
                //typeof(Performance.DoubleComponentEntityEnumeration),
                //typeof(Message.Publish),
            }).RunAll();

            //BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).RunAll();
        }
    }
}

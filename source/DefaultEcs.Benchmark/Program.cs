using BenchmarkDotNet.Running;

namespace DefaultEcs.Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            //        var config = ManualConfig.Create(DefaultConfig.Instance)
            //.With(HardwareCounter.CacheMisses);
            BenchmarkSwitcher.FromTypes(new[]
            {
                //typeof(DefaultEcs.CreateEntity),
                //typeof(DefaultEcs.EntitySetEnumeration),
                //typeof(DefaultEcs.EntitySetWithComponentEnumeration),
                typeof(DefaultEcs.System),
                //typeof(Message.Publish),
            }).RunAll();

            //BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).RunAll();
        }
    }
}

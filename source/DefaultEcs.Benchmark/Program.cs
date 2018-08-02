using BenchmarkDotNet.Running;

namespace DefaultEcs.Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            //SingleComponentEntityEnumeration test = new SingleComponentEntityEnumeration
            //{
            //    EntityCount = 100000
            //};
            //test.Setup();

            //Thread.Sleep(10000);

            //test.DefaultEcs_System();
            //test.DefaultEcs_System();
            //test.DefaultEcs_System();
            //test.DefaultEcs_System();
            //test.DefaultEcs_System();


            //Thread.Sleep(5000);

            //test.Cleanup();

            //        var config = ManualConfig.Create(DefaultConfig.Instance)
            //.With(HardwareCounter.CacheMisses);
            BenchmarkSwitcher.FromTypes(new[]
            {
                //typeof(DefaultEcs.CreateEntity),
                //typeof(DefaultEcs.EntitySetEnumeration),
                //typeof(DefaultEcs.EntitySetWithComponentEnumeration),
                //typeof(DefaultEcs.System),
                typeof(Performance.SingleComponentEntityEnumeration),
                //typeof(Message.Publish),
            }).RunAll();

            //BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).RunAll();
        }
    }
}

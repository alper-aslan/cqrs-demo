using System;

namespace CQRS.Demo.BusinessLogic.Helpers
{
    public class PerformanceProfiler : IDisposable
    {
        public void StartMeasurement()
        {
            Console.WriteLine("Profiler: Start Measurement");
        }

        public void Dispose()
        {
            Console.WriteLine("Profiler: End Measurement");
        }
    }
}

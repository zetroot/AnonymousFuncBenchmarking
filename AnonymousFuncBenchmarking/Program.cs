using System;
using BenchmarkDotNet.Running;

namespace AnonymousFuncBenchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<FuncBenchmark>();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
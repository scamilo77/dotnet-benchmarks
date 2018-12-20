using BenchmarkDotNet.Running;
using Benchmarks;
using System;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ConcatVsInterpolationVsFormat>();
        }
    }
}

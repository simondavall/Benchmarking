using BenchmarkDotNet.Running;

namespace Benchmarking;


internal class Program
{
  static void Main(string[] args)
  {
    BenchmarkRunner.Run<Benchmarks>();
  }
}

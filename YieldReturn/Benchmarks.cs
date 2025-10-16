using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarking;

[MemoryDiagnoser()]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn()]
public class Benchmarks
{
  private static readonly YieldReturn testClass = new();

  [Params(10,200,5000)]
  public int N {get;set;}

  [Benchmark]
  public int YieldReturnCall()
  {
    int tally = 0;
    foreach (var pt in testClass.GetYieldPointsClass(N))
      tally += pt.X + pt.Y;
    
    return tally;
  }

  [Benchmark]
  public int EnumerableCall()
  {
    int tally = 0;
    foreach (var pt in testClass.GetEnumerablePointsClass(N))
      tally += pt.X + pt.Y;
    
    return tally;
  }

  [Benchmark]
  public int ListCall()
  {
    int tally = 0;
    foreach (var pt in testClass.GetListPointsClass(N))
      tally += pt.X + pt.Y;
    
    return tally;
  }

  [Benchmark]
  public int YieldReturnStructCall()
  {
    int tally = 0;
    foreach (var pt in testClass.GetYieldPointsStruct(N))
      tally += pt.X + pt.Y;
    
    return tally;
  }

  [Benchmark]
  public int EnumerableStructCall()
  {
    int tally = 0;
    foreach (var pt in testClass.GetEnumerablePointsStruct(N))
      tally += pt.X + pt.Y;
    
    return tally;
  }

  [Benchmark]
  public int ListStructCall()
  {
    int tally = 0;
    foreach (var pt in testClass.GetListPointsStruct(N))
      tally += pt.X + pt.Y;
    
    return tally;
  }


}



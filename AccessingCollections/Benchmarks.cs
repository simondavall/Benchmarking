using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarking;

[MemoryDiagnoser()]
//[Orderer(SummaryOrderPolicy.FastestToSlowest)]
//[RankColumn()]
[ShortRunJob]
public class Benchmarks
{
  private static readonly AccessingCollections testClass = new();
  
  private static readonly char[] setOfChars = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();

  [Benchmark]
  public char[] AddToList()
  {
    return testClass.AddToList(setOfChars);
  }

  [Benchmark]
  public char[] AddToSortedListReturnValues()
  {
    return testClass.AddToSortedListReturnValues(setOfChars);
  }

  [Benchmark]
  public char[] AddToSortedListReturnKeys()
  {
    return testClass.AddToSortedListReturnKeys(setOfChars);
  }

  [Benchmark]
  public char[] AddToHashSet()
  {
    return testClass.AddToHashSet(setOfChars);
  }

  [Benchmark]
  public char[] AddSortedToHashSet()
  {
    return testClass.AddToSortedHashSet(setOfChars);
  }
}



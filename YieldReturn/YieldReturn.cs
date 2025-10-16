namespace Benchmarking;

public class YieldReturn
{
  public IEnumerable<PointClass> GetYieldPointsClass(int n)
  {
    for (int i = 0; i < n; i++)
      yield return new PointClass() { X = i, Y = i * 2 };
  }

  public IEnumerable<PointClass> GetEnumerablePointsClass(int n)
  {
    var list = new List<PointClass>();
    for (int i = 0; i < n; i++)
      list.Add(new PointClass() { X = i, Y = i * 2 });

    return list;
  }

  public List<PointClass> GetListPointsClass(int n)
  {
    var list = new List<PointClass>();
    for (int i = 0; i < n; i++)
      list.Add(new PointClass() { X = i, Y = i * 2 });

    return list;
  }

  public IEnumerable<PointStruct> GetYieldPointsStruct(int n)
  {
    for (int i = 0; i < n; i++)
      yield return new PointStruct() { X = i, Y = i * 2 };
  }

  public IEnumerable<PointStruct> GetEnumerablePointsStruct(int n)
  {
    var list = new List<PointStruct>();
    for (int i = 0; i < n; i++)
      list.Add(new PointStruct() { X = i, Y = i * 2 });

    return list;
  }

  public List<PointStruct> GetListPointsStruct(int n)
  {
    var list = new List<PointStruct>();
    for (int i = 0; i < n; i++)
      list.Add(new PointStruct() { X = i, Y = i * 2 });

    return list;
  }
}

public class PointClass{
  public int X { get; set; }
  public int Y { get; set; }
}

public struct PointStruct{
  public int X { get; set; }
  public int Y { get; set; }
}

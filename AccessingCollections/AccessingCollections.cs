namespace Benchmarking;

public class AccessingCollections {

  public char[] AddToList(char[] characters) {
    var list = new List<char>();
    foreach (var ch in characters) {
      list.Add(ch);
      list.Sort();
    }
    return list.ToArray();
  }

  public char[] AddToSortedListReturnValues(char[] characters) {
    var list = new SortedList<char, char>();
    foreach (var ch in characters) {
      list.Add(ch, ch);
    }
    return list.Values.ToArray();
  }

  public char[] AddToSortedListReturnKeys(char[] characters) {
    var list = new SortedList<char, char>();
    foreach (var ch in characters) {
      list.Add(ch, ch);
    }
    return list.Keys.ToArray();
  }

  public char[] AddToHashSet(char[] characters) {
    var list = new HashSet<char>();
    foreach (var ch in characters) {
      list.Add(ch);
    }
    return list.ToArray();
  }

  public char[] AddToSortedHashSet(char[] characters) {
    var list = new SortedSet<char>();
    foreach (var ch in characters) {
      list.Add(ch);
    }
    return list.ToArray();
  }

}


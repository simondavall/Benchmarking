# Testing the efficiency of Yield Return vs List return #

### Conclusion ###

The tests as setup demonstrate a 50% saving in both execution time and memory allocation.
This was determined to be a linear relationship with increasing test size.

Massive gains to be had using a struct rather than a class for the data returned by Yield and List.
The second set of results determined using a struct Point rather than the classPoint.

NB// Using yield return with struct return type allocates no memory on the heap.

### Results ###

```

BenchmarkDotNet v0.15.4, Linux Linux Mint 22.1 (Xia)
Intel Core i7-9750H CPU 2.60GHz (Max: 0.80GHz), 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.110
  [Host]     : .NET 9.0.9 (9.0.9, 9.0.925.41916), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 9.0.9 (9.0.9, 9.0.925.41916), X64 RyuJIT x86-64-v3


```
Results using class Point

| Method          | N    | Mean         | Error       | StdDev      | Rank | Gen0    | Gen1    | Allocated |
|---------------- |----- |-------------:|------------:|------------:|-----:|--------:|--------:|----------:|
| YieldReturnCall | 10   |     266.3 ns |     0.95 ns |     0.84 ns |    1 |  0.0458 |       - |     288 B |
| ListCall        | 10   |     530.6 ns |     2.71 ns |     2.40 ns |    2 |  0.0896 |       - |     568 B |
| EnumerableCall  | 10   |     589.8 ns |     3.03 ns |     2.68 ns |    3 |  0.0963 |       - |     608 B |
| YieldReturnCall | 200  |   4,404.2 ns |    10.06 ns |     7.86 ns |    4 |  0.7706 |       - |    4848 B |
| ListCall        | 200  |   6,872.3 ns |    39.43 ns |    36.88 ns |    5 |  1.4420 |  0.0381 |    9064 B |
| EnumerableCall  | 200  |   7,777.0 ns |    71.98 ns |    67.33 ns |    6 |  1.4496 |  0.0305 |    9104 B |
| YieldReturnCall | 5000 | 109,285.3 ns |   754.67 ns |   705.92 ns |    7 | 19.0430 |       - |  120048 B |
| ListCall        | 5000 | 164,517.8 ns | 1,106.08 ns | 1,034.63 ns |    8 | 39.7949 | 19.7754 |  251360 B |
| EnumerableCall  | 5000 | 187,879.4 ns | 1,553.06 ns | 1,452.73 ns |    9 | 39.7949 | 19.7754 |  251400 B |

Results using struct Point

| Method          | N    | Mean         | Error      | StdDev     | Rank | Gen0    | Gen1   | Allocated |
|---------------- |----- |-------------:|-----------:|-----------:|-----:|--------:|-------:|----------:|
| YieldReturnCall | 10   |     67.44 ns |   0.080 ns |   0.071 ns |    1 |  0.0076 |      - |      48 B |
| ListCall        | 10   |    221.16 ns |   0.339 ns |   0.317 ns |    2 |  0.0522 |      - |     328 B |
| EnumerableCall  | 10   |    258.40 ns |   0.642 ns |   0.569 ns |    3 |  0.0587 |      - |     368 B |
| YieldReturnCall | 200  |    453.95 ns |   0.353 ns |   0.313 ns |    4 |  0.0076 |      - |      48 B |
| ListCall        | 200  |  1,132.86 ns |   7.149 ns |   6.687 ns |    5 |  0.6790 | 0.0057 |    4264 B |
| EnumerableCall  | 200  |  1,410.03 ns |   6.569 ns |   5.824 ns |    6 |  0.6847 | 0.0057 |    4304 B |
| YieldReturnCall | 5000 | 11,394.09 ns |  37.171 ns |  32.952 ns |    7 |       - |      - |      48 B |
| ListCall        | 5000 | 19,688.03 ns | 155.484 ns | 145.440 ns |    8 | 20.8130 | 4.1504 |  131360 B |
| EnumerableCall  | 5000 | 27,816.36 ns |  68.782 ns |  64.338 ns |    9 | 20.8130 | 4.1504 |  131400 B |

Combined Results

| Method                | N    | Mean          | Error        | StdDev       | Rank | Gen0    | Gen1    | Allocated |
|---------------------- |----- |--------------:|-------------:|-------------:|-----:|--------:|--------:|----------:|
| YieldReturnStructCall | 10   |      71.24 ns |     1.265 ns |     1.183 ns |    1 |  0.0076 |       - |      48 B |
| ListStructCall        | 10   |     223.28 ns |     1.418 ns |     1.184 ns |    2 |  0.0522 |       - |     328 B |
| EnumerableStructCall  | 10   |     256.11 ns |     1.420 ns |     1.328 ns |    3 |  0.0587 |       - |     368 B |
| YieldReturnCall       | 10   |     265.38 ns |     1.639 ns |     1.533 ns |    4 |  0.0458 |       - |     288 B |
| YieldReturnStructCall | 200  |     482.06 ns |     3.044 ns |     2.847 ns |    5 |  0.0076 |       - |      48 B |
| ListCall              | 10   |     527.75 ns |     3.682 ns |     3.074 ns |    6 |  0.0896 |       - |     568 B |
| EnumerableCall        | 10   |     594.42 ns |     5.425 ns |     5.075 ns |    7 |  0.0963 |       - |     608 B |
| ListStructCall        | 200  |   1,067.46 ns |     6.032 ns |     5.347 ns |    8 |  0.6790 |  0.0057 |    4264 B |
| EnumerableStructCall  | 200  |   1,431.87 ns |    16.521 ns |    14.645 ns |    9 |  0.6847 |  0.0057 |    4304 B |
| YieldReturnCall       | 200  |   4,411.06 ns |    74.934 ns |    70.093 ns |   10 |  0.7706 |       - |    4848 B |
| ListCall              | 200  |   6,780.98 ns |    75.826 ns |    67.218 ns |   11 |  1.4420 |  0.0381 |    9064 B |
| EnumerableCall        | 200  |   7,688.04 ns |   153.027 ns |   229.044 ns |   12 |  1.4496 |  0.0305 |    9104 B |
| YieldReturnStructCall | 5000 |  11,631.15 ns |   107.104 ns |   100.185 ns |   13 |       - |       - |      48 B |
| ListStructCall        | 5000 |  20,261.37 ns |   389.625 ns |   594.999 ns |   14 | 20.8130 |  4.1504 |  131360 B |
| EnumerableStructCall  | 5000 |  30,006.55 ns |   311.031 ns |   275.721 ns |   15 | 20.8130 |  4.1504 |  131400 B |
| YieldReturnCall       | 5000 | 108,795.13 ns |   979.106 ns |   915.856 ns |   16 | 19.0430 |       - |  120048 B |
| ListCall              | 5000 | 168,026.13 ns | 3,268.114 ns | 4,687.033 ns |   17 | 39.7949 | 19.7754 |  251360 B |
| EnumerableCall        | 5000 | 184,468.17 ns |   748.094 ns |   699.768 ns |   18 | 39.7949 | 19.7754 |  251400 B |


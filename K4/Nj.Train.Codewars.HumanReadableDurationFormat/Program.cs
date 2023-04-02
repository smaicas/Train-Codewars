using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Nj.Train.Codewars.HumanReadableDurationFormat;

Summary summary = BenchmarkRunner.Run<Res>();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Benchmark ended!. Press any key to close");
Console.ResetColor();
Console.ReadKey();

//using HumanReadableDurationFormat;

//Resolver r = new();
//r.Resolve();

//|             Method |      Mean |     Error |    StdDev |    Median | Rank |   Gen0 | Allocated |
//|------------------- |----------:|----------:|----------:|----------:|-----:|-------:|----------:|
//|     ResolveProcess |  41.36 ns |  0.856 ns |  2.285 ns |  40.51 ns |    1 | 0.0181 |     152 B |
//|    ResolveProcess2 |  76.50 ns |  1.547 ns |  2.906 ns |  75.48 ns |    2 | 0.0334 |     280 B |
//|    ResolveProcess3 | 107.01 ns |  2.154 ns |  4.449 ns | 105.79 ns |    3 | 0.0334 |     280 B |
//|    ResolveProcess4 | 128.47 ns |  2.888 ns |  8.517 ns | 127.55 ns |    4 | 0.0525 |     440 B |
//|    ResolveProcess6 | 155.26 ns |  3.128 ns |  6.247 ns | 153.40 ns |    5 | 0.0544 |     456 B |
//|    ResolveProcess5 | 180.41 ns |  3.421 ns |  9.191 ns | 179.96 ns |    6 | 0.0544 |     456 B |
//|  ResolveDictionary | 184.92 ns |  3.689 ns |  6.264 ns | 182.11 ns |    7 | 0.0448 |     376 B |
//|   ResolveInterface | 283.58 ns |  5.669 ns | 12.563 ns | 279.61 ns |    8 | 0.0877 |     736 B |
//|  ResolveInterface2 | 414.85 ns |  6.999 ns |  6.547 ns | 411.71 ns |    9 | 0.1068 |     896 B |
//| ResolveDictionary2 | 436.33 ns |  8.744 ns | 16.424 ns | 428.53 ns |   10 | 0.0801 |     672 B |
//|  ResolveInterface3 | 441.28 ns |  8.561 ns | 14.303 ns | 440.51 ns |   10 | 0.1078 |     904 B |
//| ResolveDictionary3 | 450.93 ns |  8.950 ns | 17.456 ns | 445.12 ns |   10 | 0.0811 |     680 B |
//|  ResolveInterface4 | 542.49 ns | 10.882 ns | 31.743 ns | 531.93 ns |   11 | 0.1230 |    1032 B |
//|  ResolveInterface6 | 596.33 ns | 11.542 ns | 29.587 ns | 591.15 ns |   12 | 0.1316 |    1104 B |
//| ResolveDictionary4 | 610.81 ns | 12.183 ns | 33.143 ns | 599.86 ns |   12 | 0.0963 |     808 B |
//|  ResolveInterface5 | 623.72 ns | 12.470 ns | 31.514 ns | 614.25 ns |   13 | 0.1316 |    1104 B |
//| ResolveDictionary5 | 752.47 ns | 14.995 ns | 25.463 ns | 744.70 ns |   14 | 0.1345 |    1128 B |
//| ResolveDictionary6 | 768.92 ns | 15.249 ns | 37.693 ns | 756.45 ns |   14 | 0.1345 |    1128 B |
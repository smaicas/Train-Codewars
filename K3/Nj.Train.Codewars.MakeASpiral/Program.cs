using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Nj.Train.Codewars.MakeASpiral;

Summary summary = BenchmarkRunner.Run<Res>();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Benchmark ended!. Press any key to close");
Console.ResetColor();
Console.ReadKey();

////using MakeASpiral;
////Resolver res = new();

////res.Resolve50();
////Console.WriteLine(" ");
////res.ResolveKableado50();
////Console.WriteLine(" ");
////res.ResolveJelitter50();
////Console.WriteLine(" ");
////res.ResolveCDeCompilador10();
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Nj.Train.Codewars.HumanReadableDurationFormat;

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Res
{
    private const int Seconds = 20;
    private const int Seconds2 = 200;
    private const int Seconds3 = 2000;
    private const int Seconds4 = 20000;
    private const int Seconds5 = 200000;
    private const int Seconds6 = 2000000;

    [Benchmark]
    public void ResolveProcess() => CreateDatetimeString(Seconds);

    [Benchmark]
    public void ResolveDictionary() => CreateDatetimeStringWithDictionary(Seconds);

    [Benchmark]
    public void ResolveInterface() => ResolveWithInterface(Seconds);

    [Benchmark]
    public void ResolveProcess2() => CreateDatetimeString(Seconds2);

    [Benchmark]
    public void ResolveDictionary2() => CreateDatetimeStringWithDictionary(Seconds2);

    [Benchmark]
    public void ResolveInterface2() => ResolveWithInterface(Seconds2);

    [Benchmark]
    public void ResolveProcess3() => CreateDatetimeString(Seconds3);

    [Benchmark]
    public void ResolveDictionary3() => CreateDatetimeStringWithDictionary(Seconds3);

    [Benchmark]
    public void ResolveInterface3() => ResolveWithInterface(Seconds3);

    [Benchmark]
    public void ResolveProcess4() => CreateDatetimeString(Seconds4);

    [Benchmark]
    public void ResolveDictionary4() => CreateDatetimeStringWithDictionary(Seconds4);

    [Benchmark]
    public void ResolveInterface4() => ResolveWithInterface(Seconds4);

    [Benchmark]
    public void ResolveProcess5() => CreateDatetimeString(Seconds5);

    [Benchmark]
    public void ResolveDictionary5() => CreateDatetimeStringWithDictionary(Seconds5);

    [Benchmark]
    public void ResolveInterface5() => ResolveWithInterface(Seconds5);

    [Benchmark]
    public void ResolveProcess6() => CreateDatetimeString(Seconds6);

    [Benchmark]
    public void ResolveDictionary6() => CreateDatetimeStringWithDictionary(Seconds6);

    [Benchmark]
    public void ResolveInterface6() => ResolveWithInterface(Seconds6);

    public string ResolveWithInterface(int seconds)
    {
        if (seconds == 0) return "now";

        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);

        List<ITimeFormatter> timeFormatters = new()
        {
            new YearFormatter(), new DayFormatter(), new HourFormatter(), new MinuteFormatter(), new SecondFormatter()
        };

        List<string> timeStrings =
            timeFormatters.Where(x => x.CanFormat(timeSpan)).Select(x => x.Format(timeSpan)).ToList();

        if (timeStrings.Count == 1) return timeStrings[0];

        return string.Join(", ", timeStrings.Take(timeStrings.Count - 1)) + " and " + timeStrings.Last();
    }

    public static string CreateDatetimeString(int seconds)
    {
        if (seconds <= 0) return "now";

        TimeSpan ts = TimeSpan.FromSeconds(seconds);
        StringBuilder sb = new();

        int years = ts.Days / 365;
        if (years > 0) sb.Append($"{years}{(years > 1 ? " years" : " year")}");

        int days = ts.Days - years * 365;
        if (days > 0)
        {
            if (years > 0) sb.Append($"{(ts.Hours + ts.Minutes + ts.Seconds > 0 ? ", " : " and ")}");
            sb.Append($"{days}{(days > 1 ? " days" : " day")}");
        }

        if (ts.Hours > 0)
        {
            if (days + years > 0) sb.Append($"{(ts.Minutes + ts.Seconds > 0 ? ", " : " and ")}");
            sb.Append($"{ts.Hours}{(ts.Hours > 1 ? " hours" : " hour")}");
        }

        if (ts.Minutes > 0)
        {
            if (ts.Hours + days + years > 0) sb.Append($"{(ts.Seconds > 0 ? ", " : " and ")}");
            sb.Append($"{ts.Minutes}{(ts.Minutes > 1 ? " minutes" : " minute")}");
        }

        if (ts.Seconds > 0)
        {
            if (ts.Minutes + ts.Hours + days + years > 0) sb.Append(" and ");
            sb.Append($"{ts.Seconds}{(ts.Seconds > 1 ? " seconds" : " second")}");
        }

        return sb.ToString();
    }

    public string CreateDatetimeStringWithDictionary(int seconds)
    {
        if (seconds <= 0) return "now";

        TimeSpan ts = TimeSpan.FromSeconds(seconds);

        Dictionary<string, int> result = new();

        int years = ts.Days / 365;
        if (years > 0) result.Add($"{(years == 1 ? "year" : "years")}", years);

        int days = ts.Days - years * 365;
        if (days > 0) result.Add($"{(days == 1 ? "day" : "days")}", days);

        if (ts.Hours > 0) result.Add($"{(ts.Hours == 1 ? "hour" : "hours")}", ts.Hours);

        if (ts.Minutes > 0) result.Add($"{(ts.Minutes == 1 ? "minute" : "minutes")}", ts.Minutes);

        if (ts.Seconds > 0) result.Add($"{(ts.Seconds == 1 ? "second" : "seconds")}", ts.Seconds);

        if (result.Count > 1)
            return string.Join(", ",
                       result.Take(result.Count - 1)
                           .Select(x => $"{x.Value} {x.Key}")) +
                   $" and {result.Last().Value} {result.Last().Key}";

        return $"{result.First().Value} {result.First().Key}";
    }
}

public interface ITimeFormatter
{
    bool CanFormat(TimeSpan time);
    string Format(TimeSpan time);
}

public static class PluralHelper
{
    public static string AppendWord(int number, string value) => $"{number} {value}{(number > 1 ? "s" : "")}";
}

public class YearFormatter : ITimeFormatter
{
    public bool CanFormat(TimeSpan time) => time.Days >= 365;

    public string Format(TimeSpan time) => PluralHelper.AppendWord((int)Math.Floor(time.Days / 365d), "year");
}

public class DayFormatter : ITimeFormatter
{
    public bool CanFormat(TimeSpan time) => time.Days % 365 > 0;

    public string Format(TimeSpan time) => PluralHelper.AppendWord(time.Days % 365, "day");
}

public class HourFormatter : ITimeFormatter
{
    public bool CanFormat(TimeSpan time) => time.Hours > 0;

    public string Format(TimeSpan time) => PluralHelper.AppendWord(time.Hours, "hour");
}

public class MinuteFormatter : ITimeFormatter
{
    public bool CanFormat(TimeSpan time) => time.Minutes > 0;

    public string Format(TimeSpan time) => PluralHelper.AppendWord(time.Minutes, "minute");
}

public class SecondFormatter : ITimeFormatter
{
    public bool CanFormat(TimeSpan time) => time.Seconds > 0;

    public string Format(TimeSpan time) => PluralHelper.AppendWord(time.Seconds, "second");
}
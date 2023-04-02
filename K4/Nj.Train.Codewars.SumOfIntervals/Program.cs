//(int, int)[] Param = new (int, int)[] { (1, 2), (6, 10), (11, 15) };

(int, int)[] param = { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) };
Console.WriteLine(Intervals.SumIntervals(param.OrderBy(x => x.Item1).ToArray()));

public class Intervals
{
    public static int SumIntervals((int, int)[] intervals) => SumRec(intervals.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToArray(), int.MinValue);

    private static int SumRec(IList<(int, int)> intervals, int max)
    {
        if (intervals.Count <= 0) return 0;
        int val = intervals[0].Item2 - Math.Max(max, intervals[0].Item1) > 0
            ? intervals[0].Item2 - Math.Max(max, intervals[0].Item1)
            : 0;
        if (intervals.Count == 1) return val;
        return val + SumRec(intervals.Skip(1).ToArray(), Math.Max(max, intervals[0].Item2));
    }
}
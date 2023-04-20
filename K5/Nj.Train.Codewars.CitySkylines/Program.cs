
Console.WriteLine(string.Join(",", RemovedNumbers.removNb(26).Select(x => $"{x[0]},{x[1]}")));

public class RemovedNumbers
{
    public static List<long[]> removNb(long n)
    {
        // your code
        List<long[]> res = new List<long[]>();
        for (int i = 1; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var inner = Inner(i, j);
                if (i * j == inner)
                {
                    res.Add(new long[] { i, j });
                    res.Add(new long[] { j, i });
                }
            }
        }
        return res;
    }

    private static int Inner(int ini, int inj)
    {
        int res = 0;
        if (inj - ini <= 1) return res;
        if (inj - ini == 2) return ini + 1;
        for (int i = ini + 1; i <= inj - 1; i++)
        {
            res += i;
        }
        return res;
    }
}
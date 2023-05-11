
var dec = new Decompose();
long n = 11;
Console.WriteLine(dec.decompose(n));

public class Decompose
{
    public string decompose(long n)
    {
        var res = CalculateDecompose(new List<long>(), n - 1, n - 2, Convert.ToInt64(Math.Pow(n, 2)));
        return string.Join(" ", res);
    }

    private List<long> CalculateDecompose(List<long> res, long highIndex, long lowIndex, long target)
    {
        for (long index = lowIndex; index > 0; index--)
        {
            if (res.Sum() + Math.Pow(highIndex, 2) + Math.Pow(index, 2) > target)
            {
                res = CalculateDecompose(res, highIndex, lowIndex - 1, target);
            }
            else if (res.Sum() + Math.Pow(index, 2) + Math.Pow(index, 2) < target)
            {
                res = CalculateDecompose(res, highIndex - 1, highIndex - 2, target);
            }
            else
            {
                res.Add(index);
                res.Add(index - 1);
                return res;
            }
        }

        return res;
    }
}
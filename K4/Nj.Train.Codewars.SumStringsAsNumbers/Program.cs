Console.WriteLine(Kata.SumStrings("0276", "0286"));

public static class Kata
{
    public static string SumStrings(string a, string b)
    {
        int[] numX = a.Select(c => c - '0').ToArray();
        int[] numY = b.Select(c => c - '0').ToArray();

        int maxLength = Math.Max(numX.Length, numY.Length);
        int[] res = new int[maxLength + 1];

        int add = 0;
        for (int i = 0; i < maxLength; i++)
        {
            int digitA = i < numX.Length ? numX[numX.Length - 1 - i] : 0;
            int digitB = i < numY.Length ? numY[numY.Length - 1 - i] : 0;

            int sum = digitA + digitB + add;
            res[res.Length - 1 - i] = sum % 10;
            add = sum / 10;
        }

        if (add > 0)
            res[0] = add;
        else
            res = res.Skip(1).ToArray();

        return string.Join("", res.SkipWhile(x => x == 0));
    }
}
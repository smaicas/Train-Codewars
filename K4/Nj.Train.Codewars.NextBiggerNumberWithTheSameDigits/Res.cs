namespace Nj.Train.Codewars.NextBiggerNumberWithTheSameDigits;

public class Res
{
    public long Resolve(long number) => CalculateNumber(number);

    public static long CalculateNumber(long n)
    {
        char[] str = n.ToString().ToCharArray();
        if (str.Length == 0) return -1;
        if (str.Length == 1) return long.Parse(str);
        if (str.Length == 2)
        {
            if (str[0] < str[1]) (str[0], str[1]) = (str[1], str[0]);

            return long.Parse(str);
        }

        for (int i = str.Length - 1; i > 1; i--)
            if (str[i - 1] < str[i])
            {
                IEnumerable<char> subst = str.Skip(i).Take(str.Length - i);
                char mn = subst.Where(x => x > str[i - 1]).Min();
                long ind = str.ToList().LastIndexOf(mn);
                (str[i - 1], str[ind]) = (str[ind], str[i - 1]);

                char[] sort = str.Skip(i).Take(str.Length - i).ToArray();

                Array.Reverse(sort);

                return long.Parse(str.Take(i).Concat(sort).ToArray());
            }

        char[] substr = str.Skip(1).Take(str.Length - 2).ToArray();
        IEnumerable<char> gt = substr.Where(x => x > str[0]);
        if (!gt.Any()) return -1;
        char? min = gt.Min();
        long index = str.ToList().IndexOf((char)min);
        (str[0], str[index]) = (str[index], str[0]);

        char[] sorted = str.Skip(2).Take(str.Length - 2).ToArray();
        Array.Reverse(sorted);

        long result = long.Parse(str.Take(2).Concat(sorted).ToArray());

        return result == n ? -1 : result;
    }

    //Solution of https://www.codewars.com/users/haayhappen
    public long NextBiggerNumber(long n)
    {
        string str = GetNumbers(n);
        for (long i = n + 1; i <= long.Parse(str); i++)
            if (str == GetNumbers(i))
                return i;
        return -1;
    }

    public string GetNumbers(long number) => string.Join("", number.ToString().ToCharArray().OrderByDescending(x => x));

    public class FromBiggerToLower : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            long xi = long.Parse(x.ToString());
            long yi = long.Parse(y.ToString());

            return xi == yi ? 0 : xi > yi ? -1 : 1;
        }
    }

    public class FromLowerToBigger : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            long xi = long.Parse(x.ToString());
            long yi = long.Parse(y.ToString());
            return xi == yi ? 0 : xi < yi ? -1 : 1;
        }
    }
}
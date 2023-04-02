using System.Text.RegularExpressions;

//int a = 2345;
//while (a > 0)
//{
//    Console.WriteLine(a % 10);
//    a = a / 10;
//}

//Console.WriteLine(RomanNumerals.ToRoman(2));
Console.WriteLine(RomanNumerals.FromRoman("IX"));

public class RomanNumerals
{
    private static readonly string[][] Romans = { new[] { "I", "V" }, new[] { "X", "L" }, new[] { "C", "D" } };

    private static readonly IDictionary<char, int> FromRomanDic = new Dictionary<char, int>
    {
        { 'M', 1000 },
        { 'C', 100 },
        { 'D', 500 },
        { 'X', 10 },
        { 'L', 50 },
        { 'I', 1 },
        { 'V', 5 }
    };

    public static string ToRoman(int n)
    {
        string res = string.Empty;
        for (int i = 0; i < Romans.Length; i++)
        {
            int value = n % 10;
            n /= 10;
            switch (value)
            {
                case <= 3:
                    value.Rep(() => res += Romans[i][0]);
                    break;
                case 4:
                    res += Romans[i][0] += Romans[i][1];
                    break;
                case 5:
                    res += Romans[i][1];
                    break;
                case < 9:
                    res += Romans[i][1];
                    (value - 5).Rep(() => res += Romans[i][0]);
                    break;
                default:
                    res += Romans[i][0] += Romans[i][1];
                    break;
            }
        }

        n.Rep(() => res += "M");

        return new string(res.Reverse().ToArray());
    }

    public static int FromRoman(string romanNumeral)
    {
        int res = 0;
        Regex.Matches(romanNumeral, "M").Count().Rep(() => res += 1000);

        for (int i = Romans.Length - 1; i >= 0; i--)
            if (romanNumeral.Contains(Romans[i][1]))
            {
                Regex.Matches(romanNumeral, Romans[i][1]).Count()
                    .Rep(() => res += FromRomanDic[Romans[i][1].ToCharArray().First()]);
                if (romanNumeral.IndexOf(Romans[i][0]) > romanNumeral.IndexOf(Romans[i][1]))
                    Regex.Matches(romanNumeral, Romans[i][0]).Count()
                        .Rep(() => res += FromRomanDic[Romans[i][0].ToCharArray().First()]);
                else
                    Regex.Matches(romanNumeral, Romans[i][0]).Count()
                        .Rep(() => res -= FromRomanDic[Romans[i][0].ToCharArray().First()]);
            }
            else
            {
                Regex.Matches(romanNumeral, Romans[i][0]).Count()
                    .Rep(() => res += FromRomanDic[Romans[i][0].ToCharArray().First()]);
            }

        return res;
    }
}

public static class RepExt
{
    public static void Rep(this int times, Action action)
    {
        for (int i = 0; i < times; i++) action.Invoke();
    }
}
Console.WriteLine(Mixing.Mix("Are they here", "yes, they are here"));

//"2:eeeee/2:yy/=:hh/=:rr"
public class Mixing
{
    public static string Mix(string s1, string s2)
    {
        Dictionary<char, int> s1times = new();
        Dictionary<char, int> s2times = new();

        foreach (char c in s1)
        {
            if (!char.IsLower(c)) continue;
            if (s1times.ContainsKey(c))
                s1times[c]++;
            else
                s1times.Add(c, 1);
        }

        foreach (char c in s2)
        {
            if (!char.IsLower(c)) continue;
            if (s2times.ContainsKey(c))
                s2times[c]++;
            else
                s2times.Add(c, 1);
        }

        IEnumerable<string> selectMany1 = s1times.Select(x =>
        {
            if (s2times.ContainsKey(x.Key))
            {
                if (x.Value == s2times[x.Key]) return $"=:{x.Value.Rep(x.Key)}";
                return x.Value > s2times[x.Key] ? $"1:{x.Value.Rep(x.Key)}" : $"2:{s2times[x.Key].Rep(x.Key)}";
            }

            return $"1:{x.Value.Rep(x.Key)}";
        }).Where(x => x.Length > 3);
        IEnumerable<string> selectMany2 = s2times.Where(x => !s1times.ContainsKey(x.Key) && x.Value > 1).Select(
            x => $"2:{x.Value.Rep(x.Key)}");
        return string.Join("/",
            selectMany1.Concat(selectMany2).OrderByDescending(x => x.Length).ThenBy(x => x[0]).ThenBy(x => x[2]));
    }
}

public static class Repeat
{
    public static string Rep(this int times, char what)
    {
        char[] arr = new char[times];
        for (int i = 0; i < times; i++) arr[i] = what;
        return new string(arr);
    }
}
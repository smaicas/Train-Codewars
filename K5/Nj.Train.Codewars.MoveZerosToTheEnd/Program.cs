Console.WriteLine(string.Join(",", Res.Resolve(new[] { 1, 2, 3 })));

public class Res
{
    public static int[] Resolve(int[] input) => input.Where(x => x > 0).Concat(input.Where(x => x == 0)).ToArray();
}
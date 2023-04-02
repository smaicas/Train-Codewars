Console.WriteLine(string.Join(",", Permutations("aabb")));

Console.ReadKey();

static List<string> Permutations(string s)
{
    if (s.Length == 1)
        return new[] { s }.ToList();
    return Permutations(s[1..]).SelectMany(permutation =>
        Enumerable.Range(0, s.Length).Select(index =>
            permutation.Insert(index, s[0].ToString()))).GroupBy(x => x).Select(x => x.First()).ToList();
}
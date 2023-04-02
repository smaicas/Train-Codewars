Res.GetPINs("11");

public class Res
{
    private static readonly Dictionary<char, char[]> Posible = new()
    {
        { '1', new[] { '2', '4', '1' } },
        { '2', new[] { '1', '3', '5', '2' } },
        { '3', new[] { '2', '6', '3' } },
        { '4', new[] { '1', '5', '7', '4' } },
        { '5', new[] { '2', '4', '6', '8', '5' } },
        { '6', new[] { '3', '5', '9', '6' } },
        { '7', new[] { '4', '8', '7' } },
        { '8', new[] { '5', '7', '9', '0', '8' } },
        { '9', new[] { '6', '8', '9' } },
        { '0', new[] { '8', '0' } }
    };

    public static List<string> GetPINs(string observed) => Resolve(observed);

    // Solucion de Luis Llamas
    private static IEnumerable<string> CalculateCombinations(List<string> original, char[] newItems)
    {
        return original.Any()
            ? original.SelectMany(x => newItems, (x, y) => $"{x}{y}")
            : newItems.Select(x => x.ToString());
    }

    private static List<string> Resolve(string pin)
    {
        List<string> rst = new();

        foreach (char item in pin) rst = CalculateCombinations(rst, Posible[item]).ToList();
        return rst;
    }
}
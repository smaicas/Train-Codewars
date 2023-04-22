Console.Write(Kata.Rgb(0, 0, 0));

public class Kata
{
    public static string Rgb(int r, int g, int b)
    {
        (int rr, int gg, int bb) = (r > 0 ? Math.Min(255, r) : 0, g > 0 ? Math.Min(255, g) : 0, b > 0 ? Math.Min(255, b) : 0);

        return $"{rr:X2}{gg:X2}{bb:X2}";
    }
}

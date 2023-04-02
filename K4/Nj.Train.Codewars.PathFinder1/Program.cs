string a = ".W.\n" +
           ".W.\n" +
           "...";

Console.WriteLine(Finder.PathFinder(a));

public class Finder
{
    public static IEnumerable<char> Valids = new[] { '.', ' ' };

    public static bool PathFinder(string maze)
    {
        IEnumerable<string> lines = maze.Split("\n");
        char[][] m = lines.Select(line => line.ToCharArray()).ToArray();

        return HasPath(m, 0, 0);
    }

    public static bool HasPath(char[][] chars, int row, int col)
    {
        if (!Valids.Contains(chars[row][col])) return false;
        chars[row][col] = 'V';
        return (row == chars.Length - 1 && col == chars.Length - 1)
               || (row < chars.Length - 1 && HasPath(chars, row + 1, col))
               || (col < chars.Length - 1 && HasPath(chars, row, col + 1))
               || (col > 0 && HasPath(chars, row, col - 1))
               || (row > 0 && HasPath(chars, row - 1, col));
    }
}
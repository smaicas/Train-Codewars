namespace Nj.Train.Codewars.SnailSort;

public class Res
{
    public int[] Resolve()
    {
        int[][] input =
        {
            new[] { 1, 2, 3 },
            new[] { 4, 5, 6 },
            new[] { 7, 8, 9 }
        };

        return PrintIteration(input, 0).ToArray();
    }

    private List<int> PrintIteration(int[][] input, int index)
    {
        List<int> result = new();
        int arrDimension = input[0].Length;

        if (index == Math.Ceiling((float)arrDimension / 2)) return result;

        int j = index;
        for (int i = index; i < arrDimension - index; i++) result.Add(input[j][i]);

        j = arrDimension - index - 1;
        for (int i = index + 1; i < arrDimension - index; i++) result.Add(input[i][j]);

        j = arrDimension - index - 1;
        for (int i = arrDimension - index - 2; i >= index; i--) result.Add(input[j][i]);

        j = index;
        for (int i = arrDimension - index - 2; i > index; i--) result.Add(input[i][j]);

        result.AddRange(PrintIteration(input, index + 1));
        return result;
    }
}
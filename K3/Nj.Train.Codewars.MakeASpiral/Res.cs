using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Nj.Train.Codewars.MakeASpiral;

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Res
{
    private const int Size = 50;
    private const int Size2 = 500;
    private const int Size3 = 1000;
    private readonly int[] _dLen = { 2, 0, 2, 0 };

    private readonly int[] _dX = { 1, 0, -1, 0 };
    private readonly int[] _dY = { 0, 1, 0, -1 };

    [Benchmark]
    public void Resolve50()
    {
        int[,] res = new int[Size, Size];
        PaintIteration(res, 0, Size);
        //Print2DArray(res);
    }

    [Benchmark]
    public void ResolveKableado50() => SpiralizeKableado(Size);//Print2DArray(SpiralizeKableado(Size));

    [Benchmark]
    public void ResolveJelitter50()
    {
        int[,] arr = new int[Size, Size];

        SpiralizeJelitter(arr, 0);
        //Print2DArray(arr);
    }

    [Benchmark]
    public void ResolveCDeCompilador50() =>
        //SpiralizeCDeCompilador(Size);
        SpiralizeCDeCompilador(Size);

    [Benchmark]
    public void Resolve500()
    {
        int[,] res = new int[Size2, Size2];
        PaintIteration(res, 0, Size2);
        //Print2DArray(res);
    }

    [Benchmark]
    public void ResolveKableado500() => SpiralizeKableado(Size2);//Print2DArray(SpiralizeKableado(Size));

    [Benchmark]
    public void ResolveJelitter500()
    {
        int[,] arr = new int[Size2, Size2];

        SpiralizeJelitter(arr, 0);
        //Print2DArray(arr);
    }

    [Benchmark]
    public void ResolveCDeCompilador500() =>
        //SpiralizeCDeCompilador(Size);
        SpiralizeCDeCompilador(Size2);

    [Benchmark]
    public void Resolve1000()
    {
        int[,] res = new int[Size3, Size3];
        PaintIteration(res, 0, Size3);
        //Print2DArray(res);
    }

    [Benchmark]
    public void ResolveKableado1000() => SpiralizeKableado(Size3);//Print2DArray(SpiralizeKableado(Size));

    [Benchmark]
    public void ResolveJelitter1000()
    {
        int[,] arr = new int[Size3, Size3];

        SpiralizeJelitter(arr, 0);
        //Print2DArray(arr);
    }

    [Benchmark]
    public void ResolveCDeCompilador1000() =>
        //SpiralizeCDeCompilador(Size);
        SpiralizeCDeCompilador(Size3);

    public void SpiralizeJelitter(int[,] arr, int x)
    {
        int arrLength = arr.GetLength(0);
        if (x > Math.Ceiling((float)arrLength / 2) - 1) return;

        if (x > 0) arr[x, x - 1] = 1;

        int n = arrLength - x - 1;

        // 1st and last row
        for (int j = x; j < n; j++)
        {
            arr[x, j] = 1;

            if (n > x + 1) arr[n, j] = 1;
        }

        // Last and 1st column
        for (int i = x; i <= n; i++)
        {
            arr[i, n] = 1;

            if (i > x + 1) arr[i, x] = 1;
        }

        SpiralizeJelitter(arr, x + 2);
    }

    public int[,] SpiralizeKableado(int size)
    {
        int[,] grid = new int[size, size];
        int len = size + 1;
        int x = -2;
        int y = 0;
        int iter = 0;
        while (len > 0)
        {
            for (int i = 0; i < len; i++)
            {
                x += _dX[iter];
                y += _dY[iter];
                if (x >= 0) grid[y, x] = 1;
            }

            if (len == 1) break;
            len -= _dLen[iter];
            iter = (iter + 1) % 4;
        }

        return grid;
    }

    public int[,] SpiralizeCDeCompilador(int n)
    {
        int[] arr = new int[n * n];

        // Dibujar la mitad de las 'u' invertidas hasta la altura 5
        for (int j = 0; j < n / 2; j++)
        {
            for (int i = 0; i <= j; i++)
                if ((i & 1) == 0)
                    arr[n * j + i] = 1;
            for (int i = j; i < n / 2; i++)
                if ((j & 1) == 0)
                    arr[n * j + i] = 1;

            for (int i = n / 2; i < n - j; i++)
                if ((j & 1) == 0)
                    arr[n * j + i] = 1;
            for (int i = n / 2 + (n / 2 - j); i < n; i++)
                if ((i & 1) != 0)
                    arr[n * j + i] = 1;
        }

        // Hacer espejo de la matriz de la primera mitad con la segunda para 
        // que las 'u' invertidas formen círculos concéntricos
        for (int j = 0; j < n / 2; j++) Array.Copy(arr, n * j, arr, n * (n - 1 - j), n);

        // Cambiar diagonar para formar espiral
        for (int j = 0; j < n / 2; j++) arr[n * (j + 1) + j] = (j & 1) != 0 ? 1 : 0;

        return ConvertTo2DArray(arr, n);
    }

    private static int[,] ConvertTo2DArray(int[] arr, int n)
    {
        int[,] result = new int[n, n];

        for (int i = 0; i < n * n; i++)
        {
            int row = i / n;
            int col = i % n;
            result[row, col] = arr[i];
        }

        return result;
    }

    public void PaintIteration(int[,] res, int index, int size)
    {
        if (index >= size) return;
        // Right
        for (int i = index; i < size; i++) res[index, i] = 1;
        //Down
        for (int i = index; i < size; i++) res[i, size - 1] = 1;
        //Left
        for (int i = size - 1; i > index; i--) res[size - 1, i] = 1;
        //Up
        for (int i = size - 1; i > index + 1; i--)
        {
            if (i == index + 2 && res[i + 1, index + 1] == 0) res[i, index + 1] = 1;

            res[i, index] = 1;
        }

        PaintIteration(res, index + 2, size - 2);
    }

    public void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++) Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    #region Kableado 2

    [Benchmark]
    public void ResolveKableado2_50() => SpiralizeKableado2(Size);

    [Benchmark]
    public void ResolveKableado2_500() => SpiralizeKableado2(Size2);

    [Benchmark]
    public void ResolveKableado2_1000() => SpiralizeKableado2(Size3);

    public int[,] SpiralizeKableado2(int size)
    {
        int[,] grid = new int[size, size];
        int len = size + 1;
        int x = -2;
        int y = 0;
        while (len > 1)
        {
            for (int i = 0; i < len; i++)
            {
                x += 1;
                if (x >= 0) grid[y, x] = 1;
            }

            len -= 2;
            for (int i = 0; i < len; i++)
            {
                y += 1;
                grid[y, x] = 1;
            }

            for (int i = 0; i < len; i++)
            {
                x -= 1;
                grid[y, x] = 1;
            }

            len -= 2;
            for (int i = 0; i < len; i++)
            {
                y -= 1;
                grid[y, x] = 1;
            }
        }

        return grid;
    }

    #endregion Kableado 2
}
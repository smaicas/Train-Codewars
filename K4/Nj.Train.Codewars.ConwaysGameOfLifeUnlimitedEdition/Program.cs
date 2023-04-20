int[][,] gliders =
{
    new int[,] {{1,0,0},{0,1,1},{1,1,0}},
    new int[,] {{0,1,0},{0,0,1},{1,1,1}}
};

Console.WriteLine(ConwayLife.GetGeneration(gliders[0], 1));

public class ConwayLife
{
    public static int[,] GetGeneration(int[,] cells, int generation)
    {
        //cells.PrintMatrix();

        int[,] kernel = new int[3, 3]
        {
            { 1, 1, 1 },
            { 1, 0, 1 },
            { 1, 1, 1 }
        };
        var convolved = new int[3, 3];
        while (generation-- > 0)
        {
            convolved = cells.WrapWithZeros().Convolve(kernel).ApplyFunction((value, row, col) =>
            {
                if (cells[row, col] == 1)
                {
                    return value is 2 or 3 ? 1 : 0;

                }
                else
                {
                    return value == 3 ? 1 : 0;
                }
            });
        }
        //convolved.PrintMatrix();
        return convolved;
    }
}

public static class MatrixExtensions
{
    public static T[,] ApplyFunction<T>(this T[,] matrix, Func<T, int, int, T> function)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        T[,] result = new T[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = function(matrix[i, j], i, j);
            }
        }

        return result;
    }
    public static int[,] WrapWithZeros(this int[,] matrix, int numZeros = 1)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] newMatrix = new int[rows + (numZeros * 2), cols + (numZeros * 2)];

        for (int i = 0; i < rows + (numZeros * 2); i++)
        {
            for (int j = 0; j < cols + (numZeros * 2); j++)
            {
                if (i < numZeros || j < numZeros || i >= rows + numZeros || j >= cols + numZeros)
                {
                    newMatrix[i, j] = 0;
                }
                else
                {
                    newMatrix[i, j] = matrix[i - numZeros, j - numZeros];
                }
            }
        }

        return newMatrix;
    }

    public static int[,] Convolve(this int[,] inputMatrix, int[,] kernel)
    {
        int kernelRows = kernel.GetLength(0);
        int kernelColumns = kernel.GetLength(1);
        int inputRows = inputMatrix.GetLength(0);
        int inputColumns = inputMatrix.GetLength(1);

        int[,] outputMatrix = new int[inputRows - kernelRows + 1, inputColumns - kernelColumns + 1];

        for (int i = 0; i < outputMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < outputMatrix.GetLength(1); j++)
            {
                int sum = 0;

                for (int k = 0; k < kernelRows; k++)
                {
                    for (int l = 0; l < kernelColumns; l++)
                    {
                        sum += inputMatrix[i + k, j + l] * kernel[k, l];
                    }
                }

                outputMatrix[i, j] = sum;
            }
        }

        return outputMatrix;
    }

    public static int[,] CropZeros(this int[,] matrix)
    {
        if (matrix.Length == 0) return matrix;

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int rowStart = rows;
        int rowEnd = -1;
        int colStart = cols;
        int colEnd = -1;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] != 0)
                {
                    rowStart = Math.Min(rowStart, i);
                    rowEnd = Math.Max(rowEnd, i);
                    colStart = Math.Min(colStart, j);
                    colEnd = Math.Max(colEnd, j);
                }
            }
        }

        if (rowStart > rowEnd || colStart > colEnd) return new int[,] { };

        int croppedRows = rowEnd - rowStart + 1;
        int croppedCols = colEnd - colStart + 1;
        int[,] croppedMatrix = new int[croppedRows, croppedCols];

        for (int i = rowStart; i <= rowEnd; i++)
        {
            for (int j = colStart; j <= colEnd; j++)
            {
                croppedMatrix[i - rowStart, j - colStart] = matrix[i, j];
            }
        }

        return croppedMatrix;
    }
}

Console.WriteLine(DoubleLinear.DblLinear(10)); //22
Console.WriteLine(DoubleLinear.DblLinear(20)); //57
Console.WriteLine(DoubleLinear.DblLinear(30)); //91
Console.WriteLine(DoubleLinear.DblLinear(50)); //175

public class DoubleLinear
{
    public static int DblLinear(int n)
    {
        SortedSet<int> u = new() { 1 };

        for (int i = 0; i < n; i++)
        {
            int x = u.Min;
            u.Remove(x);
            u.Add(2 * x + 1);
            u.Add(3 * x + 1);
        }

        return u.Min;
    }
}
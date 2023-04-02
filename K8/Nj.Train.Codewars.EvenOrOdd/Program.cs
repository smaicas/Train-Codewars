Res res = new();

//Console.WriteLine(res.Resolve(25121233));
//Console.WriteLine(res.Resolve1(25112323));
public class Res
{
    public string Resolve(int n)
    {
        string[] res = { "Even", "Odd" };
        return res[n & 1];
    }

    // Solución meme
    public string Resolve1(int n)
    {
        int[] arr = new int[n];
        for (int i = 0; i < n; i++) arr[i] = i;
        int index = arr.Length - 1;
        while (arr[index] > 1) index--;

        return index == 0 ? "Even" : "Odd";
    }
}
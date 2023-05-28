using Newtonsoft.Json;

//var arr = new int[] { 1, 2, 3, 6, 4, 1, 2, 3, 2, 1 };
//var arr2 = new int[] { 1, 2, 3, 6, 4, 1, 2, 3, 2, 1 };
//var arr3 = new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3 };
//var arr4 = new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 2, 2, 1 };
var arr5 = new int[] { 2, 1, 3, 1, 2, 2, 2, 2, 1 };
//var arr6 = new int[] { 2, 1, 3, 1, 2, 2, 2, 2 };

//var res = PickPeaks.GetPeaks(arr);
//var res2 = PickPeaks.GetPeaks(arr2);
//var res3 = PickPeaks.GetPeaks(arr3);
//var res4 = PickPeaks.GetPeaks(arr4);
var res5 = PickPeaks.GetPeaks(arr5);
//var res6 = PickPeaks.GetPeaks(arr6);

//Console.WriteLine(JsonConvert.SerializeObject(res));
//Console.WriteLine(JsonConvert.SerializeObject(res2));
//Console.WriteLine(JsonConvert.SerializeObject(res3));
//Console.WriteLine(JsonConvert.SerializeObject(res4));
Console.WriteLine(JsonConvert.SerializeObject(res5));
//Console.WriteLine(JsonConvert.SerializeObject(res6));

public class PickPeaks
{
    public static Dictionary<string, List<int>> GetPeaks(int[] arr)
    {
        var pos = new List<int>();
        var peaks = new List<int>();
        for (int index = 1; index < arr.Length - 1; index++)
        {
            var val = arr[index];
            bool isPeak = true;
            for (int i = index - 1; i >= 0; i--)
            {
                if (arr[i] >= val)
                {
                    isPeak = false;
                    break;
                }

                if (arr[i] < val)
                {
                    isPeak = true;
                    break;
                }
                isPeak = false;
            }

            if (isPeak)
            {
                for (int i = index + 1; i < arr.Length; i++)
                {
                    if (arr[i] > val)
                    {
                        isPeak = false;
                        break;
                    }
                    if (arr[i] < val)
                    {
                        isPeak = true;
                        break;
                    }
                    isPeak = false;
                }
            }

            if (isPeak)
            {
                pos.Add(index);
                peaks.Add(arr[index]);
            }
        }

        return new Dictionary<string, List<int>>()
        {
            ["pos"] = pos,
            ["peaks"] = peaks
        };
    }
}

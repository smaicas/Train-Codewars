using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Nj.Train.Codewars.RangeExtraction;

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Res
{
    private readonly int[] _input =
    {
        -998, -997, -996, -995, -993, -990, -984, -982, -980, -979, -976, -974, -958, -955, -953, -949, -948, -947,
        -946, -944, -942, -941, -937, -936, -917, -911, -908, -904, -902, -901, -899, -897, -894, -891, -890, -888,
        -883, -876, -872, -871, -868, -867, -866, -865, -862, -858, -855, -846, -844, -843, -831, -830, -817, -807,
        -806, -804, -802, -801, -797, -794, -790, -789, -788, -778, -777, -774, -768, -761, -758, -756, -754, -752,
        -745, -744, -743, -742, -740, -737, -736, -731, -728, -724, -723, -722, -720, -719, -704, -697, -694, -691,
        -676, -675, -674, -671, -667, -663, -661, -658, -657, -652, -648, -647, -645, -643, -639, -630, -626, -622,
        -620, -613, -612, -609, -608, -603, -601, -600, -596, -594, -593, -589, -588, -585, -584, -580, -577, -576,
        -572, -568, -563, -558, -555, -554, -553, -546, -543, -541, -535, -533, -531, -529, -521, -519, -516, -510,
        -506, -501, -496, -495, -491, -487, -485, -474, -473, -472, -470, -465, -463, -462, -460, -443, -438, -434,
        -431, -427, -423, -421, -417, -412, -396, -393, -392, -391, -385, -379, -377, -375, -361, -359, -357, -351,
        -344, -334, -328, -326, -310, -307, -305, -304, -303, -300, -289, -286, -285, -283, -279, -274, -273, -271,
        -269, -267, -265, -262, -257, -256, -250, -249, -247, -241, -229, -225, -223, -221, -215, -214, -212, -209,
        -206, -204, -200, -197, -188, -182, -179, -172, -169, -163, -148, -147, -145, -144, -138, -137, -136, -134,
        -130, -128, -125, -123, -122, -121, -119, -117, -110, -109, -107, -106, -95, -94, -85, -83, -82, -73, -68,
        -65, -53, -52, -48, -42, -41, -35, -32, -24, -21, -17, -14, -11, -7, -6, -5, -4, -3, 3, 4, 6, 10, 12, 18,
        24, 27, 34, 37, 43, 46, 48, 52, 63, 65, 68, 69, 78, 87, 88, 99, 105, 106, 107, 111, 112, 130, 133, 134, 135,
        136, 139, 144, 145, 175, 178, 181, 183, 191, 195, 200, 202, 206, 208, 210, 215, 219, 223, 224, 226, 227,
        236, 241, 243, 245, 256, 268, 274, 278, 279, 280, 281, 285, 286, 307, 317, 322, 327, 331, 337, 340, 345,
        347, 348, 350, 351, 374, 384, 385, 388, 389, 390, 393, 405, 406, 414, 416, 417, 420, 421, 424, 425, 429,
        434, 436, 444, 448, 449, 454, 457, 461, 464, 470, 475, 477, 479, 483, 486, 490, 502, 519, 521, 525, 526,
        532, 538, 539, 542, 543, 548, 549, 555, 559, 566, 571, 572, 575, 585, 595, 596, 599, 603, 610, 613, 617,
        625, 629, 633, 642, 643, 645, 647, 648, 651, 654, 659, 663, 667, 668, 671, 672, 675, 678, 680, 681, 682,
        684, 691, 694, 698, 700, 702, 705, 707, 713, 719, 724, 741, 743, 744, 753, 756, 762, 763, 766, 776, 785,
        792, 794, 797, 799, 800, 801, 802, 805, 806, 815, 821, 826, 829, 831, 837, 839, 848, 852, 858, 864, 873,
        881, 882, 886, 890, 894, 895, 896, 897, 903, 905, 907, 909, 913, 916, 917, 918, 921, 922, 934, 944, 962,
        968, 969, 972, 980, 982, 986, 987, 997, 998
    };

    [Benchmark]
    public void Resolve()
    {
        string res = RangeList(_input, 0);
    }

    [Benchmark]
    public void ResolveAael() => RangeExtraction.Extract(_input);

    [Benchmark]
    public void ResolveAael2() => RangeExtraction2.Extract(_input);

    private string RangeList(IReadOnlyList<int> input, int index)
    {
        int i = index;

        while (i < input.Count - 1 && (input[i + 1] - input[i] == 1 || input[i] - input[i + 1] == 1)) i++;

        StringBuilder builder = new();
        builder.Append($"{input[index]}");

        switch (i - index)
        {
            case >= 2:
                builder.Append($"-{input[i]}");
                break;
            case 1:
                builder.Append($",{input[i]}");
                break;
        }

        if (i < input.Count - 1) builder.Append(",");
        return i < input.Count - 1 ? builder + RangeList(input, i + 1) : builder.ToString();
    }
}

/// <summary>
///     Author: https://www.codewars.com/users/aael
/// </summary>
public class RangeExtraction
{
    public int Value, Count;

    public RangeExtraction(int value)
    {
        Value = value;
        Count = 1;
    }

    public int NextValue => Value + Count;

    public override string ToString()
    {
        return Count == 1 ? $"{Value}" :
            Count == 2 ? $"{Value},{Value + 1}" :
            $"{Value}-{NextValue - 1}";
    }

    public static string Extract(int[] args)
    {
        List<RangeExtraction> list = new();

        foreach (int n in args)
            if (list.LastOrDefault()?.NextValue == n) list.Last().Count++;
            else list.Add(new RangeExtraction(n));

        return string.Join(",", list);
    }
}

public class RangeExtraction2
{
    public int Value, Count;

    public RangeExtraction2(int value)
    {
        Value = value;
        Count = 1;
    }

    public int NextValue => Value + Count;

    public override string ToString()
    {
        return Count == 1 ? $"{Value}" :
            Count == 2 ? $"{Value},{Value + 1}" :
            $"{Value}-{NextValue - 1}";
    }

    public static string Extract(int[] args)
    {
        List<RangeExtraction2> list = new();

        foreach (int n in args)
            if (list.LastOrDefault()?.NextValue == n) list.Last().Count++;
            else list.Add(new RangeExtraction2(n));

        return string.Join(",", list.Select(GetValue));
    }

    private static string? GetValue(RangeExtraction2 rangeExtraction2)
    {
        return rangeExtraction2.Count == 1 ? $"{rangeExtraction2.Value}" :
            rangeExtraction2.Count == 2 ? $"{rangeExtraction2.Value},{rangeExtraction2.Value + 1}" :
            $"{rangeExtraction2.Value}-{rangeExtraction2.NextValue - 1}";
    }
}
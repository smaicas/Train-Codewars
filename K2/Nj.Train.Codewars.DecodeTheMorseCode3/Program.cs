using System.Text.RegularExpressions;

// ···· · −·−−   ·−−− ··− −·· ·
//"11 0 11 0 1 00 111 00000 11 000000 111111 0 1 00 11111 00 111111 00000000000 111 0 11111111 0 11111 0 11111 000000 1 0 11 000 111111 00000111110011101100000100000";
string input =
    "0000000011011010011100000110000001111110100111110011111100000000000111011111111011111011111000000101100011111100000111110011101100000100000";
string morse = Decoder.DecodeBitsAdvanced(input);
Console.WriteLine(morse);
Console.WriteLine(Decoder.DecodeMorse(morse));

public class Decoder
{
    public static string DecodeBitsAdvanced(string bits)
    {
        string b = bits.Trim('0').Replace(" ", "");
        MatchCollection col = Regex.Matches(b, "([0]+)|([1]+)");
        string res = string.Empty;

        IDictionary<string, string> dic = new Dictionary<string, string>
        {
            { "0", "" }, { "00", "" }, { "000", " " }, { "1", "." }, { "11", "." }, { "111", "-" }
        };
        foreach (Match match in col)
        {
            List<string> matches = dic.Select(x => Regex.Replace(match.Value, $"({x.Key})", $"{x.Value}")).ToList();
            res += matches.Last(x =>
                Preloaded.MORSE_CODE.ContainsKey(x) && (string.IsNullOrEmpty(x) || x == " " || x[0] == '.'));
        }

        return res.Trim();
    }

    private static string CalculateValue(string matchValue)
    {
        string res = string.Empty;
        string dots = string.Empty;
        string dashes = string.Empty;

        if (matchValue.Length / 3 > 1)
        {
            for (int i = 0; i <= matchValue.Length / 3; i++) dashes += "-";

            res += dashes;
        }
        else
        {
            for (int i = 0; i <= matchValue.Length / 2; i++) dots += ".";
        }

        if (!Preloaded.MORSE_CODE.ContainsKey(res))
        {
        }

        return res;
    }

    public static string DecodeMorse(string morseCode)
    {
        // Map morse code using map Preloaded.MORSE_CODE
        return string.Join(" ",
            morseCode.Trim().Split("   ")
                .Select(word => string.Join("", word.Split(' ').Select(x => Preloaded.MORSE_CODE[x]))));
    }
}

public static class Preloaded
{
    private static IDictionary<char, string> EncodeMorseCodeValues
    {
        get
        {
            Dictionary<char, string> res = new()
            {
                { 'A', ".-" },
                { 'B', "-..." },
                { 'C', "-.-." },
                { 'D', "-.." },
                { 'E', "." },
                { 'F', "..-." },
                { 'G', "--." },
                { 'H', "...." },
                { 'I', ".." },
                { 'J', ".---" },
                { 'K', "-.-" },
                { 'L', ".-.." },
                { 'M', "--" },
                { 'N', "-." },
                { 'O', "---" },
                { 'P', ".--." },
                { 'Q', "--.-" },
                { 'R', ".-." },
                { 'S', "..." },
                { 'T', "-" },
                { 'U', "..-" },
                { 'V', "...-" },
                { 'W', ".--" },
                { 'X', "-..-" },
                { 'Y', "-.--" },
                { 'Z', "--.." },
                { '0', "-----" },
                { '1', ".----" },
                { '2', "..---" },
                { '3', "...--" },
                { '4', "....-" },
                { '5', "....." },
                { '6', "-...." },
                { '7', "--..." },
                { '8', "---.." },
                { '9', "----." },
                { '.', ".-.-.-" },
                { ',', "--..--" },
                { '?', "..--.." },
                { '\'', ".----." },
                { '!', "-.-.--" },
                { '/', "-..-." },
                { '(', "-.--." },
                { ')', "-.--.-" },
                { '&', ".-..." },
                { ':', "---..." },
                { ';', "-.-.-." },
                { '=', "-...-" },
                { '+', ".-.-." },
                { '-', "-....-" },
                { '_', "..--.-" },
                { '\"', ".-..-." },
                { '$', "...-..-" },
                { '@', ".--.-." },
                { ' ', "/" }
            };
            return res;
        }
    }

    public static IDictionary<string, string> MORSE_CODE => new Dictionary<string, string>
    {
        { ".-", "A" },
        { "-...", "B" },
        { "-.-.", "C" },
        { "-..", "D" },
        { ".", "E" },
        { "..-.", "F" },
        { "--.", "G" },
        { "....", "H" },
        { "..", "I" },
        { ".---", "J" },
        { "-.-", "K" },
        { ".-..", "L" },
        { "--", "M" },
        { "-.", "N" },
        { "---", "O" },
        { ".--.", "P" },
        { "--.-", "Q" },
        { ".-.", "R" },
        { "...", "S" },
        { "-", "T" },
        { "..-", "U" },
        { "...-", "V" },
        { ".--", "W" },
        { "-..-", "X" },
        { "-.--", "Y" },
        { "--..", "Z" },
        { "-----", "0" },
        { ".----", "1" },
        { "..---", "2" },
        { "...--", "3" },
        { "....-", "4" },
        { ".....", "5" },
        { "-....", "6" },
        { "--...", "7" },
        { "---..", "8" },
        { "----.", "9" },
        { ".-.-.-", "." },
        { "--..--", "," },
        { "..--..", "?" },
        { ".----.", "\'" },
        { "-.-.--", "!" },
        { "-..-.", "/" },
        { "-.--.", "(" },
        { "-.--.-", ")" },
        { ".-...", "&" },
        { "---...", ":" },
        { "-.-.-.", ";" },
        { "-...-", "=" },
        { ".-.-.", "+" },
        { "-....-", "-" },
        { "..--.-", "_" },
        { ".-..-.", "\"" },
        { "...-..-", "$" },
        { ".--.-.", "@" },
        { "/", " " }
    };
}
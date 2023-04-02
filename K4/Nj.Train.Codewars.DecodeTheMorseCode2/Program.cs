using System.Text.RegularExpressions;

string input =
    "1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011";
string input2 = "1110";

string morse = MorseCodeDecoder.DecodeBits(input2);
Console.WriteLine(morse);
Console.WriteLine(MorseCodeDecoder.DecodeMorse(morse));

public class MorseCodeDecoder
{
    public static string DecodeBits(string bits)
    {
        string b = bits.Trim('0').Replace(" ", "");
        int ut = Regex.Matches(b, "([1]+)|([0]+)").Min(x => x.Length);
        b = Regex.Replace(b, $"([0]{{{7 * ut}}})", "   ");
        b = Regex.Replace(b, $"([0]{{{3 * ut}}})", " ");
        b = Regex.Replace(b, $"([1]{{{3 * ut}}})", "-");
        b = Regex.Replace(b, $"([1]{{{1 * ut}}})", ".");
        b = Regex.Replace(b, $"([0]{{{1 * ut}}})", "");
        b = Regex.Replace(b, "([01])", "");
        return b.Trim();
    }

    public static string DecodeMorse(string morseCode)
    {
        return string.Join(" ",
            morseCode.Trim().Split("   ")
                .Select(word => string.Join("", word.Split(' ').Select(x => MorseCode.Get(x)))));
    }
}

public static class MorseCode
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

    private static IDictionary<string, string> DecodeMorseValues => new Dictionary<string, string>
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

    public static string Get(string morseCode) => DecodeMorseValues[morseCode];
}
using System.Text.RegularExpressions;

//StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" });
//StripCommentsRegex("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" });
StripCommentsRegex2("apples, pears # and bananas\ngrapes\nbananas !apples", new[] { "#", "!" });
//StripCommentsLinq("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" });

static string StripComments(string text, string[] commentSymbols)
{
    List<string> lines = text.Split("\n").ToList();
    List<string> result = new();
    foreach (string line in lines)
    {
        bool cont = false;
        foreach (string comment in commentSymbols)
            if (line.Contains(comment))
            {
                result.Add(new string(line.Take(line.IndexOf(comment.ToCharArray()[0])).ToArray()).TrimEnd());
                cont = true;
                break;
            }

        if (!cont)
            result.Add(line.TrimEnd());
    }

    return string.Join("\n", result);
}

static string StripCommentsRegex(string text, string[] commentSymbols)
{
    List<string> lines = text.Split("\n").ToList();
    List<string> result = new();
    foreach (string line in lines)
    {
        Regex rgx = new($"^[^{string.Join("", commentSymbols)}]+");
        Match res = rgx.Match(line);
        result.Add(res.Value.TrimEnd());
    }

    return string.Join("", result);
}

static string StripCommentsRegex2(string text, string[] commentSymbols)
{
    List<string> lines = text.Split("\n").ToList();
    List<string> result = new();
    Regex rgx = new("^([\\s\\S])([^#!])+");
    MatchCollection res = rgx.Matches(text);
    return string.Join("", result);
}

// Solution of https://www.codewars.com/users/cacti-acaprais
static string StripCommentsLinq(string text, string[] commentSymbols)
{
    string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);
    lines = lines.Select(x => x.Split(commentSymbols, StringSplitOptions.None).First().TrimEnd()).ToArray();
    return string.Join("\n", lines);
}
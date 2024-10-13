using System.Text.RegularExpressions;

namespace RegexLibrary;

public class RegexCore
{
    public static string SingleRegexInText(string text, string regex)
    {
        RegexOptions options = RegexOptions.IgnoreCase & RegexOptions.IgnorePatternWhitespace;
        string result = String.Empty;

        if (text is not null && text != String.Empty && regex != String.Empty)
        {
            Match match = Regex.Match(text, regex, options);

            if (match.Success) 
            {
                result = match.Value;
            }
        }

        return result;
    }

    public static List<string> MultipleRegexInText(string text, string regex)
    {
        RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
        List<string> results = new();

        if (text is not null && text != String.Empty && regex != String.Empty)
        {
            MatchCollection matches = Regex.Matches(text, regex, options);

            if (matches.Count > 0)
            {
                foreach (string value in matches.Select(x => x.ToString()))
                {
                    results.Add(value);
                }
            }
        }

        return results;
    }
}

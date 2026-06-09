using System.Text.RegularExpressions;

namespace StringCalculatorApp;

public class StringCalculatorApp
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        List<string> delimiters = [",", "\n"];
        string numbersPart = numbers;

        if (numbers.StartsWith("//"))
        {
            var delimiterSectionEnd = numbers.IndexOf('\n');
            var delimiterSection = numbers.Substring(2, delimiterSectionEnd - 2);

            var matches = Regex.Matches(delimiterSection, @"\[(.*?)\]");
            if (matches.Count > 0)
            {
                delimiters.AddRange(matches.Select(m => m.Groups[1].Value));
            }
            else
            {
                delimiters.Add(delimiterSection);
            }
            numbersPart = numbers[(delimiterSectionEnd + 1)..];
        }
        else if (
            numbers.Length > 2 &&
            !char.IsDigit(numbers[0]) && numbers[1] == '\n'
        )
        {
            delimiters.Add(numbers[0].ToString());
            numbersPart = numbers.Substring(2);
        }

        var numberStrings = numbersPart.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        var ints = numberStrings.Select(s => int.Parse(s)).ToList();

        var negatives = ints.Where(n => n < 0).ToList();
        if (negatives.Any())
        {
            throw new ArgumentException("negatives not allowed: " + string.Join(',', negatives));
        }

        return ints.Where(n => n <= 1000).Sum();
    }
}

namespace StringCalculatorApp;

public class StringCalculatorApp
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        char[] delimiters = [',', '\n'];
        string numbersPart = numbers;

        if (
            numbers.Length > 2 &&
            !char.IsDigit(numbers[0]) && numbers[1] == '\n'
        )
        {
            delimiters = [numbers[0], ',', '\n'];
            numbersPart = numbers.Substring(2);
        }

        var numberStrings = numbersPart.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        var ints = numberStrings.Select(s => int.Parse(s)).ToList();

        var negatives = ints.Where(n => n < 0).ToList();
        if (negatives.Any())
        {
            throw new ArgumentException("negatives not allowed: " + string.Join(',', negatives));
        }

        return ints.Sum();
    }
}

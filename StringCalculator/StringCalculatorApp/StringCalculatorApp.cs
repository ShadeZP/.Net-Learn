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

        var numberStrings = numbersPart.Split(delimiters);

        return numberStrings.Sum(s => int.Parse(s));
    }
}

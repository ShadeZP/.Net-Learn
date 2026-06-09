namespace StringCalculatorApp;

public class StringCalculatorApp
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        var delimiters = new[] { ',', '\n' };
        var numberStrings = numbers.Split(delimiters);

        return numberStrings.Sum(s => int.Parse(s));
    }
}

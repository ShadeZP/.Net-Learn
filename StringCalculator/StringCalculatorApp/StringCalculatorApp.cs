namespace StringCalculatorApp;

public class StringCalculatorApp
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        var numberStrings = numbers.Split(',');
        return numberStrings.Sum(s => int.Parse(s));
    }
}

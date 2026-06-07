namespace StringCalculatorApp;

public class StringCalculatorApp
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;
        return int.Parse(numbers);
    }
}

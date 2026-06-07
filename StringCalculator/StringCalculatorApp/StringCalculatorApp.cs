namespace StringCalculatorApp;

public class StringCalculatorApp
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        var parts = numbers.Split(',');

        int sum = 0;
        foreach (var part in parts)
        {
            sum += int.Parse(part);
        }

        return sum;
    }
}

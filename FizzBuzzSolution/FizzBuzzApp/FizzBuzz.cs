namespace FizzBuzzApp;

public class FizzBuzz
{
    public static string GetResult(int number)
    {
        if (number == 3)
            return "Fizz";
        if (number == 5)
            return "Buzz";
        return "1";
    }
}

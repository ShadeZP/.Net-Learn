namespace StringCalculatorApp.Tests;
public class StringCalculatorAppTests
{
    [Fact]
    public void Returns_zero_for_empty_string()
    {
        var result = StringCalculatorApp.Add("");
        Assert.Equal(0, result);
    }

    [Fact]
    public void Returns_number_for_single_number_string()
    {
        var result = StringCalculatorApp.Add("1");
        Assert.Equal(1, result);
    }

    [Fact]
    public void Returns_sum_for_two_numbers_in_string()
    {
        var result = StringCalculatorApp.Add("1,2");
        Assert.Equal(3, result);
    }
}

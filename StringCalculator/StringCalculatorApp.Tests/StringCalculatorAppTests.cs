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
        var result = StringCalculator.Add("1");
        Assert.Equal(1, result);
    }
}

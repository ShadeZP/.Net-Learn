namespace StringCalculatorApp.Tests;
public class StringCalculatorAppTests
{
    [Fact]
    public void Returns_zero_for_empty_string()
    {
        var result = StringCalculatorApp.Add("");
        Assert.Equal(0, result);
    }
}

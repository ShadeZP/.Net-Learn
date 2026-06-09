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

    [Fact]
    public void Returns_sum_for_multiple_numbers_in_string()
    {
        var result = StringCalculatorApp.Add("1,2,3");
        Assert.Equal(6, result);
    }

    [Fact]
    public void Returns_sum_for_numbers_with_newline_delimiter()
    {
        var result = StringCalculatorApp.Add("1\n2,3");
        Assert.Equal(6, result);
    }

    [Fact]
    public void Returns_sum_for_numbers_with_custom_single_char_delimiter()
    {
        var result = StringCalculatorApp.Add(";\n1;2");
        Assert.Equal(3, result);
    }

    [Fact]
    public void Throws_exception_when_negative_numbers_are_passed()
    {
        var ex = Assert.Throws<System.ArgumentException>(() =>
            StringCalculatorApp.Add("1,-2,3,-5")
        );
        Assert.Equal("negatives not allowed: -2,-5", ex.Message);
    }

    [Fact]
    public void Ignores_numbers_greater_than_1000()
    {
        var result = StringCalculatorApp.Add("2,1001,3,1500");
        Assert.Equal(5, result);
    }

    [Fact]
    public void Returns_sum_for_multiple_multi_char_custom_delimiters()
    {
        var result = StringCalculatorApp.Add("//[***][%%]\n1***2%%3");
        Assert.Equal(6, result);
    }
}

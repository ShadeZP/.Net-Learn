namespace FizzBuzzApp.Tests;
using Xunit;
using FizzBuzzApp;
public class FizzBuzzTests
{
    [Theory]
    [InlineData(0, "FizzBuzz")]
    [InlineData(-3, "Fizz")]
    [InlineData(-5, "Buzz")]
    [InlineData(-15, "FizzBuzz")]
    [InlineData(-1, "-1")]
    [InlineData(101, "101")]
    [InlineData(105, "FizzBuzz")]
    [InlineData(int.MinValue, "-2147483648")]
    [InlineData(int.MaxValue, "2147483647")]
    public void Returns_Correct_Value_Edge_Cases(int input, string expected)
    {
        var result = FizzBuzz.GetResult(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]

    public void Returns_Correct_Values_For_Many_Numbers(int input, string expected)
    {
        var result = FizzBuzz.GetResult(input);
        Assert.Equal(expected, result);
    }
}

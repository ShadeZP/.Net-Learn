namespace FizzBuzzApp.Tests;
using Xunit;
using FizzBuzzApp;
public class FizzBuzzTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(4, "4")]
    [InlineData(5, "Buzz")]
    [InlineData(6, "Fizz")]
    [InlineData(10, "Buzz")]
    [InlineData(12, "Fizz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(16, "16")]
    [InlineData(30, "FizzBuzz")]
    public void Returns_Correct_Values_For_Many_Numbers(int input, string expected)
    {
        var result = FizzBuzz.GetResult(input);
        Assert.Equal(expected, result);
    }
}

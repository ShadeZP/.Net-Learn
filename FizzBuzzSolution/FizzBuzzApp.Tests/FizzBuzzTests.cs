namespace FizzBuzzApp.Tests;
using Xunit;
using FizzBuzzApp;
public class FizzBuzzTests
{
    [Fact]
    public void Returns_1_For_Number_1()
    {
        var result = FizzBuzz.GetResult(1);
        Assert.Equal("1", result);
    }

    [Fact]
    public void Returns_Fizz_For_Number_3()
    {
        var result = FizzBuzz.GetResult(3);
        Assert.Equal("Fizz", result);
    }

    [Fact]
    public void Returns_Buzz_For_Number_5()
    {
        var result = FizzBuzz.GetResult(5);
        Assert.Equal("Buzz", result);
    }
}

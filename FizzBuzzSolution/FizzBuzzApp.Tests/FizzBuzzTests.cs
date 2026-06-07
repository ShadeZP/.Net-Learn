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
}

using Xunit;
using LeapYearApp;

public class LeapYearTests
{
    [Theory]
    [InlineData(1996, true)]
    [InlineData(1999, false)]
    [InlineData(1900, false)]
    [InlineData(2000, true)]
    [InlineData(2024, true)]
    [InlineData(2100, false)]
    [InlineData(2400, true)]
    [InlineData(1800, false)]
    [InlineData(2015, false)]
    public void Returns_correct_value_for_various_years(int year, bool expected)
    {
        Assert.Equal(expected, LeapYear.IsLeap(year));
    }
}
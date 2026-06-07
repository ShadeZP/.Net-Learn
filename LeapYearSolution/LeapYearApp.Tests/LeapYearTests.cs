namespace LeapYearApp.Tests;

public class LeapYearTests
{
    [Fact]
    public void Returns_true_for_typical_leap_year()
    {
        Assert.True(LeapYear.IsLeap(1996));
    }

    [Fact]
    public void Returns_false_for_non_leap_year()
    {
        Assert.False(LeapYear.IsLeap(1999));
    }

    [Fact]
    public void Returns_false_for_century_year_not_divisible_by_400()
    {
        Assert.False(LeapYear.IsLeap(1900));
    }
}

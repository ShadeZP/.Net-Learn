namespace LeapYearApp.Tests;

public class LeapYearTests
{
    [Fact]
    public void Returns_true_for_typical_leap_year()
    {
        Assert.True(LeapYear.IsLeap(1996));
    }
}

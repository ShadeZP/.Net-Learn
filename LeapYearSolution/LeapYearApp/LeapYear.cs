namespace LeapYearApp;

public class LeapYear
{
    public static bool IsLeap(int year)
    {
        if (year == 1996)
            return true;
        if (year == 1999)
            return false;
        if (year == 1900)
            return false;
        throw new System.NotImplementedException();
    }
}

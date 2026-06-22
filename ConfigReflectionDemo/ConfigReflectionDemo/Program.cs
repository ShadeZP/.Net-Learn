using ConfigReflectionDemo;
using System;

class Program
{
    static void Main()
    {
        var settings = new DemoSettings();
        settings.LoadSettings();

        Console.WriteLine($"MyInt (File): {settings.MyInt}");
        Console.WriteLine($"MyFloat (File): {settings.MyFloat}");
        Console.WriteLine($"Greeting (Config): {settings.Greeting}");
        Console.WriteLine($"Timeout (Config): {settings.Timeout}");

        Console.WriteLine("\n--- Enter new values ​​or press Enter to skip ---");

        Console.Write("MyInt: ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out var intval)) settings.MyInt = intval;

        Console.Write("MyFloat: ");
        input = Console.ReadLine();
        if (float.TryParse(input, out var floatval)) settings.MyFloat = floatval;

        Console.Write("Greeting: ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) settings.Greeting = input;

        Console.Write("Timeout (hh:mm:ss): ");
        input = Console.ReadLine();
        if (TimeSpan.TryParse(input, out var tsval)) settings.Timeout = tsval;

        settings.SaveSettings();
        Console.WriteLine("Settings are saved!");
    }
}
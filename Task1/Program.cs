using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (var input in args)
            {
                try
                {
                    char firstChar = GetFirstChar(input);
                    Console.WriteLine(firstChar);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        private static char GetFirstChar(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Argument cannot be empty!");
            return input[0];
        }
    }
}
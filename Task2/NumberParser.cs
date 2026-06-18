using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
                throw new ArgumentNullException(nameof(stringValue));

            if (stringValue.Trim().Length == 0)
                throw new FormatException("Input string cannot be empty.");

            stringValue = stringValue.Trim();

            int index = 0;
            int result = 0;
            bool isNegative = false;

            if (stringValue[index] == '-' || stringValue[index] == '+')
            {
                isNegative = stringValue[index] == '-';
                index++;
                if (index == stringValue.Length)
                    throw new FormatException("Input string is not a valid integer.");
            }

            while (index < stringValue.Length)
            {
                char c = stringValue[index];

                if (c < '0' || c > '9')
                    throw new FormatException("Input string contains non-numeric characters.");

                int digit = c - '0';

                if (isNegative)
                {
                    if (result < (int.MinValue + digit) / 10)
                        throw new OverflowException("The value is too small for Int32.");
                    result = result * 10 - digit;
                }
                else
                {
                    if (result > (int.MaxValue - digit) / 10)
                        throw new OverflowException("The value is too large for Int32.");
                    result = result * 10 + digit;
                }

                index++;
            }

            return result;
        }
    }
}
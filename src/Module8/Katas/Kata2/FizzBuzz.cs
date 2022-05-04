using System;

namespace Katas.Kata2
{
    public class FizzBuzz
    {
        public static string Print(string input)
        {
            var isNumeric = int.TryParse(input, out int number);

            if (!isNumeric)
                throw new InvalidOperationException("input string is not integer number");

            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";

            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Buzz";

            return number.ToString();
        }
    }
}

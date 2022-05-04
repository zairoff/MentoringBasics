using Katas.Kata2;
using System;
using Xunit;

namespace UnitTests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void CheckInteger_WhenIputDevisibleTo_3_ShouldReturnFizz()
        {
            var input = "27";
            var actual = "Fizz";

            var result = FizzBuzz.Print(input);

            Assert.Equal(actual, result);
        }

        [Fact]
        public void CheckInteger_WhenIputDevisibleTo_5_ShouldReturnBuzz()
        {
            var input = "25";
            var actual = "Buzz";

            var result = FizzBuzz.Print(input);

            Assert.Equal(actual, result);
        }

        [Fact]
        public void CheckInteger_WhenIputDevisibleTo_3_And_5_ShouldReturnFizzBuzz()
        {
            var input = "45";
            var actual = "FizzBuzz";

            var result = FizzBuzz.Print(input);

            Assert.Equal(actual, result);
        }

        [Fact]
        public void CheckInteger_WhenIputIsNotIntegerNumber_ShouldThrowException()
        {
            var input = "10.4";

            Assert.Throws<InvalidOperationException>(() => FizzBuzz.Print(input));
        }
    }
}

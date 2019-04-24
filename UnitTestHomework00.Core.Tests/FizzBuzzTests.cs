using NUnit.Framework;
using UnitTestHomework00;
using UnitTestHomework00.Core.Tests.Common;

namespace UnitTestHomework00.Core.Tests
{
    public class FizzBuzzTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Handle_GivenANumberThatIsNotDivisbleByThreeOrFive_ReturnsEmptyString()
        {
            var number = 7;

            var classToTest = new FizzBuzz();
            var result = classToTest.Handle(number);


            result.ShouldBe("");
        }

        [Test]

        public void Handle_GivenANumberThatIsDivisbleByThreeButNotFive_ReturnsFizz()
        {
            var number = 9;

            var classToTest = new FizzBuzz();
            var result = classToTest.Handle(number);

            result.ShouldBe("Fizz");
        }

        [Test]
        public void Handle_GivenANumberThatIsNotDivisbleByThreeButIsDivisbleFive_ReturnsBuzz()
        {
            var number = 10;

            var classToTest = new FizzBuzz();
            var result = classToTest.Handle(number);

            result.ShouldBe("Buzz");
        }

        [Test]
        public void Handle_GivenANumberThatIsDivisbleByThreeAndFive_ReturnsFizzBuzz()
        {

        }
    }
}
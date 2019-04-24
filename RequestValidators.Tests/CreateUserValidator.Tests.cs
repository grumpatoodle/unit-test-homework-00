using NUnit.Framework;
using System.Linq;
using UnitTestHomework00.Core.Tests.Common;

namespace RequestValidators.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // Write a method that returns the "arranged" argument in a correct state
        public CreatePetDto GenerateDtoInCorrectState()
        {
            var dtoToReturn = new CreatePetDto();
            dtoToReturn.Name = "Fonzi";
            dtoToReturn.Age = 5;
            dtoToReturn.Species = "Cat";

            return dtoToReturn;
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(int.MaxValue)]
        public void Validate_CreatePetDtoAgeIsGreaterThanZero_ErrorHasCountofZero(int age)
        {
            //var arg = new CreatePetDto();
            //arg.Age = age;
            //arg.Name = "Samoa";
            //arg.Species = "Dog";

            var arg = GenerateDtoInCorrectState();
            arg.Age = age;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Count.ShouldBe(0);
        }

        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(int.MinValue)]
        public void Validate_CreatePetDtoAgeIsZeroOrLess_ReturnsCorrectErrorMessage(int age)
        {
            var arg = GenerateDtoInCorrectState();
            arg.Age = age;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Any(x => x.ErrorMessage == "Age must be greater than 0").ShouldBe(true);
        }

        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(int.MinValue)]
        public void Validate_CreatePetDtoAgeIsZeroOrLess_ReturnsPropertyOfAge(int age)
        {
            var arg = GenerateDtoInCorrectState();
            arg.Age = age;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Any(x => x.Property == "Age").ShouldBe(true);
        }
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(int.MinValue)]
        public void Validate_CreatePetDtoAgeIsZeroOrLess_ErrorHasCountGreaterThanZero(int age)
        {
            var arg = GenerateDtoInCorrectState();
            arg.Age = age;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Count.ShouldBe(1);
        }

        [TestCase("Pepper")]
        [TestCase("Rusty")]
        public void Validate_CreatePetDtoNameHasValidStringName_ErrorHasCountofZero(string name)
        {
            var arg = GenerateDtoInCorrectState();
            arg.Name = name;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Count.ShouldBe(0);
        }

        [TestCase(null)]
        public void Validate_CreatePetDtoNameIsNull_ReturnsErrorMessage(string name)
        {
            var arg = GenerateDtoInCorrectState();
            arg.Name = name;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Any(x => x.ErrorMessage == "Name is required").ShouldBe(true);
        }

        [TestCase("")]
        public void Validate_CreatePetDtoNameIsEmptyString_ReturnsErrorMessage(string name)
        {
            var arg = GenerateDtoInCorrectState();
            arg.Name = name;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Any(x => x.ErrorMessage == "Name is required").ShouldBe(true);
        }

        [TestCase(null)]
        public void Validate_CreatePetDtoNameIsNull_ErrorHasCountGreaterThanZero(string name)
        {
            var arg = GenerateDtoInCorrectState();
            arg.Name = name;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Count.ShouldBe(1);
        }

        [TestCase("")]
        public void Validate_CreatePetDtoNameIsEmptyString_ErrorHasCountGreaterThanZero(string name)
        {
            var arg = GenerateDtoInCorrectState();
            arg.Name = name;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Count.ShouldBe(1);
        }

        [TestCase("Dog")]
        public void Validate_CreatePetDtoIsDog_ErrorHasCountOFZero(string species)
        {
            // Pet is not cat, no error
            var arg = GenerateDtoInCorrectState();
            arg.Species = species;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Count.ShouldBe(0);
        }

        [Test]
        public void Validate_CreatePetDtoIsCat_ErrorHasCountOfZero()
        {
            // Pet is not dog, no error
            var arg = GenerateDtoInCorrectState();
            arg.Species = "Cat";

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Count.ShouldBe(0);
        }

        [TestCase("Bird")]
        public void Validate_CreatePetDtoIsNotCatOrDog_ReturnsErrorMessage(string species)
        {
            // Pet is other animal, error message
            var arg = GenerateDtoInCorrectState();
            arg.Species = species;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Any(x => x.ErrorMessage == "Species must be either Cat or Dog").ShouldBe(true);
        }

        [TestCase("Bird")]
        [TestCase("Zebra")]
        [TestCase("Lion")]
        public void Validate_CreatePetDtoIsNotCatOrDog_ErrorHasCountGreaterThanZero(string species)
        {
            // Pet is other animal, error count
            var arg = GenerateDtoInCorrectState();
            arg.Species = species;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Count.ShouldBe(1);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Validate_CreatePetDtoSpeciesInvalid_ReturnsErrorMessage(string species)
        {
            // no Pet species entered, error message
            var arg = GenerateDtoInCorrectState();
            arg.Species = species;

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.Errors.Any(x => x.ErrorMessage == "Species must be either Cat or Dog").ShouldBe(true);
        }

        // Response
        [Test]
        public void Validate_CreatePetDtoIsInCorrectState_ErrorsHasCountOfZero()
        {
            // Arrange
            var arg = GenerateDtoInCorrectState();

            // Act
            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            // Assert
            result.Errors.Count.ShouldBe(0);
        }

        [Test]
        public void Validate_CreatePetDtoIsInCorrectState_IsValidIsTrue()
        {
            var arg = GenerateDtoInCorrectState();

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(arg);

            result.IsValid.ShouldBe(true);
        }

        [Test]
        public void Validate_CreatePetDtoIsNotInCorrectState_IsValidIsFalse()
        {
            var createDto = new CreatePetDto();
            createDto.Age = 0;
            createDto.Name = "";
            createDto.Species = "jklkjlknml";

            var classToTest = new CreatePetValidator();
            var result = classToTest.Validate(createDto);

            result.IsValid.ShouldBe(false);
        }


    }
}
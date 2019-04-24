using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestHomework00.Core.Tests.Common;

namespace UnitTestHomework00.Core.Tests
{
    [TestFixture]
    public class CreateUserRequestHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        public CreateUserRequest GenerateDtoInCorrectState()
        {
            var dtoToReturn = new CreateUserRequest();
            dtoToReturn.FirstName = "Matthew";
            dtoToReturn.LastName = "Puneky";
            dtoToReturn.Age = 27;

            return dtoToReturn;
            
        }

        [Test]
        public void Handle_UserHasFirstName_ReturnsDtoWithCorrectFirstName()
        {
            var arg = GenerateDtoInCorrectState();

            var classToTest = new CreateUserRequestHandler();
            var result = classToTest.Handle(arg);

            result.FirstName.ShouldBe("Matthew");
        }

        [Test]
        public void Handle_UserHasLastName_ReturnsDtoWithCorrectLastName()
        {
            var expected = "Puneky";
            var arg = new CreateUserRequest();
            arg.LastName = expected;

            var classToTest = new CreateUserRequestHandler();
            var result = classToTest.Handle(arg);

            result.LastName.ShouldBe(expected);

        }

        [Test]
        public void Handle_UserHasAge_ReturnsDtoWithCorrectAge()
        {
            var expected = 27;
            var arg = new CreateUserRequest();
            arg.Age = expected;

            var classToTest = new CreateUserRequestHandler();
            var result = classToTest.Handle(arg);

            result.Age.ShouldBe(expected); 

        }

        [Test]
        public void Handle_ReturnsDtoWithIdHavingAValue()
        {

        }
    }
}

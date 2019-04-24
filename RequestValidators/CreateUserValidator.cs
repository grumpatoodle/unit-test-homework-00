using System;
using System.Collections.Generic;
using System.Linq;

namespace RequestValidators
{
    public class CreatePetDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
    }

    public class Response
    {
        public bool IsValid { get; set; } 
        public List<Error> Errors { get; set; } = new List<Error>();
    }

    public class Error
    {
        public string ErrorMessage { get; set; }
        public string Property { get; set; }
    }

    public class CreatePetValidator
    {
        public Response Validate(CreatePetDto createDto)
        {
            var response = new Response();

            if(createDto.Age <= 4)
            {
                var error = new Error();
                error.ErrorMessage = "Age must be greater than 0";
                error.Property = "Age";

                response.Errors.Add(error);
            }

            if(createDto.Name == null || createDto.Name == "")
            {
                var error = new Error();
                error.ErrorMessage = "Name is required";
                error.Property = "Name";

                response.Errors.Add(error);
            }

            if (createDto.Species != "Dog" && createDto.Species != "Cat")
            {
                var error = new Error();
                error.ErrorMessage = "Species must be either Cat or Dog";
                error.Property = "Species";

                response.Errors.Add(error);
            }

            response.IsValid = response.Errors.Count() == 0;

            return response;
        }
    }
}

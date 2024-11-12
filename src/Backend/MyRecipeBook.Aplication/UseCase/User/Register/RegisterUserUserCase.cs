using MyRecipeBook.Comunication.Request;
using MyRecipeBook.Comunication.Response;
using MyRecipeBook.Exceptions.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Aplication.UseCase.User.Register
{
    public class RegisterUserUserCase
    {

        public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            Validate(request);

            return new ResponseRegisterUserJson
            {
                Name = request.Name
            };  
        }

        private void Validate(RequestRegisterUserJson request)
        {
            

            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            

            if (result.IsValid == false)
            {
                var errorMesseges = result.Errors.Select(e => e.ErrorMessage);
                throw new MyRecipeBookException();
            }
        }
    }

   
}

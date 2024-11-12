using FluentValidation;
using MyRecipeBook.Comunication.Request;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Aplication.UseCase.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMesagesExceptions.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMesagesExceptions.EMAIL_EMPTY);
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMesagesExceptions.EMAIL_IS_NOT_VALID);
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMesagesExceptions.PASSWORD_LESS_THAN_6);
        }
    }
}

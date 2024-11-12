using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Aplication.UseCase.User.Register;
using MyRecipeBook.Comunication.Request;
using MyRecipeBook.Comunication.Response;

namespace WebApplication1.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            var userCase = new RegisterUserUserCase();
            var result = userCase.Execute(request);
            return Created(string.Empty, result);
        }
    }
}

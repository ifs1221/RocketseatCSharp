using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Communication.Requests;

namespace Petfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RequestRegisterPetJson), StatusCodes.Status201Created)]
        public IActionResult Register([FromBody] RequestRegisterPetJson request)
        {   
            var response = new RegisterPetUseCase().Execute(request);
            return Created(string.Empty, response);
        }
    }
}

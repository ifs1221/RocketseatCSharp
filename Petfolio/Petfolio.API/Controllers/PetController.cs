using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pets.Delete;
using Petfolio.Application.UseCases.Pets.GetAll;
using Petfolio.Application.UseCases.Pets.GetById;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Application.UseCases.Pets.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RequestPetJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestPetJson request)
        {   
            var response = new RegisterPetUseCase().Execute(request);
            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson request)
        {
            new UpdatePetUseCase().Execute(id, request);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult GetAll()
        {
            var useCase = new GetAllPetsUseCase();
            var response = useCase.Execute();
            if (response.Pets.Any())
                return Ok(response);
            
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseShortPetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new GetPetByIdUseCase().Execute(id);
            if (response != null)
                return Ok(response);

            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteById(int id)
        {
            new DeletePetByIdUseCase().Execute(id);
            return NoContent();
        }
    }
}

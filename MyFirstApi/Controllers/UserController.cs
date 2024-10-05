using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Communication.Requests;

namespace MyFirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public IActionResult GetById([FromRoute] int id)
    {
        var users = new List<User>
        {
            new User { Id = 1, Name = "John", Age = 25 },
            new User { Id = 2, Name = "Jane", Age = 30 },
            new User { Id = 3, Name = "Doe", Age = 35 }
        };
        var response = users.FirstOrDefault(x => x.Id == id);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] ResponseRegisterUser request)
    {
        var response = new ResponseRegisterUser
        {
            Name = request.Name,
            Email = request.Email
        };
        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public IActionResult Update([FromRoute] int id, 
        [FromBody] ResponseRegisterUser request)
    {
        var response = new ResponseRegisterUser
        {
            Name = request.Name,
            Email = request.Email
        };
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] int id)
    {
        return NoContent();
    }
}

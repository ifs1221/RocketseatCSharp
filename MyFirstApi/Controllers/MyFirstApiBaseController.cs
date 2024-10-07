using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyFirstApiBaseController : ControllerBase
    {
        public string Author { get; set; } = "Israel Felix";
        protected string GetCustomKey()
        {
            return Request.Headers["CustomKey"].ToString();
        }

        [HttpGet("healthy")]
        public IActionResult Healthy()
        {
            return Ok("Healthy");
        }
    }
}

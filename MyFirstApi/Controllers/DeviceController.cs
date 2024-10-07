using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Entities;

namespace MyFirstApi.Controllers
{
    public class DeviceController : MyFirstApiBaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            var key = GetCustomKey();

            var laptop = new Laptop();
            var model = laptop.GetBrand(); 
            return Ok(model);
        }
    }
}

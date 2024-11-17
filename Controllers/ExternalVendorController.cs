using EmployeeApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalVendorController(ISender sender) : ControllerBase
    {
        [HttpGet("post")]
        public async Task<IActionResult> GetPost()
        {
            var result = await sender.Send(new GetPostQuery());
            return Ok(result);
        }

        [HttpGet("joke")]
        public async Task<IActionResult> GetJoke()
        {
            var result = await sender.Send(new GetJokeQuery());
            return Ok(result);
        }
    }
}
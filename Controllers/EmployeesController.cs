using EmployeeApi.Entities;
using EmployeeApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Commands;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employee)
        {
            var result = await sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeesAsync(string? term, string? sort,string? sortOrder, int page = 1, int limit = 2)
        {
            var result = await sender.Send(new GetAllEmployeesQuery(term, sort,sortOrder, page, limit));
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] int employeeId)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] int employeeId, [FromBody] EmployeeEntity employee)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(employeeId, employee));
            return Ok(result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] int employeeId)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(employeeId));
            return Ok(result);
        }
    }


}
using EmployeeManagement.Application.DataTransferObject;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) // API Calls Application Layer
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> Getemp()
        {
            var employees = await _employeeService.GetAllEmployeeAsync();
            return Ok(employees);
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }
            return Ok(employee);
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeCreateDTO model)
        {
            if (model == null)
            {
                return BadRequest("Invalid employee data.");
            }

            try
            {
                var employeeId = await _employeeService.AddAsync(model);

                return Ok(new { Message = "Employee added successfully.", EmployeeId = employeeId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateDTO model)
        {
            if (model == null)
            {
                return BadRequest("Invalid employee data.");
            }

            try
            {
                var employeeId = await _employeeService.UpdateAsync(model);

                return Ok(new { Message = "Employee added successfully.", EmployeeId = employeeId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee ID.");
            }

            var result = await _employeeService.DeleteAsync(id);

            if (!result)
            {
                return NotFound("Employee not found.");
            }

            return Ok($"Employee with ID {id} deleted successfully.");
        }





    }
}

using CorsDemo.Business.Interfaces;
using CorsDemo.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorsDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        private readonly IEmployeeService _employeeService;

        // Constructor Injection
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employee
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();

            return Ok(employees);
        }

        // GET: api/employee/1
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound(new
                {
                    Message = $"Employee with ID {id} not found."
                });
            }

            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public IActionResult AddEmployee(CreateEmployeeDto dto)
        {
            var employee = _employeeService.AddEmployee(dto);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = employee.Id },
                employee
            );
        }
    }
}

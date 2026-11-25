using CustomMiddlewareDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomMiddlewareDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new()
        {
            new Employee
            {
                EmployeeId = 1,
                EmployeeName = "Rahul",
                Department = "IT",
                Salary = 45000
            },
            new Employee
            {
                EmployeeId = 2,
                EmployeeName = "Priya",
                Department = "HR",
                Salary = 40000
            }
        };

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(
                x => x.EmployeeId == id);

            if (employee == null)
                return NotFound("Employee Not Found");

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employee.EmployeeId = employees.Max(x => x.EmployeeId) + 1;

            employees.Add(employee);

            return Ok(employee);
        }

        [HttpGet("error")]
        public IActionResult TestException()
        {
            throw new Exception("Something went wrong!");
        }
    }
}

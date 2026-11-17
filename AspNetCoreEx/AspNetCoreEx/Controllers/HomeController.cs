using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreEx.Models;

namespace AspNetCoreEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //here i list out the employe to display
        private List<Employees> Employees = new List<Employees>
        {
            new Employees { EmployeeId = 1,EmployeeName = "Sreenu Reddy Y",EmployeeSalary = 750000,Designation = "Dot Net Developer" },
            new Employees { EmployeeId = 2,EmployeeName = "Deepak Reddy A",EmployeeSalary = 800000,Designation = "Frontend Developer" },
            new Employees { EmployeeId = 3,EmployeeName = "Shashank Reddy K",EmployeeSalary = 850000,Designation = "Dynamic 365 CRM" },
            new Employees{ EmployeeId = 4,EmployeeName  = "Chintu L",EmployeeSalary = 900000,Designation = "Associate Engineer" },
            new Employees{EmployeeId = 5,EmployeeName = "Preetham K",EmployeeSalary = 950000,Designation = "WebScrabbing"},
            new Employees{ EmployeeId = 6,EmployeeName = "Adarsh Reddy A",EmployeeSalary = 1000000,Designation = "Content Creater" }
        };

        //here get the all employee details
        //here without mention any http verb and if you run then it thrown error.
        [HttpGet]
        public List<Employees> getEmployeeRecords()
        {
            //here i return the employees for that i took return type as employees.
            return Employees;
        }
    }
}

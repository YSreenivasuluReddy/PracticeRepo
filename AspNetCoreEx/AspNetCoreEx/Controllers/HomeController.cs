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
        //https://localhost:8766/api/Home/GetEmployeeRecords
        [Route("GetEmployeeRecords")]
        public List<Employees> getEmployeeRecords()
        {
            //here i return the employees for that i took return type as employees.
            return Employees;
        }

        [HttpGet]
        [Route("GetEmployeeDetailsById")]
        public List<Employees?> getEmployeesById(int id)
        {
            var employees = Employees.Where(x => x.EmployeeId == id).ToList();
            return employees;
        }

        [HttpPut]
        [Route("UpdateEmployeeDetailsById")]
        public Employees updateEmployeeDetailsById(int id, Employees employee)
        {
            var employeedetails = Employees.FirstOrDefault(x => x.EmployeeId == id);
            employeedetails.EmployeeName = employee.EmployeeName;
            employeedetails.EmployeeSalary = employee.EmployeeSalary;
            employeedetails.Designation = employee.Designation;

            return employeedetails;
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public Employees CreateEmployee(Employees employee)
        {
            Employees.Add(employee);
            return employee;
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public Employees? DeleteEmployee(int id)
        {
            var deleteemprecord = Employees.Find(x => x.EmployeeId.Equals(id));

            Employees.Remove(deleteemprecord);

            return deleteemprecord;

        }

    }
}

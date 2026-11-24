using AspNetCoreEx.Models;

namespace AspNetCoreEx.InMemory
{
    public class EmployeeStore
    {
        public static List<Employees> EmployeesData = new List<Employees>()
        {
            new Employees
            {   EmployeeId = 1,EmployeeName = "Pujitha A",EmployeeSalary = 750000,Designation = "DotNet Developer"},
            new Employees
            {
                EmployeeId = 2,EmployeeName = "Deepak Reddy A",EmployeeSalary=800000,Designation = "Frontend Developer"
            },
            new Employees
            {
                EmployeeId = 3,EmployeeName = "Shashank Reddy K",EmployeeSalary=850000,Designation = "Dynamics 365 CRM"
            },
            new Employees
            {
                EmployeeId = 4,EmployeeName = "Adarsh Reddy A",EmployeeSalary=800000,Designation = "Creater"
            },
            new Employees
            {
                EmployeeId = 4,EmployeeName = "Sreenu Reddy Y",EmployeeSalary=850000,Designation = "FullStack Developer"
            },
        };
    }
}

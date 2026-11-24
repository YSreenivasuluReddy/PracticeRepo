using AspNetCoreEx.Models;

namespace AspNetCoreEx.Interfaces
{
    public interface IEmployeeRepository
    {
        //here the below methods returns the list of employees retrieves the database.
        List<Employees> GetAllEmployees();

        //here the below methods returns the particular employee  records from the database.
        Employees? GetEmployeesById(int id);
    }
}

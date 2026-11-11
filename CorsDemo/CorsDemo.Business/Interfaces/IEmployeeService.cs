using CorsDemo.Models.DTOs;
using CorsDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsDemo.Business.Interfaces
{
    public interface IEmployeeService
    {
        //here i create method to get the employee details.
        List<Employee> GetAllEmployees();

        //here this method i used to get the employee details by id.
        Employee? GetEmployeeById(int id);

        //here this method is used to add the new employee.

        Employee AddEmployee(CreateEmployeeDto dto);
    }
}

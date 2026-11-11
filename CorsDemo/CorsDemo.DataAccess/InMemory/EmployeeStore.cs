using CorsDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsDemo.DataAccess.InMemory
{
    public static class EmployeeStore
    {
        public static List<Employee> Employees { get; } = new List<Employee>()
        {
             new Employee
            {
                Id = 1,
                Name = "Srinivas",
                Department = "IT",
                Salary = 35000
            },

            new Employee
            {
                Id = 2,
                Name = "Ramesh",
                Department = "HR",
                Salary = 30000
            },

            new Employee
            {
                Id = 3,
                Name = "Kiran",
                Department = "Finance",
                Salary = 40000
            }
        };
        
    }
}

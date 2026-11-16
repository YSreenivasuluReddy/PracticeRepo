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
                Salary = 35000,
                JoiningDate = new DateTime(2026, 1, 25)
            },

            new Employee
            {
                Id = 2,
                Name = "Ramesh",
                Department = "HR",
                Salary = 30000,
                JoiningDate = new DateTime(2026, 3, 17)
            },

            new Employee
            {
                Id = 3,
                Name = "Kiran",
                Department = "Finance",
                Salary = 40000,
                JoiningDate = new DateTime(2025, 10, 25)
            },
             new Employee
            {
                Id = 4,
                Name = "Sreenu Reddy Y",
                Department = "Dot Net Developer",
                Salary = 65000,
                JoiningDate = new DateTime(2025, 5, 29)
            },

            new Employee
            {
                Id = 5,
                Name = "Shashank Reddy",
                Department = "HR",
                Salary = 70000,
                JoiningDate = new DateTime(2022, 11, 06)
            },

            new Employee
            {
                Id = 6,
                Name = "Deepak Reddy",
                Department = "FrontEnd Developer",
                Salary = 80000,
                JoiningDate = new DateTime(2020, 06, 19)
            }
        };
        
    }
}

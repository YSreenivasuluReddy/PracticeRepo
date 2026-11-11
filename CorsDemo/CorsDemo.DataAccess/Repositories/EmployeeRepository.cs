using CorsDemo.Business.Interfaces;
using CorsDemo.DataAccess.InMemory;
using CorsDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsDemo.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        // 1. Get all employees
        public List<Employee> GetAll()
        {
            //i return records from Inmemoryclass.employeelist.ToList();
            return EmployeeStore.Employees.ToList();
        }

        // 2. Get employee by ID
        public Employee? GetById(int id)
        {
            return EmployeeStore.Employees
                .FirstOrDefault(x => x.Id == id);
        }

        // 3. Add a new employee
        public Employee Add(Employee employee)
        {
            employee.Id = EmployeeStore.Employees.Count == 0
                ? 1
                : EmployeeStore.Employees.Max(x => x.Id) + 1;

            EmployeeStore.Employees.Add(employee);

            return employee;
        }
    }
}

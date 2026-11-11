using CorsDemo.Business.Interfaces;
using CorsDemo.Models.DTOs;
using CorsDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsDemo.Business.Services
{
    //here i inherite the IEmployeeService from the interface folder to implement the logic.
    public class EmployeeService : IEmployeeService
    {
        
        private readonly IEmployeeRepository _repository;
        //we are using dependency injection.
        //because Employee service needs to repository operations such as retrieve and save the records.
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public List<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _repository.GetById(id);
        }

        public Employee AddEmployee(CreateEmployeeDto dto)
        {
            // Business validation
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException(
                    "Employee name is required.");
            }

            if (string.IsNullOrWhiteSpace(dto.Department))
            {
                throw new ArgumentException(
                    "Department is required.");
            }

            if (dto.Salary <= 0)
            {
                throw new ArgumentException(
                    "Salary must be greater than zero.");
            }

            // Convert DTO into Entity
            var employee = new Employee
            {
                Name = dto.Name,
                Department = dto.Department,
                Salary = dto.Salary
            };

            // Send employee to Repository
            return _repository.Add(employee);
        }

    }
}

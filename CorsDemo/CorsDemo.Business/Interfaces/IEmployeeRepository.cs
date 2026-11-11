using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorsDemo.Models.Entities;

namespace CorsDemo.Business.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        Employee? GetById(int id);

        Employee Add(Employee employee);
    }
}

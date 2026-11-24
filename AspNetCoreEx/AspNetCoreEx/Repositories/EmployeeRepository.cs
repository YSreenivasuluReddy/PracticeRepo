using AspNetCoreEx.Interfaces;
using AspNetCoreEx.Models;
using AspNetCoreEx.InMemory;

namespace AspNetCoreEx.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeRepository(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employees> GetAllEmployees()
        {
            return EmployeeStore.EmployeesData.ToList();
        }

        public Employees? GetEmployeesById(int id)
        {
            var empresult = EmployeeStore.EmployeesData.FirstOrDefault(x => x.EmployeeId == id);

            if (empresult == null)
            {
                return null;
            }

            return empresult;
        }
    }
}

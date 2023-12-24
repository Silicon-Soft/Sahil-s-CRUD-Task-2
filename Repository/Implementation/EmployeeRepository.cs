using Task2.Models;
using Task2.Repository.Interface;
using Task2.ViewModel;

namespace Task2.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _dbContext.Employees.ToList();
            return employees;
        }

        public Employee ReadEmployee(int id)
        {
            Employee employee = _dbContext.Employees.Find(id)!;
            return employee;
        }

        public void CreateEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void EditEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }


        public void DeleteEmployeeById(int id)
        {
            Employee employee = _dbContext.Employees.Find(id)!;
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

    }
}

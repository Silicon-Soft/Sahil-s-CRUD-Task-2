using Task2.Models;
using Task2.ViewModel;

namespace Task2.Repository.Interface
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee ReadEmployee(int id);
        void CreateEmployee(Employee employee);
        void EditEmployee(Employee employee);
        void DeleteEmployeeById(int id);
    }
}

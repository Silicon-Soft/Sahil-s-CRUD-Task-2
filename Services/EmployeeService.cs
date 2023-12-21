using Microsoft.EntityFrameworkCore;
using Task2.Models;
using Task2.Services;
using Task2.ViewModel;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeDbContext _dbContext;

    public EmployeeService(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<EmployeeViewModel> EmployeeViewModel()
    {
        List<Employee> employees = _dbContext.Employees.AsNoTracking().ToList();
        List<EmployeeViewModel> EmployeeViewModels = new List<EmployeeViewModel>();

        foreach (var employee in employees)
        {
            EmployeeViewModels.Add(new EmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Gender = employee.Gender,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
                Salary = employee.Salary
            });
        }

        return EmployeeViewModels;
    }

    public EmployeeViewModel ReadEmployee(int id)
    {
        Employee employee = _dbContext.Employees.Find(id);

        if (employee == null)
        {
            return null;
        }

        EmployeeViewModel EmployeeViewModel = new EmployeeViewModel()
        {
            Id = employee.Id,
            Name = employee.Name,
            Gender = employee.Gender,
            Address = employee.Address,
            Phone = employee.Phone,
            Email = employee.Email,
            Salary = employee.Salary
        };

        return EmployeeViewModel;
    }

    public void CreateEmployee(EmployeeViewModel EmployeeViewModel)
    {
        Employee employee = new Employee()
        {
            Id = EmployeeViewModel.Id,
            Name = EmployeeViewModel.Name,
            Gender = EmployeeViewModel.Gender,
            Address = EmployeeViewModel.Address,
            Phone = EmployeeViewModel.Phone,
            Email = EmployeeViewModel.Email,
            Salary = EmployeeViewModel.Salary
        };

        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();
    }
    public void DeleteEmployee(int id)
    {
        Employee employee = _dbContext.Employees.Find(id)!;
        _dbContext.Employees.Remove(employee);
        _dbContext.SaveChanges();
    }
    public void EditEmployee(EmployeeViewModel EmployeeViewModel)
    {
        Employee employee = new Employee()
        {
            Id = EmployeeViewModel.Id,
            Name = EmployeeViewModel.Name,
            Gender = EmployeeViewModel.Gender,
            Address = EmployeeViewModel.Address,
            Phone = EmployeeViewModel.Phone,
            Email = EmployeeViewModel.Email,
            Salary = EmployeeViewModel.Salary
        };
        _dbContext.Employees.Update(employee);
        _dbContext.SaveChanges();
    }

}
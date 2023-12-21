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

    public List<GetViewModel> GetViewModel()
    {
        List<Employee> employees = _dbContext.Employees.AsNoTracking().ToList();
        List<GetViewModel> GetViewModel = new List<GetViewModel>();

        foreach (var employee in employees)
        {
            GetViewModel.Add(new GetViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Gender = employee.Gender,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
            });
        }

        return GetViewModel;
    }

    public ReadViewModel ReadEmployee(int id)
    {
        Employee employee = _dbContext.Employees.Find(id);

        if (employee == null)
        {
            return null;
        }

        ReadViewModel ReadViewModel = new ReadViewModel()
        {
            Id = employee.Id,
            Name = employee.Name,
            Gender = employee.Gender,
            Address = employee.Address,
            Phone = employee.Phone,
            Email = employee.Email,
            Salary = employee.Salary
        };

        return ReadViewModel;
    }

    public void CreateEmployee(CreateViewModel CreateViewModel)
    {
        Employee employee = new Employee()
        {
            Name = CreateViewModel.Name,
            Gender = CreateViewModel.Gender,
            Address = CreateViewModel.Address,
            Phone = CreateViewModel.Phone,
            Email = CreateViewModel.Email,
            Salary = CreateViewModel.Salary
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
    public void EditEmployee(EditViewModel EditViewModel)
    {
        Employee employee = new Employee()
        {
            Id = EditViewModel.Id,
            Name = EditViewModel.Name,
            Gender = EditViewModel.Gender,
            Address = EditViewModel.Address,
            Phone = EditViewModel.Phone,
            Email = EditViewModel.Email,
            Salary = EditViewModel.Salary
        };
        _dbContext.Employees.Update(employee);
        _dbContext.SaveChanges();
    }

}
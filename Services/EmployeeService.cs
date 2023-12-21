using Microsoft.EntityFrameworkCore;
using Task2.Models;
using Task2.Services;
using Task2.ViewModel;


namespace Task2.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GetViewModel> GetAllEmployees()
        {
            List<Employee> employees = _dbContext.Employees.ToList();
            List<GetViewModel> getViewModels = new List<GetViewModel>();

            foreach (var employee in employees)
            {
                getViewModels.Add(new GetViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Gender = employee.Gender,
                    Address = employee.Address,
                    Phone = employee.Phone,
                    Email = employee.Email,
                });
            }

            return getViewModels;
        }

        public ReadViewModel ReadEmployee(int id)
        {
            Employee employee = _dbContext.Employees.Find(id)!;
            if (employee == null)
            {
                return null;
            }

            ReadViewModel readViewModel = new ReadViewModel()
            {

                Id = employee.Id,
                Name = employee.Name,
                Gender = employee.Gender,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
                Salary = employee.Salary

            };

            return readViewModel;
        }

        public GetViewModel GetAllEmployees(int id)
        {
            Employee employee = _dbContext.Employees.Find(id)!;

            if (employee == null)
            {
                return null;
            }

            GetViewModel getViewModel = new GetViewModel()
            {

                Id = employee.Id,
                Name = employee.Name,
                Gender = employee.Gender,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
            };

            return getViewModel;
        }

        public void CreateEmployee(CreateViewModel createViewModel)
        {
            Employee employee = new Employee()
            {
                Name = createViewModel.Name,
                Gender = createViewModel.Gender,
                Address = createViewModel.Address,
                Phone = createViewModel.Phone,
                Email = createViewModel.Email,
                Salary = createViewModel.Salary
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
        public EditViewModel EditEmployee(int id)
        {
            Employee employee = _dbContext.Employees.Find(id);
            EditViewModel editViewModel = new EditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Gender = employee.Gender,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
                Salary = employee.Salary
            };
            return editViewModel;
        }
        public void EditEmployee(EditViewModel editViewModel)
        {
            Employee employee = new Employee()
            {
                Id = editViewModel.Id,
                Name = editViewModel.Name,
                Gender = editViewModel.Gender,
                Address = editViewModel.Address,
                Phone = editViewModel.Phone,
                Email = editViewModel.Email,
                Salary = editViewModel.Salary
            };
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }

    }
}
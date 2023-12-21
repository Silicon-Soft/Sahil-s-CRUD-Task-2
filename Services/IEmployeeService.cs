using Microsoft.AspNetCore.Mvc;
using Task2.ViewModel;

namespace Task2.Services;

public interface IEmployeeService
{
    List<EmployeeViewModel> EmployeeViewModel();
    EmployeeViewModel ReadEmployee(int id);
    void CreateEmployee(EmployeeViewModel employeeViewData);
    void EditEmployee(EmployeeViewModel employeeViewData);
    void DeleteEmployee(int id);
}
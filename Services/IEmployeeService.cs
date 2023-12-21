using Microsoft.AspNetCore.Mvc;
using Task2.ViewModel;

namespace Task2.Services;

public interface IEmployeeService
{
    List<GetViewModel> GetViewModel();
    ReadViewModel ReadEmployee(int id);
    void CreateEmployee(CreateViewModel employeeViewData);
    void EditEmployee(EditViewModel employeeViewData);
    void DeleteEmployee(int id);
}
using Microsoft.AspNetCore.Mvc;
using Task2.ViewModel;

namespace Task2.Services;
public interface IEmployeeService
{
    List<GetViewModel> GetAllEmployees();
    ReadViewModel ReadEmployee(int id);
    void CreateEmployee(CreateViewModel createViewModel);
    void EditEmployee(EditViewModel editViewModel);
    void DeleteEmployee(int id);
    EditViewModel EditEmployee(int id);

}

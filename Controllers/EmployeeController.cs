using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Services;
using Task2.ViewModel;
using Task2.Models;

namespace Practice_project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View("GetAllEmployees");
        }
        public IActionResult GetAllEmployees()
        {
            return View(_employeeService.EmployeeViewModel());

        }
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                _employeeService.CreateEmployee(employeeViewModel);
                return RedirectToAction("GetAllEmployees", "Employee");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
        public IActionResult EditEmployee(int id)
        {
            return View(_employeeService.ReadEmployee(id));
        }
        [HttpPost, ActionName("EditEmployee")]
        public IActionResult Edit(EmployeeViewModel employeeViewData)
        {
            _employeeService.EditEmployee(employeeViewData);
            return RedirectToAction("GetAllEmployees", "Employee");
        }
        public IActionResult ReadEmployee(int id)
        {
            return View(_employeeService.ReadEmployee(id));
        }
        public IActionResult DeleteEmployee(int id)
        {
            return View(_employeeService.ReadEmployee(id));
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployees", "Employee");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.ViewModel;
using Task2.Models;
using Task2.Services.Interface;

namespace Practice_project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult GetAllEmployees()
        {
            return View(_employeeService.GetAllEmployees());
        }
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(CreateViewModel CreateViewModel)
        {
            try
            {
                _employeeService.CreateEmployee(CreateViewModel);
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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            return View(_employeeService.EditEmployee(id));
        }
        [HttpPost, ActionName("EditEmployee")]
        public IActionResult Edit(EditViewModel EditViewModel)
        {
            _employeeService.EditEmployee(EditViewModel);
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
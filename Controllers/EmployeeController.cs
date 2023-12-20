using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using Task2.Models;
using Task2.ViewModel;

namespace Task2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        public IActionResult GetAllEmployees(EmployeeViewModel employeeViewModel)
        {
            List<Employee> emplist = _context.Employees.ToList();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            foreach (var employee in emplist)
            {
                employeeViewModels.Add(new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Gender =employee.Gender,
                        Address = employee.Address,
                        Phone = employee.Phone,
                        Email = employee.Email,
                        Salary = employee.Salary
                    }
                );

            }
            return View(employeeViewModels);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee()
            {
                Name = employeeViewModel.Name,
                Gender = employeeViewModel.Gender,
                Address = employeeViewModel.Address,
                Phone = employeeViewModel.Phone,
                Email = employeeViewModel.Email,
                Salary = employeeViewModel.Salary
            };

            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("GetAllEmployees");
            }

            return View(employeeViewModel);
        }

        public IActionResult ReadEmployee(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = _context.Employees.Find(id)!;
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Id = empfromdb.Id,
                Name = empfromdb.Name,
                Gender = empfromdb.Gender,
                Address = empfromdb.Address,
                Phone = empfromdb.Phone,
                Email = empfromdb.Email,
                Salary = empfromdb.Salary
            };

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(employeeViewModel);
        }
        public IActionResult EditEmployee(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = _context.Employees.Find(id)!;
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Id = empfromdb.Id,
                Name = empfromdb.Name,
                Gender = empfromdb.Gender,
                Address = empfromdb.Address,
                Phone = empfromdb.Phone,
                Email = empfromdb.Email,
                Salary = empfromdb.Salary
            };

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(employeeViewModel);
        }
        [HttpPost]
        public IActionResult EditEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee()
            {
                Id = employeeViewModel.Id,
                Name = employeeViewModel.Name,
                Gender = employeeViewModel.Gender,
                Address = employeeViewModel.Address,
                Phone = employeeViewModel.Phone,
                Email = employeeViewModel.Email,
                Salary = employeeViewModel.Salary
            };
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("GetAllEmployees");
            }

            return View(employeeViewModel);
        }
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = _context.Employees.Find(id);
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Id = empfromdb.Id,
                Name = empfromdb.Name,
                Gender = empfromdb.Gender,
                Address = empfromdb.Address,
                Phone = empfromdb.Phone,
                Email = empfromdb.Email,
                Salary = empfromdb.Salary
            };

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(employeeViewModel);
        }
        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult DeleteEmp(int? id)
        {
            var deleterecord = _context.Employees.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("GetAllEmployees");
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task2.Models;
using Task2.Repository.Interface;
using Task2.Services.Interface;
using Task2.ViewModel;


namespace Task2.Services.Implementation
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        public List<GetViewModel> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = _employeeRepository.GetAllEmployees();
                List<GetViewModel> getViewModels = _mapper.Map<List<GetViewModel>>(employees);
                return getViewModels;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ReadViewModel ReadEmployee(int id)
        {
            try
            {
                Employee employee = _employeeRepository.ReadEmployee(id);
                ReadViewModel readViewModel = _mapper.Map<ReadViewModel>(employee);
                return readViewModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public void CreateEmployee(CreateViewModel createViewModel)
        {
            Employee employee = _mapper.Map<Employee>(createViewModel);
            try
            {
                _employeeRepository.CreateEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditEmployee(EditViewModel editViewModel)
        {
            Employee employee = _mapper.Map<Employee>(editViewModel);
            try
            {
                _employeeRepository.EditEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public void DeleteEmployee(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployeeById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public EditViewModel EditEmployee(int id)
        {
                try
                {
                    Employee employee = _employeeRepository.ReadEmployee(id);
                    EditViewModel editViewModel = _mapper.Map<EditViewModel>(employee);
                    return editViewModel;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
        }

    }
}
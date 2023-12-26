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
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        public List<GetViewModel> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = _employeeRepository.GetAll();
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
                Employee employee = _employeeRepository.Read(id);
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
                _employeeRepository.Create(employee);
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
                _employeeRepository.Edit(employee);
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
                _employeeRepository.Delete(id);
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
                    Employee employee = _employeeRepository.Read(id);
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
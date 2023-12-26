using Microsoft.EntityFrameworkCore;
using Task2.Models;
using Task2.Repository.Interface;
using Task2.ViewModel;

namespace Task2.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly DbSet<T> _employeeDbSet;

        public GenericRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
            _employeeDbSet = dbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            List<T> employees = _employeeDbSet.ToList();
            return employees;
        }

        public T Read(int id)
        {
            T employee = _employeeDbSet.Find(id)!;
            return employee;
        }

        public void Create(T employee)
        {
            _employeeDbSet.Add(employee);
            _dbContext.SaveChanges();
        }

        public void Edit(T employee)
        {
            _dbContext.Update(employee);
            _dbContext.SaveChanges();
        }


        public void Delete(int id)
        {
            T employee = _employeeDbSet.Find(id)!;
            _employeeDbSet.Remove(employee);
            _dbContext.SaveChanges();
        }

    }
}

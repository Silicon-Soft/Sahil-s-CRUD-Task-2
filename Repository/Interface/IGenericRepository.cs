using Task2.Models;
using Task2.ViewModel;

namespace Task2.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T Read(int id);
        void Create(T employee);
        void Edit(T employee);
        void Delete(int id);
    }
}

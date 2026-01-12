using System.Collections.Generic;

namespace HospitalSystem.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        bool Create(T obj);
        List<T> Get();
        T Get(int id);
        bool Update(T obj);
        bool Delete(int id);
    }
}

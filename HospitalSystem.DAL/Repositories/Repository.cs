using HospitalSystem.DAL.Context;
using HospitalSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        HospitalDbContext db;
        DbSet<T> table;

        public Repository(HospitalDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public bool Create(T obj)
        {
            table.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<T> Get()
        {
            return table.ToList();
        }

        public T Get(int id)
        {
            return table.Find(id);
        }

        public bool Update(T obj)
        {
            table.Update(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            if (data != null)
            {
                table.Remove(data);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}

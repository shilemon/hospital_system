using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DAL.Interfaces;
using HospitalSystem.DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        IRepository<Doctor> repo;

        public DoctorService(IRepository<Doctor> repo)
        {
            this.repo = repo;
        }

        public bool Create(Doctor doctor)
        {
            return repo.Create(doctor);
        }

        public List<Doctor> Get()
        {
            return repo.Get();
        }

        public Doctor Get(int id)
        {
            return repo.Get(id);
        }

        public bool Update(Doctor doctor)
        {
            return repo.Update(doctor);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public List<Doctor> GetAvailableDoctors()
        {
            return repo.Get().Where(d => d.IsAvailable).ToList();
        }
    }
}

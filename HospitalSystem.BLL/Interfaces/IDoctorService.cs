using HospitalSystem.DTO.Models;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Interfaces
{
    public interface IDoctorService
    {
        bool Create(Doctor doctor);
        List<Doctor> Get();
        Doctor Get(int id);
        bool Update(Doctor doctor);
        bool Delete(int id);

        // Smart feature
        List<Doctor> GetAvailableDoctors();
    }
}

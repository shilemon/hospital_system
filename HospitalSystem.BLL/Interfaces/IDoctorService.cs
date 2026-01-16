using HospitalSystem.DTO.Models;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Interfaces
{
    public interface IDoctorService
    {
        // CRUD
        bool Create(Doctor doctor);
        List<Doctor> Get();
        Doctor Get(int id);
        bool Update(Doctor doctor);
        bool Delete(int id);

        // Availability
        List<Doctor> GetAvailableDoctors();

        // 🔥 STEP 8: PERFORMANCE REPORT
        List<DoctorPerformanceDTO> GetDoctorPerformance();
    }
}

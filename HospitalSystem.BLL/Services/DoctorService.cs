using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DAL.Interfaces;
using HospitalSystem.DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> doctorRepo;
        private readonly IRepository<Appointment> appointmentRepo;

        // 🔹 UPDATED CONSTRUCTOR (two repositories)
        public DoctorService(
            IRepository<Doctor> doctorRepo,
            IRepository<Appointment> appointmentRepo)
        {
            this.doctorRepo = doctorRepo;
            this.appointmentRepo = appointmentRepo;
        }

        // ======================
        // BASIC CRUD
        // ======================
        public bool Create(Doctor doctor)
        {
            return doctorRepo.Create(doctor);
        }

        public List<Doctor> Get()
        {
            return doctorRepo.Get();
        }

        public Doctor Get(int id)
        {
            return doctorRepo.Get(id);
        }

        public bool Update(Doctor doctor)
        {
            return doctorRepo.Update(doctor);
        }

        public bool Delete(int id)
        {
            return doctorRepo.Delete(id);
        }

        public List<Doctor> GetAvailableDoctors()
        {
            return doctorRepo.Get()
                .Where(d => d.IsAvailable)
                .ToList();
        }

        // ======================
        // 🔥 STEP 8: PERFORMANCE REPORT
        // ======================
        public List<DoctorPerformanceDTO> GetDoctorPerformance()
        {
            var doctors = doctorRepo.Get();
            var appointments = appointmentRepo.Get();

            var report = doctors.Select(d => new DoctorPerformanceDTO
            {
                DoctorId = d.Id,
                DoctorName = d.FullName,
                Specialty = d.Specialty,

                TotalAppointments = appointments.Count(a => a.DoctorId == d.Id),
                ConfirmedAppointments = appointments.Count(a =>
                    a.DoctorId == d.Id && a.Status == "Confirmed"),
                RejectedAppointments = appointments.Count(a =>
                    a.DoctorId == d.Id && a.Status == "Rejected"),

                IsAvailable = d.IsAvailable
            }).ToList();

            return report;
        }
    }
}

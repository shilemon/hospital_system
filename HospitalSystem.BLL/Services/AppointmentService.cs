using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DAL.Interfaces;
using HospitalSystem.DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> appointmentRepo;
        private readonly IRepository<Patient> patientRepo;
        private readonly IRepository<Doctor> doctorRepo;
        private readonly INotificationService notificationService;

        public AppointmentService(
            IRepository<Appointment> appointmentRepo,
            IRepository<Patient> patientRepo,
            IRepository<Doctor> doctorRepo,
            INotificationService notificationService)
        {
            this.appointmentRepo = appointmentRepo;
            this.patientRepo = patientRepo;
            this.doctorRepo = doctorRepo;
            this.notificationService = notificationService;
        }

        // ✅ FIXED METHOD
        public List<AppointmentDto> Get()
        {
            var appointments = appointmentRepo.Get();
            var patients = patientRepo.Get();
            var doctors = doctorRepo.Get();

            return appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,

                PatientName = patients
                    .FirstOrDefault(p => p.Id == a.PatientId)?.FullName
                    ?? "Unknown Patient",

                DoctorName = doctors
                    .FirstOrDefault(d => d.Id == a.DoctorId)?.FullName
                    ?? "Unknown Doctor"
            }).ToList();
        }

        public Appointment Get(int id)
        {
            return appointmentRepo.Get(id);
        }

        public Appointment Create(Appointment appointment)
        {
            var doctor = doctorRepo.Get(appointment.DoctorId);

            if (doctor == null || !doctor.IsAvailable)
            {
                appointment.Status = "Rejected";
                appointmentRepo.Create(appointment);

                notificationService.Send(
                    appointment.PatientId,
                    "Your appointment has been rejected."
                );

                return appointment;
            }

            appointment.Status = "Confirmed";
            doctor.IsAvailable = false;

            doctorRepo.Update(doctor);
            appointmentRepo.Create(appointment);

            notificationService.Send(
                appointment.PatientId,
                "Your appointment has been confirmed."
            );

            return appointment;
        }
    }
}

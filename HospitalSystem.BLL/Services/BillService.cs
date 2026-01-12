using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DAL.Interfaces;
using HospitalSystem.DTO.Models;
using System;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Services
{
    public class BillService : IBillService
    {
        IRepository<Bill> billRepo;
        IRepository<Appointment> appointmentRepo;
        IRepository<Doctor> doctorRepo;

        public BillService(
            IRepository<Bill> billRepo,
            IRepository<Appointment> appointmentRepo,
            IRepository<Doctor> doctorRepo)
        {
            this.billRepo = billRepo;
            this.appointmentRepo = appointmentRepo;
            this.doctorRepo = doctorRepo;
        }

        public bool GenerateBill(int appointmentId)
        {
            var appointment = appointmentRepo.Get(appointmentId);
            if (appointment == null || appointment.Status != "Confirmed")
                return false;

            var doctor = doctorRepo.Get(appointment.DoctorId);

            decimal amount = doctor.Specialty switch
            {
                "Cardiology" => 1500,
                "Neurology" => 2000,
                "Orthopedics" => 1800,
                _ => 1000
            };

            var bill = new Bill
            {
                AppointmentId = appointmentId,
                Amount = amount,
                Status = "Unpaid",
                CreatedAt = DateTime.Now
            };

            return billRepo.Create(bill);
        }

        public List<Bill> GetAll()
        {
            return billRepo.Get();
        }

        public Bill Get(int id)
        {
            return billRepo.Get(id);
        }
    }
}

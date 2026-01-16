using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSystem.DTO.Models
{
    public class DoctorPerformanceDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialty { get; set; }

        public int TotalAppointments { get; set; }
        public int ConfirmedAppointments { get; set; }
        public int RejectedAppointments { get; set; }

        public bool IsAvailable { get; set; }
    }
}

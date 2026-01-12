using System;

namespace HospitalSystem.DTO.Models
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}

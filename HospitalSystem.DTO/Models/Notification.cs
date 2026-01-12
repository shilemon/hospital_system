using System;

namespace HospitalSystem.DTO.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public int PatientId { get; set; }   // ✅ ADD THIS

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

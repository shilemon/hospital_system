using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSystem.DTO.Models
{
    public class Bill
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; } // Paid / Unpaid

        public DateTime CreatedAt { get; set; }
    }
}

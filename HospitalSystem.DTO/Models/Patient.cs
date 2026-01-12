using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSystem.DTO.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

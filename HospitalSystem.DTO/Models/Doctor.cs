using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSystem.DTO.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public bool IsAvailable { get; set; }
    }
}



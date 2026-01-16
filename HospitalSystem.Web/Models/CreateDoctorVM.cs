using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Web.Models
{
    public class CreateDoctorVM
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Specialty { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}

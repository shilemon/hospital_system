using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Web.Models
{
    public class CreatePatientVM
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}

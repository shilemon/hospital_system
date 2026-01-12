using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Web.Models
{
    public class EditPatientVM
    {
        public int Id { get; set; } // only for URL

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

}

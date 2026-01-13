using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Web.Models
{
    public class CreateBillVM
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        public string Status { get; set; } = "Unpaid";
    }
}

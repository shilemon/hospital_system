namespace HospitalSystem.Web.Models
{
    public class BillVM
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

        // coming from API
        public DateTime CreatedAt { get; set; }

        // 👇 ADD THIS PROPERTY (VERY IMPORTANT)
        public DateTime BillDate => CreatedAt;
    }
}

namespace HospitalSystem.Web.Models
{
    public class DoctorVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }   // ✅ MUST MATCH API
        public bool IsAvailable { get; set; }
    }
}

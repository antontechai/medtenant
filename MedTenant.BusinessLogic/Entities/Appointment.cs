namespace MedTenant.BusinessLogic.Entities
{
    public class Appointment
    {
        //
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int DoctorId { get; set; }
        public int PatientUserId { get; set; }
        public DateTime TimeSlot { get; set; }
        public string Status { get; set; }
    }
}

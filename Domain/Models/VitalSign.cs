namespace Domain.Models
{
    public class VitalSign:BaseModule
    {
        public Guid VitalSignMasterId { get; set; }
        public VitalSignMaster VitalSignMaster { get; set; }
        public string Value { get; set; }

        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}

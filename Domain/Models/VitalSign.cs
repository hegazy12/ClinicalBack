using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class VitalSign:BaseModule
    {
        [ForeignKey("VitalSignMaster")]
        public Guid VitalSignMasterId { get; set; }
        public VitalSignMaster VitalSignMaster { get; set; }
        public string Value { get; set; }

        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    public class saveVitalSign : BaseModule
    {
        [Required]
        [ForeignKey(nameof(VitalSign))]
        public Guid VitalSignId { get; set; }
        public VitalSign VitalSign { get; set; }
        [Required]
        [ForeignKey(nameof(Appointment))]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public string value { get; set; }
    }
}

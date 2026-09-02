using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class chiefComplaint : BaseModule
    {
        public string Text { get; set; }
        
        [Required]
        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}

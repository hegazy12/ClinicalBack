using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class saveExaminationFinding : BaseModule
    {
        public string? Notes { get; set; }
        [Required]
        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [ForeignKey(nameof(ExaminationFinding))]
        public Guid ExaminationFindingId { get; set; }
        public ExaminationFinding ExaminationFinding { get; set; }
    }
}

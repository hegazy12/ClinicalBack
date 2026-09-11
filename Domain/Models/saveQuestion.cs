using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class saveQuestion :BaseModule
    {
        public string? Notes { get; set; } = string.Empty;
        [Required]
        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        [ForeignKey(nameof(Sheet))]
        public Guid SheetId { get; set; }
        public Sheet Sheet { get; set; }

        public string value { get; set; }
    }
}

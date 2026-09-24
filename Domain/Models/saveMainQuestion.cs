using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class saveMainQuestion : BaseModule
    {
        public string? Notes { get; set; } = string.Empty;
        
        [Required]
        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey(nameof(MainQuestion))]
        public Guid MainQuestionId { get; set; }
        public MainQuestion MainQuestion { get; set; }

        public string value { get; set; }

    }
}

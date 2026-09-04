using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    public class saveExaminationPhotos : BaseModule
    {
        [Required]
        [ForeignKey(nameof(saveExamination))]
        public Guid examinationId { get; set; }
        public saveExamination saveExamination { get; set; }
        
        public string? photoPath { get; set; }
        public string? photoBase64 { get; set; }
        public byte[]? imageBytes { get; set; } = null;
    }
}


using Domain.Models;
namespace ServiceLayer.vitalSignMaster.Dtos
{
    public class VitalSignMasterDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public List<VitalSign>? VitalSigns { get; set; } = new List<VitalSign>();
    }
}

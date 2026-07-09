using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.vitalSignMaster.Dtos
{
    public class CreateVitalSignMasterDto
    {
        [Required]
        public string Name { get; set; }
    }
}

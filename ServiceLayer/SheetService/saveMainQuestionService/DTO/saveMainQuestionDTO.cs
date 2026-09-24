using Domain.Models;
using ServiceLayer.SheetService.MainQuestionService.DTO;

namespace ServiceLayer.SheetService.saveMainQuestionService.DTO
{
    public class saveMainQuestionDTO
    {
        public string? Notes { get; set; }
        public Guid PatientId { get; set; }
        public Guid MainQuestionId { get; set; }
        public string value { get; set; }
    }

    public class saveMainQuestionDTO1 : saveMainQuestionDTO
    {
        public Guid Id { get; set; }
    }

    public class saveMainQuestionDTO2 : saveMainQuestionDTO1
    {
        public MainQuestionDTO1 mainQuestionDTO1 { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static saveMainQuestionDTO1 TosaveMainQuestionDTO1(this saveMainQuestion save)
        {
            return new saveMainQuestionDTO1()
            {
                Id = save.Id,
                Notes = save.Notes,
                PatientId = save.PatientId,
                MainQuestionId = save.MainQuestionId,
                value = save.value
            };
        }

        public static saveMainQuestionDTO2 TosaveMainQuestionDTO2(this saveMainQuestion save)
        {
            return new saveMainQuestionDTO2()
            {
                Id = save.Id,
                Notes = save.Notes,
                PatientId = save.PatientId,
                MainQuestionId = save.MainQuestionId,
                value = save.value,
                mainQuestionDTO1 = (save.MainQuestion != null) ? save.MainQuestion.ToMainQuestionDTO1() : null
            };
        }
    }
}

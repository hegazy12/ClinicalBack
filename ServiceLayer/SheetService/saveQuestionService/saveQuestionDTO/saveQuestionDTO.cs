
using Domain.Models;
using ServiceLayer.SheetService.DTO;
using ServiceLayer.SheetService.QuestionService.DTO;


namespace ServiceLayer.SheetService.saveQuestionService.saveQtionDTO
{
    public class saveQuestionDTO
    {
        public string? Notes { get; set; } 
        public Guid AppointmentId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid SheetId { get; set; }
        public string value { get; set; }
    }

    public class saveQuestionDTO1 : saveQuestionDTO
    {
        public Guid Id { get; set; }
    }


    public class saveQuestionDTO2 : saveQuestionDTO1
    {
        public QuestionDTO1 questionDTO1 { get; set; }
        public SheetDTO1 SheetDTO1 { get; set; }
    }

    public static partial class AdHocMapper
    {                                           
        public static saveQuestionDTO2 TosaveQuestionDTO2(this saveQuestion save)
        {
            return new saveQuestionDTO2()
            {
                AppointmentId = save.AppointmentId,
                Notes = save.Notes,
                Id = save.Id,
                SheetId = save.SheetId,
                value = save.value,
                questionDTO1 = (save.Question != null)? save.Question.ToQuestionDTO1() : null,
                QuestionId = save.QuestionId,
                SheetDTO1  =(save.Sheet != null)? save.Sheet.ToSheetDTO1() : null
            };
        }
    }
}

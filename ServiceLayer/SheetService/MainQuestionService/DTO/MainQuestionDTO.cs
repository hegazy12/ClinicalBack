using Domain.Models;

namespace ServiceLayer.SheetService.MainQuestionService.DTO
{
    public class MainQuestionDTO
    {
        public string QuestionBody { get; set; }
        public string description { get; set; }
        public string dataTypeName { get; set; }
        public string maxValue { get; set; }
        public string minValue { get; set; }
        public bool requeried { get; set; }
        public List<string>? listValues { get; set; }
        public int Gendar { get; set; }
        public int minage { get; set; }
        public int maxage {  get; set; }
        public bool requer { get; set; }
    }

    public class MainQuestionDTO1 : MainQuestionDTO
    {
        public Guid Id { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static MainQuestionDTO1 ToMainQuestionDTO1(this MainQuestion DTO)
        {
            return new MainQuestionDTO1()
            {
                Id = DTO.Id,
                QuestionBody = DTO.QuestionBody,
                description = DTO.description,
                dataTypeName = DTO.dataTypeName,
                maxValue = DTO.maxValue,
                minValue = DTO.minValue,
                requeried = DTO.requeried,
                listValues = DTO.listValues,
                Gendar = DTO.Gendar,
                maxage = DTO.maxage,
                minage = DTO.minage,
                requer = DTO.requer
            };
        }
    }
}

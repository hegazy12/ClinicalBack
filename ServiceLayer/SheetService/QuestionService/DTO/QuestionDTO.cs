using Domain.Models;
using ServiceLayer.SheetService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.SheetService.QuestionService.DTO
{
    public class QuestionDTO
    {
        public Guid SheetId { get; set; }
        public string QuestionBody { get; set; }
        public string description { get; set; }
        public string dataTypeName { get; set; }
        public string maxValue { get; set; }
        public string minValue { get; set; }
        public bool requeried { get; set; }
        public List<string> listValues { get; set; }
        public Guid? QuestionDependId { get; set; }
    }

    public class QuestionDTO1 : QuestionDTO
    {
        public Guid Id { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static QuestionDTO1 ToQuestionDTO1(this Question DTO)
        {
            return new QuestionDTO1()
            {
                Id = DTO.Id,
                dataTypeName = DTO.dataTypeName,
                maxValue = DTO.maxValue,
                description = DTO.description,
                listValues = DTO.listValues,
                minValue = DTO.minValue,
                QuestionBody = DTO.QuestionBody,
                QuestionDependId = (Guid)DTO.QuestionDependId,
                requeried = DTO.requeried,
                SheetId = DTO.SheetId
            };
        }
    }
}

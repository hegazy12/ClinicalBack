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
        public Guid QuestionDependId { get; set; }
    }

    public class QuestionDTO1 : QuestionDTO
    {
        public Guid Id { get; set; }
    }
}

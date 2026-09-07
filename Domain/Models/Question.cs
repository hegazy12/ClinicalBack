using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Question :BaseModule
    {
        [ForeignKey("Sheet")]
        public Guid SheetId { get; set; }
        public Sheet Sheet { get; set; }
        public string QuestionBody { get; set; }
        public string description { get; set; }
        public string dataTypeName { get; set; }
        public string maxValue { get; set; }
        public string minValue { get; set; }

        public bool requeried { get; set; }
        public List<string> listValues { get; set; }

        [ForeignKey("QuestionDepend")]
        public Guid QuestionDependId { get; set; }
        public Question QuestionDepend { get; set; }
        
        public List<Question> questionsDependOnMe { get; set; }
    }
}

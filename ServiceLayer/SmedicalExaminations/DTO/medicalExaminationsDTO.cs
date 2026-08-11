using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.SmedicalExaminations.DTO
{
    public class medicalExaminationsDTO
    {
        public string nameAr { get; set; }
        public string code { get; set; }
        public string nameEn { get; set; }
        public Guid classificationId { get; set; }
    }

    public class medicalExaminationsDTO1 : medicalExaminationsDTO 
    { 
        public Guid id { get; set; }
    }
}

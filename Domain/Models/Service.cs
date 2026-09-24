using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Service : BaseModule
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public Guid? ExaminationId { get; set; }
        public Guid? medicalExaminationId { get; set; }
    }
}

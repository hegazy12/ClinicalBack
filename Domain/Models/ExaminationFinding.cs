using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ExaminationFinding : BaseModule
    {
        public string Name { get; set;}
        public string Description { get; set;}
        public List<string> Answers { get; set;}
    }
}

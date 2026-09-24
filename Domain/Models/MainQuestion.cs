

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MainQuestion : BaseModule
    {
        public string QuestionBody { get; set; }
        public string description { get; set; }
        public string dataTypeName { get; set; }
        public string maxValue { get; set; }
        public string minValue { get; set; }
        public bool requeried { get; set; }
        public List<string>? listValues { get; set; }
        public int Gendar {  get; set; }
        public int minage { get; set; }
        public int maxage { get; set; }
        public  Boolean requer {  get; set; }
    }
}

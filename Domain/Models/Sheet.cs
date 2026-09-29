using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Sheet : BaseModule
    {
        public string Name { get; set; }
        public bool requeried { get; set; }
        public int Gendar { get; set; }
        public int minage { get; set; }
        public int maxage { get; set; }
        public List<Question> questions { get; set; }
    }
}

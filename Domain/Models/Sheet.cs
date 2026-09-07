using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Sheet : BaseModule
    {
        public string Name { get; set; }
        public List<Question> questions { get; set; }
    }
}

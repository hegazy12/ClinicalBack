using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Doctor.DTO
{
    public class DoctorDTO_1 :DoctorDTO_0
    {
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string jobTitle { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid Id { get; set; }
    }
}

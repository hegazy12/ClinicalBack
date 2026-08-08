using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Models;

namespace ServiceLayer.Prescription.DTO
{
    public class PrescriptionDTO
    {
        public string Notes { get; set; }
        public Guid AppointmentId { get; set; }
        public DateOnly from { get; set; }
        public DateOnly to { get; set; }
        public int Frequency { get; set; }
        public int type { get; set; }
        public Guid DrugId { get; set; }
    }

    public class PrescriptionDTO1 : PrescriptionDTO
    {
       public Guid id { get; set;}
    }

    public static partial class AdHocMapper
    {
     
    }
}

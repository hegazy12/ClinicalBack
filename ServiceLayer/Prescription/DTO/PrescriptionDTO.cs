using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Models;
using ServiceLayer.Doctor.DTO;
using ServiceLayer.Drug.Dtos;



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

    public class PrescriptionDTO2 : PrescriptionDTO1
    {
        public DoctorDTO_1 doctor { get; set; }
        public DrugDto drug  { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static PrescriptionDTO2 ToPrescriptionDTO2(this Domain.Models.Prescription prescription)
        {
            return new PrescriptionDTO2()
            {
                id = prescription.Id,
                Notes = prescription.Notes,
                AppointmentId = prescription.AppointmentId,
                drug = (prescription.Drug != null)? ToDrugDto(prescription.Drug) : null,
                Frequency = prescription.Frequency,
                from = prescription.from,
                to = prescription.to,
                type = prescription.type
            };
        }


        public static DrugDto ToDrugDto(Domain.Models.Drug drug)
        {
            return new DrugDto()
            {
                Id = drug.Id,
                CommercialNameAr = drug.CommercialNameAr,
                CommercialNameEn = drug.CommercialNameEn,
                DrugClass = drug.DrugClass,
                Manufacturer = drug.Manufacturer,
               // PriceEgp = drug.PriceEgp,
                Route = drug.Route,
                ScientificName = drug.ScientificName,
            };
        }


    }
}

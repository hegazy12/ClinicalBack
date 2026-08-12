using Domain.Models;
using ServiceLayer.Appointment.DTO;
using ServiceLayer.Doctor.DTO;
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

    public class classificationExaminationDTO
    {
        public string categoryAr { get; set; }
        public string categoryNameEn { get; set; }
    }

    public class classificationExaminationDTO1 : classificationExaminationDTO
    {
        public Guid Id { get; set; }
     
    }

    public class medicalExaminationsDTO1 : medicalExaminationsDTO 
    { 
        public Guid id { get; set; }
        public classificationExaminationDTO1 classificationExaminationDTO1 { get; set; }
    }



    public class saveExaminationDTO
    {
        public Guid idExamination { get; set; }
        public Guid idAppointment { get; set; }

    }
    




    public class saveExaminationDTO1 : saveExaminationDTO
    {
        public Guid id { get; set; }
        public medicalExaminationsDTO1 medicalExaminationsDTO { get; set; }
        public DoctorDTO_1 DoctorDTO { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static medicalExaminationsDTO1 ToMedicalExaminationsDTO1(this medicalExamination data)
        {
            return new medicalExaminationsDTO1()
            {
                id = data.Id,
                nameAr = data.nameAr,
                classificationId = data.classificationId,
                code = data.code,
                nameEn = data.nameEn,
                classificationExaminationDTO1 = (data.classification != null) ? data.classification.ToClassificationExaminationDTO1() : null
            };
        }
        public static classificationExaminationDTO1 ToClassificationExaminationDTO1(this classificationMedicalExamination data)
        {
            return new classificationExaminationDTO1()
            {
                Id = data.Id,
                categoryAr = data.categoryAr,
                categoryNameEn = data.categoryNameEn,
                
            };
        }

        public static saveExaminationDTO1 TosaveExaminationDTO1(this saveExamination x)
        {
            return new saveExaminationDTO1()
            {
                id = x.Id,
                idAppointment = x.AppointmentId,
                idExamination = x.AppointmentId,
                medicalExaminationsDTO = (x.medicalExamination != null)? x.medicalExamination.ToMedicalExaminationsDTO1() : null,
                DoctorDTO = (x.Appointment.Doctor != null)? x.Appointment.Doctor.ToDoctorDTO_1():null
            };
        }

    }
}

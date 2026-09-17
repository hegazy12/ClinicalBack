using Domain.Models;
using ServiceLayer.ExaminationFindingService.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.ExaminationFindingService.Save.DTO
{
    public class saveExaminationFindingDTO
    {
        public string? Notes { get; set; }
        public Guid AppointmentId { get; set; }  
        public Guid ExaminationFindingId { get; set; }
        public string Value { get; set; }
    }

    public class saveExaminationFindingDTO1 : saveExaminationFindingDTO
    {
        public Guid id {  get; set; }
    }

    public class saveExaminationFindingDTO2 : saveExaminationFindingDTO1
    {
        public ExaminationFindingDTO1? ExaminationFindingDTO1 { get; set; }
    }


    public static partial class AdHocMapper
    {
        public static saveExaminationFindingDTO1 ToExaminationFindingDTO1(this Domain.Models.saveExaminationFinding DTO)
        {
            if (DTO == null) return null;
            return new saveExaminationFindingDTO1
            {
                AppointmentId = DTO.AppointmentId,
                ExaminationFindingId = DTO.ExaminationFindingId,
                Value = DTO.Value,
                Notes = DTO.Notes,
                id = DTO.Id
            };
        }

        public static saveExaminationFindingDTO2 TOsaveExaminationFindingDTO2(this Domain.Models.saveExaminationFinding Model)
        {
            if (Model == null) return null;
            return new saveExaminationFindingDTO2
            {
                AppointmentId = Model.AppointmentId,
                ExaminationFindingId = Model.ExaminationFindingId,
                Value = Model.Value,
                Notes = Model.Notes,
                id = Model.Id,
                ExaminationFindingDTO1 = (Model.ExaminationFinding != null) ? Model.ExaminationFinding.ToExaminationFindingDTO1() : null
            };
        }
    }


}

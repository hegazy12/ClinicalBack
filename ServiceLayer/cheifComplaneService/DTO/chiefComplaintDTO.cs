using Domain.Models;
using ServiceLayer.Doctor.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.cheifComplaneService.DTO
{
    public class chiefComplaintDTO
    {
        public string Text { get; set; }
        public Guid AppointmentId { get; set; }
    }

    public class chiefComplaintDTO1 : chiefComplaintDTO
    {
       public Guid id { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static chiefComplaintDTO1 TochiefComplaintDTO1(this chiefComplaint DTO)
        {
            if (DTO == null) return null;
            return new chiefComplaintDTO1
            {
                Text = DTO.Text,
                AppointmentId = DTO.AppointmentId,
                id = DTO.Id
            };
        }
    }
}

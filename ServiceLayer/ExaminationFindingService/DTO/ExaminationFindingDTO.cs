using Domain.Models;
using ServiceLayer.Patient.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ExaminationFindingService.DTO
{
    public class ExaminationFindingDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ExaminationFindingDTO1 : ExaminationFindingDTO
    {
        public Guid id { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static ExaminationFindingDTO1 ToExaminationFindingDTO1(this ExaminationFinding ExaminationFinding)
        {
            if (ExaminationFinding == null) return null;
            return new ExaminationFindingDTO1
            {
                id = ExaminationFinding.Id,
                Name = ExaminationFinding.Name,
                Description = ExaminationFinding.Description,
            };
        }
    }

 }

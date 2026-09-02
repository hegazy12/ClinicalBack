using Domain.Models;
using ServiceLayer.VitalSignMaster.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.DiagnosService.DTO
{

    public class CreateDiagnosDTO
    {
        public string id { get; set; }
        public string Name { get; set; } 
        public string Note { get; set; }
        public Guid AppointmentId { get; set; }
    }

    public class MasterDiagnosDTO_0
    {
        public string Name { get; set; } 
        public string Code { get; set; } 
    }

    public class MasterDiagnosDTO_1 : MasterDiagnosDTO_0
    {
        public Guid Id { get; set; }
    }

    public class DiagnosDTO_0
    {
        public string Notes { get; set; } 
        public Guid AppointmentId { get; set; }
        public Guid DiagnosMasterId { get; set; }
    }

    public class DiagnosDTO_1 : DiagnosDTO_0
    {
        public Guid Id { get; set; }
    }

    public class DiagnosDTO_2 : DiagnosDTO_1
    {
        public MasterDiagnosDTO_1 DiagnosMaster {get; set;}
    }

    public static partial class AdHocMapper
    {
        public static MasterDiagnosDTO_1 ToMasterDiagnosDTO_1(this DiagnosMaster DiagnosMaster)
        {
            return new MasterDiagnosDTO_1()
            {
                Name = DiagnosMaster.Name,
                Code = DiagnosMaster.Code,
                Id = DiagnosMaster.Id
            };
        }

        public static DiagnosDTO_1 ToDiagnosDTO_1(this Diagnos Diagnos)
        {
            return new DiagnosDTO_1()
            {
                Notes = Diagnos.Notes,
                AppointmentId = Diagnos.AppointmentId,
                DiagnosMasterId = Diagnos.DiagnosMasterId,
                Id = Diagnos.Id
            };
        }

        public static DiagnosDTO_2 ToDiagnosDTO_2(this Diagnos Diagnos)
        {
            return new DiagnosDTO_2()
            {
                Notes = Diagnos.Notes,
                AppointmentId = Diagnos.AppointmentId,
                DiagnosMasterId = Diagnos.DiagnosMasterId,
                Id = Diagnos.Id,
                DiagnosMaster = (Diagnos.DiagnosMaster != null) ? Diagnos.DiagnosMaster.ToMasterDiagnosDTO_1() : null
            };
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace ServiceLayer.Doctor.DTO
{
    public class DoctorDTO_0
    {
        public string Specialization { get; set; } = string.Empty;
        public string ClinicName { get; set; } = string.Empty;
        public string ClinicAddress { get; set; } = string.Empty;
        public string ClinicPhoneNumber { get; set; } = string.Empty;
        public string ClinicEmail { get; set; } = string.Empty;
    }

    public class SpecializationDTO
    {
        public string SpecializationName { get; set; }
    }

    public class SpecializationDTO1 : SpecializationDTO
    {
        public Guid id { get; set; }
    }


    public static partial class AdHocMapper
    {
        public static DoctorDTO_1 ToDoctorDTO_1(this Domain.Models.Doctor doctor)
        {
            if (doctor == null) return null;
            return new DoctorDTO_1
            {
                Id = doctor.Id,
                Specialization = doctor.Specialization,
                ClinicName = doctor.ClinicName,
                ClinicAddress = doctor.ClinicAddress,
                ClinicPhoneNumber = doctor.ClinicPhoneNumber,
                ClinicEmail = doctor.ClinicEmail ,
                FristName = (doctor.ApplicationUser != null) ?  doctor.ApplicationUser.FirstName : "" ,
                LastName  = (doctor.ApplicationUser != null) ? doctor.ApplicationUser.LastName   : "" ,
                Email = (doctor.ApplicationUser != null) ? doctor.ApplicationUser.Email : ""

            };
        }

        public static Domain.Models.Doctor ToDoctor(this DoctorDTO_1 doctorDTO)
        {
            if (doctorDTO == null) return null;
            return new Domain.Models.Doctor
            {
                Id = doctorDTO.Id,
                Specialization = doctorDTO.Specialization,
                ClinicName = doctorDTO.ClinicName,
                ClinicAddress = doctorDTO.ClinicAddress,
                ClinicPhoneNumber = doctorDTO.ClinicPhoneNumber,
                ClinicEmail = doctorDTO.ClinicEmail
            };
        }

        public static SpecializationDTO1 ToSpecializationDTO1(this Specialization DTO)
        {
            return new SpecializationDTO1
            {
                id = DTO.Id,
                SpecializationName = DTO.SpecializationName,
            };
        }
    }
}

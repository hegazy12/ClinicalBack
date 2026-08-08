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
                FristName = (doctor.ApplicationUser != null) ?  doctor.ApplicationUser.FirstName : null ,
                LastName  = (doctor.ApplicationUser != null) ? doctor.ApplicationUser.LastName   : null ,
                Email = (doctor.ApplicationUser != null) ? doctor.ApplicationUser.Email : null

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
    }
}

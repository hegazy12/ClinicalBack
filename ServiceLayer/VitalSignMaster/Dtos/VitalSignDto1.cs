using Domain.Models;
using ServiceLayer.Appointment.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.VitalSignMaster.Dtos
{
    public class VitalSignDto1
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string dataTypeName { get; set; }
        public string maxValue { get; set; }
        public string minValue { get; set; }
        public string mastarName { get; set; }
        public List<string> listValues { get; set; }
    }
    public class savaVitalSigDto
    {
        public Guid VitalSignId { get; set; }
        public Guid AppointmentId { get; set; }
        public string value { get; set; }
    }

    public class savaVitalSigDto1 : savaVitalSigDto
    {
        public Guid Id { get; set; }
    }

    public class savaVitalSigDto2 : savaVitalSigDto1
    {
        public AppointmentDTO_1 appointmentDTO1 { get; set; }
        public VitalSignDto1 VitalSignDto1 { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static VitalSignDto1 ToVitalSignDto1(this VitalSign vitalSign)
        {
            return new VitalSignDto1() {
                dataTypeName = vitalSign.dataTypeName,
                description  = vitalSign.description,
                listValues   = vitalSign.listValues,
                maxValue     = vitalSign.maxValue,
                minValue     = vitalSign.minValue,
                name         = vitalSign.name,
                Id           = vitalSign.Id,
                mastarName   = (vitalSign.VitalSignMaster !=null)? vitalSign.VitalSignMaster.Name : ""
            };
        }

        public static savaVitalSigDto1 TosavaVitalSigDto1(this saveVitalSign saveVitalSign)
        {
            return new savaVitalSigDto1() 
            {
                AppointmentId = saveVitalSign.AppointmentId,
                VitalSignId = saveVitalSign.VitalSignId,
                Id = saveVitalSign.Id,
                value = saveVitalSign.value
            };
        }

        public static savaVitalSigDto2 TosavaVitalSigDto2(this saveVitalSign saveVitalSign) {
            
            return new savaVitalSigDto2()
            {
                Id = saveVitalSign.Id,
                appointmentDTO1 = (saveVitalSign.Appointment != null)? saveVitalSign.Appointment.ToAppointmentDTO_1(): null,
                AppointmentId = saveVitalSign.AppointmentId,
                value = saveVitalSign.value,
                VitalSignId = saveVitalSign.VitalSignId,
                VitalSignDto1 = (saveVitalSign.VitalSign != null)? saveVitalSign.VitalSign.ToVitalSignDto1():null
            };
        }
    }
}

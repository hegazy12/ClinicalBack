using Domain.Models;
using System;
using System.Collections.Generic;
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

    public static partial class AdHocMapper
    {

        public static VitalSignDto1 ToVitalSignDto1(this VitalSign vitalSign)
        {
            return new VitalSignDto1() {
                dataTypeName = vitalSign.dataTypeName,
                description = vitalSign.description,
                listValues = vitalSign.listValues,
                maxValue = vitalSign.maxValue,
                minValue = vitalSign.minValue,
                name = vitalSign.name,
                Id = vitalSign.Id,
                mastarName = (vitalSign.VitalSignMaster !=null)? vitalSign.VitalSignMaster.Name : null
            };

        }
    }

}

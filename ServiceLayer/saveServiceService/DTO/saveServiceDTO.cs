using Domain.Models;
using ServiceLayer.ServiceOfServices.DTO;

namespace ServiceLayer.saveServiceService.DTO
{
    public class saveServiceDTO
    {
        public string? Notes { get; set; }
        public Guid AppointmentId { get; set; }
        public Guid ServiceId { get; set; }
    }

    public class saveServiceDTO1 : saveServiceDTO
    {
        public Guid Id { get; set; }
    }

    public class saveServiceDTO2 : saveServiceDTO1
    {
        public ServiceDTO1 serviceDTO1 { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static saveServiceDTO1 TosaveServiceDTO1(this saveService save)
        {
            return new saveServiceDTO1()
            {
                Id = save.Id,
                Notes = save.Notes,
                AppointmentId = save.AppointmentId,
                ServiceId = save.ServiceId
            };
        }

        public static saveServiceDTO2 TosaveServiceDTO2(this saveService save)
        {
            return new saveServiceDTO2()
            {
                Id = save.Id,
                Notes = save.Notes,
                AppointmentId = save.AppointmentId,
                ServiceId = save.ServiceId,
                serviceDTO1 = (save.Service != null) ? save.Service.ToServiceDTO1() : null
            };
        }
    }
}

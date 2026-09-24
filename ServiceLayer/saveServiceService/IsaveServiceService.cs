using Domain.Response;
using ServiceLayer.saveServiceService.DTO;

namespace ServiceLayer.saveServiceService
{
    public interface IsaveServiceService
    {
        public Task<GeneralResponse<saveServiceDTO1>> Add(saveServiceDTO DTO, Guid userId);
        public Task<GeneralResponse<Boolean>> Delete(Guid saveServiceID, Guid userId);
        public Task<GeneralResponse<IEnumerable<saveServiceDTO2>>> GetByAppointmentID(Guid AppointmentID);
    }
}

using Domain.Response;
using ServiceLayer.ServiceOfServices.DTO;

namespace ServiceLayer.ServiceOfServices
{
    public interface IServiceOfServices
    {
        public Task<GeneralResponse<ServiceDTO1>> Add(ServiceDTO DTO, Guid userId);
        public Task<GeneralResponse<IEnumerable<ServiceDTO1>>> Search(string? name);
        public Task<GeneralResponse<ServiceDTO1>> GetById(Guid serviceId);
        public Task<GeneralResponse<Boolean>> Delete(Guid serviceId, Guid userId);
    }
}

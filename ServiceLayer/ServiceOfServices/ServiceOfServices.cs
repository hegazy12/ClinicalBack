using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.ServiceOfServices.DTO;

namespace ServiceLayer.ServiceOfServices
{
    public class ServiceOfServices : IServiceOfServices
    {
        public IUnitOfWork unitOfWork;
        public ServiceOfServices(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GeneralResponse<ServiceDTO1>> Add(ServiceDTO DTO, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(DTO.name) || DTO.price < 0)
            {
                return new GeneralResponse<ServiceDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "Service name is required and price can not be negative",
                    Success = false
                };
            }

            Service service = new Service()
            {
                name = DTO.name.Trim(),
                description = DTO.description,
                price = DTO.price,
            };

            service.Create(userId);
            var IsCreatBefor = await unitOfWork.serviceRepository.IsCreatBefor(service);

            if (IsCreatBefor)
            {
                return new GeneralResponse<ServiceDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "you are save this Service befor",
                    Success = false
                };
            }
            else
            {
                await unitOfWork.serviceRepository.AddAsync(service);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<ServiceDTO1>()
                {
                    Data = service.ToServiceDTO1(),
                    dateTime = DateTime.Now,
                    Message = "The data was successfully saved completed",
                    Success = true
                };
            }
        }

        public async Task<GeneralResponse<IEnumerable<ServiceDTO1>>> Search(string? name)
        {
            // empty search returns all services
            var x = string.IsNullOrWhiteSpace(name)
                ? await unitOfWork.serviceRepository.FindAllAsync(m => !m.IsDeleted)
                : await unitOfWork.serviceRepository.FindAllAsync(m => m.name.Contains(name.Trim()) && !m.IsDeleted);

            var m = x.Select(x => x.ToServiceDTO1()).ToList();
            return new GeneralResponse<IEnumerable<ServiceDTO1>>()
            {
                Data = m,
                dateTime = DateTime.Now,
                Message = "The data was successfully completed",
                Success = true,
            };
        }

        public async Task<GeneralResponse<ServiceDTO1>> GetById(Guid serviceId)
        {
            var x = await unitOfWork.serviceRepository.FindAllAsync(m => m.Id == serviceId && !m.IsDeleted);
            var service = x.FirstOrDefault();
            return new GeneralResponse<ServiceDTO1>()
            {
                Data = service?.ToServiceDTO1(),
                dateTime = DateTime.Now,
                Message = service == null ? "Service not found" : "The data was successfully completed",
                Success = service != null,
            };
        }

        public async Task<GeneralResponse<Boolean>> Delete(Guid serviceId, Guid userId)
        {
            try
            {
                var service = unitOfWork.serviceRepository.Find(m => m.Id == serviceId && !m.IsDeleted);
                if (service == null)
                {
                    return new GeneralResponse<bool>()
                    {
                        Data = false,
                        dateTime = DateTime.Now,
                        Message = "Service not found",
                        Success = false,
                    };
                }
                service.MarkAsDeleted(userId);
                unitOfWork.serviceRepository.Update(service);
                await unitOfWork.SaveChangesAsync();

                return new GeneralResponse<bool>()
                {
                    Data = true,
                    dateTime = DateTime.Now,
                    Message = "The data was successfully Deleted completed",
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<bool>()
                {
                    Data = false,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };
            }
        }
    }
}

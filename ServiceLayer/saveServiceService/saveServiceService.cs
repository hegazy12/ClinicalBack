using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.saveServiceService.DTO;

namespace ServiceLayer.saveServiceService
{
    public class saveServiceService : IsaveServiceService
    {
        public IUnitOfWork unitOfWork;
        public saveServiceService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GeneralResponse<saveServiceDTO1>> Add(saveServiceDTO DTO, Guid userId)
        {
            var appointment = await unitOfWork.appoinmentRepository.FindAsync(m => m.Id == DTO.AppointmentId && !m.IsDeleted);
            if (appointment == null)
            {
                return new GeneralResponse<saveServiceDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "Appointment not found",
                    Success = false
                };
            }

            var service = await unitOfWork.serviceRepository.FindAsync(m => m.Id == DTO.ServiceId && !m.IsDeleted);
            if (service == null)
            {
                return new GeneralResponse<saveServiceDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "Service not found",
                    Success = false
                };
            }

            var save = new saveService()
            {
                AppointmentId = DTO.AppointmentId,
                ServiceId = DTO.ServiceId,
                Notes = DTO.Notes
            };

            save.Create(userId);

            var x = await unitOfWork.saveServiceRepository.IsCreatBefor(save);
            if (x)
            {
                return new GeneralResponse<saveServiceDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "You are save this Service Befor",
                    Success = false
                };
            }
            else
            {
                await unitOfWork.saveServiceRepository.AddAsync(save);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<saveServiceDTO1>()
                {
                    Data = save.TosaveServiceDTO1(),
                    dateTime = DateTime.Now,
                    Message = "The data was successfully completed",
                    Success = true
                };
            }
        }

        public async Task<GeneralResponse<bool>> Delete(Guid saveServiceID, Guid userId)
        {
            try
            {
                var saveService = unitOfWork.saveServiceRepository.Find(m => m.Id == saveServiceID && !m.IsDeleted);
                if (saveService == null)
                {
                    return new GeneralResponse<bool>()
                    {
                        Data = false,
                        dateTime = DateTime.Now,
                        Message = "Saved service not found",
                        Success = false,
                    };
                }
                saveService.MarkAsDeleted(userId);
                unitOfWork.saveServiceRepository.Update(saveService);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<bool>()
                {
                    Data = true,
                    dateTime = DateTime.Now,
                    Message = "The data was successfully completed",
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

        public async Task<GeneralResponse<IEnumerable<saveServiceDTO2>>> GetByAppointmentID(Guid AppointmentID)
        {
            var savedServices = await unitOfWork.saveServiceRepository.FindAllAsync(m => m.AppointmentId == AppointmentID && !m.IsDeleted, new string[] { "Service" });
            var x = savedServices.Select(m => m.TosaveServiceDTO2()).ToList();

            return new GeneralResponse<IEnumerable<saveServiceDTO2>>()
            {
                Data = x,
                dateTime = DateTime.UtcNow,
                Success = true,
                Message = "The data was successfully completed"
            };
        }
    }
}

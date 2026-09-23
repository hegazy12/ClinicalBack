using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.cheifComplaneService.DTO;


namespace ServiceLayer.cheifComplaneService
{
    public class cheifComplaneService :IcheifComplaneService
    {
        public IUnitOfWork unitOfWork;
        public cheifComplaneService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<bool>> Delete(Guid chiefComplaintId, Guid userId)
        {
            try
            {
                var chiefComplaint = unitOfWork.chiefComplaintRepository.Find(m => m.Id == chiefComplaintId);
                chiefComplaint.MarkAsDeleted(userId);
                unitOfWork.chiefComplaintRepository.Update(chiefComplaint);
                await unitOfWork.SaveChangesAsync();

                return new GeneralResponse<bool>()
                {
                    Data = true,
                    dateTime = DateTime.Now,
                    Message = "The data was deleted successfully completed",
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

        public async Task<GeneralResponse<IEnumerable<chiefComplaintDTO1>>> GetbyAppointmentId(Guid id)
        {
           var x = await unitOfWork.chiefComplaintRepository.FindAllAsync(m => m.AppointmentId == id && !m.IsDeleted );
            return new GeneralResponse<IEnumerable<chiefComplaintDTO1>>()
            {
                Data     = x.Select(m=>m.TochiefComplaintDTO1()),
                Message  = "chief Complaints retrieved successfully",
                Success  = true,
                dateTime = DateTime.Now
            };
        }

        public async Task<GeneralResponse<chiefComplaintDTO1>> save(chiefComplaintDTO DTO, Guid userId)
        {
            chiefComplaint chief = new chiefComplaint()
            {
               AppointmentId = DTO.AppointmentId,
               Text = DTO.Text,
            };
            
            var x = await unitOfWork.chiefComplaintRepository.IsCreatBefor(chief);

            if (x == false)
            {
                try
                {
                    chief.Create(userId);
                    await unitOfWork.chiefComplaintRepository.AddAsync(chief);
                    var m = await unitOfWork.SaveChangesAsync();
                    return new GeneralResponse<chiefComplaintDTO1>()
                    {
                        Data = chief.TochiefComplaintDTO1(),
                        dateTime = DateTime.Now,
                        Message = "save is done",
                        Success = true,
                    };
                }
                catch (Exception ex)
                {

                    return new GeneralResponse<chiefComplaintDTO1>()
                    {
                        Data = null,
                        Success = false,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new GeneralResponse<chiefComplaintDTO1>()
                {
                    Data = null,
                    Success = false,
                    Message = "you are save this item befor"
                };
            }
        }
    }
}

using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.Prescription.DTO;
using ServiceLayer.vitalSignMaster.Interfaces;
using ServiceLayer.VitalSignMaster.Dtos;

namespace ServiceLayer.VitalSignMaster.Interfaces
{
    public class VitalSignMasterService : IVitalSignMasterService
    {
        public IUnitOfWork unitOfWork;
        
        public VitalSignMasterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GeneralResponse<VitalSignDto1>> Delete(Guid id, Guid userid)
        {
            try
            {
                var VitalSign = unitOfWork.saveVitalSignRepository.Find(m => m.Id == id);
                VitalSign.MarkAsDeleted(userid);
                unitOfWork.saveVitalSignRepository.Update(VitalSign);
                await unitOfWork.SaveChangesAsync();

                return new GeneralResponse<VitalSignDto1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "The data was deleted successfully completed",
                    Success = true,
                };

            }
            catch (Exception ex)
            {

                return new GeneralResponse<VitalSignDto1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };

            }
        }

        public async Task<GeneralResponse<IList<savaVitalSigDto2>>> GetByAppointmentIdAsync(Guid id)
        {
           var m = await unitOfWork.vitalSignsRepository.GetByAppointmentIdAsync(id);
            return new GeneralResponse<IList<savaVitalSigDto2>>()
            {
                Data     = m.Select(m => m.TosavaVitalSigDto2()).ToList(),
                Success  = true,
                dateTime = DateTime.Now,
                Message  = "is sacsess"
            };
        }

        public async Task<GeneralResponse<IEnumerable<VitalSignDto1>>> GetSearchTearmAsync(string x)
        {
            try
            {
                var m = await unitOfWork.vitalSignsRepository.GetSearchTearmAsync(x);
                var s = m.Select(ss => ss.ToVitalSignDto1()).ToList();
                return new GeneralResponse<IEnumerable<VitalSignDto1>>()
                {
                    Data = s,
                    Success = true,
                    dateTime = DateTime.Now,
                    Message = "is sacsess"
                };
            }
            catch (Exception ex) {
                return new GeneralResponse<IEnumerable<VitalSignDto1>>()
                {
                    Data = null,
                    Success = false,
                    dateTime = DateTime.Now,
                    Message = "is not sacsess"
                };
            }
        }

        public async Task<GeneralResponse<savaVitalSigDto1>> save(savaVitalSigDto Dto , Guid Creatby)
        {
            try
            {
                var Vital = new saveVitalSign()
                {
                    value = Dto.value,
                    VitalSignId = Dto.VitalSignId,
                    AppointmentId = Dto.AppointmentId
                };
                                                
                Vital.Create(Creatby);

                var x = await unitOfWork.saveVitalSignRepository.IsCreatBefor(Vital);
                if (x)
                {
                    return new GeneralResponse<savaVitalSigDto1>()
                    {
                        Data = null,
                        Success = false,
                        dateTime = DateTime.Now,
                        Message = "you are save this VitalSign befor"
                    };

                }
                else
                {

                    var m = await unitOfWork.vitalSignsRepository.save(Vital);

                    await unitOfWork.SaveChangesAsync();

                    return new GeneralResponse<savaVitalSigDto1>()
                    {
                        Data = m.TosavaVitalSigDto1(),
                        Success = true,
                        dateTime = DateTime.Now,
                        Message = "is sacsess"
                    };
                }
            }
            catch 
            (Exception ex)
            {
                return new GeneralResponse<savaVitalSigDto1>()
                {
                    Data = null,
                    Success = false,
                    dateTime = DateTime.Now,
                    Message = ex.Message
                };
            }
        }
    }
}
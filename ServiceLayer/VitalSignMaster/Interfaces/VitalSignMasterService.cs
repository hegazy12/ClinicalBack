using Domain.IUnitOfWork;
using Domain.Response;
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
    }
}

using Domain.Response;
using ServiceLayer.Prescription.DTO;
using ServiceLayer.vitalSignMaster.Dtos;
using ServiceLayer.VitalSignMaster.Dtos;

namespace ServiceLayer.vitalSignMaster.Interfaces
{
    public interface IVitalSignMasterService
    {
       public Task<GeneralResponse<IEnumerable<VitalSignDto1>>> GetSearchTearmAsync(string x);
       public Task<GeneralResponse<savaVitalSigDto1>> save(savaVitalSigDto savaVitalSigDto , Guid Creatby);
       public Task<GeneralResponse<IList<savaVitalSigDto2>>> GetByAppointmentIdAsync(Guid id);
        public Task<GeneralResponse<VitalSignDto1>> Delete(Guid id, Guid userid);
    }
}

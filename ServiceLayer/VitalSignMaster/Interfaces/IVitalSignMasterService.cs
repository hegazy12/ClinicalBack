using Domain.Response;
using ServiceLayer.vitalSignMaster.Dtos;
using ServiceLayer.VitalSignMaster.Dtos;

namespace ServiceLayer.vitalSignMaster.Interfaces
{
    public interface IVitalSignMasterService
    {
       public Task<GeneralResponse<IEnumerable<VitalSignDto1>>> GetSearchTearmAsync(string x);

    }
}

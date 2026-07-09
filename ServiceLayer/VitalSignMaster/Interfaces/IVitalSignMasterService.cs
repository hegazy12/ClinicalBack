using ServiceLayer.vitalSignMaster.Dtos;
using ServiceLayer.Response;

namespace ServiceLayer.vitalSignMaster.Interfaces
{
    public interface IVitalSignMasterService
    {
        Task<GeneralResponse<VitalSignMasterDto>> CreateVitalSignMasterAsync(Guid UserId,CreateVitalSignMasterDto vitalSignMasterDto);

    }
}

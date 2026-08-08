using ServiceLayer.Patient.DTO;
using Domain.Response;

namespace ServiceLayer.Patient;

public interface IPatient
{
  public Task<GeneralResponse<PatientDTO_1>> CreatPatient(PatientDTO_0 patientDTO_0 , Guid Createby);
  public Task<GeneralResponse<List<PatientDTO_1>>> GetbyCreateBy(Guid CreateBy);
  public Task<GeneralResponse<List<PatientDTO_1>>> GetPatientsNew();
  public Task<GeneralResponse<PatientDTO_1>> GetPatient(Guid id);

  public Task<GeneralResponse<PatientDTO_2>> GetAllInfo(Guid id);
}

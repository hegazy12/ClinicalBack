using ServiceLayer.Patient.DTO;
using ServiceLayer.Response;

namespace ServiceLayer.Patient;

public interface IPatient
{
  public Task<GeneralResponse<PatientDTO_1>> CreatPatient(PatientDTO_0 patientDTO_0 , Guid Createby);
}

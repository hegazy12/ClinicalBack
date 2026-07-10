using ServiceLayer.Patient.DTO;
using Domain.IUnitOfWork;
using ServiceLayer.Response;

namespace ServiceLayer.Patient;

public class Patient : IPatient
{

    public IUnitOfWork _unitOfWork;
    
    public Patient(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<GeneralResponse<PatientDTO_0>>  CreatPatient(PatientDTO_0 patientDTO_0 ,Guid Createby)
    {
        Domain.Models.Patient patient = new Domain.Models.Patient()
        {
            FirstName = patientDTO_0.FirstName,
            LastName = patientDTO_0.LastName,
            DateOfBirth = patientDTO_0.DateOfBirth,
            Address = patientDTO_0.Address,
            PhoneNumber = patientDTO_0.PhoneNumber,
        };
        
        patient.Create(Createby);
        
        _unitOfWork.patientRepository.Add(patient);
        await  _unitOfWork.SaveChangesAsync();
        
       return  new GeneralResponse<PatientDTO_0>()
        {
              
        };

       
    }

}

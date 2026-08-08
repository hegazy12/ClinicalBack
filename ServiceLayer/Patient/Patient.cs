using ServiceLayer.Patient.DTO;
using Domain.IUnitOfWork;
using Domain.Response;

namespace ServiceLayer.Patient;

public class Patient : IPatient
{

    public IUnitOfWork _unitOfWork;

    public Patient(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GeneralResponse<PatientDTO_1>> CreatPatient(PatientDTO_0 patientDTO_0, Guid Createby)
    {

        try
        {
            Domain.Models.Patient patient = new Domain.Models.Patient()
            {
                FirstName = patientDTO_0.firstName,
                LastName = patientDTO_0.lastName,
                DateOfBirth = patientDTO_0.dateOfBirth,
                Address = patientDTO_0.address,
                PhoneNumber = patientDTO_0.phoneNumber,
                gender = patientDTO_0.gender,
            };
           
            patient.Create(Createby);
            
            Domain.Models.Patient P = _unitOfWork.patientRepository.Add(patient);
            
            await _unitOfWork.SaveChangesAsync();

            return new GeneralResponse<PatientDTO_1>()
            {
                Success = true,
                Data = P.ToPatientDTO_1(),
                Message = "Patient created successfully."
            };
        }
        catch (Exception ex)
        {
            return new GeneralResponse<PatientDTO_1>() { Success = false, Data = null, Message = ex.Message };
        }


    }

    public async Task<GeneralResponse<List<PatientDTO_1>>> GetbyCreateBy(Guid CreateBy)
    {
        try
        {
            var patients = await _unitOfWork.patientRepository.GetPatientsByCreateByAsync(CreateBy);
            var patientDTOs = patients.Select(p => p.ToPatientDTO_1()).ToList();

            return new GeneralResponse<List<PatientDTO_1>>()
            {
                Success = true,
                Data = patientDTOs,
                Message = "Patients retrieved successfully."
            };
        }
        catch (Exception ex)
        {
            return new GeneralResponse<List<PatientDTO_1>>()
            {
                Success = false,
                Data = null,
                Message = ex.Message
            };
        }

    }

    public async Task<GeneralResponse<List<PatientDTO_1>>> GetPatientsNew()
    {
        try
        {
            var patients = await _unitOfWork.patientRepository.GetPatientsNew();
            var patientDTOs = patients.OrderBy(m => m.CreatedAt).Select(p => p.ToPatientDTO_1()).ToList();
            return new GeneralResponse<List<PatientDTO_1>>()
            {
                Success = true,
                Data = patientDTOs,
                Message = "Patients retrieved successfully."
            };
        }
        catch (Exception ex)
        {
            return new GeneralResponse<List<PatientDTO_1>>()
            {
                Success = false,
                Data = null,
                Message = ex.Message
            };
        }
    }

    public async Task<GeneralResponse<PatientDTO_1>> GetPatient(Guid id)
    {
        try
        {
            var p = _unitOfWork.patientRepository.GetById(id);
            var Patient = p.ToPatientDTO_1();
            return new GeneralResponse<PatientDTO_1>()
            {
                Data = Patient,
                Success = true,
                Message = "this patient is loaded"
            };
        }
        catch (Exception ex)
        {
            return new GeneralResponse<PatientDTO_1>()
            {
                Data = null,
                Success = false,
                Message = "this patient is not loaded"
            };
        }
    }

    public Task<GeneralResponse<PatientDTO_2>> GetAllInfo(Guid id)
    {
        try
        {
            var p = _unitOfWork.patientRepository.GetById(id);
            return Task.FromResult(new GeneralResponse<PatientDTO_2>()
            {
                Data = p.ToPatientDTO_2(),
                Success = false,
                Message = "this patient is not loaded"
            });
        }
        catch (Exception ex)
        {
            return Task.FromResult(new GeneralResponse<PatientDTO_2>()
            {
                Data = null,
                Success = false,
                Message = "this patient is not loaded"
            });
        }
    }
}

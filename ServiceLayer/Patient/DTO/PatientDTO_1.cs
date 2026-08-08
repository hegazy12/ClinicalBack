namespace ServiceLayer.Patient.DTO;

public class PatientDTO_1 : PatientDTO_0
{
    public Guid Id {get; set;}
}

public class PatientDTO_2 : PatientDTO_1
{
   
}

public static partial class AdHocMapper
{
    public static PatientDTO_1 ToPatientDTO_1(this Domain.Models.Patient patient)
    {
        if (patient == null) return null;
        return new PatientDTO_1
        {
            Id = patient.Id,
            firstName = patient.FirstName,
            lastName = patient.LastName,
            dateOfBirth = patient.DateOfBirth,
            address = patient.Address,
            phoneNumber = patient.PhoneNumber,
            gender = patient.gender
        };
    }


    public static Domain.Models.Patient ToPatient(this Domain.Models.Patient patient)
    {
        if (patient == null) return null;
        return new Domain.Models.Patient
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            DateOfBirth = patient.DateOfBirth,
            Address = patient.Address,
            PhoneNumber = patient.PhoneNumber,
            gender = patient.gender
        };
    }

    public static PatientDTO_2 ToPatientDTO_2(this Domain.Models.Patient patient)
    {
        if (patient == null) return null;
        return new PatientDTO_2
        {
            Id = patient.Id,
            firstName = patient.FirstName,
            lastName = patient.LastName,
            dateOfBirth = patient.DateOfBirth,
            address = patient.Address,
            phoneNumber = patient.PhoneNumber,
            gender = patient.gender
        };
    }
}
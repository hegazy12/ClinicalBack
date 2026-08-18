using ServiceLayer.Doctor.DTO;
using ServiceLayer.Patient.DTO;
using ServiceLayer.Prescription.DTO;
using ServiceLayer.SmedicalExaminations.DTO;

namespace ServiceLayer.Appointment.DTO;

public class AppointmentDTO_1 : AppointmentDTO_0
{
    public string PatientFirstName { get; set; } = string.Empty;
    public string PatientLastName { get; set; } = string.Empty;
    public string DoctorFirstName { get; set; } = string.Empty;
    public string DoctorLastName { get; set; } = string.Empty;
    public string DoctorSpecialization { get; set; } = string.Empty;
    public Guid Id {get; set;}
}
public class AppointmentDTO_2 : AppointmentDTO_1
{
    public PatientDTO_1 PatientDTO_1 { get; set;}
    public DoctorDTO_1 DoctorDTO_1 { get; set; }
} 

public class AppointmentDTO_3 : AppointmentDTO_2
{
    public IEnumerable<saveExaminationDTO1> examinationDTO1s { get; set; }
    public IEnumerable<PrescriptionDTO2> prescriptionDTO2s { get; set; }

}
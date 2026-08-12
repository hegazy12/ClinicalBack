using ServiceLayer.Doctor.DTO;
using ServiceLayer.Patient.DTO;

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
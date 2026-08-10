using ServiceLayer.Doctor.DTO;
using ServiceLayer.Patient.DTO;

namespace ServiceLayer.Appointment.DTO;

public class AppointmentDTO_0
{
    public Guid DoctorID { get; set; }
    public Guid PatientID { get; set; }
    public DateOnly AppointmentDate { get; set; }
    public string Status { get; set; } = "Pending"; 
    public string? Notes { get; set; }
    public double Deposit {get; set;}
}

public static partial class AdHocMapper
{ 

    public static AppointmentDTO_1 ToAppointmentDTO_1(this Domain.Models.Appointment appointment)
    {
        if (appointment == null) return null;
       var i = new AppointmentDTO_1
        {
            Id = appointment.Id,
            DoctorID = appointment.DoctorId,
            PatientID = appointment.PatientId,
            AppointmentDate = appointment.AppointmentDate,
            Status = appointment.Status,
            Notes = appointment.Notes,
            Deposit = appointment.Deposit ,
            DoctorSpecialization = (appointment.Doctor != null)?  appointment.Doctor.Specialization : null,
            PatientFirstName     = (appointment.Patient != null)? appointment.Patient.FirstName     : null,
            PatientLastName      = (appointment.Patient != null)? appointment.Patient.LastName      : null
        };
        return i;
    }

    public static Domain.Models.Appointment ToAppointment(this AppointmentDTO_1 appointmentDTO)
    {
        if (appointmentDTO == null) return null;
        return new Domain.Models.Appointment
        {
            Id = appointmentDTO.Id,
            DoctorId = appointmentDTO.DoctorID,
            PatientId = appointmentDTO.PatientID,
            AppointmentDate = appointmentDTO.AppointmentDate,
            Status = appointmentDTO.Status,
            Notes = appointmentDTO.Notes,
            Deposit = appointmentDTO.Deposit
        };
    }

    public static AppointmentDTO_2 ToAppointmentDTO_2(this Domain.Models.Appointment appointment)
    {
        if (appointment == null) return null;
        return new AppointmentDTO_2
        {
            Id = appointment.Id,
            DoctorID = appointment.DoctorId,
            PatientID = appointment.PatientId,
            AppointmentDate = appointment.AppointmentDate,
            Status = appointment.Status,
            Notes = appointment.Notes,
            Deposit = appointment.Deposit,
            DoctorSpecialization = (appointment.Doctor  != null) ? appointment.Doctor.Specialization : null,
            PatientFirstName     = (appointment.Patient != null) ? appointment.Patient.FirstName : null,
            PatientLastName      = (appointment.Patient != null) ? appointment.Patient.LastName : null,
            DoctorDTO_1          = (appointment.Doctor  != null) ? appointment.Doctor.ToDoctorDTO_1() : null,
            PatientDTO_1         = (appointment.Patient != null) ? appointment.Patient.ToPatientDTO_1() : null
        };
    }
}
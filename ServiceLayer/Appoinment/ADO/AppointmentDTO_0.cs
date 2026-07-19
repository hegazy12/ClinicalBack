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

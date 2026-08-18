
using ServiceLayer.Appointment.DTO;
using Domain.Response;
namespace ServiceLayer.Appointment;
public interface IAppointmentService
{
    public Task<GeneralResponse<AppointmentDTO_1>>  Creat(AppointmentDTO_0 patientDTO_0 , Guid Createby);
    public Task<GeneralResponse<List<AppointmentDTO_1>>> GetByCreatby(Guid Createby);
    public Task<GeneralResponse<List<AppointmentDTO_1>>> GetByDoctor(Guid DoctorId);
    public Task<GeneralResponse<List<AppointmentDTO_1>>> GetByPatient(Guid PatientId);
    public Task<GeneralResponse<AppointmentDTO_2>> GetAllInfo(Guid AppointmentId);
    public Task<GeneralResponse<List<AppointmentDTO_1>>> GetAllAppointmentsIsCompleted(Guid PatientId);
    public Task<GeneralResponse<AppointmentDTO_3>> GetHistoryAppointment(Guid AppointmentId);
    public Task<GeneralResponse<int>> makeItComplete(Guid AppointmentId);
}

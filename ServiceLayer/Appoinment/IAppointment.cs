using ServiceLayer.Response;
using ServiceLayer.Appointment.DTO;
namespace ServiceLayer.Appointment;
public interface IAppointment
{
    public Task<GeneralResponse<AppointmentDTO_0>> CreatAppointment(AppointmentDTO_0 patientDTO_0 , Guid Createby);
}

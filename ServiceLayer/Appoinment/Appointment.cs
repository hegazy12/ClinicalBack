using ServiceLayer.Response;
using ServiceLayer.Appointment.DTO;
using Domain.IUnitOfWork;
namespace ServiceLayer.Appointment;

public class Appointment : IAppointment
{
    public IUnitOfWork unitOfWork;

    public Appointment(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<GeneralResponse<AppointmentDTO_0>> CreatAppointment(AppointmentDTO_0 AppointmentDTO_0 , Guid Createby)
    { 
        return new GeneralResponse<AppointmentDTO_0>(){Success = true};
    }
}

using ServiceLayer.Response;
using ServiceLayer.Appointment.DTO;
using Domain.IUnitOfWork;
namespace ServiceLayer.Appointment;

public class AppointmentService : IAppointmentService
{
    public IUnitOfWork unitOfWork;

    public AppointmentService(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<GeneralResponse<AppointmentDTO_0>> CreatAppointment(AppointmentDTO_0 DTO_0 , Guid Createby)
    { 
       var Model =  new Domain.Models.Appointment(){
        AppointmentDate = DTO_0.AppointmentDate ,
        DoctorId = DTO_0.DoctorID ,
        PatientId = DTO_0.PatientID,
        Deposit = DTO_0.Deposit,
        Status = DTO_0.Status,
        Notes = DTO_0.Notes};
        Model.Create(Createby);

        unitOfWork.appoinmentRepository.Add(Model);
        await unitOfWork.SaveChangesAsync();
        
        return new GeneralResponse<AppointmentDTO_0>(){Success = true};
    }
}

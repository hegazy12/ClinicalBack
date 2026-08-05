using ServiceLayer.Appointment.DTO;
using Domain.IUnitOfWork;
using Domain.Response;
namespace ServiceLayer.Appointment;

public class AppointmentService //: IAppointmentService
{
    public IUnitOfWork unitOfWork;

    public AppointmentService(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<GeneralResponse<AppointmentDTO_0>> Creat(AppointmentDTO_0 DTO_0 , Guid Createby)
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
        
        return new GeneralResponse<AppointmentDTO_0>();
    }

    //public async Task<GeneralResponse<List<AppointmentDTO_1>>> GetByCreatby(Guid Createby);
    //public async Task<GeneralResponse<List<AppointmentDTO_1>>> GetByDoctor(Guid DoctorId);
    //public async Task<GeneralResponse<List<AppointmentDTO_1>>> GetByPatient(Guid PatientId);
}

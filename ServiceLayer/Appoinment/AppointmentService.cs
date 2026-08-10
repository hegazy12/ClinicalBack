using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.Appointment.DTO;

namespace ServiceLayer.Appointment;

public class AppointmentService : IAppointmentService
{
    public IUnitOfWork unitOfWork;

    public AppointmentService(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<GeneralResponse<AppointmentDTO_1>> Creat(AppointmentDTO_0 DTO_0, Guid Createby)
    {
        try
        {
            var Model = new Domain.Models.Appointment()
            {
                AppointmentDate = DTO_0.AppointmentDate,
                DoctorId = DTO_0.DoctorID,
                PatientId = DTO_0.PatientID,
                Deposit = DTO_0.Deposit,
                Status = DTO_0.Status,
                Notes = DTO_0.Notes
            };

            Model.Create(Createby);

            var createdAppointment = await unitOfWork.appoinmentRepository.AddAsync(Model);
            await unitOfWork.SaveChangesAsync();
           
            return new GeneralResponse<AppointmentDTO_1>()
            {   Success = true,
                Data = createdAppointment.ToAppointmentDTO_1(),
                Message = "Appointment created successfully." };
        }
        catch (Exception ex) 
        { 
            return new GeneralResponse<AppointmentDTO_1>()
            {
                Data = null,
                Message = ex.Message,
                Success = false,
                Errors = new Dictionary<string, List<string>>()
                {
                    { "Exception", new List<string> { ex.Message } }
                },
                dateTime = DateTime.Now
            };
        }
    }

    public async Task<GeneralResponse<AppointmentDTO_2>> GetAllInfo(Guid AppointmentId)
    {
        var appointment = await unitOfWork.appoinmentRepository.FindAsync(m => m.Id == AppointmentId, new string [] { "Patient", "Doctor" });
        if (appointment != null)
        {
            return new GeneralResponse<AppointmentDTO_2>()
            {
                Success = true,
                Data = appointment.ToAppointmentDTO_2(),
                Message = "Appointments retrieved successfully",
                Errors =null,
                dateTime = DateTime.Now
            };
        }
        else
        {
            return new GeneralResponse<AppointmentDTO_2>()
            {
                Success = false,
                Data = null,
                Message = "No appointments found for the given doctor ID.",
                Errors = new Dictionary<string, List<string>>()
                {
                    { "NotFound", new List<string> { "No appointments found for the given doctor ID." } }
                },
                dateTime = DateTime.Now
            };
        }
        throw new NotImplementedException();
    }

    public async Task<GeneralResponse<List<AppointmentDTO_1>>> GetByCreatby(Guid Createby)
    {
        return new GeneralResponse<List<AppointmentDTO_1>>();
    }
    
    public async Task<GeneralResponse<List<AppointmentDTO_1>>> GetByDoctor(Guid DoctorId)
    {
        var user = unitOfWork.AppUserRepository.Find(m=> m.Id == Convert.ToString(DoctorId));
        var id = unitOfWork.doctorRepository.Find(m => m.ApplicationUser.Id == user.Id).Id;        

        var appointments = await unitOfWork.appoinmentRepository.GetByDoctorId(id);

        if (appointments == null)
        {
            return new GeneralResponse<List<AppointmentDTO_1>>()
            {
                Success = false,
                Data = null,
                Message = "No appointments found for the given doctor ID.",
                Errors = new Dictionary<string, List<string>>()
                {
                    { "NotFound", new List<string> { "No appointments found for the given doctor ID." } }
                },
                dateTime = DateTime.Now
            };
        }

        List<AppointmentDTO_1> appointmentDTO_1s = appointments.Select(a => a.ToAppointmentDTO_1()).ToList();

        return new GeneralResponse<List<AppointmentDTO_1>>()
        {
            Success = true,
            Message = "Appointments retrieved successfully.",
            dateTime = DateTime.Now,
            Data = appointmentDTO_1s
        };
    }

    public async Task<GeneralResponse<List<AppointmentDTO_1>>> GetByPatient(Guid PatientId)
    {
        var appointments = await  unitOfWork.appoinmentRepository.GetByPatientId(PatientId);
        
        if ( appointments == null )
        {
            return new GeneralResponse<List<AppointmentDTO_1>>()
            {
                Success = false,
                Data = null,
                Message = "No appointments found for the given patient ID.",
                Errors = new Dictionary<string, List<string>>()
                {
                    { "NotFound", new List<string> { "No appointments found for the given patient ID." } }
                },
                dateTime = DateTime.Now
            };
        }

        List<AppointmentDTO_1> appointmentDTO_1s = appointments.Select(a => a.ToAppointmentDTO_1()).ToList();

        return new GeneralResponse<List<AppointmentDTO_1>>() { 
            Success = true,
            Message = "Appointments retrieved successfully.",
            dateTime = DateTime.Now,
            Data = appointmentDTO_1s };
    }

   
}



using Domain.Models;

namespace Domain.IRepository;

public interface IAppoinmentRepository : IBaseRepository<Appointment>
{
    public  Task<List<Appointment>> GetByPatientId(Guid PatientId);
    public  Task<List<Appointment>> GetByDoctorId(Guid DoctorId);
    public  Task<List<Appointment>> GetByCreatby(Guid PatientId);
    public Task<List<Appointment>> GetByPatientIdIsCompleted(Guid PatientId);
}

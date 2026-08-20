using Domain.Models;
using Domain.IRepository;

namespace DatabaseLayer.Repository;

public class AppoinmentRepository : BaseRepository<Appointment>, IAppoinmentRepository
{
  
    public AppoinmentRepository(AppDbContext context) : base(context){}
    
    public  async Task<List<Appointment>> GetByPatientId(Guid PatientId)
    {
        var x = await FindAllAsync(s => s.PatientId == PatientId && s.Status != "Completed", new string[] { "Patient", "Doctor" });
            x = x.OrderByDescending(m=> m.AppointmentDate);
        return x.ToList();
    }


    public async Task<List<Appointment>> GetByDoctorId(Guid DoctorId)
    {
        var x = await FindAllAsync(s => s.DoctorId == DoctorId && s.Status == "Pending", new string[] { "Patient", "Doctor" });
        x = x.OrderByDescending(m=> m.AppointmentDate);
        return x.ToList();
    }


    public async  Task<List<Appointment>> GetByCreatby(Guid CreatedBy)
    {
        var x = await FindAllAsync(s => s.CreatedBy == Convert.ToString(CreatedBy), new string[] { "Patient", "Doctor" });
            x = x.OrderByDescending(m=> m.AppointmentDate);
        return x.ToList();
    }

    public async Task<List<Appointment>> GetByPatientIdIsCompleted(Guid PatientId)
    {
        var x = await FindAllAsync(s => s.PatientId == PatientId && s.Status == "Completed", new string[] { "Patient", "Doctor" });
        x = x.OrderByDescending(m => m.AppointmentDate);
        return x.ToList();
    }
    
}

using Domain.Models;
using Domain.IRepository;

namespace DatabaseLayer.Repository;

public class AppoinmentRepository : BaseRepository<Appointment>, IAppoinmentRepository
{
  
    public AppoinmentRepository(AppDbContext _context) : base(context)
    {
      
    }
    
    public  async Task<List<Appointment>> GetByPatientId(Guid PatientId)
    {
        var x = await FindAllAsync(s => s.PatientId == PatientId);
        return x.ToList();
    }


    public async Task<List<Appointment>> GetByDoctorId(Guid DoctorId)
    {
        var x = await FindAllAsync(s => s.DoctorId == DoctorId);
        return x.ToList();
    }


    public async  Task<List<Appointment>> GetByCreatby(Guid CreatedBy)
    {
        var x = await FindAllAsync(s => s.CreatedBy == CreatedBy);
        return x.ToList();
    }

}

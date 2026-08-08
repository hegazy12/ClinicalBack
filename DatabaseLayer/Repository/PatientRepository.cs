using DatabaseLayer;
using Domain.Models;
using Domain.IRepository;

namespace DatabaseLayer.Repository;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Patient> GetByIdAsync(Guid id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public async Task<IEnumerable<Patient>> GetPatientsByCreateByAsync(Guid createBy)
    {
        return await FindAllAsync(p => p.CreatedBy == createBy);
    }

    public async Task<IEnumerable<Patient>> GetPatientsNew()
    {
        return await FindAllAsync(p => p.CreatedAt >= DateTime.UtcNow.AddDays(-7),30,0);
    }
}
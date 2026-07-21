using DatabaseLayer;
using Domain.Models;
using Domain.IRepository;

namespace DatabaseLayer.Repository;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context)
    {
    }
}
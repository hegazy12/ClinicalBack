using Domain.IRepository;
using Domain.Models;

namespace DatabaseLayer.Repository;

public class AppoinmentRepository : BaseRepository<Appointment>, IAppoinmentRepository
{
    
    public AppoinmentRepository(AppDbContext context) : base(context)
    {
        
    }
}

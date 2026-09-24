using Domain.IRepository;
using Domain.Models;

namespace DatabaseLayer.Repository
{
    public class saveServiceRepository : BaseRepository<saveService>, IsaveServiceRepository
    {
        public saveServiceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsCreatBefor(saveService x)
        {
            var S = await FindAllAsync(m => m.AppointmentId == x.AppointmentId && m.ServiceId == x.ServiceId && !m.IsDeleted);
            return S.Any();
        }
    }
}

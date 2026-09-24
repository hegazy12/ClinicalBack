using Domain.IRepository;
using Domain.Models;

namespace DatabaseLayer.Repository
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsCreatBefor(Service x)
        {
            var S = await FindAllAsync(m => m.name == x.name && !m.IsDeleted);
            return S.Any();
        }
    }
}

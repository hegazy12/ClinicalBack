using Domain.IUnitOfWork;
using Domain.IRepository;

namespace DatabaseLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        
        public IApplicationUserRepository AppUserRepository { get; private set; }
        public UnitOfWork(AppDbContext context , IApplicationUserRepository applicationUserRepository)
        {
            _context = context;
            AppUserRepository = applicationUserRepository;
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

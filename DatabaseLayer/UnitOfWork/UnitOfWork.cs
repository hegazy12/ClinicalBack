using Domain.IUnitOfWork;
using Domain.IRepository;

namespace DatabaseLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        
        public IApplicationUserRepository AppUserRepository { get; private set; }
        public IBaseRepository<Domain.Models.Drug> DrugRepository { get; private set; }
        public UnitOfWork(AppDbContext context , IApplicationUserRepository applicationUserRepository, IBaseRepository<Domain.Models.Drug> drugRepository)
        {
            _context = context;
            AppUserRepository = applicationUserRepository;
            DrugRepository = drugRepository;
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

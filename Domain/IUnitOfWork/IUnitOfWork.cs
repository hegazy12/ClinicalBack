
using Domain.IRepository;
namespace Domain.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        public IApplicationUserRepository AppUserRepository { get; }
        public IBaseRepository<Domain.Models.Drug> DrugRepository { get; }
        Task<int> SaveChangesAsync();

    }
}

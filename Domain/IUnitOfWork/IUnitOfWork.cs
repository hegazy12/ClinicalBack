
using Domain.IRepository;
namespace Domain.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        public IApplicationUserRepository AppUserRepository { get; }
        public IPatientRepository patientRepository {get;}
        public IBaseRepository<Domain.Models.Drug> DrugRepository { get; }
        public IAppoinmentRepository appoinmentRepository {get;}
        Task<int> SaveChangesAsync();

    }
}

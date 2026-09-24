using Domain.Models;

namespace Domain.IRepository
{
    public interface IServiceRepository : IBaseRepository<Service>
    {
        public Task<bool> IsCreatBefor(Service x);
    }
}

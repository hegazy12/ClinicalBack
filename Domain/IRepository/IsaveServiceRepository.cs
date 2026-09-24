using Domain.Models;

namespace Domain.IRepository
{
    public interface IsaveServiceRepository : IBaseRepository<saveService>
    {
        public Task<bool> IsCreatBefor(saveService x);
    }
}

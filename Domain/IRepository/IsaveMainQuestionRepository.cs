using Domain.Models;

namespace Domain.IRepository
{
    public interface IsaveMainQuestionRepository : IBaseRepository<saveMainQuestion>
    {
        public Task<bool> IsCreatBefor(saveMainQuestion x);
    }
}

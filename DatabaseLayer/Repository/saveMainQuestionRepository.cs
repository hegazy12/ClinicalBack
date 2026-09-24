using Domain.IRepository;
using Domain.Models;

namespace DatabaseLayer.Repository
{
    public class saveMainQuestionRepository : BaseRepository<saveMainQuestion>, IsaveMainQuestionRepository
    {
        public saveMainQuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsCreatBefor(saveMainQuestion x)
        {
            var S = await FindAllAsync(m => m.PatientId == x.PatientId && m.MainQuestionId == x.MainQuestionId && !m.IsDeleted);
            return S.Any();
        }
    }
}

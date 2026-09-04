using Domain.IRepository;
using Domain.Models;


namespace DatabaseLayer.Repository
{
    public class vitalSignsRepository : BaseRepository<VitalSign>, IvitalSignsRepository
    {

        public vitalSignsRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<VitalSign>> GetSearchTearmAsync(string SearchTearm)
        {
            return await FindAllAsync(m => m.name.Contains(SearchTearm) && !m.IsDeleted, new string[] { "VitalSignMaster" });
        }
    }
}

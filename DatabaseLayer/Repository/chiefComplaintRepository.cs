using Domain.IRepository;
using Domain.Models;


namespace DatabaseLayer.Repository
{
    public class chiefComplaintRepository : BaseRepository<chiefComplaint>, IChiefComplaintRepository
    {
        public chiefComplaintRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsCreatBefor(chiefComplaint x)
        {
            var S = await FindAllAsync(m => m.AppointmentId == x.AppointmentId && m.Text == x.Text && !m.IsDeleted);
            if (S.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class saveVitalSignRepository : BaseRepository<saveVitalSign>, IsaveVitalSignRepository
    {
        public saveVitalSignRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Boolean> IsCreatBefor(saveVitalSign x)
        {
            var s = await FindAllAsync(m=> m.value == x.value && m.AppointmentId == x.AppointmentId && m.VitalSignId == x.VitalSignId);
            if(s.Count() > 0)
            {
                return true;
            }else 
            {
                return false;
            }
        }
    }
}

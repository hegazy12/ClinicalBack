using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IsaveVitalSignRepository : IBaseRepository<saveVitalSign>
    {
        public Task<Boolean> IsCreatBefor(saveVitalSign x);
        //public Task<Boolean> Deleted(Guid x);
    }
}
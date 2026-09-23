using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IChiefComplaintRepository : IBaseRepository<chiefComplaint>
    {
        public Task<bool> IsCreatBefor(chiefComplaint x);
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IvitalSignsRepository : IBaseRepository<VitalSign>
    {
        public Task<IEnumerable<VitalSign>> GetSearchTearmAsync(string SearchTearm);
    }
}
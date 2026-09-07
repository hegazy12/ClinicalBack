using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IvitalSignsRepository : IBaseRepository<VitalSign>
    {
        public Task<IEnumerable<VitalSign>> GetSearchTearmAsync(string SearchTearm);
        public Task<saveVitalSign> save(saveVitalSign saveVitalSign);
        public Task<IList<saveVitalSign>> GetByAppointmentIdAsync(Guid Id);
    }
}
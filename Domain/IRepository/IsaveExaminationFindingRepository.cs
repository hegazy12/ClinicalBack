using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IsaveExaminationFindingRepository : IBaseRepository<saveExaminationFinding>
    {
        public Task<Boolean> IsCreatBefor(saveExaminationFinding x);
        public Task<IEnumerable<saveExaminationFinding>> GetByAppointmentIdAsync(Guid appointmentId);
    }
}

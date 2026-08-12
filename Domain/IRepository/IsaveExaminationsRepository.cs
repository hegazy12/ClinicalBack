using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IsaveExaminationsRepository : IBaseRepository<saveExamination>
    {
        public Task<saveExamination> Save(saveExamination x);
        public Task<IEnumerable<saveExamination>> GetbyAppoitmentID(Guid id);
        public Task<IEnumerable<saveExamination>> GetbyIdes(List<Guid> ids);
        public Task<IEnumerable<saveExamination>> GetbyAppoitmentIDAsync(Guid appointmentId);
    }
}

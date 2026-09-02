using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IDiagnosRepository : IBaseRepository<Diagnos>
    {
        public Task<IEnumerable<Diagnos>> GetByAppointmentIdAsync(Guid appointmentId);
    }
}

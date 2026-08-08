using Domain.Models;
using Domain.Response;

namespace Domain.IRepository
{
    public interface IPrescriptionRepository : IBaseRepository<Prescription>
    {
        public Task<IEnumerable<Prescription>> GetByAppointmentIdAsync(Guid appointmentId);
        public Task<IEnumerable<Prescription>> GetByDrugIdAsync(Guid drugId);
        public Task<Prescription> CreateAsync(Prescription prescription);
    }
}

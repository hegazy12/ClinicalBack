using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.IRepository;
using Domain.Response;

namespace DatabaseLayer.Repository
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Prescription> CreateAsync(Prescription prescription)
        {
            await AddAsync(prescription);
            return prescription;
        }

        public Task<IEnumerable<Prescription>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prescription>> GetByDrugIdAsync(Guid drugId)
        {
            throw new NotImplementedException();
        }
    }
}

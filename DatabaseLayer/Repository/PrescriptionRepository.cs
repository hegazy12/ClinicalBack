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

        public async Task<IEnumerable<Prescription>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            var x = await FindAllAsync(m => m.AppointmentId == appointmentId, new string[] { "Drug" });

            return x;
        }

     

        public Task<IEnumerable<Prescription>> GetByDrugIdAsync(Guid drugId)
        {
            throw new NotImplementedException();
        }
    }
}

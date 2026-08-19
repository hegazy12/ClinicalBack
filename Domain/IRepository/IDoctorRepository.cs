using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        public Task<Doctor> GetDoctor(Guid id);
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization);
        public Task<Doctor> addDoctor(Doctor doctor);
        public Task<Doctor> updateDoctor(Doctor doctor);
        public Task<Doctor> deleteDoctor(Guid id);
        public Task<List<Doctor>> GetByIdsAsync(List<Guid> guids);
        public Task<ApplicationUser> GetUserByDoctorIdAsync(Guid guid);
    }
}

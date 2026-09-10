using Domain.IRepository;
using Domain.Models;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DatabaseLayer.Repository
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {
           _context = context;
        }

        public async Task<List<Doctor>> GetByIdsAsync(List<Guid> guids)
        {
            if (guids == null || !guids.Any())
            {
                return new List<Doctor>();
            }

            
            var stringGuids = guids.Select(g => g.ToString()).ToList();

            var x = await FindAllAsync(m => stringGuids.Contains(m.UserId) && !m.IsDeleted, new string[] { "ApplicationUser" } );
            return x.ToList();
        }

        public async Task<ApplicationUser> GetUserByDoctorIdAsync(Guid guid)
        {
            var x = await FindAllAsync(m => m.Id == guid && !m.IsDeleted, new string[] { "ApplicationUser" });
            //string sql = x.ToQueryString();
            //Console.WriteLine(sql);
            return x.First().ApplicationUser;
        }

        public async Task<Doctor> addDoctor(Doctor doctor)
        {
            var doctor1 = await AddAsync(doctor);
            return doctor1;
        }

        public async Task<Doctor> deleteDoctor(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> GetDoctor(Guid id)
        {
            var doctor = await GetByIdAsync(id);
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await FindAllAsync(m=> false== false && !m.IsDeleted, new string[] { "ApplicationUser" });
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization)
        {
            return await FindAllAsync(d=> d.Specialization == specialization && !d.IsDeleted);
        }

        public Task<Doctor> updateDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Specialization>> GetSpecializationsAsync()
        {
            return await _context.specializationNames.ToListAsync();
        }
    }
}

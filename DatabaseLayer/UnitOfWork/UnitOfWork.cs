using Domain.IUnitOfWork;
using Domain.IRepository;

namespace DatabaseLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        
        public IApplicationUserRepository AppUserRepository { get; private set; }
        public IDrugRepository DrugRepository { get; private set; }
        public IPatientRepository patientRepository {get; private set;}
        public IAppoinmentRepository appoinmentRepository {get; private set;}
        public IDoctorRepository doctorRepository {get; private set;}
        public IPrescriptionRepository prescriptionRepository { get; private set; }

        public UnitOfWork(AppDbContext context , 
                        IApplicationUserRepository applicationUserRepository,
                        IDrugRepository drugRepository,
                        IPatientRepository _patientRepository,
                        IAppoinmentRepository _appoinmentRepository,
                        IDoctorRepository _doctorRepository,
                        IPrescriptionRepository _prescriptionRepository)
                        {
                                _context = context;
                                AppUserRepository = applicationUserRepository;
                                DrugRepository = drugRepository;
                                patientRepository = _patientRepository;
                                appoinmentRepository = _appoinmentRepository;
                                doctorRepository = _doctorRepository;
                                prescriptionRepository = _prescriptionRepository;
                        }
        
        public void Dispose()
        {
           _context.Dispose();
        }
        public void Dispose(int i)
        {
            if (i == 1) {
                _context.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
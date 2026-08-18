using DatabaseLayer.Repository;
using Domain.IRepository;
using Domain.IUnitOfWork;

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
        public ImedicalExaminationsRepository medicalExaminationsRepository {get; private set;}
        public IsaveExaminationsRepository saveExaminationsRepository {get; private set;}
        public IClassificationExaminationsRepository ClassificationExaminationsRepository { get; private set;}
        public IvitalSignsRepository vitalSignsRepository {get; private set;}
        public UnitOfWork(AppDbContext context , 
                        IApplicationUserRepository applicationUserRepository,
                        IDrugRepository drugRepository,
                        IPatientRepository _patientRepository,
                        IAppoinmentRepository _appoinmentRepository,
                        IDoctorRepository _doctorRepository,
                        IPrescriptionRepository _prescriptionRepository,
                        ImedicalExaminationsRepository _medicalExaminationsRepository,
                        IsaveExaminationsRepository _saveExaminationsRepository,
                        IClassificationExaminationsRepository _ClassificationExaminationsRepository,
                        IvitalSignsRepository _vitalSignsRepository)
                        {
                                _context = context;
                                AppUserRepository = applicationUserRepository;
                                DrugRepository = drugRepository;
                                patientRepository = _patientRepository;
                                appoinmentRepository = _appoinmentRepository;
                                doctorRepository = _doctorRepository;
                                prescriptionRepository = _prescriptionRepository;
                                medicalExaminationsRepository = _medicalExaminationsRepository;
                                saveExaminationsRepository = _saveExaminationsRepository;
                                ClassificationExaminationsRepository = _ClassificationExaminationsRepository;
                                vitalSignsRepository = _vitalSignsRepository; 
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
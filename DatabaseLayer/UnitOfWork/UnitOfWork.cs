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
        public IDiagnosMasterRepository diagnosMasterRepository { get; private set; }
        public IDiagnosRepository diagnosRepository {get; private set;}
        public IExaminationPhotoRepository examinationPhotoRepository { get; private set; }
        public IsaveVitalSignRepository saveVitalSignRepository {get; private set;}
        public IsaveQuestionRepository saveQuestionRepository { get; }
        public IQuestionRepository questionRepository { get; }
        public ISheetRepository sheetRepository { get; }

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
                        IvitalSignsRepository _vitalSignsRepository,
                        IDiagnosMasterRepository _diagnosMasterRepository,
                        IDiagnosRepository _diagnosRepository,
                        IExaminationPhotoRepository _examinationPhotoRepository,
                        IsaveVitalSignRepository _saveVitalSignRepository,
                        IsaveQuestionRepository _saveQuestionRepository,
                        IQuestionRepository _questionRepository,
                        ISheetRepository _sheetRepository)
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
                                diagnosMasterRepository = _diagnosMasterRepository;
                                diagnosRepository = _diagnosRepository;
                                examinationPhotoRepository = _examinationPhotoRepository;
                                saveVitalSignRepository = _saveVitalSignRepository;
                                saveQuestionRepository = _saveQuestionRepository;
                                questionRepository = _questionRepository;
                                sheetRepository = _sheetRepository;
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
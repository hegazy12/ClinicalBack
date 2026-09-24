
using Domain.IRepository;
namespace Domain.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        public IApplicationUserRepository AppUserRepository { get; }
        public IPatientRepository patientRepository {get;}
        public IDrugRepository DrugRepository { get; }
        public IAppoinmentRepository appoinmentRepository {get;}
        public IDoctorRepository doctorRepository { get; }
        public IPrescriptionRepository prescriptionRepository { get; }
        public ImedicalExaminationsRepository medicalExaminationsRepository { get; }
        public IsaveExaminationsRepository saveExaminationsRepository { get; }
        public IClassificationExaminationsRepository ClassificationExaminationsRepository{ get; }
        public IvitalSignsRepository vitalSignsRepository {  get; }
        public IDiagnosMasterRepository diagnosMasterRepository { get;}
        public IDiagnosRepository diagnosRepository { get; }
        public IExaminationPhotoRepository examinationPhotoRepository { get; }
        public IsaveVitalSignRepository saveVitalSignRepository {  get; }
        public IsaveQuestionRepository saveQuestionRepository { get; }
        public IQuestionRepository questionRepository { get; }
        public ISheetRepository sheetRepository { get; }
        public IExaminationFindingRepository examinationFindingRepository { get; }
        public IsaveExaminationFindingRepository saveExaminationFindingRepository  { get; }
        public IChiefComplaintRepository chiefComplaintRepository { get; }
        public IMainQuestionRepository mainQuestionRepository { get; }
        public IsaveMainQuestionRepository saveMainQuestionRepository { get; }
        public IServiceRepository serviceRepository { get; }
        public IsaveServiceRepository saveServiceRepository { get; }
        Task<int> SaveChangesAsync();

    }
}

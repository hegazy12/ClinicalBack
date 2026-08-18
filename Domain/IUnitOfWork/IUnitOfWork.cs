
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
        Task<int> SaveChangesAsync();

    }
}

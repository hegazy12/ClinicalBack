using ServiceLayer.SmedicalExaminations.DTO;
using Domain.Response;
using Domain.DTO;

namespace ServiceLayer.SmedicalExaminations
{
    public interface ImedicalExaminations
    {
        public Task<GeneralResponse<IEnumerable<medicalExaminationsDTO1>>> GetbySearchTerm(string SearchTerm);
        public Task<GeneralResponse<saveExaminationDTO1>> saveExaminationAsync(saveExaminationDTO dTO , Guid Createby);
        public Task<GeneralResponse<IEnumerable<saveExaminationDTO1>>> GetByAppointmentIdAsync(Guid Appointment);
        public Task<GeneralResponse<string>> uploadPhoto(Guid IdExamination, Guid CreateBy, UploadPhotoRequest request, string uploadsRootPath);
        public Task<GeneralResponse<saveExaminationDTO1>> Delete(Guid id, Guid userid);
        public Task<GeneralResponse<saveExaminationDTO1>> GetByIdFull(Guid id);
        public Task<GeneralResponse<IEnumerable<saveExaminationPhotosDTO1>>> GetExaminationsByIdPhotos(Guid Id);
    }
}
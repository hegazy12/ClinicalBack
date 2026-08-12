using ServiceLayer.SmedicalExaminations.DTO;

using Domain.Response;

namespace ServiceLayer.SmedicalExaminations
{
    public interface ImedicalExaminations
    {
        public Task<GeneralResponse<IEnumerable<medicalExaminationsDTO1>>> GetbySearchTerm(string SearchTerm);
        public Task<GeneralResponse<saveExaminationDTO1>> saveExaminationAsync(saveExaminationDTO dTO , Guid Createby);
        public Task<GeneralResponse<IEnumerable<saveExaminationDTO1>>> GetByAppointmentIdAsync(Guid Appointment);
    }
}
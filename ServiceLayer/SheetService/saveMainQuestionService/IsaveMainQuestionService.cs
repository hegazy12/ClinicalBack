using Domain.Response;
using ServiceLayer.SheetService.saveMainQuestionService.DTO;

namespace ServiceLayer.SheetService.saveMainQuestionService
{
    public interface IsaveMainQuestionService
    {
        public Task<GeneralResponse<IEnumerable<saveMainQuestionDTO1>>> AddList(IEnumerable<saveMainQuestionDTO> DTOs, Guid userId);
        public Task<GeneralResponse<Boolean>> Delete(Guid saveMainQuestionID, Guid userId);
        public Task<GeneralResponse<IEnumerable<saveMainQuestionDTO2>>> GetByPatientID(Guid PatientID);
    }
}

using Domain.Response;
using ServiceLayer.SheetService.DTO;
using ServiceLayer.SheetService.saveQuestionService.saveQtionDTO;


namespace ServiceLayer.SheetService.saveQuestionService
{
    public interface IsaveQuestionService
    {
        public Task<GeneralResponse<Boolean>> Delete(Guid saveQuestionID, Guid userId);
        public Task<GeneralResponse<saveQuestionDTO1>> Add(saveQuestionDTO DTO, Guid userId);
        public Task<GeneralResponse<IEnumerable<saveQuestionDTO1>>> AddList(IEnumerable<saveQuestionDTO> DTOs, Guid userId);
        public Task<GeneralResponse<IEnumerable<saveQuestionDTO2>>> GetBySheetID(Guid SheetId);
        public Task<GeneralResponse<IEnumerable<SheetDTO1>>> GetSheetsInAppointmentSaved(Guid Appointment);
        public Task<GeneralResponse<IEnumerable<saveQuestionDTO2>>> GetAllQuestionInAppointmentSaved(Guid Appointment);

        //public Task<GeneralResponse<Boolean> Delete();
    }
}

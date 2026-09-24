using Domain.Response;
using ServiceLayer.SheetService.MainQuestionService.DTO;

namespace ServiceLayer.SheetService.MainQuestionService
{
    public interface IMainQuestionService
    {
        public Task<GeneralResponse<MainQuestionDTO1>> Add(MainQuestionDTO DTO, Guid userId);
        public Task<GeneralResponse<IEnumerable<MainQuestionDTO1>>> GetAll();
        public Task<GeneralResponse<MainQuestionDTO1>> GetById(Guid mainQuestionId);
        public Task<GeneralResponse<Boolean>> Delete(Guid mainQuestionId, Guid userId);
    }
}

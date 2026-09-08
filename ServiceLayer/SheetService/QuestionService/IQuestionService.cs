using Domain.Response;
using ServiceLayer.SheetService.QuestionService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.SheetService.QuestionService
{
    public interface IQuestionService
    {
        public Task<GeneralResponse<QuestionDTO1>> Add(QuestionDTO DTO , Guid userId);
        public Task<GeneralResponse<List<QuestionDTO1>>> GetbySheetId(Guid sheetId);
        public Task<GeneralResponse<List<QuestionDTO1>>> GetbyDepndOnQuestionID(Guid questionId);
        public Task<GeneralResponse<Boolean>> Delete(Guid QuestionID, Guid userId);

    }
}

using Domain.Response;
using ServiceLayer.SheetService.QuestionService.DTO;
using ServiceLayer.SheetService.saveQuestionService.saveQtionDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.SheetService.saveQuestionService
{
    public interface IsaveQuestionService
    {
        //public Task<GeneralResponse<Boolean>> Delete(Guid QuestionID, Guid userId);
        public Task<GeneralResponse<saveQuestionDTO1>> Add(saveQuestionDTO DTO, Guid userId);
    }
}

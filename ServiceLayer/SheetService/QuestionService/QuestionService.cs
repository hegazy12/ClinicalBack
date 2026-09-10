using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.SheetService.QuestionService.DTO;

namespace ServiceLayer.SheetService.QuestionService
{
    public class QuestionService : IQuestionService
    {
        public IUnitOfWork unitOfWork;
        public QuestionService(IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GeneralResponse<QuestionDTO1>> Add(QuestionDTO DTO, Guid userId)
        {
            Question question = new Question()
            {
              QuestionBody   = DTO.QuestionBody,
              listValues = DTO.listValues,
              maxValue = DTO.maxValue,
              QuestionDependId = DTO.QuestionDependId,
              dataTypeName = DTO.dataTypeName,
              SheetId = DTO.SheetId,
              description = DTO.description,
              minValue = DTO.minValue,
              requeried = DTO.requeried,
              
            };

            question.Create(userId);
            var IsCreatBefor = await unitOfWork.questionRepository.IsCreatBefor(question);
            
            if (IsCreatBefor)
            {
                return new GeneralResponse<QuestionDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "you are save this item befor",
                    Success = false
                };
            }
            else
            {
                await unitOfWork.questionRepository.AddAsync(question);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<QuestionDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "The data was successfully completed",
                    Success = true
                };
            }

        }

        public async Task<GeneralResponse<Boolean>> Delete(Guid QuestionID, Guid userId)
        {
            try
            {
                var question = unitOfWork.questionRepository.Find(m => m.Id == QuestionID && !m.IsDeleted);
                question.MarkAsDeleted(userId);
                unitOfWork.questionRepository.Update(question);
                await unitOfWork.SaveChangesAsync();

                return new GeneralResponse<bool>()
                {
                    Data = true,
                    dateTime = DateTime.Now,
                    Message = "The data was successfully completed",
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<bool>()
                {
                    Data = false,
                    dateTime = DateTime.Now,
                    Message = ex.Message,
                    Success = false,
                };
            }
        }

        public async Task<GeneralResponse<IEnumerable<QuestionDTO1>>> GetbyDepndOnQuestionID(Guid questionId)
        {
            var x = await unitOfWork.questionRepository.FindAllAsync(m => m.QuestionDependId == questionId && !m.IsDeleted);
            var m = x.Select(x => x.ToQuestionDTO1());
            return new GeneralResponse<IEnumerable<QuestionDTO1>>()
            {
                Data = (List<QuestionDTO1>)m,
                dateTime = DateTime.Now,
                Message = "The data was successfully completed",
                Success = true,
            };
        }

        public async Task<GeneralResponse<IEnumerable<QuestionDTO1>>> GetbySheetId(Guid sheetId)
        {
            var x = await unitOfWork.questionRepository.FindAllAsync(m => m.SheetId == sheetId && !m.IsDeleted);
            var m = x.Select(x => x.ToQuestionDTO1());
            return new GeneralResponse<IEnumerable<QuestionDTO1>>()
            {
                Data = m,
                dateTime = DateTime.Now,
                Message = "The data was successfully completed",
                Success = true,
            };
        }


    }
}

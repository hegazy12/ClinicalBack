using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.SheetService.saveMainQuestionService.DTO;

namespace ServiceLayer.SheetService.saveMainQuestionService
{
    public class saveMainQuestionService : IsaveMainQuestionService
    {
        public IUnitOfWork unitOfWork;
        public saveMainQuestionService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GeneralResponse<IEnumerable<saveMainQuestionDTO1>>> AddList(IEnumerable<saveMainQuestionDTO> DTOs, Guid userId)
        {
            List<saveMainQuestion> questions = new List<saveMainQuestion>();
            saveMainQuestion save;
            foreach (saveMainQuestionDTO dto in DTOs)
            {
                save = new saveMainQuestion()
                {
                    PatientId = dto.PatientId,
                    MainQuestionId = dto.MainQuestionId,
                    value = dto.value,
                    Notes = dto.Notes
                };
                save.Create(userId);

                // skip answers already saved for this patient (in the DB or earlier in this list)
                if (await unitOfWork.saveMainQuestionRepository.IsCreatBefor(save)  || questions.Any(m => m.PatientId == save.PatientId && m.MainQuestionId == save.MainQuestionId))
                {
                    continue;
                }
                questions.Add(save);
            }

            if (questions.Count == 0)
            {
                return new GeneralResponse<IEnumerable<saveMainQuestionDTO1>>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "You are save this Questions Befor",
                    Success = false
                };
            }

            await unitOfWork.saveMainQuestionRepository.AddRangeAsync(questions);
            await unitOfWork.SaveChangesAsync();
            return new GeneralResponse<IEnumerable<saveMainQuestionDTO1>>()
            {
                Data = questions.Select(m => m.TosaveMainQuestionDTO1()).ToList(),
                dateTime = DateTime.Now,
                Message = "The data was successfully completed",
                Success = true
            };
        }

        public async Task<GeneralResponse<bool>> Delete(Guid saveMainQuestionID, Guid userId)
        {
            try
            {
                var saveMainQuestion = unitOfWork.saveMainQuestionRepository.Find(m => m.Id == saveMainQuestionID && !m.IsDeleted);
                if (saveMainQuestion == null)
                {
                    return new GeneralResponse<bool>()
                    {
                        Data = false,
                        dateTime = DateTime.Now,
                        Message = "Saved question not found",
                        Success = false,
                    };
                }
                saveMainQuestion.MarkAsDeleted(userId);
                unitOfWork.saveMainQuestionRepository.Update(saveMainQuestion);
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

        public async Task<GeneralResponse<IEnumerable<saveMainQuestionDTO2>>> GetByPatientID(Guid PatientID)
        {
            var savedQuestions = await unitOfWork.saveMainQuestionRepository.FindAllAsync(m => m.PatientId == PatientID && !m.IsDeleted, new string[] { "MainQuestion" });
            var x = savedQuestions.Select(m => m.TosaveMainQuestionDTO2()).ToList();

            return new GeneralResponse<IEnumerable<saveMainQuestionDTO2>>()
            {
                Data = x,
                dateTime = DateTime.UtcNow,
                Success = true,
                Message = "The data was successfully completed"
            };
        }
    }
}

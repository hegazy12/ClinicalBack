using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.Appointment.DTO;
using ServiceLayer.SheetService.DTO;
using ServiceLayer.SheetService.QuestionService.DTO;
using ServiceLayer.SheetService.saveQuestionService.saveQtionDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.SheetService.saveQuestionService
{
    public class SaveQuestionService : IsaveQuestionService
    {
        public IUnitOfWork unitOfWork;
        public SaveQuestionService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

      

        public async Task<GeneralResponse<IEnumerable<saveQuestionDTO1>>> AddList(IEnumerable<saveQuestionDTO> DTOs, Guid userId)
        {
            
            List<saveQuestion> questions = new List<saveQuestion>();
            saveQuestion save;
            foreach (saveQuestionDTO dto in DTOs)
            {
                save =new saveQuestion() {
                        AppointmentId = dto.AppointmentId,
                        QuestionId = dto.QuestionId,
                        SheetId = dto.SheetId,
                        value = dto.value,
                        Notes = dto.Notes
                    };
                save.Create(userId);
                questions.Add(save);
            }

            await unitOfWork.saveQuestionRepository.AddRangeAsync(questions);
            await unitOfWork.SaveChangesAsync();
            return new GeneralResponse<IEnumerable<saveQuestionDTO1>>()
            {
                Data = null,
                dateTime = DateTime.Now,
                Message = "The data was successfully completed",
                Success = true
            };


        }

        public async Task<GeneralResponse<bool>> Delete(Guid saveQuestionID, Guid userId)
        {
            try
            {
                var saveQuestion = unitOfWork.saveQuestionRepository.Find(m => m.Id == saveQuestionID);
                saveQuestion.MarkAsDeleted(userId);
                unitOfWork.saveQuestionRepository.Update(saveQuestion);
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

        public async Task<GeneralResponse<IEnumerable<saveQuestionDTO2>>> GetAllQuestionInAppointmentSaved(Guid AppointmentID)
        {
            var savedQuestions = await unitOfWork.saveQuestionRepository.FindAllAsync(m => m.AppointmentId == AppointmentID && !m.IsDeleted , new string[] {"Question","Sheet" });
            var x = savedQuestions.Select(m => m.TosaveQuestionDTO2());

            return new GeneralResponse<IEnumerable<saveQuestionDTO2>>()
            {
                Data = x,
                dateTime = DateTime.UtcNow,
                Success = true,
                Message = "The data was successfully completed"
            };
        }

        public async Task<GeneralResponse<IEnumerable<saveQuestionDTO2>>> GetBySheetID(Guid SheetId)
        {
            var savedQuestions = await unitOfWork.saveQuestionRepository.FindAllAsync(m => m.SheetId == SheetId && !m.IsDeleted, new string[] { "Question", "Sheet" });
            var x = savedQuestions.Select(m => m.TosaveQuestionDTO2());

            return new GeneralResponse<IEnumerable<saveQuestionDTO2>>()
            {
                Data = x,
                dateTime = DateTime.UtcNow,
                Success = true,
                Message = "The data was successfully completed"
            };
        }

        public Task<GeneralResponse<IEnumerable<SheetDTO1>>> GetSheetsInAppointmentSaved(Guid Appointment)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse<saveQuestionDTO1>> Add(saveQuestionDTO DTO, Guid userId)
        {
            var save = new saveQuestion()
            {
                AppointmentId = DTO.AppointmentId,
                QuestionId = DTO.QuestionId,
                value = DTO.value
            };


            save.Create(userId);

            var x = await unitOfWork.saveQuestionRepository.IsCreatBefor(save);
            if (x)
            {
                return new GeneralResponse<saveQuestionDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "You are save this Question Befor",
                    Success = false
                };
            }
            else
            {
                await unitOfWork.saveQuestionRepository.AddAsync(save);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<saveQuestionDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "The data was successfully completed",
                    Success = true
                };
            }
        }


    }
}

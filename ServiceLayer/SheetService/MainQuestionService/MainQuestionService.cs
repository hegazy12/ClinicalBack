using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.SheetService.MainQuestionService.DTO;

namespace ServiceLayer.SheetService.MainQuestionService
{
    public class MainQuestionService : IMainQuestionService
    {
        public IUnitOfWork unitOfWork;
        public MainQuestionService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GeneralResponse<MainQuestionDTO1>> Add(MainQuestionDTO DTO, Guid userId)
        {
            MainQuestion mainQuestion = new MainQuestion()
            {
                QuestionBody = DTO.QuestionBody,
                description = DTO.description,
                dataTypeName = DTO.dataTypeName,
                maxValue = DTO.maxValue,
                minValue = DTO.minValue,
                requeried = DTO.requeried,
                listValues = DTO.listValues,
                Gendar = DTO.Gendar,
                minage = DTO.minage,
                maxage = DTO.maxage,
                requer = DTO.requer,
            };

            mainQuestion.Create(userId);
            var IsCreatBefor = await unitOfWork.mainQuestionRepository.IsCreatBefor(mainQuestion);

            if (IsCreatBefor)
            {
                return new GeneralResponse<MainQuestionDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "you are save this Question befor",
                    Success = false
                };
            }
            else
            {
                await unitOfWork.mainQuestionRepository.AddAsync(mainQuestion);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<MainQuestionDTO1>()
                {
                    Data = mainQuestion.ToMainQuestionDTO1(),
                    dateTime = DateTime.Now,
                    Message = "The data was successfully saved completed",
                    Success = true
                };
            }
        }

        public async Task<GeneralResponse<Boolean>> Delete(Guid mainQuestionId, Guid userId)
        {
            try
            {
                var mainQuestion = unitOfWork.mainQuestionRepository.Find(m => m.Id == mainQuestionId && !m.IsDeleted);
                if (mainQuestion == null)
                {
                    return new GeneralResponse<bool>()
                    {
                        Data = false,
                        dateTime = DateTime.Now,
                        Message = "Question not found",
                        Success = false,
                    };
                }
                mainQuestion.MarkAsDeleted(userId);
                unitOfWork.mainQuestionRepository.Update(mainQuestion);
                await unitOfWork.SaveChangesAsync();

                return new GeneralResponse<bool>()
                {
                    Data = true,
                    dateTime = DateTime.Now,
                    Message = "The data was successfully Deleted completed",
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

        public async Task<GeneralResponse<IEnumerable<MainQuestionDTO1>>> GetAll()
        {
            var x = await unitOfWork.mainQuestionRepository.FindAllAsync(m => !m.IsDeleted);
            var m = x.Select(x => x.ToMainQuestionDTO1()).ToList();
            return new GeneralResponse<IEnumerable<MainQuestionDTO1>>()
            {
                Data = m,
                dateTime = DateTime.Now,
                Message = "The data was successfully completed",
                Success = true,
            };
        }

        public async Task<GeneralResponse<MainQuestionDTO1>> GetById(Guid mainQuestionId)
        {
            var x = await unitOfWork.mainQuestionRepository.FindAllAsync(m => m.Id == mainQuestionId && !m.IsDeleted);
            var mainQuestion = x.FirstOrDefault();
            return new GeneralResponse<MainQuestionDTO1>()
            {
                Data = mainQuestion?.ToMainQuestionDTO1(),
                dateTime = DateTime.Now,
                Message = mainQuestion == null ? "Question not found" : "The data was successfully completed",
                Success = mainQuestion != null,
            };
        }
    }
}

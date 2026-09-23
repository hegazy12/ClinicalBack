using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.ExaminationFindingService.DTO;


namespace ServiceLayer.ExaminationFindingService
{
    public class ExaminationFindingService : IExaminationFindingService
    {
        public IUnitOfWork unitOfWork;
        public ExaminationFindingService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GeneralResponse<ExaminationFindingDTO1>> Add(ExaminationFindingDTO DTO, Guid CreateBy)
        {
            ExaminationFinding examinationFinding = new ExaminationFinding()
            {
                Name = DTO.Name,
                Description = DTO.Description,
            };

            var x = await unitOfWork.examinationFindingRepository.IsCreatBefor(examinationFinding);
            if (x)
            {
                return new GeneralResponse<ExaminationFindingDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "you are save this ExaminationFinding befor",
                    Success = false
                };
            }
            else
            {
                examinationFinding.Create(CreateBy);
                unitOfWork.examinationFindingRepository.Add(examinationFinding);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<ExaminationFindingDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "you are save this ExaminationFinding ",
                    Success = true
                };

            }
        }

        public async Task<GeneralResponse<bool>> Delete(Guid ID, Guid CreateBy)
        {
            try
            {
                var examinationFinding = unitOfWork.examinationFindingRepository.Find(m => m.Id == ID);
                examinationFinding.MarkAsDeleted(CreateBy);
                unitOfWork.examinationFindingRepository.Update(examinationFinding);
                await unitOfWork.SaveChangesAsync();

                return new GeneralResponse<bool>()
                {
                    Data = true,
                    dateTime = DateTime.Now,
                    Message = "The data was deleted successfully completed",
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

        public async Task<GeneralResponse<IEnumerable<ExaminationFindingDTO1>>> GetAll()
        {
            var examinationFindings = await unitOfWork.examinationFindingRepository.FindAllAsync(m => !m.IsDeleted);
            return new GeneralResponse<IEnumerable<ExaminationFindingDTO1>>()
            {
                Data = examinationFindings.Select(M => M.ToExaminationFindingDTO1()),
                dateTime = DateTime.Now,
                Success = true,
                Message = "you are Get this ExaminationFinding successfully",

            };
        }

        public async Task<GeneralResponse<IEnumerable<ExaminationFindingDTO1>>> GetSearchTearmAsync(string SearchTearm)
        {
            var examinationFindings = await unitOfWork.examinationFindingRepository.FindAllAsync(m=> m.Name.Contains(SearchTearm) && !m.IsDeleted);
            return new GeneralResponse<IEnumerable<ExaminationFindingDTO1>>()
            {
                Data = examinationFindings.Select(M => M.ToExaminationFindingDTO1()),
                dateTime = DateTime.Now,
                Success = true,
                Message = "you are Get this ExaminationFinding successfully",

            };
        }
    }
}

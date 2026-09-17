using Domain.IUnitOfWork;
using Domain.Response;
using ServiceLayer.ExaminationFindingService.Save.DTO;


namespace ServiceLayer.ExaminationFindingService.Save
{
    public class saveExaminationFinding : IsaveExaminationFinding
    {

        public IUnitOfWork unitOfWork;
        public saveExaminationFinding(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public async Task<GeneralResponse<saveExaminationFindingDTO1>> Add(saveExaminationFindingDTO DTO, Guid CreateBy)
        {
            Domain.Models.saveExaminationFinding saveExaminationFinding = new Domain.Models.saveExaminationFinding()
            {
                AppointmentId = DTO.AppointmentId,
                ExaminationFindingId = DTO.ExaminationFindingId,
                Value = DTO.Value,
                Notes = DTO.Notes
            };

            var x = await unitOfWork.saveExaminationFindingRepository.IsCreatBefor(saveExaminationFinding);
            if (x)
            {
                return new GeneralResponse<saveExaminationFindingDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Message = "you are save this ExaminationFinding befor",
                    Success = false
                };
            }
            else
            {
                saveExaminationFinding.Create(CreateBy);
                unitOfWork.saveExaminationFindingRepository.Add(saveExaminationFinding);
                await unitOfWork.SaveChangesAsync();
                return new GeneralResponse<saveExaminationFindingDTO1>()
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
                var examinationFinding = unitOfWork.saveExaminationFindingRepository.Find(m => m.Id == ID);
                examinationFinding.MarkAsDeleted(CreateBy);
                unitOfWork.saveExaminationFindingRepository.Update(examinationFinding);
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

        public async Task<GeneralResponse<IEnumerable<saveExaminationFindingDTO2>>> GetByAppointmentIdAsync(Guid Appointment)
        {
            var x = await unitOfWork.saveExaminationFindingRepository.GetByAppointmentIdAsync(Appointment);
            return new GeneralResponse<IEnumerable<saveExaminationFindingDTO2>>()
            {
                Data = x.Select(M => M.TOsaveExaminationFindingDTO2()),
                dateTime = DateTime.Now,
                Success = true,
                Message = "you are Get this ExaminationFinding successfully",
            };
        }
    }
}
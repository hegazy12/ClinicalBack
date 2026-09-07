using Domain.IUnitOfWork;
using Domain.Models;
using Domain.Response;
using ServiceLayer.SheetService.DTO;
using ServiceLayer.SmedicalExaminations.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.SheetService
{
    public class SheetService : ISheetService
    {
        public IUnitOfWork unitOfWork;
        public SheetService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GeneralResponse<bool>> Delete(Guid SheetId, Guid userId)
        {
            try
            {
                var Sheet = unitOfWork.saveExaminationsRepository.Find(m => m.Id == SheetId);
                Sheet.MarkAsDeleted(userId);
                unitOfWork.saveExaminationsRepository.Update(Sheet);
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

        public async Task<GeneralResponse<IList<SheetDTO1>>> GetAll()
        {
           var x = await unitOfWork.sheetRepository.GetAllAsync();
           return new GeneralResponse<IList<SheetDTO1>>()
            {
                Data = x.Select(m=> m.ToSheetDTO1()).ToList(),
                Success = true ,
                Message = "The data was successfully completed"
            };
        }

        public async Task<GeneralResponse<SheetDTO1>> save(SheetDTO SheetDTO , Guid userId)
        {
            Sheet Sheet = new Sheet()
            {
                Name = SheetDTO.Name,
            };

            var x = await unitOfWork.sheetRepository.IsSavedBefor(Sheet);

            if (x) 
            {
                return new GeneralResponse<SheetDTO1>()
                {
                    Data = null,
                    dateTime = DateTime.Now,
                    Success = false,
                    Message = "you are save this item befor"
                };
            }
            else
            {
                await unitOfWork.sheetRepository.AddAsync(Sheet);
                unitOfWork.SaveChangesAsync();
                return new GeneralResponse<SheetDTO1>()
                {
                    Data = null,
                    Success = true,
                    Message = "save is done",
                    dateTime = DateTime.Now,
                };
            }
        }

    }
}

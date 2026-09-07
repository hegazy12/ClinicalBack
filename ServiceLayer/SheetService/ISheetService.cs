using Domain.Response;
using ServiceLayer.SheetService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.SheetService
{
    public interface ISheetService
    {
        public Task<GeneralResponse<SheetDTO1>> save(SheetDTO SheetDTO, Guid userId);
        public Task<GeneralResponse<Boolean>> Delete(Guid SheetId, Guid userId);
        public Task<GeneralResponse<IList<SheetDTO1>>> GetAll();

    }
}

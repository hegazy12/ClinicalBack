using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.SheetService.DTO
{
    public class SheetDTO
    {
        public string Name { get; set;}
    }

    public class SheetDTO1 : SheetDTO
    {
        public Guid Id { get; set;}
    }

    public static partial class AdHocMapper
    {
        public static SheetDTO1 ToSheetDTO1(this Sheet Sheet)
        {
            return new SheetDTO1()
            {
                Name = Sheet.Name,
                Id = Sheet.Id
            };
        }
    }
}

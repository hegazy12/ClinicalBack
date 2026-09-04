using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class UploadPhotoRequest
    {
        public string? PhotoBase64 { get; set; }
        public Guid CreateBy { get; set; }
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.SheetService.saveQuestionService.saveQtionDTO
{
    public class saveQuestionDTO
    {
        public string? Notes { get; set; } = string.Empty;
        public Guid AppointmentId { get; set; }
        public Guid QuestionId { get; set; }
        public string value { get; set; }
    }

    public class saveQuestionDTO1
    {
        public Guid Id { get; set; }
    }
}

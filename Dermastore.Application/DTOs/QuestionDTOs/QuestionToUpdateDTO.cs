﻿using Dermastore.Application.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.QuestionDTOs
{
    public class QuestionToUpdateDTO
    {
        public int questionId { get; set; }
        public string content { get; set; }
        public List<AnswerToUpdateDto> answerToUpdate { get; set; } = new List<AnswerToUpdateDto>();
    }
}

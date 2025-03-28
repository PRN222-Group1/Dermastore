using Dermastore.Application.DTOs.QuizResultDTOs;
using Dermastore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Extensions
{
    public static class QuizResultMappingExtension
    {
        public static QuizResult? ToEntity(this QuizResultDto result)
        {
            if (result == null)
            {
                return null;
            }

            return new QuizResult
            {
                SkinType = result.skinType,
                CareTips = result.careTips,
                Characteristic = result.characteristic,
                Description = result.description,
            };
        }

        public static void UpdateQuizResultFromDto(this QuizResult result, UpdateQuizResultDto resultDto)
        {
            if (resultDto == null || resultDto == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            result.Description = result.Description;
            result.SkinType = resultDto.skinType;
            result.CareTips = resultDto.careTips;
            result.Characteristic = resultDto.characteristic;
        }

        public static QuizResultResponseDto ToDto(this QuizResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            return new QuizResultResponseDto
            {
                quizId = result.Id,
                careTips = result.CareTips,
                characteristic = result.Characteristic,
                description = result.Description,
                skinType = result.SkinType,
                answerDTOs = result.Answers?.Select(x => x.ToDto()).ToList()
            };
        }
    }
}

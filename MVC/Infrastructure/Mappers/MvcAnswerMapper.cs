using MVC.Models.Shared;
using BLL.Entities;

namespace MVC.Infrastructure.Mappers
{
    public static class MvcAnswerMapper
    {
        public static AnswerViewModel ToMvcAnswer(this AnswerEntity answerEntity)
        {
            return new AnswerViewModel()
            {
                Id = answerEntity.Id,
                Text = answerEntity.Text,
                Number = answerEntity.Number
            };
        }

        public static AnswerEntity ToBllAnswer(this AnswerViewModel answerViewModel)
        {
            return new AnswerEntity()
            {
                Id = answerViewModel.Id,
                Text = answerViewModel.Text,
                Number = answerViewModel.Number
            };
        }
    }
}
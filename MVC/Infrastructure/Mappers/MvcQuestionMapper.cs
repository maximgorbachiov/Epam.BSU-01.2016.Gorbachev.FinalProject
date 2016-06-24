using MVC.Models.Shared;
using BLL.Entities;

namespace MVC.Infrastructure.Mappers
{
    public static class MvcQuestionMapper
    {
        public static QuestionViewModel ToMvcQuestion(this QuestionEntity questionEntity)
        {
            return new QuestionViewModel()
            {
                Id = questionEntity.Id,
                QuestionText = questionEntity.Text,
                RightAnswer = questionEntity.RightAnswer,
                TestId = questionEntity.TestId,
                Image = questionEntity.Image
            };
        }

        public static QuestionEntity ToBllQuestion(this QuestionViewModel questionViewModel)
        {
            return new QuestionEntity()
            {
                Id = questionViewModel.Id,
                Text = questionViewModel.QuestionText,
                RightAnswer = questionViewModel.RightAnswer,
                TestId = questionViewModel.TestId,
                Image = questionViewModel.Image
            };
        }
    }
}
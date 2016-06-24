using DAL.Entities;
using BLL.Entities;

namespace BLL.Mappers
{
    public static class BllQuestionMapper
    {
        public static DalQuestion ToDalQuestion(this QuestionEntity question)
        {
            return new DalQuestion()
            {
                Id = question.Id,
                Text = question.Text,
                RightAnswer = question.RightAnswer,
                TestId = question.TestId,
                Image = question.Image
            };
        }

        public static QuestionEntity ToBllQuestion(this DalQuestion question)
        {
            return new QuestionEntity()
            {
                Id = question.Id,
                Text = question.Text,
                RightAnswer = question.RightAnswer,
                TestId = question.TestId,
                Image = question.Image
            };
        }
    }
}

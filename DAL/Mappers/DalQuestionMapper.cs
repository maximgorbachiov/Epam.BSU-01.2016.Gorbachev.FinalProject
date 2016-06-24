using ORM;
using DAL.Entities;

namespace DAL.Mappers
{
    public static class DalQuestionMapper
    {
        public static Question ToQuestion(this DalQuestion question)
        {
            return new Question()
            {
                Id = question.Id,
                Text = question.Text,
                RightAnswer = question.RightAnswer,
                TestId = question.TestId,
                Image = question.Image
            };
        }

        public static DalQuestion ToDalQuestion(this Question question)
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
    }
}

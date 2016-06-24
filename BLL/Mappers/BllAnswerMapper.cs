using DAL.Entities;
using BLL.Entities;

namespace BLL.Mappers
{
    public static class BllAnswerMapper
    {
        public static DalAnswer ToDalAnswer(this AnswerEntity answer)
        {
            return new DalAnswer()
            {
                Id = answer.Id,
                Text = answer.Text,
                Number = answer.Number,
                QuestionId = answer.QuestionId
            };
        }

        public static AnswerEntity ToBllAnswer(this DalAnswer answer)
        {
            return new AnswerEntity()
            {
                Id = answer.Id,
                Text = answer.Text,
                Number = answer.Number,
                QuestionId = answer.QuestionId
            };
        }
    }
}

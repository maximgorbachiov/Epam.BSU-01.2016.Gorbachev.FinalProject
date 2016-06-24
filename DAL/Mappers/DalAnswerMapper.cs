using ORM;
using DAL.Entities;

namespace DAL.Mappers
{
    public static class DalAnswerMapper
    {
        public static Answer ToAnswer(this DalAnswer answer)
        {
            return new Answer()
            {
                Id = answer.Id,
                Text = answer.Text,
                Number = answer.Number,
                QuestionId = answer.QuestionId
            };
        }

        public static DalAnswer ToDalAnswer(this Answer answer)
        {
            return new DalAnswer()
            {
                Id = answer.Id,
                Text = answer.Text,
                Number = answer.Number,
                QuestionId = answer.QuestionId
            };
        }
    }
}

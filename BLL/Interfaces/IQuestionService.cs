using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        QuestionEntity GetQuestionEntity(int id);
        IEnumerable<QuestionEntity> GetQuestionsByName(string name);
        IEnumerable<QuestionEntity> GetAllQuestionEntities();
        IEnumerable<QuestionEntity> GetQuestionEntitiesByTestId(int testId);
        int CreateQuestion(QuestionEntity question);
        void UpdateQuestion(QuestionEntity question);
        void DeleteQuestion(QuestionEntity question);
    }
}

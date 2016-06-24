using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IAnswerService
    {
        AnswerEntity GetAnswerEntity(int id);
        IEnumerable<AnswerEntity> GetAnswersByName(string name);
        IEnumerable<AnswerEntity> GetAllAnswerEntities();
        IEnumerable<AnswerEntity> GetAnswersByQuestionId(int questionId);
        void CreateAnswer(AnswerEntity answer);
        void UpdateAnswer(AnswerEntity answer);
        void DeleteAnswer(AnswerEntity answer);
    }
}

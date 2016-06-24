using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces.IRepositories
{
    public interface IAnswerRepository
    {
        DalAnswer GetAnswerById(int id);
        IEnumerable<DalAnswer> GetAnswerByPredicate(Expression<Func<DalAnswer, bool>> predicate);
        IEnumerable<DalAnswer> GetAnswerByName(string name);
        IEnumerable<DalAnswer> GetAnswersByQuestionId(int questionId);
        IEnumerable<DalAnswer> GetAllAnswers();
        void CreateAnswer(DalAnswer answer);
        void UpdateAnswer(DalAnswer answer);
        void RemoveAnswer(int id);
    }
}

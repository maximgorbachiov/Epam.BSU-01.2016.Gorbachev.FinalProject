using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces.IRepositories
{
    public interface IQuestionRepository
    {
        DalQuestion GetQuestionById(int id);
        IEnumerable<DalQuestion> GetQuestionByPredicate(Expression<Func<DalQuestion, bool>> predicate);
        IEnumerable<DalQuestion> GetQuestionByName(string name);
        IEnumerable<DalQuestion> GetQuestionsByTestId(int testId);
        IEnumerable<DalQuestion> GetAllQuestions();
        int GetLastQuestion();
        void CreateQuestion(DalQuestion question);
        void UpdateQuestion(DalQuestion question);
        void RemoveQuestion(int id);
    }
}

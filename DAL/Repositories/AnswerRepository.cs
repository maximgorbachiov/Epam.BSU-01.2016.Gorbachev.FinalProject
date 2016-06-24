using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ORM;
using DAL.Entities;
using System.Data.Entity;
using DAL.Interfaces.IRepositories;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class AnswerRepository : EntityRepository, IAnswerRepository 
    {
        public AnswerRepository(DbContext context) : base(context) { }

        public IEnumerable<DalAnswer> GetAllAnswers()
        {
            var answers = context.Set<Answer>().ToList();
            return answers.Select(answer => answer.ToDalAnswer());
        }

        public DalAnswer GetAnswerById(int id)
        {
            return context.Set<Answer>().FirstOrDefault(answer => answer.Id == id)?.ToDalAnswer();
        }

        public IEnumerable<DalAnswer> GetAnswerByName(string name)
        {
            var answers = context.Set<Answer>().ToList();
            return answers.Where(answer => answer.Text == name)
                          .Select(answer => answer.ToDalAnswer());
        }

        public IEnumerable<DalAnswer> GetAnswerByPredicate(Expression<Func<DalAnswer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAnswer> GetAnswersByQuestionId(int questionId)
        {
            var answers = context.Set<Answer>().ToList();
            return answers.Where(answer => answer.QuestionId == questionId)
                          .Select(answer => answer.ToDalAnswer());
        }

        public void CreateAnswer(DalAnswer answer)
        {
            if (answer == null) return;
            var newAnswer = answer.ToAnswer();
            context.Set<Answer>().Add(newAnswer);
        }

        public void RemoveAnswer(int id)
        {
            var answer = context.Set<Answer>().FirstOrDefault(t => t.Id == id);

            if (answer == null) return;

            context.Set<Answer>().Remove(answer);
        }

        public void UpdateAnswer(DalAnswer dalAnswer)
        {
            var ormAnswer = context.Set<Answer>().FirstOrDefault(answer => answer.Id == dalAnswer.Id);

            if (ormAnswer == null) return;

            ormAnswer.Text = dalAnswer.Text;
            ormAnswer.Number = dalAnswer.Number;
            ormAnswer.QuestionId = dalAnswer.QuestionId;
            context.Entry(ormAnswer).State = EntityState.Modified;
        }
    }
}

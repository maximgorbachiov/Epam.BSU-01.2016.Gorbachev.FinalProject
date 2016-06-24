using System;
using System.Collections.Generic;
using System.Linq;
using ORM;
using DAL.Mappers;
using System.Data.Entity;
using DAL.Interfaces.IRepositories;
using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class QuestionRepository : EntityRepository, IQuestionRepository
    {
        public QuestionRepository(DbContext context) : base(context) { }

        public IEnumerable<DalQuestion> GetAllQuestions()
        {
            var questions = context.Set<Question>().ToList();
            return questions.Select(question => question.ToDalQuestion());
        }

        public DalQuestion GetQuestionById(int id)
        {
            return context.Set<Question>().FirstOrDefault(client => client.Id == id)?.ToDalQuestion();
        }

        public IEnumerable<DalQuestion> GetQuestionByName(string name)
        {
            var questions = context.Set<Question>().ToList();
            return questions.Where(question => question.Text == name)
                            .Select(question => question.ToDalQuestion());
        }

        public IEnumerable<DalQuestion> GetQuestionsByTestId(int testId)
        {
            var questions = context.Set<Question>().ToList();
            return questions.Where(question => question.TestId == testId)
                            .Select(question => question.ToDalQuestion());
        }

        public IEnumerable<DalQuestion> GetQuestionByPredicate(Expression<Func<DalQuestion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetLastQuestion()
        {
            return context.Set<Question>().OrderByDescending(question => question.Id).FirstOrDefault().Id;
        }

        public void CreateQuestion(DalQuestion question)
        {
            if (question == null) return;
            var newQuestion = question.ToQuestion();
            context.Set<Question>().Add(newQuestion);
        }

        public void RemoveQuestion(int id)
        {
            var question = context.Set<Question>().FirstOrDefault(t => t.Id == id);
            if (question == null) return;

            var answers = context.Set<Answer>()?.Where(answer => answer.QuestionId == id);

            foreach(var answer in answers)
            {
                context.Set<Answer>().Remove(answer);
            }

            context.Set<Question>().Remove(question);
        }

        public void UpdateQuestion(DalQuestion dalQuestion)
        {
            var ormQuestion = context.Set<Question>().FirstOrDefault(question => question.Id == dalQuestion.Id);

            if (ormQuestion == null) return;

            ormQuestion.Text = dalQuestion.Text;
            ormQuestion.RightAnswer = dalQuestion.RightAnswer;
            ormQuestion.Image = dalQuestion.Image;
            context.Entry(ormQuestion).State = EntityState.Modified;
        }
    }
}

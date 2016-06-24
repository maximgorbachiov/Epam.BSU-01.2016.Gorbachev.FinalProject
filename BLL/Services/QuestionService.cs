using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using DAL.Interfaces.IUnitsOfWork;
using BLL.Mappers;
using System;

namespace BLL.Services
{
    public class QuestionService : EntityService, IQuestionService
    {
        public QuestionService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<QuestionEntity> GetAllQuestionEntities()
        {
            return uow.Questions.GetAllQuestions().Select(dalQuestion => dalQuestion.ToBllQuestion());
        }

        public IEnumerable<QuestionEntity> GetQuestionEntitiesByTestId(int testId)
        {
            return uow.Questions.GetQuestionsByTestId(testId).Select(dalQuestion => dalQuestion.ToBllQuestion());
        }

        public QuestionEntity GetQuestionEntity(int id)
        {
            return uow.Questions.GetQuestionById(id)?.ToBllQuestion();
        }

        public IEnumerable<QuestionEntity> GetQuestionsByName(string name)
        {
            return uow.Questions.GetQuestionByName(name).Select(dalQuestion => dalQuestion.ToBllQuestion());
        }

        public int CreateQuestion(QuestionEntity question)
        {
            uow.Questions.CreateQuestion(question.ToDalQuestion());
            uow.Commit();
            return uow.Questions.GetLastQuestion();
        }

        public void DeleteQuestion(QuestionEntity question)
        {
            uow.Questions.RemoveQuestion(question.ToDalQuestion().Id);
            uow.Commit();
        }

        public void UpdateQuestion(QuestionEntity question)
        {
            uow.Questions.UpdateQuestion(question.ToDalQuestion());
            uow.Commit();
        }
    }
}

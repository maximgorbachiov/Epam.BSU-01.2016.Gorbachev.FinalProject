using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using DAL.Interfaces.IUnitsOfWork;
using BLL.Mappers;
using System;

namespace BLL.Services
{
    public class AnswerService : EntityService, IAnswerService
    {
        public AnswerService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<AnswerEntity> GetAllAnswerEntities()
        {
            return uow.Answers.GetAllAnswers().Select(dalAnswer => dalAnswer.ToBllAnswer());
        }

        public AnswerEntity GetAnswerEntity(int id)
        {
            return uow.Answers.GetAnswerById(id).ToBllAnswer();
        }

        public IEnumerable<AnswerEntity> GetAnswersByName(string name)
        {
            return uow.Answers.GetAnswerByName(name).Select(dalAnswer => dalAnswer.ToBllAnswer());
        }

        public IEnumerable<AnswerEntity> GetAnswersByQuestionId(int questionId)
        {
            return uow.Answers.GetAnswersByQuestionId(questionId).Select(answer => answer.ToBllAnswer());
        }

        public void CreateAnswer(AnswerEntity answer)
        {
            uow.Answers.CreateAnswer(answer.ToDalAnswer());
            uow.Commit();
        }

        public void DeleteAnswer(AnswerEntity answer)
        {
            uow.Answers.RemoveAnswer(answer.ToDalAnswer().Id);
            uow.Commit();
        }

        public void UpdateAnswer(AnswerEntity answer)
        {
            uow.Answers.UpdateAnswer(answer.ToDalAnswer());
            uow.Commit();
        }
    }
}

using DAL.Interfaces.IUnitsOfWork;
using System.Data.Entity;
using DAL.Interfaces.IRepositories;
using DAL.Repositories;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        private ITestRepository testRepository;
        private ICategoryRepository categoryRepository;
        private IQuestionRepository questionRepository;
        private IAnswerRepository answerRepository;
        private IClientRepository clientRepository;
        private IRoleRepository roleRepository;
        private IPassedTestRepository passedTestRepository;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public ITestRepository Tests
        {
            get
            {
                if (testRepository == null)
                {
                    testRepository = new TestRepository(context);
                }
                return testRepository;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }

        public IQuestionRepository Questions
        {
            get
            {
                if (questionRepository == null)
                {
                    questionRepository = new QuestionRepository(context);
                }
                return questionRepository;
            }
        }

        public IAnswerRepository Answers
        {
            get
            {
                if (answerRepository == null)
                {
                    answerRepository = new AnswerRepository(context);
                }
                return answerRepository;
            }
        }

        public IClientRepository Clients
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new ClientRepository(context);
                }
                return clientRepository;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                {
                    roleRepository = new RoleRepository(context);
                }
                return roleRepository;
            }
        }

        public IPassedTestRepository PassedTests
        {
            get
            {
                if (passedTestRepository == null)
                {
                    passedTestRepository = new PassedTestRepository(context);
                }
                return passedTestRepository;
            }
        }

        public void Commit()
        {
            if (context != null)
            {
                try
                { 
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}

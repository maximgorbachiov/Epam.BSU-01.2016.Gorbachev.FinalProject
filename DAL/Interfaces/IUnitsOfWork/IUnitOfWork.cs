using System;
using DAL.Interfaces.IRepositories;

namespace DAL.Interfaces.IUnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITestRepository Tests { get; }
        ICategoryRepository Categories { get; }
        IQuestionRepository Questions { get; }
        IAnswerRepository Answers { get; }
        IClientRepository Clients { get; }
        IRoleRepository Roles { get; }
        IPassedTestRepository PassedTests { get; }
        void Commit();
    }
}

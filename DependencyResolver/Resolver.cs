using System.Data.Entity;
using BLL.Services;
using DAL;
using DAL.Interfaces.IRepositories;
using DAL.Repositories;
using DAL.Interfaces.IUnitsOfWork;
using BLL.Interfaces;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class Resolver
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<EntityModelContext>().InRequestScope();

            kernel.Bind<ITestService>().To<TestService>();
            kernel.Bind<ITestRepository>().To<TestRepository>();

            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();

            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IQuestionRepository>().To<QuestionRepository>();

            kernel.Bind<IAnswerService>().To<AnswerService>();
            kernel.Bind<IAnswerRepository>().To<AnswerRepository>();

            kernel.Bind<IClientService>().To<ClientService>();
            kernel.Bind<IClientRepository>().To<ClientRepository>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            kernel.Bind<IPassedTestService>().To<PassedTestService>();
            kernel.Bind<IPassedTestRepository>().To<PassedTestRepository>();
        }
    }
}

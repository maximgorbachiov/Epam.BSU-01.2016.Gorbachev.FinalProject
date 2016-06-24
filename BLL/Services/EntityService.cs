using DAL.Interfaces.IUnitsOfWork;

namespace BLL.Services
{
    public class EntityService
    {
        protected IUnitOfWork uow;

        public EntityService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}

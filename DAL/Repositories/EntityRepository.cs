using System.Data.Entity;

namespace DAL.Repositories
{
    public class EntityRepository
    {
        protected readonly DbContext context;

        public EntityRepository(DbContext context)
        {
            this.context = context;
        }
    }
}

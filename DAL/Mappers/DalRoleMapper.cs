using ORM;
using DAL.Entities;

namespace DAL.Mappers
{
    public static class DalRoleMapper
    {
        public static Role ToRole(this DalRole role)
        {
            return new Role()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}

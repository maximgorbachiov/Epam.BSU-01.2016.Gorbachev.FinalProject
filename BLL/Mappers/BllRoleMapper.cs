using DAL.Entities;
using BLL.Entities;

namespace BLL.Mappers
{
    public static class BllRoleMapper
    {
        public static DalRole ToDalRole(this RoleEntity role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static RoleEntity ToBllRole(this DalRole role)
        {
            return new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}

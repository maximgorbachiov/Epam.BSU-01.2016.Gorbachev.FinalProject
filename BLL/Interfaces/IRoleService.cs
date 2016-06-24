using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        RoleEntity GetRoleEntity(int id);
        IEnumerable<RoleEntity> GetRolesByClientId(int clientId);
        IEnumerable<RoleEntity> GetRolesByName(string name);
        IEnumerable<RoleEntity> GetAllRoleEntities();
        void AddRoleToClient(int clientId, RoleEntity role);
        void CreateRole(RoleEntity role);
        void UpdateRole(RoleEntity role);
        void DeleteRole(RoleEntity role);
    }
}

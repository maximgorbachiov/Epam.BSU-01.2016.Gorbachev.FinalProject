using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces.IRepositories
{
    public interface IRoleRepository
    {
        DalRole GetRoleById(int id);
        IEnumerable<DalRole> GetRolesByClientId(int clientId);
        IEnumerable<DalRole> GetRoleByPredicate(Expression<Func<DalRole, bool>> predicate);
        IEnumerable<DalRole> GetRoleByName(string name);
        IEnumerable<DalRole> GetAllRoles();
        void AddRoleToClient(int clientId, DalRole role);
        void CreateRole(DalRole role);
        void UpdateRole(DalRole role);
        void RemoveRole(int id);
    }
}

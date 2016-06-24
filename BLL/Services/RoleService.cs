using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;
using DAL.Interfaces.IUnitsOfWork;
using BLL.Entities;
using BLL.Interfaces;
using System;

namespace BLL.Services
{
    public class RoleService : EntityService, IRoleService
    {
        public RoleService(IUnitOfWork uow) : base(uow) { }

        public RoleEntity GetRoleEntity(int id)
        {
            return uow.Roles.GetRoleById(id).ToBllRole();
        }

        public IEnumerable<RoleEntity> GetRolesByClientId(int clientId)
        {
            return uow.Roles.GetRolesByClientId(clientId).Select(dalRole => dalRole.ToBllRole());
        }

        public IEnumerable<RoleEntity> GetRolesByName(string name)
        {
            return uow.Roles.GetRoleByName(name).Select(dalRole => dalRole.ToBllRole());
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return uow.Roles.GetAllRoles().Select(dalRole => dalRole.ToBllRole());
        }

        public void AddRoleToClient(int clientId, RoleEntity role)
        {
            uow.Roles.AddRoleToClient(clientId, role.ToDalRole());
            uow.Commit();
        }

        public void CreateRole(RoleEntity role)
        {
            uow.Roles.CreateRole(role.ToDalRole());
            uow.Commit();
        }

        public void DeleteRole(RoleEntity role)
        {
            uow.Roles.RemoveRole(role.ToDalRole().Id);
            uow.Commit();
        }

        public void UpdateRole(RoleEntity role)
        {
            uow.Roles.UpdateRole(role.ToDalRole());
            uow.Commit();
        }
    }
}

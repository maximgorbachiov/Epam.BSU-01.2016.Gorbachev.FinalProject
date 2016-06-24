using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ORM;
using DAL.Entities;
using System.Data.Entity;
using DAL.Interfaces.IRepositories;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class RoleRepository : EntityRepository, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context) { }

        public DalRole GetRoleById(int id)
        {
            return context.Set<Role>().FirstOrDefault(role => role.Id == id).ToDalRole();
        }

        public IEnumerable<DalRole> GetRolesByClientId(int clientId)
        {
            var client = context.Set<Client>().Find(clientId);
            return client.Roles.Select(role => role.ToDalRole());
        }

        public IEnumerable<DalRole> GetRoleByName(string name)
        {
            var roles = context.Set<Role>().ToList();
            return roles.Where(role => role.Name == name).Select(role => role.ToDalRole());
        }

        public IEnumerable<DalRole> GetRoleByPredicate(Expression<Func<DalRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAllRoles()
        {
            var roles = context.Set<Role>().ToList();
            return roles.Select(role => role.ToDalRole());
        }

        public void AddRoleToClient(int clientId, DalRole role)
        {
            var ormClient = context.Set<Client>().Find(clientId);
            var ormRole = context.Set<Role>().Find(role.Id);
            ormClient.Roles.Add(ormRole);
        }

        public void CreateRole(DalRole role)
        {
            context.Set<Role>().Add(role.ToRole());
        }

        public void RemoveRole(int id)
        {
            var role = context.Set<Role>().FirstOrDefault(t => t.Id == id);
            context.Set<Role>().Remove(role);
        }

        public void UpdateRole(DalRole dalRole)
        {
            var ormRole = context.Set<Role>().FirstOrDefault(role => role.Id == dalRole.Id);

            if (ormRole == null) return;

            ormRole.Name = dalRole.Name;
            context.Entry(ormRole).State = EntityState.Modified;
        }
    }
}

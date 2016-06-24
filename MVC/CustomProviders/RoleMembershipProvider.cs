using System;
using System.Linq;
using System.Web.Security;
using BLL.Interfaces;
using BLL.Entities;
using System.Collections.Generic;

namespace MVC.CustomProviders
{
    public class RoleMembershipProvider : RoleProvider
    {
        public IClientService ClientService
            => (IClientService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IClientService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool IsUserInRole(string email, string roleName)
        {
            ClientEntity client = ClientService.GetClientByEmail(email);

            if (client == null) return false;

            IEnumerable<RoleEntity> clientRole = RoleService.GetRolesByClientId(client.Id);

            if (clientRole == null) return false;

            foreach(var role in clientRole)
            {
                if (role.Name == roleName) return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string email)
        {
            ClientEntity clientEntity = ClientService.GetClientByEmail(email);

            if (clientEntity == null) return null;

            string[] roles = RoleService.GetRolesByClientId(clientEntity.Id)
                    .Select(role => role.Name).ToArray();

            return roles;
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleEntity() { Name = roleName };
            RoleService.CreateRole(newRole);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}
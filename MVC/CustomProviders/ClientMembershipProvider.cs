using System;
using System.Linq;
using System.Web.Helpers;
using BLL.Entities;
using MVC.Models.Shared;
using System.Web.Security;
using BLL.Interfaces;
using MVC.Models;
using MVC.Infrastructure.Mappers;

namespace MVC.CustomProviders
{
    public class ClientMembershipProvider : MembershipProvider
    {
        public IClientService ClientService 
            => (IClientService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IClientService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public MembershipUser CreateClient(RegisterViewModel userView)
        {
            MembershipUser membershipUser = GetUser(userView.Email, false);

            if (membershipUser != null) return null;

            var client = userView.ToBllClient();
            client.Password = Crypto.HashPassword(client.Password);
            ClientService.CreateClient(client);

            var role = RoleService.GetAllRoleEntities().FirstOrDefault(r => r.Name == "User");

            if (role != null)
            {
                client = ClientService.GetClientByEmail(client.Email);
                RoleService.AddRoleToClient(client.Id, role);
            }

            membershipUser = GetUser(userView.Email, false);
            return membershipUser;
        }

        public void UpdateClient(ProfileViewModel profile)
        {
            var client = ClientService.GetClientEntity(profile.ClientId);
            client.Name = profile.Name ?? client.Name;
            client.Surname = profile.Surname ?? client.Surname;
            client.Patronymic = profile.Patronymic ?? client.Patronymic;
            client.Email = profile.Email ?? client.Email;
            client.Age = profile.Age == 0 ? client.Age : profile.Age;
            client.Password =  profile.Password != null ? Crypto.HashPassword(profile.Password) : client.Password;
            
            ClientService.UpdateClient(client);
        }

        public override bool ValidateUser(string email, string password)
        {
            var client = ClientService.GetClientByEmail(email);

            if (client != null && Crypto.VerifyHashedPassword(client.Password, password)) return true;

            return false;
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            var client = ClientService.GetClientByEmail(email);

            if (client == null) return null;

            var memberUser = new MembershipUser("ClientMembershipProvider", client.Email,
                null, null, null, null,
                false, false, DateTime.Now,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        #region Stabs
        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        #endregion     
    }
}
using System;
using System.Web.Security;

namespace Store.Web.App.Providers
{
    // GetRolesForUser, который возвращает все роли пользователя
    // IsUserInRole, который показывает, связан ли пользователь с данной ролью.

    public class HelpdeskRoleProvider : RoleProvider
    {

        public override string[] GetRolesForUser(string UserName)
        {
            string[] role = new string[] { };
            
            return role;

        }

        public override bool IsUserInRole(string UserName, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
             
            return outputResult;
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }



        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
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

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
    }
}
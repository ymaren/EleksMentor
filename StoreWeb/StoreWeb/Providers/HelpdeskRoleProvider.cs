using Core.Dal.Ado.Net;
using ProductStore.Infustructure;
using ProductStore.Model;
using ProductStore.Service;
using StoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using ProductStore.Models.DbContect;

namespace StoreWeb.Providers
{
    // GetRolesForUser, который возвращает все роли пользователя
    // IsUserInRole, который показывает, связан ли пользователь с данной ролью.

    public class HelpdeskRoleProvider : RoleProvider
    {

        public override string[] GetRolesForUser(string UserName)
        {
            string[] role = new string[] { };
            using (DBContext _db = new DBContext())
            {
                try
                {
                    // Получаем пользователя
                    UserViewModel user = _db.User.ViewSingle(UserName);
                    if (user != null)
                    {
                        // получаем роль
                        UsersRoleViewModel userRole = _db.UserRole.ViewSingle(user.UserRoleId);

                        if (userRole != null)
                        {
                            role = new string[] { userRole.UserRoleName };
                        }
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            }
            return role;

        }

        public override bool IsUserInRole(string UserName, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
            using (DBContext _db = new DBContext())
            {
                try
                {
                    // Получаем пользователя
                    UserViewModel user = _db.User.ViewSingle(UserName);
                    if (user != null)
                    {
                        // получаем роль
                        UsersRoleViewModel userRole = _db.UserRole.ViewSingle(user.UserRoleId);

                        //сравниваем
                        if (userRole != null && userRole.UserRoleName == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch
                {
                    outputResult = false;
                }
            }
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProductStore.Model
{
   public class UserViewModel
    {   public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public int UserRoleId { get; set; }
        public UsersRoleViewModel UserRole { get; set; }
        public UserViewModel(int userId, string userLogin, string userPassword, string userName,
           int UserRoleId , UsersRoleViewModel usersRoleViewModel)
        {
            this.UserId = userId;
            this.UserLogin = userLogin;
            this.UserPassword = userPassword;
            this.UserName = userName;
            this.UserRoleId = UserRoleId;
            this.UserRole = usersRoleViewModel;

        }
        public UserViewModel(int userId, string userLogin, string userPassword, string userName,
           int UserRoleId)
        {
            this.UserId = userId;
            this.UserLogin = userLogin;
            this.UserPassword = userPassword;
            this.UserName = userName;
            this.UserRoleId = UserRoleId;
            

        }


        public UserViewModel()
        {

        }
    }
}

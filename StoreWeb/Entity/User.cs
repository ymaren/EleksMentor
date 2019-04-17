using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public int UserRoleId { get; set; }

        public User(int userId, string userLogin, string userPassword, string userName,
           int UserRoleId)
        {
            this.UserId = userId;
            this.UserLogin = userLogin;
            this.UserPassword = userPassword;
            this.UserName = userName;
            this.UserRoleId = UserRoleId;
            
        }
        public User()
        {

        }
    }
}

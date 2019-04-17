using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProductStore.Model
{
   public class UsersRoleViewModel
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }

        public List<UserCredentialViewModel> RoleCredentialList { get; set; }


        public UsersRoleViewModel(int userroleId, string userRoleName )
        {
            this.UserRoleId = userroleId;
            this.UserRoleName = userRoleName;
        }
        
        public UsersRoleViewModel()
        {

        }
    }
}

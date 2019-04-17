using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsersRole
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        
        public UsersRole(int userroleId, string userRoleName)
        {
            this.UserRoleId = userroleId;
            this.UserRoleName = userRoleName;
                        
        }
        public UsersRole()
        {

        }
    }
}

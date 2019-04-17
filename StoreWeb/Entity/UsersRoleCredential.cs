using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsersRoleCredential
    {
        public int UserRoleid { get; set; }
        public int Credentialid { get; set; }
        
        public UsersRoleCredential(int userRoleid, int credentialid)
        {
            this.UserRoleid = userRoleid;
            this.Credentialid = credentialid;
                        
        }
        public UsersRoleCredential()
        {

        }
    }
}

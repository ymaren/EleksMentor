using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Model
{
   public class UsersRoleCredentialViewModel
    {
        public int UserRoleid { get; set; }
        public int Credentialid { get; set; }
        public string NameCredential { get; set; }
        public string FullNameCredential { get; set; }

        public int? ParentCredentialid { get; set; }
        public int Order { get; set; }
        public bool IsSelected { get; set; }

        public UsersRoleCredentialViewModel(int userRoleid, int credentialid, string nameCredential , string fullNameCredential,
           int? parentCredentialid, int order, bool IsSelected)
        {
            this.UserRoleid = userRoleid;
            this.Credentialid = credentialid;
            this.NameCredential = nameCredential;
            this.FullNameCredential = fullNameCredential;
            this.ParentCredentialid = parentCredentialid;
            this.Order = order;
            this.IsSelected = IsSelected;
        }
        public UsersRoleCredentialViewModel()
        {

        }


    }
}

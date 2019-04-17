using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsersCredential
    {
        public int idCredential { get; set; }
        public string NameCredential { get; set; }
        public string FullNameCredential { get; set; }
        public int ParentCredentialid { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }

        public UsersCredential(int idCredential, string nameCredential, string fullNameCredential,
            int parentCredentialid,
            int order, string url)
        {
            this.idCredential = idCredential;
            this.NameCredential = nameCredential;
            this.FullNameCredential = fullNameCredential;
            this.ParentCredentialid = parentCredentialid;
            this.Order = order;
            this.Url = url;
                        
        }
        public UsersCredential()
        {

        }
    }
}

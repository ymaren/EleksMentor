using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProductStore.Model
{
    public class UserCredentialViewModel
    {
        public int idCredential { get; set; }
        public string NameCredential { get; set; }
        public string FullNameCredential { get; set; }
        public int? ParentCredentialid { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
        


        public UserCredentialViewModel(int idCredential, string nameCredential, string fullNameCredential,
        int? parentCredentialid,
        int order, string url)
        {
            this.idCredential = idCredential;
            this.NameCredential = nameCredential;
            this.FullNameCredential = fullNameCredential;
            this.ParentCredentialid = parentCredentialid;
            this.Order = order;
            this.Url = url;
            

        }
    }
}

using Entity;
using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IUserCredentionalView:IObject
    {
        UserCredentialViewModel ViewSingle(int id);
        IEnumerable<UserCredentialViewModel> ViewAll();
       
    }
}

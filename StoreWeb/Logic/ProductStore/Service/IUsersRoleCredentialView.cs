using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IUsersRoleCredentialView:IObject
    {
        //UsersRoleCredentialViewModel ViewSingle(int id);
        List<UsersRoleCredentialViewModel> ViewAll();
        List<UsersRoleCredentialViewModel> ViewCredentialForRole(int role_id);
        //bool Add(UsersRoleCredentialViewModel entity);

        //bool Change(UsersRoleCredentialViewModel entity);
        //bool Delete(int key);

    }
}

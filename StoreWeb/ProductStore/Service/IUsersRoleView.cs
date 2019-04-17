using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IUsersRoleView:IObject
    {
        UsersRoleViewModel ViewSingle(int id);
        IEnumerable<UsersRoleViewModel> ViewAll();
        bool Add(UsersRoleViewModel entity);

        bool Change(UsersRoleViewModel entity);
        bool CanDelete(int key, out string reason);
        bool Delete(int key);

      
    }
}

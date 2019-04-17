using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IUserView:IObject
    {
        UserViewModel ViewSingle(int id);
        UserViewModel ViewSingle(string login);
        UserViewModel ViewSingle(string login, string password);
        IEnumerable<UserViewModel> ViewAll();
        bool Add(UserViewModel entity);

        bool Change(UserViewModel entity);

        bool Delete(int key);
    }
}

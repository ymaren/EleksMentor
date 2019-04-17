using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Model;
using Core.Dal;
using Entity;
using ProductStore.Models.DbContect;

namespace ProductStore.Service.impl
{
    class InternalUsersRoleView:IUsersRoleView
    {
        private readonly IRepositoryFactory _sourceFactory;

       
        public InternalUsersRoleView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<UsersRoleViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersRole, int>())
            {
                return   repository.GetAll().Select(c =>  new UsersRoleViewModel(c.UserRoleId, c.UserRoleName));
            }           
        }

        public UsersRoleViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersRole, int>() )
            {     
               var role = repository.GetSingle(id);
               return new UsersRoleViewModel(role.UserRoleId, role.UserRoleName);
            }
        }

        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersRole, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(UsersRoleViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersRole, int>())
            {
               return repository.Add(new UsersRole (entity.UserRoleId, entity.UserRoleName));
            };
           
        }
        public bool Change(UsersRoleViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersRole, int>())
            {

                return repository.Change(new UsersRole(entity.UserRoleId, entity.UserRoleName));

            }
        }

        public bool CanDelete(int roleid, out string reason)
        {
            reason = null;
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersRole, int>())
            {
                if (repository.GetAll().Where(c => c.UserRoleId == roleid).Any())
                {
                    reason = "You can't delete current role.Role include users!!!";
                    return false;
                }
                return true;
            }
        }

        

        //IEnumerable<UserCredentialViewModel> GetCredentialForRole(int id)
        //{
        //    using (var repository = _sourceFactory.CreateRepository<Entity.UsersCredential, int>())
        //    {
        //        using (DBContext _db = new DBContext())
        //        {
        //            return _db.UserCredentials.ViewAll();
        //        }
        //    }

        //}




    }
}

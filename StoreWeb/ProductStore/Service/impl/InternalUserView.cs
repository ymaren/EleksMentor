using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Model;
using Core.Dal;
using Entity;

namespace ProductStore.Service.impl
{
    class InternalUserView:IUserView
    {
        private readonly IRepositoryFactory _sourceFactory;

       
        public InternalUserView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<UserViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.User, int>())
            {
                IEnumerable<UsersRole> usersRole = _sourceFactory.CreateRepository<Entity.UsersRole, int>().GetAll();
                return repository.GetAll().Select(c => new UserViewModel(c.UserId, c.UserLogin, c.UserPassword, c.UserName, c.UserRoleId,
                    
                    usersRole.Where(u => u.UserRoleId == c.UserRoleId).Select(ur => new UsersRoleViewModel(ur.UserRoleId, ur.UserRoleName)).FirstOrDefault()));
                    
                    
            }
        }

        public UserViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.User, int>() )
            {
               var user = repository.GetSingle(id);
               return new UserViewModel(user.UserId, user.UserLogin, user.UserPassword, user.UserName, user.UserRoleId );
            }
        }

        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.User, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(UserViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.User, int>())
            {

               return repository.Add(new User (entity.UserId, entity.UserLogin, entity.UserPassword, entity.UserName, entity.UserRoleId));
                 
            };
           
        }

        public bool Change(UserViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.User, int>())
            {

                return repository.Change(new User(entity.UserId, entity.UserLogin, entity.UserPassword, entity.UserName, entity.UserRoleId));

            }
        }

        public UserViewModel ViewSingle(string login)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.User, int>())
            { User user = repository.GetAll().FirstOrDefault(u => u.UserLogin == login);
                if ( user!=null)
                return new UserViewModel(user.UserId, user.UserLogin, user.UserPassword, user.UserName, user.UserRoleId);
                else
                return null;
            }
        }

        public UserViewModel ViewSingle(string login, string password)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.User, int>())
            {
                User user = repository.GetAll().FirstOrDefault(u => u.UserLogin.Trim() == login.Trim() && u.UserPassword.Trim()==password.Trim());
                if (user != null)
                    return new UserViewModel(user.UserId, user.UserLogin, user.UserPassword, user.UserName, user.UserRoleId);
                else
                    return null;
            }
        }
    }
}

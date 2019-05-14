namespace Store.Logic.ProductStore.Service.impl
{
    using Core.Common.Dal;
    using Models.ModifyModels;
    using Models.ViewModels;
    using Service.ModifyServices;
    using Service.ViewServices;
    using System.Collections.Generic;

    internal class UserServiceImpl : IUserViewService, IUserModifyService
    {
        private readonly IRepositoryFactory _sourceFactory;

        public UserServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public bool Add(UserModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, UserModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserViewModel> ViewAll()
        {
            throw new System.NotImplementedException();
        }

        public UserViewModel ViewSingle(string login)
        {
            throw new System.NotImplementedException();
        }

        public UserViewModel ViewSingle(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        public UserViewModel ViewSingle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

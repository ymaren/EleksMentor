namespace Store.Logic.ProductStore.Service.impl
{
    using Core.Common.Dal;
    using Models.ModifyModels;
    using Models.ViewModels;
    using Service.ModifyServices;
    using Service.ViewServices;
    using System.Collections.Generic;

    internal class UserRoleServiceImpl : IUserRoleViewService, IUserRoleModifyService
    {
        private readonly IRepositoryFactory _sourceFactory;

        public UserRoleServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public bool Add(UserRoleModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key, out string reason)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, UserRoleModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UsersRoleViewModel> ViewAll()
        {
            throw new System.NotImplementedException();
        }

        public UsersRoleViewModel ViewSingle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

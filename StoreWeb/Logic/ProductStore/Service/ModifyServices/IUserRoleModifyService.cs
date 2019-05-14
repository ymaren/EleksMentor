namespace Store.Logic.ProductStore.Service.ModifyServices
{
    using Infustructure;
    using Models.ModifyModels;


    public interface IUserRoleModifyService : IObject, IModifyService<UserRoleModifyModel>
    { 
        bool Delete(int key, out string reason);
    }
}

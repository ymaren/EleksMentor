namespace Store.Logic.ProductStore.Service.ViewServices
{
    using Infustructure;
    using Models.ViewModels;

    public interface IUserViewService : IObject, IViewService<UserViewModel>
    {
        UserViewModel ViewSingle(string login);

        UserViewModel ViewSingle(string login, string password);
    }
}

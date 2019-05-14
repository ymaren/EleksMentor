namespace Store.Logic.ProductStore.Service.ModifyServices
{
    using Infustructure;
    using Models.ModifyModels;

    public interface IProductGroupModifyService : IObject, IModifyService<ProductGroupModifyModel>
    {
        bool Delete(int key, out string reason);
    }
}

namespace Store.Logic.ProductStore.Models.ViewModels
{
    public class ProductGroupViewModel
    {
        public int Id { get; internal set; }

        public string Name { get; internal set; }

        public string Description { get; internal set; }

        public  ProductCategoryViewModel Category { get; internal set; }
    }
}

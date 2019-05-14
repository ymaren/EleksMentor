namespace Store.Logic.ProductStore.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; internal set; }

        public string ProductCode { get; internal set; }

        public string Name { get; internal set; }

        public int Price { get; internal set; }

        public string Description { get; internal set; }

        public ProductGroupViewModel Group { get; internal set; }
    }
}

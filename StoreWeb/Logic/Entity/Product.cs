namespace Store.Logic.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductCode { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int GroupId { get; set; }

        public ProductGroup Group { get; set; }
    }
}

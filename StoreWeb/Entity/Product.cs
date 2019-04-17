using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }

        public Product(int id, string productcode, string name, int price, string description,
           int groupId)
        {
            this.Id = id;
            this.ProductCode = productcode;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.GroupId = groupId;
        }
        public Product()
        {

        }
    }
}

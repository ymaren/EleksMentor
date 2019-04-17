using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        

        public ProductCategory(int id, string categoryName, string categoryDescription)
        {
            this.CategoryId = id;
            this.CategoryName = categoryName;
            this.CategoryDescription = categoryDescription;
            
        }
        public ProductCategory()
        {

        }
    }
}

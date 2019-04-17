using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Model
{
   public class ProductGroupViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public int CategoryId { get; set; }
        public  ProductCategoryViewModel Category { get; set; }


        public ProductGroupViewModel(int id, string groupName, string groupDescription, int categoryId)
        {
            this.GroupId = id;
            this.GroupName = groupName;
            this.GroupDescription = groupDescription;
            this.CategoryId = categoryId;
            this.Category = null;
        }


        public ProductGroupViewModel(int id, string groupName, string groupDescription, int categoryId, ProductCategoryViewModel category) 
            :this(id, groupName, groupDescription,categoryId)
        {
          this.Category = category;
        }
         
        public ProductGroupViewModel()
        {

        }
    }
}

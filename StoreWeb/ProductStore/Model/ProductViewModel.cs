using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProductStore.Model
{
   public class ProductViewModel
    {
        
        public int Id { get;  set; }
        public string ProductCode { get;  set; }
        //[Display(Name = "Product name")]
        public string Name { get;  set; }
        public int Price { get;  set; }
        [DataType(DataType.MultilineText)]
        //[Display(Name = "Описание")]
        public string Description { get;  set; }
        public int GroupId { get; set; }

        public ProductGroupViewModel group{ get; set; }

        public ProductViewModel(int id, string productcode, string name, int price, 
            string description, int groupID, ProductGroupViewModel group)
        {
            this.Id = id;
            this.ProductCode = productcode;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.GroupId = groupID;
            this.group = group;
        }

        public ProductViewModel()
        {
           
        }

    }
}

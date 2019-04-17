using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public int CategoryId { get; set; }
        

        public ProductGroup(int id, string groupName, string groupDescription, int categoryId)
        {
            this.GroupId = id;
            this.GroupName = groupName;
            this.GroupDescription = groupDescription;
            this.CategoryId = categoryId;
        }
        public ProductGroup()
        {

        }
    }
}

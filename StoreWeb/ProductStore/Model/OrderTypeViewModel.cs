using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Model
{
    public class OrderTypeViewModel
    {
        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }


        public OrderTypeViewModel(int orderTypeId, string orderTypeName)
        {
            this.OrderTypeId = orderTypeId;
            this.OrderTypeName = orderTypeName;


        }
        public OrderTypeViewModel()
        {

        }

    }
}

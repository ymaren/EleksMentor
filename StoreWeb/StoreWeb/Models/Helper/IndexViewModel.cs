using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWeb.Models.Helper
{
    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PageInfo PageInfo { get; set; }
        public int? CurrentGroup { get; set; }
    }
}
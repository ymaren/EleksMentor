using Core.Dal.Ado.Net;
using ProductStore.Infustructure;
using ProductStore.Model;
using ProductStore.Service;
using StoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ProductStore.Models.DbContect;
namespace StoreWeb.Controllers
{
    public class NavController : Controller
    {

        DBContext _db ;
        IEnumerable<ProductCategoryViewModel> categories;
        IEnumerable<ProductGroupViewModel> group;
        public NavController()
        {
            _db = new DBContext();
            categories = _db.ProductCategory.ViewAll();
            group = _db.ProductGroup.ViewAll();
        }


        public PartialViewResult Menu(int? category = 0)
        {
            ViewBag.Categories = categories;
            ViewBag.Group = group;
            ViewBag.CurrentCategory = category;
            return PartialView();
        }
    }
}
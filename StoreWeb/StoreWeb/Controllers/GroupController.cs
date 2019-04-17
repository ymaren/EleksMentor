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
    [Authorize]
    public class GroupController : Controller
    {

        DBContext _db;
        IEnumerable<ProductCategoryViewModel> categories;
        IEnumerable<ProductGroupViewModel> groups;
        public GroupController()
        {
            _db = new DBContext();
            categories = _db.ProductCategory.ViewAll();
            groups = _db.ProductGroup.ViewAll();
        }

        //list
        public ViewResult Index()
        {
            return View(groups);
        }

        //edit one group
        [HttpGet]
        public ViewResult Edit(int? GroupId)
        {
            SelectList categorylist = new SelectList(categories, "CategoryId", "CategoryName");
            ViewBag.Categories = categorylist;
            ProductGroupViewModel group = groups.FirstOrDefault(c => c.GroupId == GroupId);
            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(ProductGroupViewModel group)
        {
            
            if (ModelState.IsValid)
            {
                if (groups.Any(c => c.GroupId== group.GroupId))
                {
                    _db.ProductGroup.Change(group);
                    TempData["message"] = string.Format("Group \"{0}\"uploaded", group.GroupName);
                    
                }
                else
                {
                    _db.ProductGroup.Add(group);
                    TempData["message"] = string.Format("Group\"{0}\"added", group.GroupName);
                }
               return RedirectToAction("Index");
            }
            else
            {
                
                return View(group);
            }
          
        }

        [HttpPost]
        public ViewResult Create()
        {
            return View("Edit", new ProductCategoryViewModel());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            string message = string.Empty;
            if (!_db.ProductCategory.CanDelete(Id, out message))
            {
                TempData["message"] = string.Format(message);
                return RedirectToAction("Index");
            }
            if (_db.ProductCategory.Delete(Id))
            {
                TempData["message"] = string.Format("Product category  was deleted");
            }
            return RedirectToAction("Index");
        }
    }

}


   
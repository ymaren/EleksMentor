using Core.Dal.Ado.Net;
using ProductStore.Infustructure;
using ProductStore.Model;
using ProductStore.Models.DbContect;
using ProductStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace StoreWeb.Controllers
{
    public class AdminController : Controller
    {

        DBContext _db;
        IEnumerable<ProductViewModel> products;
        IEnumerable<ProductGroupViewModel> groups;
        public AdminController()
        {
            _db = new DBContext();
             products = _db.Products.ViewAll();
             groups = _db.ProductGroup.ViewAll();

        }

        public ViewResult Index()
        {
           return View(products);
        }
        [HttpGet]
        public ViewResult Edit(int? Id)
        {
            SelectList teams = new SelectList(groups, "GroupId", "GroupName");
            ViewBag.Teams = teams;
            ProductViewModel product = products.FirstOrDefault(p => p.Id == Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel product, HttpPostedFileBase upload)
        {
            
            if (ModelState.IsValid)
            {
                if (products.Any(p => p.Id == product.Id))
                {
                    _db.Products.Change(product);
                    TempData["message"] = string.Format("Product \"{0}\" saved", product.Name);
                    
                }
                else
                {
                    _db.Products.Add(product);
                    TempData["message"] = string.Format("Product\"{0}\"saved", product.Name);
                }
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Pictures в проекте
                    upload.SaveAs(Server.MapPath("~/Pictures/"+product.Id+".jpg"));
                    TempData["message"] = string.Format("Foto add\"{0}\"", product.Name);
                   return Edit(product.Id);
                }
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(product);
            }
           // return View(product);
        }

        public ViewResult Create()
        {
            return View("Edit", new ProductViewModel());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            if (_db.Products.Delete(Id))
            {
                TempData["message"] = string.Format("Product  was deleted");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string Upload(HttpPostedFileBase upload, int? Id)
        {
            if (upload != null)
            {
                
                string fileName = System.IO.Path.GetFileName(upload.FileName);
               
                upload.SaveAs(Server.MapPath("~/Pictures/" + fileName));
            }
            return string.Empty;
        }
    }

}


   
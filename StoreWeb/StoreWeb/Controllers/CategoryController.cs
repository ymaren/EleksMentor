using ProductStore.Model;
using StoreWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductStore.Models.DbContect;
namespace StoreWeb.Controllers
{
    [Authorize (Roles ="Admin")]
    public class CategoryController : Controller
    {

        DBContext _db;
        IEnumerable<ProductCategoryViewModel> categories;
        public CategoryController()
        {
            _db = new DBContext();
            categories = _db.ProductCategory.ViewAll();
        }

        public ViewResult Index()
        {
            return View(categories);
        }

        [HttpGet]
        public ViewResult Edit(int? CategoryId)
        {
            ProductCategoryViewModel prodcategory = categories.FirstOrDefault(c => c.CategoryId == CategoryId);
            return View(prodcategory);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategoryViewModel category)
        {

            if (ModelState.IsValid)
            {
                if (categories.Any(c => c.CategoryId == category.CategoryId))
                {
                    _db.ProductCategory.Change(category);
                    TempData["message"] = string.Format("Category \"{0}\"uploaded", category.CategoryName);

                }
                else
                {
                    _db.ProductCategory.Add(category);
                    TempData["message"] = string.Format("Category\"{0}\"added", category.CategoryName);
                }
                return RedirectToAction("Index");
            }
            else
            {

                return View(category);
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



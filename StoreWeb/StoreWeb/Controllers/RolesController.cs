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
    public class RolesController : Controller
    {

        DBContext _db;
        IEnumerable<UsersRoleViewModel> usersRoles;
        
        public RolesController()
        {
            _db = new DBContext();
            usersRoles = _db.UserRole.ViewAll();
        }

        //list
        public ViewResult Index()
        {
            return View(usersRoles);
        }

        //edit one group
        [HttpGet]
        public ViewResult Edit(int? UserRoleId)
        {

            UsersRoleViewModel roles = usersRoles.FirstOrDefault(c => c.UserRoleId == UserRoleId);
            return View(roles);
        }

        [HttpPost]
        public ActionResult Edit(UsersRoleViewModel role)
        {
            
            if (ModelState.IsValid)
            {
                if (usersRoles.Any(c => c.UserRoleId== role.UserRoleId))
                {
                    _db.UserRole.Change(role);
                    TempData["message"] = string.Format("Role \"{0}\"uploaded", role.UserRoleName);
                    
                }
                else
                {
                    _db.UserRole.Add(role);
                    TempData["message"] = string.Format("Role\"{0}\"added", role.UserRoleName);
                }
               return RedirectToAction("Index");
            }
            else
            {
                
                return View(role);
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
            if (!_db.UserRole.CanDelete(Id, out message))
            {
                TempData["message"] = string.Format(message);
                return RedirectToAction("Index");
            }
            if (_db.UserRole.Delete(Id))
            {
                TempData["message"] = string.Format("Role  was deleted");
            }
            return RedirectToAction("Index");
        }
    }

}


   
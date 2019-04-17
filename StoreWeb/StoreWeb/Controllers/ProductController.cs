using Core.Dal.Ado.Net;
using Entity;
using ProductStore;
using ProductStore.Infustructure;
using ProductStore.Model;
using ProductStore.Service;
using StoreWeb.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace StoreWeb.Controllers
{
    
    public class ProductController : Controller
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DefaultAdoNet"].ConnectionString;
       // string connectionString = "Data Source=DESKTOP-EN8J2M6\\SQLEXPRESS; Initial Catalog=LotShop; Persist Security Info=true; User ID=sa; Password=1";
        private int pageSize = 12;
        IObjectFactory factory;
        public ProductController ()
        {
            var builder = new ObjectFactoryBuilder(); 
            builder.AddSource(new AdoRepositoryFactory(connectionString));
            factory = builder.Build();  
        }
        // GET: Product
        public ActionResult GetAll(int? category, int? group, int page = 1)
        {
            IEnumerable<ProductCategoryViewModel> categories = factory.Creates<IProductCategoryView>().ViewAll();
            IEnumerable<ProductGroupViewModel> groups = factory.Creates<IProductGroupView>().ViewAll();
            IEnumerable<ProductViewModel> products = factory.Creates<IProductView>().ViewAll();
            IEnumerable<ProductViewModel> selectedProducts = null;
            if (category != null && group == null)
            {
                IEnumerable<int> Selectedgroups = groups.Where(c => c.CategoryId == category).Select(s => s.GroupId);
                Func<ProductViewModel, bool> Conditional_Expression = GroupConditions(Selectedgroups);
                selectedProducts = products.Where(Conditional_Expression);

            }
            else /*if (category == null && group != null)*/
            {
                selectedProducts = products.Where(g => group == null || g.GroupId == group);
                   ;
            }

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = selectedProducts.Count() };
            IndexViewModel ivm = new IndexViewModel
            {
                PageInfo = pageInfo,
                Products = selectedProducts.OrderBy(P => P.Id).Skip((page - 1) * pageSize).Take(pageSize),
                CurrentGroup = group
            };


            return View(ivm);
        }

        private Func<ProductViewModel, bool> GroupConditions (IEnumerable<int> arrayGroupId)
        { 
            var param = Expression.Parameter(typeof(ProductViewModel), "c");
            PropertyInfo field = typeof(ProductViewModel).GetProperty("GroupId");
            Expression condition = null;
            foreach (int id in arrayGroupId )
           {
                if (condition == null)
                {
                   condition = Expression.Property(param, field);
                   condition = Expression.Equal(condition, Expression.Constant(id));
                }
                else
                {

                   Expression conditionfield = Expression.Equal(
                        Expression.Property(param, field)
                       , Expression.Constant(id));

                    condition = Expression.Or(condition, conditionfield);
                   
                }
            }
            var l = Expression.Lambda<Func<ProductViewModel, bool>>(condition, param);
           return l.Compile();
        }




        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(ProductViewModel prod)
        {
            
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

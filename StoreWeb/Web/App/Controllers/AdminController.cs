namespace Store.Web.App.Controllers
{
    using Logic.ProductStore.Infustructure;
    using Logic.ProductStore.Models.ViewModels;
    using Logic.ProductStore.Service.ModifyServices;
    using Logic.ProductStore.Service.ViewServices;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        private readonly IProductViewService _productViewService;
        private readonly IProductModifyService _productModifyService;
        private readonly IProductGroupViewService _productGroupViewService;

        public AdminController(IObjectFactory objectFactory)
        {
            _productViewService = objectFactory.Create<IProductViewService>();
            _productModifyService = objectFactory.Create<IProductModifyService>(); 
            _productGroupViewService = objectFactory.Create<IProductGroupViewService>(); 
        }

        public ViewResult Index()
        {
            var products = _productViewService.ViewAll();
            return View(products);
        }

        [HttpGet]
        public ViewResult Edit(int? Id)
        {
            var products = _productViewService.ViewAll();
            var groups = _productGroupViewService.ViewAll();
            var teams = new SelectList(groups, "GroupId", "GroupName");
            ViewBag.Teams = teams;

            ProductViewModel product = products.FirstOrDefault(p => p.Id == Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel product, HttpPostedFileBase upload)
        {
            var products = _productViewService.ViewAll();

            if (ModelState.IsValid)
            {
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
            if (_productModifyService.Delete(Id))
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



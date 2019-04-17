using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StoreWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //   / 	  Выводит первую страницу списка товаров всех категорий
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Product",
                    action = "GetAll",
                    group = UrlParameter.Optional,
                    page = 1
                }
            );

            /////Page2  Выводит указанную страницу(в этом случае страницу 2), отображая товары всех категорий
            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { controller = "Product", action = "GetAll" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}

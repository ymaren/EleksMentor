namespace Store.Web.App.Infrastructure
{
    using Core.Dal.AdoNet;
    using Logic.ProductStore.Infustructure;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class CustomControllerFactory : DefaultControllerFactory
    {
        private static Dictionary<string, Type> _controllersContainer = new Dictionary<string, Type>();

        public override IController CreateController(RequestContext requestContext, string controllerName)

        { 
            var controllername = requestContext.RouteData.Values["controller"].ToString();
            var controllerType = ResolveControllerType(controllerName);

            if (controllerType == null)
                return base.CreateController(requestContext, controllerName);

            var builder = new ObjectFactoryBuilder();
            builder.AddSource(
                new AdoNetRepositoryFactory(ConfigurationManager.ConnectionStrings["DefaultAdoNet"].ConnectionString));
            var factory = builder.Build();

            var controller = Activator.CreateInstance(controllerType, new object[] { factory }) as IController;
            return controller;
        }

        private Type ResolveControllerType(string name)
        {
            if (!_controllersContainer.TryGetValue(name, out var controllerType))
            {
                controllerType = GetType().Assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(typeof(Controller)) && t.Name.ToLower() == $"{name}controller");
                if (controllerType != null)

                    _controllersContainer[name] = controllerType;
            }

            return controllerType;
        }
    }
}
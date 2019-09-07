using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vic.SportStore.WebApp.App_Start
{
    public class IocConfig
    {
        public static void ConfigIoc()
        {
            var builder = new ContainerBuilder();

            builder.
                RegisterControllers(typeof(MvcApplication).Assembly).
                PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
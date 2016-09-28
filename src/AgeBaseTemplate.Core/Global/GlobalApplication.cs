using System;
using System.Reflection;
using System.Web.Mvc;
using AgeBaseTemplate.Core.Controllers;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace AgeBaseTemplate.Core.Global
{
    public class GlobalApplication : UmbracoApplication
    {
        protected override void OnApplicationStarting(object sender, EventArgs e)
        {
            DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(BasePageController));
        }

        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            container.Register<ILogService, LogService>();
            container.Register<IMasterPageService, MasterPageService>();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
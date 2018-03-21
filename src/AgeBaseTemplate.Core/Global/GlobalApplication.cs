using System;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AgeBaseTemplate.Core.Controllers;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using AgeBaseTemplate.Core.Wrappers;
using AgeBaseTemplate.Core.Wrappers.Implementations;
using log4net;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace AgeBaseTemplate.Core.Global
{
    public class GlobalApplication : UmbracoApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static Container Container;

        protected override void OnApplicationStarting(object sender, EventArgs e)
        {
            Log.Debug("Application Starting");

            base.OnApplicationStarting(sender, e);

            DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(BasePageController));
        }

        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            Log.Debug("Application Started");

            base.OnApplicationStarted(sender, e);

            Container = new Container();

            Container.Options.ConstructorResolutionBehavior = new UmbracoConstructorBehavior
            {
                DefaultBehavior = Container.Options.ConstructorResolutionBehavior
            };

            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            Container.Register<IFileSystem, FileSystem>(Lifestyle.Scoped);
            Container.Register<IMasterPageService, MasterPageService>(Lifestyle.Scoped);
            Container.Register<IThread, ThreadWrapper>(Lifestyle.Scoped);

            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            Container.RegisterMvcIntegratedFilterProvider();
            Container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }

        protected override void OnApplicationEnd(object sender, EventArgs e)
        {
            Log.Debug("Application Ended");

            base.OnApplicationEnd(sender, e);
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (!custom.ToLower().Equals("url"))
            {
                return base.GetVaryByCustomString(context, custom);
            }

            return "url=" + context.Request.Url.AbsoluteUri;
        }
    }

    public class UmbracoConstructorBehavior : IConstructorResolutionBehavior
    {
        public IConstructorResolutionBehavior DefaultBehavior { get; set; }

        public ConstructorInfo GetConstructor(Type implementationType)
        {
            return implementationType.Namespace != null && implementationType.Namespace.Contains("Umbraco")
                ? GetUmbracoConstructor(implementationType)
                : DefaultBehavior.GetConstructor(implementationType);
        }

        private ConstructorInfo GetUmbracoConstructor(Type i) => (from ctor in i.GetConstructors()
                                                                     orderby ctor.GetParameters().Length
                                                                     select ctor)
                                                                 .FirstOrDefault() ?? DefaultBehavior.GetConstructor(i);
    }
}
﻿using System;
using System.IO.Abstractions;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AgeBaseTemplate.Core.Controllers;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using AgeBaseTemplate.Core.Umbraco;
using AgeBaseTemplate.Core.Wrappers;
using AgeBaseTemplate.Core.Wrappers.Implementations;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using HttpContextWrapper = AgeBaseTemplate.Core.Wrappers.Implementations.HttpContextWrapper;
using HttpServerUtilityWrapper = AgeBaseTemplate.Core.Wrappers.Implementations.HttpServerUtilityWrapper;

namespace AgeBaseTemplate.Core.Global
{
    public class GlobalApplication : UmbracoApplication
    {
        public static Container Container;

        protected override void OnApplicationStarting(object sender, EventArgs e)
        {
            DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(BasePageController));
        }

        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            Container = new Container();

            Container.Options.ConstructorResolutionBehavior = new UmbracoConstructorBehavior
            {
                DefaultBehavior = Container.Options.ConstructorResolutionBehavior
            };

            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            Container.Register<IConfigPageService, ConfigPageService>(Lifestyle.Scoped);
            Container.Register<ICountryPageService, CountryPageService>(Lifestyle.Scoped);
            Container.Register<IFileSystem, FileSystem>(Lifestyle.Scoped);
            Container.Register<IGoogleAnalyticsService, GoogleAnalyticsService>(Lifestyle.Scoped);
            Container.Register<IHomePageService, HomePageService>(Lifestyle.Scoped);
            Container.Register<ILanguagePageService, LanguagePageService>(Lifestyle.Scoped);
            Container.Register<IMasterPageService, MasterPageService>(Lifestyle.Scoped);
            Container.Register<IPageService, PageService>(Lifestyle.Scoped);
            Container.Register<IThemeService, ThemeService>(Lifestyle.Scoped);

            Container.Register<ICultureInfo, CultureInfoWrapper>(Lifestyle.Scoped);
            Container.Register<IHttpContext, HttpContextWrapper>(Lifestyle.Scoped);
            Container.Register<IHttpServerUtility, HttpServerUtilityWrapper>(Lifestyle.Scoped);
            Container.Register<IProfileLogger, ProfileLoggerWrapper>(Lifestyle.Scoped);
            Container.Register<IUmbracoContext, UmbracoContextWrapper>(Lifestyle.Scoped);
            Container.Register<IUmbracoHelper, UmbracoHelperWrapper>(Lifestyle.Scoped);

            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            Container.RegisterMvcIntegratedFilterProvider();
            Container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom.ToLower().Equals("url"))
            {
                return "url=" + context.Request.Url.AbsoluteUri;
            }

            return base.GetVaryByCustomString(context, custom);
        }
    }
}
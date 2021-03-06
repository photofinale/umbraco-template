﻿using System;
using System.Linq;
using System.Reflection;
using SimpleInjector.Advanced;

namespace AgeBaseTemplate.Core.Umbraco
{
    public class UmbracoConstructorBehavior : IConstructorResolutionBehavior
    {
        public IConstructorResolutionBehavior DefaultBehavior { get; set; }

        public ConstructorInfo GetConstructor(Type implementationType)
        {
            if (implementationType.Namespace != null && implementationType.Namespace.Contains("Umbraco"))
            {
                return GetNonDefaultConstructor(implementationType);
            }

            if (implementationType.Namespace != null && implementationType.Namespace.Contains("AgeBaseTemplate.Core.Controllers.Api"))
            {
                return GetNonDefaultConstructor(implementationType);
            }

            return DefaultBehavior.GetConstructor(implementationType);
        }

        private ConstructorInfo GetNonDefaultConstructor(Type i)
        {
            var retval = i.GetConstructors().OrderBy(ctor => ctor.GetParameters().Length).FirstOrDefault();

            return retval ?? DefaultBehavior.GetConstructor(i);
        }
    }
}
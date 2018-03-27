using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Xml;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class UmbracoHelperWrapper : IUmbracoHelper
    {
        private readonly UmbracoHelper _umbracoHelper;

        public UmbracoHelperWrapper(IUmbracoContext umbracoContext)
        {
            _umbracoHelper = new UmbracoHelper(umbracoContext.Current);
        }

        public IPublishedContent TypedContentSingleAtXPath(string xpath, params XPathVariable[] vars)
        {
            return _umbracoHelper.TypedContentSingleAtXPath(xpath, vars);
        }

        public IEnumerable<IPublishedContent> TypedContentAtXPath(string xpath, params XPathVariable[] vars)
        {
            return _umbracoHelper.TypedContentAtXPath(xpath, vars);
        }
    }
}
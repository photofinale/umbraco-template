using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Xml;

namespace AgeBaseTemplate.Core.Wrappers
{
    public interface IUmbracoHelper
    {
        IPublishedContent TypedContentSingleAtXPath(string xpath, params XPathVariable[] vars);
        IEnumerable<IPublishedContent> TypedContentAtXPath(string xpath, params XPathVariable[] vars);
    }
}
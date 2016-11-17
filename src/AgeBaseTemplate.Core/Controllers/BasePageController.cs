using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace AgeBaseTemplate.Core.Controllers
{
    public class BasePageController : SurfaceController, IRenderMvcController
    {
        public virtual ActionResult Index(RenderModel model)
        {
            return CurrentTemplate(model);
        }

        protected ActionResult CurrentTemplate<T>(T model)
        {
            var template = ControllerContext.RouteData.Values["action"].ToString();

            var result = ViewEngines.Engines.FindView(ControllerContext, template, null);
            if (result.View == null || model == null)
                return new HttpNotFoundResult();

            return View(template, model);
        }
    }
}
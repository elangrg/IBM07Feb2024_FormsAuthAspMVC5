using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM07Feb2024_FormsAuthAspMVC5.Infra
{

    public class LogFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine(" Log Attr" + context.RouteData.Values["controller"] + "=>" + context.RouteData.Values["action"] + "---OnActionExecuted Called");

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine(" Log Attr" + context.RouteData.Values["controller"] + "=>" + context.RouteData.Values["action"] + "---OnActionExecuting Called");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine(" Log Attr" + context.RouteData.Values["controller"] + "=>" + context.RouteData.Values["action"] + "---OnResultExecuted Called");
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine(" Log Attr" + context.RouteData.Values["controller"] + "=>" + context.RouteData.Values["action"] + "---OnResultExecuting Called");
        }
    } 
}
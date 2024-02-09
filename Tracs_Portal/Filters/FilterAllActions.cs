using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using Tracs.Common.Models;

public class RedirectingAction : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string skip = context.HttpContext.Session.GetString("Skip");
        if ((skip??"false") == "true")
        {
            context.HttpContext.Session.SetString("Skip", "false");
            return;
        }

        base.OnActionExecuting(context);

        if (context.HttpContext.Session.GetString("Token") == null)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Home",
                action = "Index",
                area="Login"

            }));
            context.HttpContext.Session.SetString("Skip", "true");
        }
    }
}
public class FilterAllActions : IActionFilter, IResultFilter
{
    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        throw new System.NotImplementedException();
    }

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
        throw new System.NotImplementedException();
    }

    public void OnResultExecuting(ResultExecutingContext filterContext)
    {
        throw new System.NotImplementedException();
    }

    public void OnResultExecuted(ResultExecutedContext filterContext)
    {
        throw new System.NotImplementedException();
    }
}
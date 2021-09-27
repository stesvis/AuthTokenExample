using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AuthTokenExample.Models
{
    public class RedirectFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();
            if(userId == null)
            {

                filterContext.Result = new RedirectResult(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +"/"+filterContext.ActionDescriptor.ActionName);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
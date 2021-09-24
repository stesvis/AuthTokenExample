using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
namespace AuthTokenExample.Models
{
    public class CustomAuthorizeAttribute :AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            
            var token = httpContext.Request.QueryString["Token"];
            if (httpContext.User.Identity.IsAuthenticated)
            {
                return true;
            }
            if (token != null)
            {
                
                var ticket = Startup.OAuthOptions.AccessTokenFormat.Unprotect(token);
                if(ticket == null)
                {
                    return false;
                }
                var expireddate = ticket.Properties.Dictionary[".expires"];
                DateTime dateTime = DateTime.Parse(expireddate);
               if(dateTime < DateTime.Now)
                {
                    return false;
                }
           
                var id = new ClaimsIdentity(ticket.Identity.Claims, DefaultAuthenticationTypes.ApplicationCookie);

                var ctx = httpContext.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(id);
               
                
                return true;

            }
            return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

    }
}
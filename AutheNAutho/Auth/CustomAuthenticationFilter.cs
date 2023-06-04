using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace AutheNAutho.Auth
{
    public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private readonly bool _IsRequired;
        public CustomAuthenticationFilter(bool IsRequired=true)
        {
            _IsRequired= IsRequired;
        }
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (_IsRequired)
            {
                if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserId"])))
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
            
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                //Redirecting the user to the Login View of Auth Controller  
                filterContext.Result = new RedirectResult("/Auth/Index");
            }
        }
    }
}
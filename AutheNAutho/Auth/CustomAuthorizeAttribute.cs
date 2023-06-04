using AutheNAutho.DB;
using Microsoft.Ajax.Utilities;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutheNAutho.Auth
{
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        private readonly string[] _roles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var userId = Convert.ToString(httpContext.Session["UserId"]);
            if (!string.IsNullOrEmpty(userId))
            {
                var context = new UserDB();
                var userRole = context.RoleList().FirstOrDefault(x=>x.UserId==Convert.ToInt32(userId));
                var IfRoleExists = Array.Exists(_roles,e=>e.Equals(userRole.RoleName));
                if (IfRoleExists)
                {
                    authorize = true;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result =  new RedirectResult("/Auth/UnAuthorize");
        }
    }
}
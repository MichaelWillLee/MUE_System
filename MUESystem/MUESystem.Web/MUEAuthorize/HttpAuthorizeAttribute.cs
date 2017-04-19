using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MUESystem.Web.MUEAuthorize
{
    public class HttpAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool _pass = false;

            if (httpContext.Session["UserName"] != null)
            {
                _pass = true;
            }

            return _pass;
        }

        /// <summary>
        /// 没有权限转登录界面
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/");
        }
    }
}
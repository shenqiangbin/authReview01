using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthTest.Filters
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private bool isAuthorize;
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (isAuthorize)//如果认证了，只是没有权限则展示无权限界面
                filterContext.Result = new RedirectResult("/home/unAuthrize");
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            isAuthorize = base.AuthorizeCore(httpContext);
            bool canAccess = IsInRole(httpContext.User.Identity.Name, httpContext.Request.Url.AbsolutePath);
            return isAuthorize && canAccess;
        }

        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);
        }

        private bool IsInRole(string account, string url)
        {
            //todo:添加角色验证代码
            if (account == "admin" && url == "/home/about")
                return false;
            else
                return true;
        }
    }
}
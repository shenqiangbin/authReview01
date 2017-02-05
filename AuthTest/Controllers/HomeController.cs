using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthTest.Filters;

namespace AuthTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult SignIn(string returnUrl)
        {
            //todo:添加登录验证代码
            FormsAuthentication.SetAuthCookie("admin", false);
            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index");
            else
                return Redirect(returnUrl);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult unAuthrize()
        {
            return Content("无权限访问");
        }

        //新闻
        [UserAuthorize]
        public ActionResult News()
        {
            return View();
        }

        //关于
        [UserAuthorize]
        public ActionResult About()
        {
            return View();
        }
    }
}
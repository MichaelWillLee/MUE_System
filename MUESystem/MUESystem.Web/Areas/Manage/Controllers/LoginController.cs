using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MUESystem.BLL;
using MUESystem.IBLL;
using MUESystem.Web.Areas.Manage.Models;

namespace MUESystem.Web.Areas.Manage.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;
        public LoginController() { userService = new UserService(); }

        [AllowAnonymous]
        // GET: Manage/Login
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(ViewLogin viewUser)
        {
            if (ModelState.IsValid)
            {
                //var user = userService.Find(a => a.UserName == viewUser.UserName);
                var user = userService.Find(viewUser.LoginName);
                if (user == null)
                {
                    ModelState.AddModelError("LoginName", "用户名不存在");
                }
                else if (viewUser.Password != user.Password)
                {
                    ModelState.AddModelError("Password", "密码不正确");
                }
                else
                {
                    Session.Add("UserName", viewUser.LoginName);
                    Session.Add("Password", viewUser.Password);
                    //return RedirectToAction("Index", "Welcome");
                }
            }
            return View(viewUser);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MUESystem.BLL;
using MUESystem.IBLL;
using MUESystem.Web.ModelsView;

namespace MUESystem.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;
        public LoginController() { userService = new UserService(); }

        [AllowAnonymous]
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
                var user = userService.Find(viewUser.UserName);
                if (user == null)
                {
                    //ModelState.AddModelError("LoginName", "用户名不存在");
                }
                else if (viewUser.Password != user.Password)
                {
                    //ModelState.AddModelError("Password", "密码不正确");
                }
                else
                {
                    Session.Add("UserName", viewUser.UserName);
                    Session.Add("Password", viewUser.Password);
                    //return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            return View(viewUser);
        }
    }
}
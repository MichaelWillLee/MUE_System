using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MUESystem.BLL;
using MUESystem.IBLL;
using MUESystem.Web.MUEAuthorize;
using MUESystem.Model;

namespace MUESystem.Web.Controllers
{
    public class UserManageController : Controller
    {
        private IUserService userService;
        public UserManageController() { userService = new UserService(); }

        [HttpAuthorize]
        // GET: UserManage
        public ActionResult Index()
        {
            int totalRecord = 0;
            return View(userService.FindPageList(out totalRecord, 1, 10, 0).ToList());
        }

        [HttpAuthorize]
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model.User user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [HttpAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                if (userService.Exist(user.UserName)) {
                    bool bl = userService.Update(user);
                    if (bl) {
                        return RedirectToAction("Index", "UserManage");
                    }
                }
            }
            return View(user);
        }
    }
}
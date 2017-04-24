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
using MUESystem.Common.DataTimeCommon;
using log4net;
using MUESystem.Web.Log;

namespace MUESystem.Web.Controllers
{
    public class UserManageController : BaseController
    {
        private IUserService userService;
        public UserManageController() { userService = new UserService(); }
        private static readonly ILog logs = LogHelper.GetInstance();
        /// <summary>
        /// 显示用户列表GET
        /// </summary>
        /// <returns></returns>
        [HttpAuthorize]
        public ActionResult Index()
        {
            int totalRecord = 0;
            return View(userService.FindPageList(out totalRecord, 1, 10, 0).ToList());
        }

        /// <summary>
        /// GET  编辑用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpAuthorize]
        public ActionResult Edit(int id)
        {
            Model.User user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// POST 编辑用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [HttpAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userService.Exist(user.UserName))
                    {
                        bool bl = userService.Update(user);
                        if (bl)
                        {
                            return RedirectToAction("Index", "UserManage");
                        }
                    }
                }
            }
            catch (Exception ex){ 
            
            }
            return View(user);
        }


        /// <summary>
        /// Get 新增用户
        /// </summary>
        /// <returns></returns>
        [HttpAuthorize]
        public ActionResult Creat() 
        {
            return View();
        }

        /// <summary>
        /// POST 新增用户
        /// </summary>
        /// <returns></returns>
        [HttpAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creat(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User newUser = userService.Add(user);
                    if (!string.IsNullOrWhiteSpace(newUser.UserName))
                    {
                        return RedirectToAction("Index", "UserManage");
                    }
                }
            }
            catch (Exception ex)
            {
                string ret = ex.Message;
               
            }
            return View(user);
        }

        [HttpAuthorize]
        public ActionResult Delete(int id)
        {
            try
            {
                var userDelet = userService.Find(id);
                if (userDelet != null) {
                    userService.Delete(userDelet);
                    return RedirectToAction("Index", "UserManage");
                }
            }
            catch (Exception ex)
            {
                string exdd = ex.Message;
            }
            return View();
        }

        [HttpAuthorize]
        public ActionResult Details(int id) {
            string time = DataTimeHelper.GetNowTimeNosplit();
            logs.Error("错误测试");
            Model.User user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}
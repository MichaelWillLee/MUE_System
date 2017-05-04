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
using MUESystem.Common.LogCommon;
using System.Text;
using PagedList;
using MUESystem.DAL;
using MUESystem.Web.Configer;



namespace MUESystem.Web.Controllers
{
    public class UserManageController : BaseController
    {
        private IUserService userService;
        public UserManageController() { userService = new UserService(); }

        /// <summary>
        /// 显示用户列表GET
        /// </summary>
        /// <returns></returns>
        [HttpAuthorize]
        public ActionResult Index(string SearchString, int page = 1)
        {
            try
            {
                //每页显示多少条  
                //int pageSize = ConfigerHelper.GetPageSize();
                if (string.IsNullOrWhiteSpace(SearchString))
                {
                    //通过ToPagedList扩展方法进行分页  
                    IPagedList<User> pagedList = userService.Entities.OrderBy(x => x.ID).ToPagedList(page, pageSize);

                    //将分页处理后的列表传给View  
                    return View(pagedList);
                }
                else {
                    //通过ToPagedList扩展方法进行分页  
                    IPagedList<User> pagedList = userService.Entities.Where(x => x.UserName.Contains(SearchString)).OrderBy(x => x.ID).ToPagedList(page, pageSize);

                    //将分页处理后的列表传给View  
                    return View(pagedList);
                }
            }
            catch(Exception ex) {
                Log.Error("UserManageController-Index-",ex);
            }
            return View();
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
                Log.Error("UserManageController-Edit-post-", ex);
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
                    var ret = userService.Exist(x=>x.UserName == user.UserName || x.DisplayName == user.DisplayName);
                    if (ret) {
                        return View(user);
                    }
                    user.Status = EnumVal.GetStatusVal(Status.Y);
                    User newUser = userService.Add(user);
                    if (!string.IsNullOrWhiteSpace(newUser.UserName))
                    {
                        return RedirectToAction("Index", "UserManage");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Post新增用户：",ex);
            }
            return View(user);
        }

        [HttpAuthorize]
        public ActionResult Delete(int id)
        {
            try
            {
                var userDelet = userService.Find(id);
                if (userDelet != null && !userDelet.UserName.Equals("admin")) {
                    //只是更改状态并不实际删除
                    userDelet.Status = EnumVal.GetStatusVal(Status.N);
                    userService.Update(userDelet);
                    return RedirectToAction("Index", "UserManage");
                }
            }
            catch (Exception ex)
            {
                Log.Error("UserManage-Delete-", ex);
            }
            return RedirectToAction("Index", "UserManage");
        }

        [HttpAuthorize]
        public ActionResult Details(int id) {
            Model.User user = userService.Find(id);
            if (user == null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UserManage-Details-");
                sb.Append("id=").Append(id.ToString());
                Log.Error(sb.ToString());
                return HttpNotFound();
            }
            return View(user);
        }
    }
}
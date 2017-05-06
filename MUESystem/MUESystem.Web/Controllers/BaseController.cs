using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MUESystem.Common.SessionCommon;
using MUESystem.Web.Configer;

namespace MUESystem.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 页面条数
        /// </summary>
        protected int pageSize = ConfigerHelper.GetPageSize();

        /// <summary>
        /// 表中常用状态
        /// </summary>
        protected const string statusY = "Y";

        /// <summary>
        /// 表中常用状态
        /// </summary>
        protected const string statusN = "N";

        /// <summary>
        /// 当前用户ID
        /// </summary>
        protected int userID = SessionHelper.GetSeeionUserID();

        protected override HttpNotFoundResult HttpNotFound(string statusDescription)
        {
            this.Response.StatusCode = 404;
            this.Response.TrySkipIisCustomErrors = true;
            Response.Clear();
            Response.Redirect("~/Error");
            Response.End();
            return null;
        }
    }
}
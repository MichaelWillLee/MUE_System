using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MUESystem.Common.LogCommon;

namespace MUESystem.Common.SessionCommon
{
    public class SessionHelper
    {
        /// <summary>
        /// 获取UserID
        /// </summary>
        /// <returns></returns>
        public static int GetSeeionUserID()
        {
            HttpContext httpContex = HttpContext.Current;
            if (httpContex.Session["UserID"] == null) {
                Log.Error("GetSeeionUserID()-获取UserID失败");
                return -1;
            }
            return Convert.ToInt32(httpContex.Session["UserID"]);   
        }

    }
}

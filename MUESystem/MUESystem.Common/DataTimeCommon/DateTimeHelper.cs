using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUESystem.Common.LogCommon;

namespace MUESystem.Common.DateTimeCommon
{
    public class DateTimeHelper
    {
        /// <summary>
        /// 获取现在时间没有分隔的时间字符串
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowTime() {
            try
            {
                string timeNow = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                return Convert.ToDateTime(timeNow);
            }
            catch (Exception ex) {
                Log.Error("",ex);
                return System.DateTime.Now;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.Common.DataTimeCommon
{
    public class DataTimeHelper
    {
        /// <summary>
        /// 获取现在时间没有分隔的时间字符串
        /// </summary>
        /// <returns></returns>
        public static string GetNowTimeNosplit() {
            return System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        /// <summary>
        /// DateTime转换有分隔的字符串转换
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns></returns>
        public static string GetNowTimeNosplit(DateTime dt) {
            return dt.ToString("yyyyMMddHHmmssffff");
        }

        /// <summary>
        /// 获取现在有分隔的字符串转换
        /// </summary>
        /// <returns></returns>
        public static string GetNowTime() {
            return System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss: ffff");
        }

        /// <summary>
        /// DateTime转换有分隔的字符串转换
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns></returns>
        public static string GetNowTime(DateTime dt) {
            return dt.ToString("yyyy-MM-dd HH:mm:ss: ffff");
        }
    }
}

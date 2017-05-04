using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MUESystem.Common.LogCommon;

namespace MUESystem.Web.Configer
{
    public class ConfigerHelper
    {
        public static string GetVal(string key) {
            var ret =  System.Configuration.ConfigurationManager.AppSettings[key];
            if (ret == null) {
                StringBuilder sb = new StringBuilder();
                sb.Append("ConfigerHelper-GetVal-").Append(key);
                Log.Error(sb.ToString());
            }
            return ret;
        }

        /// <summary>
        /// 获取页面显示条数
        /// </summary>
        /// <returns>失败返回-1，成功返回对应配置</returns>
        public static int GetPageSize() {
            try {
                int pageSize = Convert.ToInt32(ConfigerHelper.GetVal("pageSize"));
                return pageSize;
            }catch(Exception ex){
                Log.Error("获取页面显示条数",ex );
                return -1;
            }
        }
    }
}
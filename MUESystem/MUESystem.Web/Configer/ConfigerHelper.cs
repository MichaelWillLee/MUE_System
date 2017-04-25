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
    }
}
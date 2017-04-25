using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MUESystem.Common.LogCommon
{
    public class LogHelper
    {
        private static ILog log;
        private static LogHelper logHelper = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configPath"></param>
        private LogHelper(string configPath)
        {
            if (!string.IsNullOrEmpty(configPath))
            {
                log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(configPath));
            }
            else
            {
                log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
        }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static ILog GetInstance()
        {
            logHelper = new LogHelper(null);

            return log;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static ILog GetInstance(string configPath)
        {
            logHelper = new LogHelper(configPath);

            return log;
        }

    }
}

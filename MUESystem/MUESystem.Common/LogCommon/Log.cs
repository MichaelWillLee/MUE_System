using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using MUESystem.Common.LogCommon;

namespace MUESystem.Common.LogCommon
{
    public class Log
    {
        private static readonly ILog logs = LogHelper.GetInstance();

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">object</param>
        public static void Error(object message){
            logs.Error(message);
        }

        /// <summary>
        /// 错误Exception
        /// </summary>
        /// <param name="message">object</param>
        /// <param name="exception">Exception</param>
        public static void Error(object message, Exception exception) {
            logs.Error(message,exception);
        }

        /// <summary>
        /// 错误日志格式
        ///  object[] args = new object[]{"11111111","22222222"};Log.InfoFormat("test1={0};test2={1}", args);
        /// </summary>
        /// <param name="format">string</param>
        /// <param name="args"> params object[]</param>
        public static void ErrorFormat(string format, params object[] args) {
            logs.ErrorFormat(format, args);
        }

        /// <summary>
        /// object
        /// </summary>
        /// <param name="message">object</param>
        public static void Info(object message) {
            logs.Info(message);
        }

        /// <summary>
        /// Info object&Exception
        /// </summary>
        /// <param name="message">object</param>
        /// <param name="exception">Exception</param>
        public static void Info(object message, Exception exception) {
            logs.Info(message, exception);
        }

        /// <summary>
        ///  object[] args = new object[]{"11111111","22222222"};Log.InfoFormat("test1={0};test2={1}", args);
        ///  InfoFormat
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void InfoFormat(string format, params object[] args) {
            logs.InfoFormat(format,args);
        }
    }
}
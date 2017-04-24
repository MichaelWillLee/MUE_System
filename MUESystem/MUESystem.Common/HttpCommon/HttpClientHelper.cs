﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.Common.Http
{
    public class HttpClientHelper
    {
        public static string Post(string url, string paramData)
        {
            return Post(url, paramData, Encoding.UTF8);
        }

        public static string Post(string url, string paramData, Encoding encoding)
        {
            string result = string.Empty;

            if (url.ToLower().IndexOf("https", System.StringComparison.Ordinal) > -1)
            {
                ServicePointManager.ServerCertificateValidationCallback =
                               new RemoteCertificateValidationCallback((sender, certificate, chain, errors) => { return true; });
            }

            try
            {
                var wc = new WebClient();
                if (string.IsNullOrEmpty(wc.Headers["Content-Type"]))
                    wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Encoding = encoding;

                result = wc.UploadString(url, "POST", paramData);
            }
            catch
            {
                return "Fail";
            }

            return result;
        }

        public static string Get(string url)
        {
            return Get(url, Encoding.UTF8);
        }

        public static string Get(string url, Encoding encoding)
        {
            try
            {
                var wc = new WebClient { Encoding = encoding };
                var readStream = wc.OpenRead(url);
                using (var sr = new StreamReader(readStream, encoding))
                {
                    var result = sr.ReadToEnd();
                    return result;
                }
            }
            catch
            {
                return "Fail";
            }
        }
    }
}

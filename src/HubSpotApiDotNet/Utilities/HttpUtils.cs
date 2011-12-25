using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HubSpotApiDotNet.Utilities
{
	public class HttpUtils
	{

		private const int DefaultTimeout = 100000;

		public static string SendRequestByPost(string serviceUrl, string postData)
		{
			return SendRequestByPost(serviceUrl, postData, null, DefaultTimeout);
		}
        public static string SendRequestByGet(string serviceUrl)
        {
            return SendRequestByGet(serviceUrl, null, DefaultTimeout);
        }

		public static string SendRequestByPost(string serviceUrl, string postData, System.Net.WebProxy proxy, int timeout)
		{
			WebResponse objResp;
			WebRequest objReq;
			string strResp = string.Empty;
			byte[] byteReq;

			try {
				byteReq = Encoding.UTF8.GetBytes(postData);
				objReq = WebRequest.Create(serviceUrl);
				objReq.Method = "POST";
				objReq.ContentLength = byteReq.Length;
				objReq.ContentType = "application/x-www-form-urlencoded";
				objReq.Timeout = timeout;
				if (proxy != null) {
					objReq.Proxy = proxy;
				}
				Stream OutStream = objReq.GetRequestStream();
				OutStream.Write(byteReq, 0, byteReq.Length);
				OutStream.Close();
				objResp = objReq.GetResponse();
				StreamReader sr = new StreamReader(objResp.GetResponseStream(), Encoding.UTF8, true);
				strResp += sr.ReadToEnd();
				sr.Close();
			}
			catch (Exception ex) {
				throw new ArgumentException("Error SendRequest: " + ex.Message + " " + ex.Source);
			}

			return strResp;
		}

        public static string SendRequestByGet(string serviceUrl, System.Net.WebProxy proxy, int timeout)
        {
            WebResponse objResp;
            WebRequest objReq;
            string strResp = string.Empty;

            try
            {                
                objReq = WebRequest.Create(serviceUrl);
                objReq.Method = "GET";
                objReq.Timeout = timeout;
                if (proxy != null)
                {
                    objReq.Proxy = proxy;
                }                                
                objResp = objReq.GetResponse();
                StreamReader sr = new StreamReader(objResp.GetResponseStream(), Encoding.UTF8, true);
                strResp += sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error SendRequest: " + ex.Message + " " + ex.Source);
            }

            return strResp;
        }
		
	}
}

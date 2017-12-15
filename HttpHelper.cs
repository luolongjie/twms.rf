using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
//using System.Net.Security;
//using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Rf_Wms
{
    public class HttpHelper
    {
        public static string HttpGet(string Url, string postDataStr)
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Comm.url+@"/" +Url+"?"+ postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        //private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        //{
        //    return true; //总是接受     
        //}  

      

        public static string HttpPost(string func,string postDataStr)
        {
            //byte[] buffer = Encoding.UTF8.GetBytes(func);
            //string msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            Comm.fun = Comm.url + func;

            //Comm.fun = Comm.url + Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            Comm.par = postDataStr;
            Comm.retval = "";
            //ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;//

            postDataStr = SetSpecStr(postDataStr);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Comm.url+func);
            request.Proxy = null;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = postDataStr.Length;
            request.Timeout = 10000;//yy
            //StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.UTF8);
            //writer.Write(postDataStr);
            //writer.Flush();
            //writer.Close();
            byte[] data = Encoding.UTF8.GetBytes(postDataStr);
            request.ContentLength = data.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            } 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            Comm.retval = retString;
            request.KeepAlive = false;
            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }
            System.Net.ServicePointManager.DefaultConnectionLimit = 50;
            return retString;
        }

        //public static string HttpPost(string func, string postDataStr)
        //{
        //    //byte[] buffer = Encoding.UTF8.GetBytes(func);
        //    //string msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        //    Comm.fun = Comm.url + func;

        //    //Comm.fun = Comm.url + Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        //    Comm.par = postDataStr;
        //    Comm.retval = "";
        //    //ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;//

        //    postDataStr = SetSpecStr(postDataStr);
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Comm.url + func);
        //    request.Proxy = null;
        //    request.ProtocolVersion = HttpVersion.Version10;
        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    //request.ContentLength = postDataStr.Length;
        //    request.Timeout = 10000;//yy
        //    StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.UTF8);
        //    writer.Write(postDataStr);
        //    writer.Flush();
        //    writer.Close();
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    string encoding = response.ContentEncoding;
        //    if (encoding == null || encoding.Length < 1)
        //    {
        //        encoding = "UTF-8"; //默认编码  
        //    }
        //    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
        //    string retString = reader.ReadToEnd();
        //    Comm.retval = retString;
        //    request.KeepAlive = false;
        //    if (response != null)
        //    {
        //        response.Close();
        //    }
        //    if (request != null)
        //    {
        //        request.Abort();
        //    }
        //    System.Net.ServicePointManager.DefaultConnectionLimit = 50;
        //    return retString;
        //}

        static string SetSpecStr(string str)
        {
            str = str.Replace("%", "%25");
            str = str.Replace("#","%23");
            //str = str.Replace("%", "%26");
            str = str.Replace("?", "%3F");
            str = str.Replace("/", "%2F");
            str = str.Replace("+", "%2B");
            //str = str.Replace("&", "%26");
            return str;
        }

        public string x()
        {
            //Cursor.Current = Cursors.WaitCursor;

            //string url = @"http://218.242.7.4:26060/traffic_web/inter/inter";


            //Encoding encoding = Encoding.GetEncoding("utf-8");
            //IDictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("username", "zfzd");
            //parameters.Add("password", "zfzd@1");
            //parameters.Add("license", CarID);
            //parameters.Add("color", CarIDColor);

            //HttpWebResponse response = Program.CreatePostHttpResponse(url, parameters, encoding);

            ////response.ContentLength = 1;

            //Stream stream = response.GetResponseStream();   //获取响应的字符串流  
            //StreamReader sr = new StreamReader(stream); //创建一个stream读取流  
            //string mdata = sr.ReadToEnd();   //从头读到尾，放到字符串html  
            //sr.Close();
            return "";
        }

        public static string CreatePostHttpResponse(string func, IDictionary<string, string> parameters)
        {
            HttpWebRequest request = null;
            //HTTPSQ请求  

            request = WebRequest.Create(Comm.url+func) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowWriteStreamBuffering = true;

            //如果需要POST数据     
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                Encoding charset = Encoding.GetEncoding("utf-8");
                byte[] data = charset.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            HttpWebResponse response= request.GetResponse() as HttpWebResponse;
            //response.ContentLength = 1;

            Stream stream1 = response.GetResponseStream();   //获取响应的字符串流  
            StreamReader sr = new StreamReader(stream1); //创建一个stream读取流  
            string mdata = sr.ReadToEnd();   //从头读到尾，放到字符串html  
            sr.Close();
            return mdata;
        }

        
    }
}

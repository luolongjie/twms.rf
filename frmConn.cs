using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace Rf_Wms
{
    public partial class frmConn : Form
    {
        public frmConn()
        {
            InitializeComponent();
        }

        private  long HttpPost(string str)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
          

            string murl = @"http://twmsmobile.wilmar.cn/twms-hand/api/demo"+str;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(murl);
            request.Proxy = null;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Timeout = 30000;//yy
            byte[] data = Encoding.UTF8.GetBytes("");
            request.ContentLength = data.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            sw.Start();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            sw.Stop();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
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
            
            return sw.ElapsedMilliseconds;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void TestNetWork()
        {
            //this.label1.Text = "开始测试...\n";
            //Application.DoEvents();
            long cal = 0;
            int max = 10;
            bool b = true;
            for (int i = 0; i <= max; i++)
            {
                try
                {
                    long x;
                    //if (i == 3)
                    //{
                    //    x = HttpPost(i.ToString());
                    //}
                    //else
                    //{
                        x = HttpPost("");
                    //}
                    cal += x;
                    //this.label1.Text += "第" + i.ToString() + "次测试...耗时" + x.ToString() + "ms\n";
                    this.BeginInvoke(m_CpFlHandler, new object[] { "第" + i.ToString() + "次测试...耗时" + x.ToString() + "ms\n" });
                }
                catch (Exception)
                {
                    //this.label1.Text += "第" + i.ToString() + "次测试...超时\n";
                    this.BeginInvoke(m_CpFlHandler, new object[] { "第" + i.ToString() + "次测试...超时\n" });
                    b = false;
                }
                //Application.DoEvents();
            }
            long a = cal / max;
            //this.label1.Text += "测试结束...\n";
            this.BeginInvoke(m_CpFlHandler, new object[] { "测试结束...\n" });
            if (b)
            {
                string val = "本次测试结果:\n平均耗时" + a + "ms:网络质量:";
                //this.label1.Text += "本次测试结果:\n平均耗时" + a + "ms:网络质量:";
                if (a <= 80)
                {
                    //this.label1.Text += "好";
                    val += "好";
                }
                else if (a <= 1000)
                {
                    //this.label1.Text += "中";
                    val += "中";
                }
                else
                {
                    //this.label1.Text += "差";
                    val += "差";
                }
                this.BeginInvoke(m_CpFlHandler, new object[] { val });
            }
            else
            {
                //this.label1.Text += "网络不稳定，有异常情况";
                this.BeginInvoke(m_CpFlHandler, new object[] { "网络不稳定，有异常情况" });
            }
        }


        private delegate void CopyFileHandler(string x);
        CopyFileHandler m_CpFlHandler;
        private Thread thupd;
        private void UpdateProgram()
        {

            this.BeginInvoke(m_CpFlHandler, new object[] { "123"});
        }

        void a(string x)
        {
            this.label1.Text += x;
        }

        private void frmConn_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(1000);
            this.label1.Text = "开始测试...\n";
            m_CpFlHandler = new CopyFileHandler(a);
            thupd = new Thread(TestNetWork);
            thupd.Start();
            //TestNetWork();
        }
    }
}
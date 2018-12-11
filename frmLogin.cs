using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Net;
namespace Rf_Wms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        Control co = null;
        Model.Mmsg msg = null;
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("1");
            //MessageBox.Show(x);
            Model.Mlogin m=null;
           
            try
            {
                Cursor.Current=Cursors.WaitCursor;
                //string x = HttpHelper.HttpGet("login", @"account=" + this.txtuser.Text.Trim() + @"&password=" + this.txtpassword.Text + "");
                string x = HttpHelper.HttpPost("login", @"account=" + this.txtuser.Text.Trim() + @"&password=" + this.txtpassword.Text + "&isScanned="+isScanned);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                m = (Model.Mlogin)JsonConvert.DeserializeObject(x, typeof(Model.Mlogin));
                if (m == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                Comm.userame = m.data.name;
                Comm.lcCode = m.data.lcCode;
                Comm.usercode = m.data.code;
                Comm.warehouseList = m.data.warehourseList;
                this.cmbwarehouse.DataSource = m.data.warehourseList;
                this.cmbwarehouse.DisplayMember = "name";
                this.cmbwarehouse.ValueMember = "whId";

                this.panel1.Visible = true;
                this.cmbwarehouse.Focus();
                //this.txtuser.Enabled = false;
                //this.txtpassword.Enabled = false;
                //this.btnLogin.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
            catch (WebException)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("网络错误");
                return;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                this.txtuser.Focus();
                this.txtuser.SelectAll();
                return;
                //string _txt = @"d:\" + code + " Get " + DateTime.Now.ToString("yyMMddHHmmss") + ".txt";
                //using (StreamWriter sw = new StreamWriter(_txt))
                //{
                //    errMsg = errMsg = "单据下载成功,生成文件失败,Json文件地址为 " + _txt + " 查看文件联系相关人员";
                //    sw.Write(_Json);

                //}
                //return -1;
            }
        }

        string version = "";
        string filepath1 = "";
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            version=Assembly.GetExecutingAssembly().GetName().Version.ToString().Trim();
            lblVersion.Text = "当前版本:" + version;
            Comm.version = version;
            string filePath = System.IO.Path.GetDirectoryName
               (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (filePath.Substring(0, 6) == @"file:\")
            {
                filePath = filePath.Substring(6);
            }
            filepath1 = System.IO.Path.Combine(filePath, "2.txt");
            filePath = System.IO.Path.Combine(filePath, "setting.txt");
            //MessageBox.Show("1");
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string s = sr.ReadLine();
                    Comm.url = s;
                    Comm.upd = sr.ReadLine();
                }
            }
            else
            {
                File.Create(filePath);
            }
            if (string.IsNullOrEmpty(Comm.url))
            {
                MessageBox.Show("请先配置setting.txt");
                return;
            }

            download();
            //Comm.url = @"http://10.115.2.214:7083/twms-hand/api/";
            co = txtuser;
            this.txtuser.Focus();
            //http://10.227.112.53:8091/twms-hand-web/api/login?account=admin&password=123
           
        }

        void download()
        {
            //获得版本号
            bool bv = true;
            try
            {
                string str = Comm.upd.Substring(0, Comm.upd.Length - 10);
                str = System.IO.Path.Combine(str, "version.txt");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd().Trim();
                myStreamReader.Close();
                myResponseStream.Close();
                if (retString != version)
                {
                    this.btnUpd.Visible = true;
                    this.labserversion.Text = "服务版本:" + retString;
                    bv = false;
                }
                else
                {
                    this.btnUpd.Visible = false;
                }
            }
            catch (WebException)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("网络错误");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (!File.Exists(filepath1))
            {
                if (!bv)
                {
                    btnUpd_Click(null, null);
                }
            }
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13 || this.txtuser.Text=="")
                return;
            if (DateTime.Compare(DateTime.Now.AddSeconds(-1), dt) < 0)
            {
                isScanned = "1";
                button1_Click(null, null);
               
                return;
            }
            isScanned = "0";
            this.txtpassword.Focus();
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13 || this.txtpassword.Text == "")
                return;
            this.btnLogin.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void cmbwarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            download();
            InMain();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.txtpassword.Text = "";
            this.txtuser.Text = "";
            this.txtuser.Focus();
            this.panel1.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            InMain();
        }

        void InMain()
        {
            if (this.cmbwarehouse.Text == "")
                return;
            Comm.warehousecode = this.cmbwarehouse.SelectedValue.ToString();
            Comm.warehousename = this.cmbwarehouse.Text;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string x = HttpHelper.HttpPost("getBaseInfo", @"lcCode=" + Comm.lcCode);
                msg = (Model.Mmsg)JsonConvert.DeserializeObject(x, typeof(Model.Mmsg));
                if (msg == null)
                    throw new Exception("错误信息捕捉失败");
                if (!msg.success)
                    throw new Exception(msg.msg);
                Comm.basein = (Model.MbaseIn)JsonConvert.DeserializeObject(x, typeof(Model.MbaseIn));
                if (Comm.basein == null)
                {
                    throw new Exception("数据信息捕捉失败");
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;

            }
            frmMain frm = new frmMain();
            //frmMenuPic frm = new frmMenuPic();
            frm.ShowDialog();
            panel1.Visible = false;
            this.txtpassword.Text = "";
            this.txtuser.Text = "";
            this.txtuser.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.115.2.215:9100/static/setting.txt");
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            MessageBox.Show(retString);
        }

        DateTime dt;
        string isScanned = "0";
        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            if (txtuser.Text.Length == 1)
                dt = DateTime.Now;
        }

        private void btnkeyboard_Click(object sender, EventArgs e)
        {
            RIL_IME.ShowIME("Letter Recognizer");
           
            //foreach (Control v in this.Controls)
            //{
            //    if (v is TextBox)
            //    {
            //        if (v.Enabled)
            //            v.Focus();
            //    }
            //}
            co.Focus();
            (co as TextBox).SelectionStart = (co as TextBox).Text.Length;
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pro = new System.Diagnostics.Process();
            string filePath = System.IO.Path.GetDirectoryName
               (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (filePath.Substring(0, 6) == @"file:\")
            {
                filePath = filePath.Substring(6);
            }
            filePath = System.IO.Path.Combine(filePath, "download.exe");
            pro.StartInfo.FileName = filePath;
            pro.Start();
            Application.Exit();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.ShowDialog();
        }

        private void txtuser_GotFocus(object sender, EventArgs e)
        {
            this.txtuser.SelectAll();
            co = txtuser;
        }

        private void txtpassword_GotFocus(object sender, EventArgs e)
        {
            this.txtpassword.SelectAll();
            co = txtpassword;
        }

       
    }
}
namespace Rf_Wms
{
    partial class frmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbwarehouse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.labserversion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(84, 170);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(72, 20);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(165, 170);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(84, 86);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(130, 23);
            this.txtuser.TabIndex = 5;
            this.txtuser.TextChanged += new System.EventHandler(this.txtuser_TextChanged);
            this.txtuser.GotFocus += new System.EventHandler(this.txtuser_GotFocus);
            this.txtuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuser_KeyPress);
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(84, 135);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(130, 23);
            this.txtpassword.TabIndex = 6;
            this.txtpassword.GotFocus += new System.EventHandler(this.txtpassword_GotFocus);
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.cmbwarehouse);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 140);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(136, 106);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "返回";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(29, 106);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 20);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbwarehouse
            // 
            this.cmbwarehouse.Location = new System.Drawing.Point(50, 45);
            this.cmbwarehouse.Name = "cmbwarehouse";
            this.cmbwarehouse.Size = new System.Drawing.Size(140, 23);
            this.cmbwarehouse.TabIndex = 12;
            this.cmbwarehouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbwarehouse_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(82, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "仓库信息";
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(3, 170);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(72, 20);
            this.btnkeyboard.TabIndex = 263;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpd.ForeColor = System.Drawing.Color.White;
            this.btnUpd.Location = new System.Drawing.Point(3, 200);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(72, 20);
            this.btnUpd.TabIndex = 268;
            this.btnUpd.Text = "更新";
            this.btnUpd.Visible = false;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(60, 224);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(120, 16);
            this.lblVersion.Text = "当前版本:1.1.0.9";
            // 
            // labserversion
            // 
            this.labserversion.ForeColor = System.Drawing.Color.Red;
            this.labserversion.Location = new System.Drawing.Point(60, 252);
            this.labserversion.Name = "labserversion";
            this.labserversion.Size = new System.Drawing.Size(140, 16);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 30);
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
            this.pictureBox14.Location = new System.Drawing.Point(216, 0);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(20, 30);
            this.pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 30);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(50, 135);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 30);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(29, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 16);
            this.label1.Text = "登录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labserversion);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbwarehouse;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label labserversion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}


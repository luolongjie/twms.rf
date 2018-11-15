namespace Rf_Wms.Out
{
    partial class frmBalOper
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.txtblno = new System.Windows.Forms.TextBox();
            this.txtminqty = new System.Windows.Forms.TextBox();
            this.txtcommonqty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labblNoqty = new System.Windows.Forms.Label();
            this.labblno = new System.Windows.Forms.Label();
            this.labunitname = new System.Windows.Forms.Label();
            this.labminunitname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.Text = "商品/追溯码";
            // 
            // txtbarcode
            // 
            this.txtbarcode.Location = new System.Drawing.Point(97, 26);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(131, 23);
            this.txtbarcode.TabIndex = 2;
            this.txtbarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarcode_KeyPress);
            // 
            // txtblno
            // 
            this.txtblno.Enabled = false;
            this.txtblno.Location = new System.Drawing.Point(97, 112);
            this.txtblno.Name = "txtblno";
            this.txtblno.Size = new System.Drawing.Size(131, 23);
            this.txtblno.TabIndex = 4;
            this.txtblno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtblno_KeyPress);
            // 
            // txtminqty
            // 
            this.txtminqty.Enabled = false;
            this.txtminqty.Location = new System.Drawing.Point(156, 233);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(47, 23);
            this.txtminqty.TabIndex = 58;
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.Enabled = false;
            this.txtcommonqty.Location = new System.Drawing.Point(70, 233);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(47, 23);
            this.txtcommonqty.TabIndex = 57;
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(3, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.Text = "甩货数量";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "提单号";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.Text = "出库单号";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(83, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 20);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(142, 265);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 64;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(3, 59);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(225, 35);
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(25, 265);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(72, 20);
            this.btnkeyboard.TabIndex = 321;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.Text = "提单数量";
            // 
            // labblNoqty
            // 
            this.labblNoqty.Location = new System.Drawing.Point(97, 195);
            this.labblNoqty.Name = "labblNoqty";
            this.labblNoqty.Size = new System.Drawing.Size(131, 20);
            // 
            // labblno
            // 
            this.labblno.Location = new System.Drawing.Point(97, 154);
            this.labblno.Name = "labblno";
            this.labblno.Size = new System.Drawing.Size(131, 20);
            // 
            // labunitname
            // 
            this.labunitname.Location = new System.Drawing.Point(121, 236);
            this.labunitname.Name = "labunitname";
            this.labunitname.Size = new System.Drawing.Size(30, 20);
            // 
            // labminunitname
            // 
            this.labminunitname.Location = new System.Drawing.Point(206, 236);
            this.labminunitname.Name = "labminunitname";
            this.labminunitname.Size = new System.Drawing.Size(30, 20);
            // 
            // frmBalOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.labminunitname);
            this.Controls.Add(this.labunitname);
            this.Controls.Add(this.labblno);
            this.Controls.Add(this.labblNoqty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtminqty);
            this.Controls.Add(this.txtcommonqty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtblno);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBalOper";
            this.Text = "结余操作";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.TextBox txtblno;
        private System.Windows.Forms.TextBox txtminqty;
        private System.Windows.Forms.TextBox txtcommonqty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labblNoqty;
        private System.Windows.Forms.Label labblno;
        private System.Windows.Forms.Label labunitname;
        private System.Windows.Forms.Label labminunitname;
    }
}
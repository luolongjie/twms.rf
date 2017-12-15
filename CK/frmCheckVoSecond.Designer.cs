namespace Rf_Wms.CK
{
    partial class frmCheckVoSecond
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
            this.label4 = new System.Windows.Forms.Label();
            this.txttraycode = new System.Windows.Forms.TextBox();
            this.labinfo = new System.Windows.Forms.Label();
            this.labsIname = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtminqty = new System.Windows.Forms.TextBox();
            this.labminunit = new System.Windows.Forms.Label();
            this.labcommonUnit = new System.Windows.Forms.Label();
            this.txtcommonqty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSlId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtorderid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.labqtyall = new System.Windows.Forms.Label();
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.labbatch = new System.Windows.Forms.Label();
            this.labmaterialcode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "托盘条码";
            // 
            // txttraycode
            // 
            this.txttraycode.Enabled = false;
            this.txttraycode.Location = new System.Drawing.Point(69, 167);
            this.txttraycode.Name = "txttraycode";
            this.txttraycode.Size = new System.Drawing.Size(140, 23);
            this.txttraycode.TabIndex = 271;
            this.txttraycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttraycode_KeyPress);
            // 
            // labinfo
            // 
            this.labinfo.Location = new System.Drawing.Point(0, 195);
            this.labinfo.Name = "labinfo";
            this.labinfo.Size = new System.Drawing.Size(238, 20);
            // 
            // labsIname
            // 
            this.labsIname.Location = new System.Drawing.Point(155, 60);
            this.labsIname.Name = "labsIname";
            this.labsIname.Size = new System.Drawing.Size(80, 20);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(138, 274);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 323;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtminqty
            // 
            this.txtminqty.Enabled = false;
            this.txtminqty.Location = new System.Drawing.Point(134, 219);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(47, 23);
            this.txtminqty.TabIndex = 322;
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // labminunit
            // 
            this.labminunit.Location = new System.Drawing.Point(183, 222);
            this.labminunit.Name = "labminunit";
            this.labminunit.Size = new System.Drawing.Size(44, 20);
            this.labminunit.Text = "单位2";
            // 
            // labcommonUnit
            // 
            this.labcommonUnit.Location = new System.Drawing.Point(95, 222);
            this.labcommonUnit.Name = "labcommonUnit";
            this.labcommonUnit.Size = new System.Drawing.Size(45, 20);
            this.labcommonUnit.Text = "单位1";
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.Enabled = false;
            this.txtcommonqty.Location = new System.Drawing.Point(43, 219);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(47, 23);
            this.txtcommonqty.TabIndex = 321;
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(0, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.Text = "数量";
            // 
            // txtSlId
            // 
            this.txtSlId.Location = new System.Drawing.Point(69, 58);
            this.txtSlId.Name = "txtSlId";
            this.txtSlId.Size = new System.Drawing.Size(80, 23);
            this.txtSlId.TabIndex = 320;
            this.txtSlId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlId_KeyPress);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.Text = "库位编码";
            // 
            // txtorderid
            // 
            this.txtorderid.Location = new System.Drawing.Point(69, 5);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(140, 23);
            this.txtorderid.TabIndex = 319;
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "盘点单号";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(29, 248);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 20);
            this.btnNext.TabIndex = 331;
            this.btnNext.Text = "跳过";
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(138, 248);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(72, 20);
            this.btnFinish.TabIndex = 342;
            this.btnFinish.Text = "结束库位";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // labqtyall
            // 
            this.labqtyall.ForeColor = System.Drawing.Color.Red;
            this.labqtyall.Location = new System.Drawing.Point(0, 34);
            this.labqtyall.Name = "labqtyall";
            this.labqtyall.Size = new System.Drawing.Size(230, 16);
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(29, 274);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(72, 20);
            this.btnkeyboard.TabIndex = 353;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // labbatch
            // 
            this.labbatch.Location = new System.Drawing.Point(0, 138);
            this.labbatch.Name = "labbatch";
            this.labbatch.Size = new System.Drawing.Size(230, 16);
            // 
            // labmaterialcode
            // 
            this.labmaterialcode.Location = new System.Drawing.Point(0, 81);
            this.labmaterialcode.Name = "labmaterialcode";
            this.labmaterialcode.Size = new System.Drawing.Size(235, 55);
            this.labmaterialcode.Text = "是撒大声地高但是的水电费高但是覆盖是打钩富商大贾是打钩富商大贾";
            // 
            // frmCheckVoSecond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.labmaterialcode);
            this.Controls.Add(this.labbatch);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.labqtyall);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txttraycode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labinfo);
            this.Controls.Add(this.labsIname);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtminqty);
            this.Controls.Add(this.labminunit);
            this.Controls.Add(this.labcommonUnit);
            this.Controls.Add(this.txtcommonqty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSlId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckVoSecond";
            this.Text = "复盘";
            this.Load += new System.EventHandler(this.frmCheckVoSecond_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttraycode;
        private System.Windows.Forms.Label labinfo;
        private System.Windows.Forms.Label labsIname;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtminqty;
        private System.Windows.Forms.Label labminunit;
        private System.Windows.Forms.Label labcommonUnit;
        private System.Windows.Forms.TextBox txtcommonqty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSlId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label labqtyall;
        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.Label labbatch;
        private System.Windows.Forms.Label labmaterialcode;
    }
}
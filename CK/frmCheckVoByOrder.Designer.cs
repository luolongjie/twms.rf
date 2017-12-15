namespace Rf_Wms.CK
{
    partial class frmCheckVoByOrder
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
            this.btnError = new System.Windows.Forms.Button();
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
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCheckAgain = new System.Windows.Forms.Button();
            this.labinfo = new System.Windows.Forms.Label();
            this.laberr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxrr = new System.Windows.Forms.ComboBox();
            this.btnkeybord = new System.Windows.Forms.Button();
            this.labmaterialcode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(7, 272);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(72, 20);
            this.btnError.TabIndex = 278;
            this.btnError.Text = "异常";
            this.btnError.Visible = false;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // labsIname
            // 
            this.labsIname.Location = new System.Drawing.Point(152, 69);
            this.labsIname.Name = "labsIname";
            this.labsIname.Size = new System.Drawing.Size(85, 20);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(162, 246);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 275;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtminqty
            // 
            this.txtminqty.Location = new System.Drawing.Point(131, 192);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(47, 23);
            this.txtminqty.TabIndex = 274;
            this.txtminqty.GotFocus += new System.EventHandler(this.txtminqty_GotFocus);
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // labminunit
            // 
            this.labminunit.Location = new System.Drawing.Point(180, 195);
            this.labminunit.Name = "labminunit";
            this.labminunit.Size = new System.Drawing.Size(44, 20);
            this.labminunit.Text = "单位2";
            // 
            // labcommonUnit
            // 
            this.labcommonUnit.Location = new System.Drawing.Point(92, 195);
            this.labcommonUnit.Name = "labcommonUnit";
            this.labcommonUnit.Size = new System.Drawing.Size(45, 20);
            this.labcommonUnit.Text = "单位1";
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.Location = new System.Drawing.Point(40, 192);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(47, 23);
            this.txtcommonqty.TabIndex = 273;
            this.txtcommonqty.GotFocus += new System.EventHandler(this.txtcommonqty_GotFocus);
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(1, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.Text = "数量";
            // 
            // txtSlId
            // 
            this.txtSlId.Location = new System.Drawing.Point(70, 66);
            this.txtSlId.Name = "txtSlId";
            this.txtSlId.Size = new System.Drawing.Size(76, 23);
            this.txtSlId.TabIndex = 272;
            this.txtSlId.GotFocus += new System.EventHandler(this.txtSlId_GotFocus);
            this.txtSlId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlId_KeyPress);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(1, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.Text = "库位编码";
            // 
            // txtorderid
            // 
            this.txtorderid.Location = new System.Drawing.Point(70, 4);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(154, 23);
            this.txtorderid.TabIndex = 270;
            this.txtorderid.GotFocus += new System.EventHandler(this.txtorderid_GotFocus);
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "盘点单号";
            // 
            // txtbarcode
            // 
            this.txtbarcode.Location = new System.Drawing.Point(70, 281);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(140, 23);
            this.txtbarcode.TabIndex = 305;
            this.txtbarcode.Visible = false;
            this.txtbarcode.GotFocus += new System.EventHandler(this.txtbarcode_GotFocus);
            this.txtbarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarcode_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(2, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.Text = "商品码";
            this.label5.Visible = false;
            // 
            // btnCheckAgain
            // 
            this.btnCheckAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnCheckAgain.ForeColor = System.Drawing.Color.White;
            this.btnCheckAgain.Location = new System.Drawing.Point(4, 246);
            this.btnCheckAgain.Name = "btnCheckAgain";
            this.btnCheckAgain.Size = new System.Drawing.Size(72, 20);
            this.btnCheckAgain.TabIndex = 307;
            this.btnCheckAgain.Text = "异常维护";
            this.btnCheckAgain.Click += new System.EventHandler(this.btnCheckAgain_Click);
            // 
            // labinfo
            // 
            this.labinfo.Location = new System.Drawing.Point(0, 161);
            this.labinfo.Name = "labinfo";
            this.labinfo.Size = new System.Drawing.Size(238, 20);
            // 
            // laberr
            // 
            this.laberr.Location = new System.Drawing.Point(0, 222);
            this.laberr.Name = "laberr";
            this.laberr.Size = new System.Drawing.Size(238, 20);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "库区";
            // 
            // cbxrr
            // 
            this.cbxrr.Location = new System.Drawing.Point(70, 34);
            this.cbxrr.Name = "cbxrr";
            this.cbxrr.Size = new System.Drawing.Size(124, 23);
            this.cbxrr.TabIndex = 320;
            this.cbxrr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxrr_KeyPress);
            // 
            // btnkeybord
            // 
            this.btnkeybord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeybord.ForeColor = System.Drawing.Color.White;
            this.btnkeybord.Location = new System.Drawing.Point(83, 246);
            this.btnkeybord.Name = "btnkeybord";
            this.btnkeybord.Size = new System.Drawing.Size(72, 20);
            this.btnkeybord.TabIndex = 334;
            this.btnkeybord.Text = "键盘";
            this.btnkeybord.Click += new System.EventHandler(this.btnkeybord_Click);
            // 
            // labmaterialcode
            // 
            this.labmaterialcode.Location = new System.Drawing.Point(1, 102);
            this.labmaterialcode.Name = "labmaterialcode";
            this.labmaterialcode.Size = new System.Drawing.Size(235, 55);
            // 
            // frmCheckVoByOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.labmaterialcode);
            this.Controls.Add(this.btnkeybord);
            this.Controls.Add(this.cbxrr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.laberr);
            this.Controls.Add(this.btnCheckAgain);
            this.Controls.Add(this.labinfo);
            this.Controls.Add(this.btnError);
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
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckVoByOrder";
            this.Text = "初盘";
            this.Load += new System.EventHandler(this.frmCheckVoByOrder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnError;
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
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCheckAgain;
        private System.Windows.Forms.Label labinfo;
        private System.Windows.Forms.Label laberr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxrr;
        private System.Windows.Forms.Button btnkeybord;
        private System.Windows.Forms.Label labmaterialcode;
    }
}
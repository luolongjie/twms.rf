namespace Rf_Wms.Out
{
    partial class frmPackingUp
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
            this.btnExit = new System.Windows.Forms.Button();
            this.txtminqty = new System.Windows.Forms.TextBox();
            this.labminunit = new System.Windows.Forms.Label();
            this.labcommonUnit = new System.Windows.Forms.Label();
            this.txtcommonqty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbtoslname = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtslid = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labneedqty = new System.Windows.Forms.Label();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.txttraycode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtorderid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labSlname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.labtrayqty = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtToTraycode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnData = new System.Windows.Forms.Button();
            this.btnAssistance = new System.Windows.Forms.Button();
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.txttoslname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxrr = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(159, 268);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 69;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtminqty
            // 
            this.txtminqty.Location = new System.Drawing.Point(134, 187);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(55, 23);
            this.txtminqty.TabIndex = 68;
            this.txtminqty.GotFocus += new System.EventHandler(this.txtminqty_GotFocus);
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // labminunit
            // 
            this.labminunit.Location = new System.Drawing.Point(192, 188);
            this.labminunit.Name = "labminunit";
            this.labminunit.Size = new System.Drawing.Size(40, 20);
            this.labminunit.Text = "单位";
            // 
            // labcommonUnit
            // 
            this.labcommonUnit.Location = new System.Drawing.Point(95, 188);
            this.labcommonUnit.Name = "labcommonUnit";
            this.labcommonUnit.Size = new System.Drawing.Size(40, 20);
            this.labcommonUnit.Text = "单位";
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.Location = new System.Drawing.Point(40, 187);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(55, 23);
            this.txtcommonqty.TabIndex = 67;
            this.txtcommonqty.GotFocus += new System.EventHandler(this.txtcommonqty_GotFocus);
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(1, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.Text = "数量";
            // 
            // cmbtoslname
            // 
            this.cmbtoslname.Location = new System.Drawing.Point(159, 239);
            this.cmbtoslname.Name = "cmbtoslname";
            this.cmbtoslname.Size = new System.Drawing.Size(78, 23);
            this.cmbtoslname.TabIndex = 66;
            this.cmbtoslname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbtoslname_KeyPress);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(1, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 20);
            this.label12.Text = "暂存区";
            // 
            // txtslid
            // 
            this.txtslid.Location = new System.Drawing.Point(73, 268);
            this.txtslid.Name = "txtslid";
            this.txtslid.Size = new System.Drawing.Size(151, 23);
            this.txtslid.TabIndex = 65;
            this.txtslid.Visible = false;
            this.txtslid.GotFocus += new System.EventHandler(this.txtslid_GotFocus);
            this.txtslid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtslid_KeyPress);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(1, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.Text = "库位条码";
            this.label11.Visible = false;
            // 
            // labneedqty
            // 
            this.labneedqty.Location = new System.Drawing.Point(73, 112);
            this.labneedqty.Name = "labneedqty";
            this.labneedqty.Size = new System.Drawing.Size(164, 16);
            this.labneedqty.Text = "3000千克0瓶 2017-01-01";
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(1, 74);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(230, 34);
            this.labmaterialname.Text = "物料描述";
            // 
            // txttraycode
            // 
            this.txttraycode.Location = new System.Drawing.Point(73, 139);
            this.txttraycode.Name = "txttraycode";
            this.txttraycode.Size = new System.Drawing.Size(151, 23);
            this.txttraycode.TabIndex = 62;
            this.txttraycode.GotFocus += new System.EventHandler(this.txttraycode_GotFocus);
            this.txttraycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttraycode_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "托盘条码";
            // 
            // txtorderid
            // 
            this.txtorderid.Location = new System.Drawing.Point(73, 2);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(102, 23);
            this.txtorderid.TabIndex = 61;
            this.txtorderid.GotFocus += new System.EventHandler(this.txtorderid_GotFocus);
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "拣货单号";
            // 
            // labSlname
            // 
            this.labSlname.Location = new System.Drawing.Point(73, 54);
            this.labSlname.Name = "labSlname";
            this.labSlname.Size = new System.Drawing.Size(87, 20);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "应拣库位";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(178, 52);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(57, 20);
            this.btnNext.TabIndex = 89;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // labtrayqty
            // 
            this.labtrayqty.Location = new System.Drawing.Point(73, 162);
            this.labtrayqty.Name = "labtrayqty";
            this.labtrayqty.Size = new System.Drawing.Size(158, 20);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(1, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 20);
            this.label10.Text = "托盘数量";
            // 
            // txtToTraycode
            // 
            this.txtToTraycode.Location = new System.Drawing.Point(73, 213);
            this.txtToTraycode.Name = "txtToTraycode";
            this.txtToTraycode.Size = new System.Drawing.Size(151, 23);
            this.txtToTraycode.TabIndex = 99;
            this.txtToTraycode.GotFocus += new System.EventHandler(this.txtToTraycode_GotFocus);
            this.txtToTraycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToTraycode_KeyPress);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(1, 217);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 20);
            this.label14.Text = "移入托盘";
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnData.ForeColor = System.Drawing.Color.White;
            this.btnData.Location = new System.Drawing.Point(84, 268);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(72, 20);
            this.btnData.TabIndex = 101;
            this.btnData.Text = "列表";
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnAssistance
            // 
            this.btnAssistance.Location = new System.Drawing.Point(178, 3);
            this.btnAssistance.Name = "btnAssistance";
            this.btnAssistance.Size = new System.Drawing.Size(57, 20);
            this.btnAssistance.TabIndex = 223;
            this.btnAssistance.Click += new System.EventHandler(this.btnAssistance_Click);
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(9, 268);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(72, 20);
            this.btnkeyboard.TabIndex = 271;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // txttoslname
            // 
            this.txttoslname.Location = new System.Drawing.Point(73, 239);
            this.txttoslname.Name = "txttoslname";
            this.txttoslname.Size = new System.Drawing.Size(80, 23);
            this.txttoslname.TabIndex = 288;
            this.txttoslname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttoslname_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.Text = "库区列表";
            // 
            // cbxrr
            // 
            this.cbxrr.Location = new System.Drawing.Point(73, 27);
            this.cbxrr.Name = "cbxrr";
            this.cbxrr.Size = new System.Drawing.Size(105, 23);
            this.cbxrr.TabIndex = 307;
            this.cbxrr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxrr_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.Text = "应拣数量";
            // 
            // frmPackingUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxrr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttoslname);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.btnAssistance);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.txtToTraycode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.labtrayqty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.labSlname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtminqty);
            this.Controls.Add(this.labminunit);
            this.Controls.Add(this.txtcommonqty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbtoslname);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labneedqty);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.txttraycode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labcommonUnit);
            this.Controls.Add(this.txtslid);
            this.Controls.Add(this.label11);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPackingUp";
            this.Text = "拣货";
            this.Load += new System.EventHandler(this.frmPackingUp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtminqty;
        private System.Windows.Forms.Label labminunit;
        private System.Windows.Forms.Label labcommonUnit;
        private System.Windows.Forms.TextBox txtcommonqty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbtoslname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtslid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labneedqty;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.TextBox txttraycode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labSlname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label labtrayqty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtToTraycode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnAssistance;
        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.TextBox txttoslname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxrr;
        private System.Windows.Forms.Label label5;
    }
}
namespace Rf_Wms.Out
{
    partial class frmStockOutCheck
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
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labqty = new System.Windows.Forms.Label();
            this.labminunit1 = new System.Windows.Forms.Label();
            this.txtminqty = new System.Windows.Forms.TextBox();
            this.labcommonUnit1 = new System.Windows.Forms.Label();
            this.txtcommonqty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.labcheckqty = new System.Windows.Forms.Label();
            this.labbatch = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labpdata = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.labminunit = new System.Windows.Forms.Label();
            this.txtcheckminqty = new System.Windows.Forms.TextBox();
            this.labcommonUnit = new System.Windows.Forms.Label();
            this.txtcheckqty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnData = new System.Windows.Forms.Button();
            this.lbltraycode = new System.Windows.Forms.Label();
            this.lblpickno = new System.Windows.Forms.Label();
            this.btnchange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(1, 266);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(57, 20);
            this.btnkeyboard.TabIndex = 264;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(178, 266);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 20);
            this.btnExit.TabIndex = 263;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "托盘条码";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "拣货单号";
            // 
            // labqty
            // 
            this.labqty.Location = new System.Drawing.Point(93, 60);
            this.labqty.Name = "labqty";
            this.labqty.Size = new System.Drawing.Size(140, 20);
            // 
            // labminunit1
            // 
            this.labminunit1.Location = new System.Drawing.Point(205, 89);
            this.labminunit1.Name = "labminunit1";
            this.labminunit1.Size = new System.Drawing.Size(25, 20);
            this.labminunit1.Text = "个";
            // 
            // txtminqty
            // 
            this.txtminqty.Enabled = false;
            this.txtminqty.Location = new System.Drawing.Point(150, 86);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(55, 23);
            this.txtminqty.TabIndex = 276;
            this.txtminqty.GotFocus += new System.EventHandler(this.txtminqty_GotFocus);
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // labcommonUnit1
            // 
            this.labcommonUnit1.Location = new System.Drawing.Point(127, 89);
            this.labcommonUnit1.Name = "labcommonUnit1";
            this.labcommonUnit1.Size = new System.Drawing.Size(20, 20);
            this.labcommonUnit1.Text = "箱";
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.Enabled = false;
            this.txtcommonqty.Location = new System.Drawing.Point(66, 86);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(55, 23);
            this.txtcommonqty.TabIndex = 275;
            this.txtcommonqty.GotFocus += new System.EventHandler(this.txtcommonqty_GotFocus);
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(5, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.Text = "复核量";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.Text = "托盘数量";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(163, 190);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 20);
            this.btnNext.TabIndex = 298;
            this.btnNext.Text = "跳过";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // labcheckqty
            // 
            this.labcheckqty.Location = new System.Drawing.Point(4, 213);
            this.labcheckqty.Name = "labcheckqty";
            this.labcheckqty.Size = new System.Drawing.Size(225, 20);
            // 
            // labbatch
            // 
            this.labbatch.Location = new System.Drawing.Point(93, 190);
            this.labbatch.Name = "labbatch";
            this.labbatch.Size = new System.Drawing.Size(137, 16);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.Text = "批次";
            // 
            // labpdata
            // 
            this.labpdata.Location = new System.Drawing.Point(93, 168);
            this.labpdata.Name = "labpdata";
            this.labpdata.Size = new System.Drawing.Size(137, 16);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(4, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 16);
            this.label10.Text = "生产日期";
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(4, 117);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(230, 44);
            // 
            // labminunit
            // 
            this.labminunit.Location = new System.Drawing.Point(198, 236);
            this.labminunit.Name = "labminunit";
            this.labminunit.Size = new System.Drawing.Size(40, 20);
            // 
            // txtcheckminqty
            // 
            this.txtcheckminqty.Enabled = false;
            this.txtcheckminqty.Location = new System.Drawing.Point(140, 233);
            this.txtcheckminqty.Name = "txtcheckminqty";
            this.txtcheckminqty.Size = new System.Drawing.Size(55, 23);
            this.txtcheckminqty.TabIndex = 310;
            this.txtcheckminqty.GotFocus += new System.EventHandler(this.txtcheckminqty_GotFocus);
            this.txtcheckminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcheckminqty_KeyPress);
            // 
            // labcommonUnit
            // 
            this.labcommonUnit.Location = new System.Drawing.Point(98, 236);
            this.labcommonUnit.Name = "labcommonUnit";
            this.labcommonUnit.Size = new System.Drawing.Size(40, 20);
            // 
            // txtcheckqty
            // 
            this.txtcheckqty.Enabled = false;
            this.txtcheckqty.Location = new System.Drawing.Point(46, 233);
            this.txtcheckqty.Name = "txtcheckqty";
            this.txtcheckqty.Size = new System.Drawing.Size(50, 23);
            this.txtcheckqty.TabIndex = 309;
            this.txtcheckqty.GotFocus += new System.EventHandler(this.txtcheckqty_GotFocus);
            this.txtcheckqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcheckqty_KeyPress);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 20);
            this.label9.Text = "数量";
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnData.ForeColor = System.Drawing.Color.White;
            this.btnData.Location = new System.Drawing.Point(119, 266);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(57, 20);
            this.btnData.TabIndex = 327;
            this.btnData.Text = "列表";
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // lbltraycode
            // 
            this.lbltraycode.Location = new System.Drawing.Point(88, 30);
            this.lbltraycode.Name = "lbltraycode";
            this.lbltraycode.Size = new System.Drawing.Size(137, 16);
            // 
            // lblpickno
            // 
            this.lblpickno.Location = new System.Drawing.Point(88, 6);
            this.lblpickno.Name = "lblpickno";
            this.lblpickno.Size = new System.Drawing.Size(137, 16);
            // 
            // btnchange
            // 
            this.btnchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnchange.ForeColor = System.Drawing.Color.White;
            this.btnchange.Location = new System.Drawing.Point(60, 266);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(57, 20);
            this.btnchange.TabIndex = 344;
            this.btnchange.Text = "提单";
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // frmStockOutCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.btnchange);
            this.Controls.Add(this.lbltraycode);
            this.Controls.Add(this.lblpickno);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.labminunit);
            this.Controls.Add(this.txtcheckminqty);
            this.Controls.Add(this.labcommonUnit);
            this.Controls.Add(this.txtcheckqty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.labcheckqty);
            this.Controls.Add(this.labbatch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labpdata);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labqty);
            this.Controls.Add(this.labminunit1);
            this.Controls.Add(this.txtminqty);
            this.Controls.Add(this.labcommonUnit1);
            this.Controls.Add(this.txtcommonqty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockOutCheck";
            this.Text = "复核";
            this.Load += new System.EventHandler(this.frmStockOutCheck_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labqty;
        private System.Windows.Forms.Label labminunit1;
        private System.Windows.Forms.TextBox txtminqty;
        private System.Windows.Forms.Label labcommonUnit1;
        private System.Windows.Forms.TextBox txtcommonqty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label labcheckqty;
        private System.Windows.Forms.Label labbatch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labpdata;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.Label labminunit;
        private System.Windows.Forms.TextBox txtcheckminqty;
        private System.Windows.Forms.Label labcommonUnit;
        private System.Windows.Forms.TextBox txtcheckqty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Label lbltraycode;
        private System.Windows.Forms.Label lblpickno;
        private System.Windows.Forms.Button btnchange;
    }
}
namespace Rf_Wms.Out
{
    partial class frmNStockOutMaterial
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
            this.lbltraycode = new System.Windows.Forms.Label();
            this.lblpickno = new System.Windows.Forms.Label();
            this.labqty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.labminunit = new System.Windows.Forms.Label();
            this.txtminqty = new System.Windows.Forms.TextBox();
            this.labcommonUnit = new System.Windows.Forms.Label();
            this.txtcommonqty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labcheckqty = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbltraycode
            // 
            this.lbltraycode.Location = new System.Drawing.Point(79, 60);
            this.lbltraycode.Name = "lbltraycode";
            this.lbltraycode.Size = new System.Drawing.Size(150, 16);
            // 
            // lblpickno
            // 
            this.lblpickno.Location = new System.Drawing.Point(79, 36);
            this.lblpickno.Name = "lblpickno";
            this.lblpickno.Size = new System.Drawing.Size(150, 16);
            // 
            // labqty
            // 
            this.labqty.Location = new System.Drawing.Point(79, 157);
            this.labqty.Name = "labqty";
            this.labqty.Size = new System.Drawing.Size(137, 20);
            this.labqty.Text = "3000千克0瓶 2017-01-01";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "拣货数量";
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(7, 278);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(60, 20);
            this.btnkeyboard.TabIndex = 330;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnData.ForeColor = System.Drawing.Color.White;
            this.btnData.Location = new System.Drawing.Point(89, 278);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(60, 20);
            this.btnData.TabIndex = 329;
            this.btnData.Text = "列表";
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(3, 87);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(220, 59);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(171, 278);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 20);
            this.btnExit.TabIndex = 328;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labminunit
            // 
            this.labminunit.Location = new System.Drawing.Point(187, 253);
            this.labminunit.Name = "labminunit";
            this.labminunit.Size = new System.Drawing.Size(44, 20);
            this.labminunit.Text = "单位2";
            // 
            // txtminqty
            // 
            this.txtminqty.Enabled = false;
            this.txtminqty.Location = new System.Drawing.Point(138, 250);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(47, 23);
            this.txtminqty.TabIndex = 327;
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // labcommonUnit
            // 
            this.labcommonUnit.Location = new System.Drawing.Point(99, 253);
            this.labcommonUnit.Name = "labcommonUnit";
            this.labcommonUnit.Size = new System.Drawing.Size(45, 20);
            this.labcommonUnit.Text = "单位1";
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.Enabled = false;
            this.txtcommonqty.Location = new System.Drawing.Point(47, 250);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(47, 23);
            this.txtcommonqty.TabIndex = 326;
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(3, 253);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.Text = "数量";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "托盘条码";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "拣货单号";
            // 
            // txtbarcode
            // 
            this.txtbarcode.Location = new System.Drawing.Point(83, 3);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(140, 23);
            this.txtbarcode.TabIndex = 350;
            this.txtbarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarcode_KeyPress);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.Text = "商品码";
            // 
            // labcheckqty
            // 
            this.labcheckqty.Location = new System.Drawing.Point(79, 183);
            this.labcheckqty.Name = "labcheckqty";
            this.labcheckqty.Size = new System.Drawing.Size(137, 20);
            this.labcheckqty.Text = "3000千克0瓶 2017-01-01";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.Text = "复核数量";
            // 
            // frmNStockOutMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.labcheckqty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbltraycode);
            this.Controls.Add(this.lblpickno);
            this.Controls.Add(this.labqty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labminunit);
            this.Controls.Add(this.txtminqty);
            this.Controls.Add(this.labcommonUnit);
            this.Controls.Add(this.txtcommonqty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNStockOutMaterial";
            this.Text = "二次拣货";
            this.Load += new System.EventHandler(this.frmNStockOutMaterial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbltraycode;
        private System.Windows.Forms.Label lblpickno;
        private System.Windows.Forms.Label labqty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labminunit;
        private System.Windows.Forms.TextBox txtminqty;
        private System.Windows.Forms.Label labcommonUnit;
        private System.Windows.Forms.TextBox txtcommonqty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labcheckqty;
        private System.Windows.Forms.Label label6;
    }
}
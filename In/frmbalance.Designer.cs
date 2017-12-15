namespace Rf_Wms.In
{
    partial class frmbalance
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtorderid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsorderid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labminunit = new System.Windows.Forms.Label();
            this.txtminqty = new System.Windows.Forms.TextBox();
            this.labcommonUnit = new System.Windows.Forms.Label();
            this.txtcommonqty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.labneedqty = new System.Windows.Forms.Label();
            this.btnkeybord = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labsurplus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtorderid
            // 
            this.txtorderid.Enabled = false;
            this.txtorderid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtorderid.Location = new System.Drawing.Point(84, 9);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(150, 23);
            this.txtorderid.TabIndex = 3;
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "合单号";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(158, 272);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 45;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtbarcode
            // 
            this.txtbarcode.Enabled = false;
            this.txtbarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtbarcode.Location = new System.Drawing.Point(84, 38);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(150, 23);
            this.txtbarcode.TabIndex = 47;
            this.txtbarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarcode_KeyPress);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label5.Location = new System.Drawing.Point(2, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.Text = "商品码";
            // 
            // txtsorderid
            // 
            this.txtsorderid.Enabled = false;
            this.txtsorderid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtsorderid.Location = new System.Drawing.Point(84, 168);
            this.txtsorderid.Name = "txtsorderid";
            this.txtsorderid.Size = new System.Drawing.Size(150, 23);
            this.txtsorderid.TabIndex = 50;
            this.txtsorderid.GotFocus += new System.EventHandler(this.txtsorderid_GotFocus);
            this.txtsorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsorderid_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.Text = "退货单号";
            this.label2.ParentChanged += new System.EventHandler(this.label2_ParentChanged);
            // 
            // labminunit
            // 
            this.labminunit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labminunit.Location = new System.Drawing.Point(191, 238);
            this.labminunit.Name = "labminunit";
            this.labminunit.Size = new System.Drawing.Size(44, 20);
            // 
            // txtminqty
            // 
            this.txtminqty.Enabled = false;
            this.txtminqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtminqty.Location = new System.Drawing.Point(144, 237);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(47, 23);
            this.txtminqty.TabIndex = 58;
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // labcommonUnit
            // 
            this.labcommonUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labcommonUnit.Location = new System.Drawing.Point(109, 238);
            this.labcommonUnit.Name = "labcommonUnit";
            this.labcommonUnit.Size = new System.Drawing.Size(45, 20);
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.Enabled = false;
            this.txtcommonqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtcommonqty.Location = new System.Drawing.Point(56, 237);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(47, 23);
            this.txtcommonqty.TabIndex = 57;
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label13.Location = new System.Drawing.Point(2, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.Text = "结余量";
            // 
            // labneedqty
            // 
            this.labneedqty.Location = new System.Drawing.Point(2, 201);
            this.labneedqty.Name = "labneedqty";
            this.labneedqty.Size = new System.Drawing.Size(226, 20);
            // 
            // btnkeybord
            // 
            this.btnkeybord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeybord.ForeColor = System.Drawing.Color.White;
            this.btnkeybord.Location = new System.Drawing.Point(8, 272);
            this.btnkeybord.Name = "btnkeybord";
            this.btnkeybord.Size = new System.Drawing.Size(72, 20);
            this.btnkeybord.TabIndex = 72;
            this.btnkeybord.Text = "键盘";
            this.btnkeybord.Click += new System.EventHandler(this.btnkeybord_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(83, 272);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 20);
            this.btnNext.TabIndex = 123;
            this.btnNext.Text = "下一个";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(84, 67);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(150, 72);
            this.labmaterialname.ParentChanged += new System.EventHandler(this.labmaterialname_ParentChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "物料描述";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.Text = "合单待结余";
            // 
            // labsurplus
            // 
            this.labsurplus.Location = new System.Drawing.Point(81, 142);
            this.labsurplus.Name = "labsurplus";
            this.labsurplus.Size = new System.Drawing.Size(153, 20);
            // 
            // frmbalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.labsurplus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnkeybord);
            this.Controls.Add(this.labneedqty);
            this.Controls.Add(this.labminunit);
            this.Controls.Add(this.txtminqty);
            this.Controls.Add(this.txtcommonqty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtsorderid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labcommonUnit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmbalance";
            this.Text = "结余";
            this.Load += new System.EventHandler(this.frmbalance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsorderid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labminunit;
        private System.Windows.Forms.TextBox txtminqty;
        private System.Windows.Forms.Label labcommonUnit;
        private System.Windows.Forms.TextBox txtcommonqty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labneedqty;
        private System.Windows.Forms.Button btnkeybord;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labsurplus;
    }
}
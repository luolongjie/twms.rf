namespace Rf_Wms.In
{
    partial class frmrefund
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
            this.txtorderid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labcustomer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttraycode = new System.Windows.Forms.TextBox();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.labneedqty = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtdate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbatch = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbmaterialCondition = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtcommonqty = new System.Windows.Forms.TextBox();
            this.labcommonUnit = new System.Windows.Forms.Label();
            this.labminunit = new System.Windows.Forms.Label();
            this.txtminqty = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnkeybord = new System.Windows.Forms.Button();
            this.btnShelve = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.labmaterialcode = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtorderid
            // 
            this.txtorderid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtorderid.Location = new System.Drawing.Point(85, 2);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(140, 23);
            this.txtorderid.TabIndex = 1;
            this.txtorderid.GotFocus += new System.EventHandler(this.txtorderid_GotFocus);
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "合单号";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(2, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.Text = "货主";
            // 
            // labcustomer
            // 
            this.labcustomer.Location = new System.Drawing.Point(85, 30);
            this.labcustomer.Name = "labcustomer";
            this.labcustomer.Size = new System.Drawing.Size(152, 16);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label4.Location = new System.Drawing.Point(2, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "托盘条码";
            // 
            // txttraycode
            // 
            this.txttraycode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txttraycode.Location = new System.Drawing.Point(85, 43);
            this.txttraycode.Name = "txttraycode";
            this.txttraycode.Size = new System.Drawing.Size(140, 23);
            this.txttraycode.TabIndex = 15;
            this.txttraycode.GotFocus += new System.EventHandler(this.txttraycode_GotFocus);
            this.txttraycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttraycode_KeyPress);
            // 
            // txtbarcode
            // 
            this.txtbarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtbarcode.Location = new System.Drawing.Point(85, 68);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(140, 23);
            this.txtbarcode.TabIndex = 17;
            this.txtbarcode.GotFocus += new System.EventHandler(this.txtbarcode_GotFocus);
            this.txtbarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarcode_KeyPress);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label5.Location = new System.Drawing.Point(2, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.Text = "商品码";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label6.Location = new System.Drawing.Point(2, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.Text = "物料描述";
            // 
            // labmaterialname
            // 
            this.labmaterialname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labmaterialname.Location = new System.Drawing.Point(85, 117);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(152, 16);
            // 
            // labneedqty
            // 
            this.labneedqty.Location = new System.Drawing.Point(2, 145);
            this.labneedqty.Name = "labneedqty";
            this.labneedqty.Size = new System.Drawing.Size(234, 20);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label10.Location = new System.Drawing.Point(2, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 20);
            this.label10.Text = "生产日期";
            // 
            // dtdate
            // 
            this.dtdate.Location = new System.Drawing.Point(85, 168);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(111, 24);
            this.dtdate.TabIndex = 29;
            this.dtdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtdate_KeyPress);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label11.Location = new System.Drawing.Point(2, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.Text = "批次";
            // 
            // txtbatch
            // 
            this.txtbatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtbatch.Location = new System.Drawing.Point(85, 196);
            this.txtbatch.Name = "txtbatch";
            this.txtbatch.Size = new System.Drawing.Size(140, 23);
            this.txtbatch.TabIndex = 32;
            this.txtbatch.GotFocus += new System.EventHandler(this.txtbatch_GotFocus);
            this.txtbatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbatch_KeyPress);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label12.Location = new System.Drawing.Point(2, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 20);
            this.label12.Text = "状态";
            // 
            // cmbmaterialCondition
            // 
            this.cmbmaterialCondition.Location = new System.Drawing.Point(85, 226);
            this.cmbmaterialCondition.Name = "cmbmaterialCondition";
            this.cmbmaterialCondition.Size = new System.Drawing.Size(93, 23);
            this.cmbmaterialCondition.TabIndex = 35;
            this.cmbmaterialCondition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbmaterialCondition_KeyPress);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label13.Location = new System.Drawing.Point(2, 257);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.Text = "数量";
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtcommonqty.Location = new System.Drawing.Point(41, 254);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(47, 23);
            this.txtcommonqty.TabIndex = 38;
            this.txtcommonqty.GotFocus += new System.EventHandler(this.txtcommonqty_GotFocus);
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // labcommonUnit
            // 
            this.labcommonUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labcommonUnit.Location = new System.Drawing.Point(93, 255);
            this.labcommonUnit.Name = "labcommonUnit";
            this.labcommonUnit.Size = new System.Drawing.Size(45, 20);
            // 
            // labminunit
            // 
            this.labminunit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labminunit.Location = new System.Drawing.Point(181, 255);
            this.labminunit.Name = "labminunit";
            this.labminunit.Size = new System.Drawing.Size(44, 20);
            // 
            // txtminqty
            // 
            this.txtminqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtminqty.Location = new System.Drawing.Point(132, 254);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(47, 23);
            this.txtminqty.TabIndex = 42;
            this.txtminqty.GotFocus += new System.EventHandler(this.txtminqty_GotFocus);
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(181, 281);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 20);
            this.btnExit.TabIndex = 44;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnkeybord
            // 
            this.btnkeybord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeybord.ForeColor = System.Drawing.Color.White;
            this.btnkeybord.Location = new System.Drawing.Point(1, 281);
            this.btnkeybord.Name = "btnkeybord";
            this.btnkeybord.Size = new System.Drawing.Size(57, 20);
            this.btnkeybord.TabIndex = 60;
            this.btnkeybord.Text = "键盘";
            this.btnkeybord.Click += new System.EventHandler(this.btnkeybord_Click);
            // 
            // btnShelve
            // 
            this.btnShelve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnShelve.ForeColor = System.Drawing.Color.White;
            this.btnShelve.Location = new System.Drawing.Point(61, 281);
            this.btnShelve.Name = "btnShelve";
            this.btnShelve.Size = new System.Drawing.Size(57, 20);
            this.btnShelve.TabIndex = 77;
            this.btnShelve.Text = "上架";
            this.btnShelve.Visible = false;
            this.btnShelve.Click += new System.EventHandler(this.btnShelve_Click);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnData.ForeColor = System.Drawing.Color.White;
            this.btnData.Location = new System.Drawing.Point(121, 281);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(57, 20);
            this.btnData.TabIndex = 94;
            this.btnData.Text = "未收";
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // labmaterialcode
            // 
            this.labmaterialcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labmaterialcode.Location = new System.Drawing.Point(85, 95);
            this.labmaterialcode.Name = "labmaterialcode";
            this.labmaterialcode.Size = new System.Drawing.Size(152, 16);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label9.Location = new System.Drawing.Point(2, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.Text = "物料代码";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(181, 227);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(57, 20);
            this.btnNext.TabIndex = 291;
            this.btnNext.Text = "跳过";
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // frmrefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(240, 305);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.labmaterialcode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.btnShelve);
            this.Controls.Add(this.btnkeybord);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labminunit);
            this.Controls.Add(this.txtminqty);
            this.Controls.Add(this.labcommonUnit);
            this.Controls.Add(this.txtcommonqty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtbatch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtdate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labneedqty);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txttraycode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labcustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbmaterialCondition);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmrefund";
            this.Text = "合并退货";
            this.Load += new System.EventHandler(this.frmPicking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labcustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttraycode;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.Label labneedqty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtbatch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbmaterialCondition;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtcommonqty;
        private System.Windows.Forms.Label labcommonUnit;
        private System.Windows.Forms.Label labminunit;
        private System.Windows.Forms.TextBox txtminqty;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnkeybord;
        private System.Windows.Forms.Button btnShelve;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Label labmaterialcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNext;
    }
}
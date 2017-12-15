namespace Rf_Wms.In
{
    partial class frmrefundshelveOne
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
            this.txtcarton = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labrecommendSlId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtshelve = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labcode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labqty = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.txttotraycode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnslid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtcarton
            // 
            this.txtcarton.Location = new System.Drawing.Point(85, 12);
            this.txtcarton.Name = "txtcarton";
            this.txtcarton.Size = new System.Drawing.Size(150, 23);
            this.txtcarton.TabIndex = 1;
            this.txtcarton.GotFocus += new System.EventHandler(this.txtcarton_GotFocus);
            this.txtcarton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcarton_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "托盘编码";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.Text = "建议库位";
            // 
            // labrecommendSlId
            // 
            this.labrecommendSlId.Location = new System.Drawing.Point(90, 157);
            this.labrecommendSlId.Name = "labrecommendSlId";
            this.labrecommendSlId.Size = new System.Drawing.Size(67, 20);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "库位名称";
            // 
            // txtshelve
            // 
            this.txtshelve.Enabled = false;
            this.txtshelve.Location = new System.Drawing.Point(85, 210);
            this.txtshelve.Name = "txtshelve";
            this.txtshelve.Size = new System.Drawing.Size(150, 23);
            this.txtshelve.TabIndex = 17;
            this.txtshelve.GotFocus += new System.EventHandler(this.txtshelve_GotFocus);
            this.txtshelve.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtshelve_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(163, 246);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 46;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(85, 39);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(150, 50);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.Text = "物料描述";
            // 
            // labcode
            // 
            this.labcode.Location = new System.Drawing.Point(90, 99);
            this.labcode.Name = "labcode";
            this.labcode.Size = new System.Drawing.Size(145, 16);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.Text = "物料编码";
            // 
            // labqty
            // 
            this.labqty.Location = new System.Drawing.Point(90, 125);
            this.labqty.Name = "labqty";
            this.labqty.Size = new System.Drawing.Size(118, 20);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(5, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.Text = "数量";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(84, 246);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 20);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(5, 246);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(72, 20);
            this.btnkeyboard.TabIndex = 271;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // txttotraycode
            // 
            this.txttotraycode.Enabled = false;
            this.txttotraycode.Location = new System.Drawing.Point(85, 180);
            this.txttotraycode.Name = "txttotraycode";
            this.txttotraycode.Size = new System.Drawing.Size(150, 23);
            this.txttotraycode.TabIndex = 283;
            this.txttotraycode.GotFocus += new System.EventHandler(this.txttotraycode_GotFocus);
            this.txttotraycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotraycode_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "合并托盘";
            // 
            // btnslid
            // 
            this.btnslid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnslid.ForeColor = System.Drawing.Color.White;
            this.btnslid.Location = new System.Drawing.Point(163, 155);
            this.btnslid.Name = "btnslid";
            this.btnslid.Size = new System.Drawing.Size(72, 20);
            this.btnslid.TabIndex = 295;
            this.btnslid.Text = "建议库位";
            this.btnslid.Visible = false;
            this.btnslid.Click += new System.EventHandler(this.btnslid_Click);
            // 
            // frmrefundshelveOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnslid);
            this.Controls.Add(this.txttotraycode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.labqty);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labcode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtshelve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labrecommendSlId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcarton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmrefundshelveOne";
            this.Text = "上架";
            this.Load += new System.EventHandler(this.frmshelve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtcarton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labrecommendSlId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtshelve;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labqty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.TextBox txttotraycode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnslid;
    }
}
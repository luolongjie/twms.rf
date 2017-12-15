namespace Rf_Wms.Ot
{
    partial class frmTMcustomer
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
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtorderid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(29, 254);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 20);
            this.btnOK.TabIndex = 50;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(-2, 40);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 198);
            this.dataGrid1.TabIndex = 49;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(135, 254);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 48;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtorderid
            // 
            this.txtorderid.Location = new System.Drawing.Point(111, 9);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(100, 23);
            this.txtorderid.TabIndex = 52;
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "货主编号";
            // 
            // frmTMcustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTMcustomer";
            this.Text = "无单转储";
            this.Load += new System.EventHandler(this.frmTMcustomer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
    }
}
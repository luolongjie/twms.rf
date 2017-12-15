namespace Rf_Wms.Ot
{
    partial class frmWarehouse
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
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbwarehouse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(130, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "返回";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbwarehouse
            // 
            this.cmbwarehouse.Location = new System.Drawing.Point(49, 67);
            this.cmbwarehouse.Name = "cmbwarehouse";
            this.cmbwarehouse.Size = new System.Drawing.Size(140, 23);
            this.cmbwarehouse.TabIndex = 18;
            this.cmbwarehouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbwarehouse_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(81, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "仓库信息";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(36, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 20);
            this.btnOK.TabIndex = 51;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbwarehouse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWarehouse";
            this.Text = "切换仓库";
            this.Load += new System.EventHandler(this.frmWarehouse_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbwarehouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
    }
}
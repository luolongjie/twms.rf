namespace Rf_Wms.Out
{
    partial class frmStockOutMenu
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
            this.btnS = new System.Windows.Forms.Button();
            this.btnF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(133, 206);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 45);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "返回";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(133, 54);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(72, 45);
            this.btnS.TabIndex = 7;
            this.btnS.Text = "二次拣货";
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnF
            // 
            this.btnF.Location = new System.Drawing.Point(33, 54);
            this.btnF.Name = "btnF";
            this.btnF.Size = new System.Drawing.Size(72, 45);
            this.btnF.TabIndex = 6;
            this.btnF.Text = "复核";
            this.btnF.Click += new System.EventHandler(this.btnF_Click);
            // 
            // frmStockOutMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnF);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockOutMenu";
            this.Text = "拣货复核";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnF;
    }
}
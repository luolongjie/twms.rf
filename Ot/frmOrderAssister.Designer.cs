namespace Rf_Wms.Ot
{
    partial class frmOrderAssister
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
            this.cmbmaterialSurface = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtorderid
            // 
            this.txtorderid.Location = new System.Drawing.Point(25, 49);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(188, 23);
            this.txtorderid.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "转储单号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.Text = "状态";
            // 
            // cmbmaterialSurface
            // 
            this.cmbmaterialSurface.Enabled = false;
            this.cmbmaterialSurface.Location = new System.Drawing.Point(25, 135);
            this.cmbmaterialSurface.Name = "cmbmaterialSurface";
            this.cmbmaterialSurface.Size = new System.Drawing.Size(188, 23);
            this.cmbmaterialSurface.TabIndex = 292;
            // 
            // frmOrderAssister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbmaterialSurface);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrderAssister";
            this.Text = "工单记录";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbmaterialSurface;
    }
}
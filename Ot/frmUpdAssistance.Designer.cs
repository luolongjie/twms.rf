namespace Rf_Wms.Ot
{
    partial class frmUpdAssistance
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
            this.txtassistance = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labcode = new System.Windows.Forms.Label();
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtassistance
            // 
            this.txtassistance.Location = new System.Drawing.Point(74, 109);
            this.txtassistance.Name = "txtassistance";
            this.txtassistance.Size = new System.Drawing.Size(150, 23);
            this.txtassistance.TabIndex = 0;
            this.txtassistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtassistance_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(133, 220);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "返回";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "单号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.Text = "协助人";
            // 
            // labcode
            // 
            this.labcode.Location = new System.Drawing.Point(74, 49);
            this.labcode.Name = "labcode";
            this.labcode.Size = new System.Drawing.Size(150, 20);
            this.labcode.Text = "单号";
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(33, 220);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(72, 20);
            this.btnkeyboard.TabIndex = 272;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // frmUpdAssistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.labcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtassistance);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdAssistance";
            this.Text = "协助人更新";
            this.Load += new System.EventHandler(this.frmUpdAssistance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtassistance;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labcode;
        private System.Windows.Forms.Button btnkeyboard;
    }
}
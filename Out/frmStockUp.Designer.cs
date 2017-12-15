namespace Rf_Wms.Out
{
    partial class frmStockUp
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
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labstockUpConfirmMsg = new System.Windows.Forms.Label();
            this.labpick = new System.Windows.Forms.Label();
            this.labcheck = new System.Windows.Forms.Label();
            this.labcheckorder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtorderid
            // 
            this.txtorderid.Location = new System.Drawing.Point(93, 10);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(140, 23);
            this.txtorderid.TabIndex = 53;
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "拣货单号";
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(6, 267);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(90, 20);
            this.btnkeyboard.TabIndex = 264;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(143, 267);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 20);
            this.btnExit.TabIndex = 263;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.Text = "未拣货数量";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.Text = "未分拣数量";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.Text = "单据待分拣数量";
            // 
            // labstockUpConfirmMsg
            // 
            this.labstockUpConfirmMsg.Location = new System.Drawing.Point(5, 41);
            this.labstockUpConfirmMsg.Name = "labstockUpConfirmMsg";
            this.labstockUpConfirmMsg.Size = new System.Drawing.Size(227, 114);
            // 
            // labpick
            // 
            this.labpick.Location = new System.Drawing.Point(143, 160);
            this.labpick.Name = "labpick";
            this.labpick.Size = new System.Drawing.Size(90, 20);
            this.labpick.Text = "未拣货数量";
            // 
            // labcheck
            // 
            this.labcheck.Location = new System.Drawing.Point(143, 190);
            this.labcheck.Name = "labcheck";
            this.labcheck.Size = new System.Drawing.Size(90, 20);
            this.labcheck.Text = "未拣货数量";
            // 
            // labcheckorder
            // 
            this.labcheckorder.Location = new System.Drawing.Point(143, 226);
            this.labcheckorder.Name = "labcheckorder";
            this.labcheckorder.Size = new System.Drawing.Size(90, 20);
            this.labcheckorder.Text = "未拣货数量";
            // 
            // frmStockUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.labcheckorder);
            this.Controls.Add(this.labcheck);
            this.Controls.Add(this.labpick);
            this.Controls.Add(this.labstockUpConfirmMsg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockUp";
            this.Text = "备货信息";
            this.Load += new System.EventHandler(this.frmStockUp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labstockUpConfirmMsg;
        private System.Windows.Forms.Label labpick;
        private System.Windows.Forms.Label labcheck;
        private System.Windows.Forms.Label labcheckorder;
    }
}
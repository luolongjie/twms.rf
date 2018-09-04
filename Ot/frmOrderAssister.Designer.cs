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
            this.cmboperation = new System.Windows.Forms.ComboBox();
            this.txtAssister = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnkeybord = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbunit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labinfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtorderid
            // 
            this.txtorderid.Location = new System.Drawing.Point(25, 23);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(188, 23);
            this.txtorderid.TabIndex = 3;
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "单据号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.Text = "操作项";
            // 
            // cmboperation
            // 
            this.cmboperation.Enabled = false;
            this.cmboperation.Location = new System.Drawing.Point(25, 71);
            this.cmboperation.Name = "cmboperation";
            this.cmboperation.Size = new System.Drawing.Size(188, 23);
            this.cmboperation.TabIndex = 292;
            this.cmboperation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmboperation_KeyPress);
            // 
            // txtAssister
            // 
            this.txtAssister.Location = new System.Drawing.Point(25, 161);
            this.txtAssister.Name = "txtAssister";
            this.txtAssister.Size = new System.Drawing.Size(188, 23);
            this.txtAssister.TabIndex = 294;
            this.txtAssister.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAssister_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(83, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 20);
            this.btnSave.TabIndex = 297;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnkeybord
            // 
            this.btnkeybord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeybord.ForeColor = System.Drawing.Color.White;
            this.btnkeybord.Location = new System.Drawing.Point(1, 258);
            this.btnkeybord.Name = "btnkeybord";
            this.btnkeybord.Size = new System.Drawing.Size(72, 20);
            this.btnkeybord.TabIndex = 296;
            this.btnkeybord.Text = "键盘";
            this.btnkeybord.Click += new System.EventHandler(this.btnkeybord_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(165, 258);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 295;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbunit
            // 
            this.cmbunit.Items.Add("吨");
            this.cmbunit.Items.Add("件");
            this.cmbunit.Location = new System.Drawing.Point(25, 117);
            this.cmbunit.Name = "cmbunit";
            this.cmbunit.Size = new System.Drawing.Size(188, 23);
            this.cmbunit.TabIndex = 300;
            this.cmbunit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbunit_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "计量单位";
            // 
            // labinfo
            // 
            this.labinfo.Location = new System.Drawing.Point(25, 188);
            this.labinfo.Name = "labinfo";
            this.labinfo.Size = new System.Drawing.Size(188, 65);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(28, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "辅助人";
            // 
            // frmOrderAssister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labinfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbunit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnkeybord);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtAssister);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmboperation);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrderAssister";
            this.Text = "工单记录";
            this.Load += new System.EventHandler(this.frmOrderAssister_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmboperation;
        private System.Windows.Forms.TextBox txtAssister;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnkeybord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbunit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labinfo;
        private System.Windows.Forms.Label label4;
    }
}
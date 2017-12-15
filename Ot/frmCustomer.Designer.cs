namespace Rf_Wms.Ot
{
    partial class frmCustomer
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
            this.btnExit = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbordertype = new System.Windows.Forms.ComboBox();
            this.cmbbusinessType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtorder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnkeybord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtorderid
            // 
            this.txtorderid.Location = new System.Drawing.Point(103, 64);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(100, 23);
            this.txtorderid.TabIndex = 9;
            this.txtorderid.GotFocus += new System.EventHandler(this.txtorderid_GotFocus);
            this.txtorderid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorderid_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "货主编号";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(162, 252);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 45;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(0, 89);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 146);
            this.dataGrid1.TabIndex = 46;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(84, 252);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 20);
            this.btnOK.TabIndex = 47;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.Text = "类型";
            // 
            // cmbordertype
            // 
            this.cmbordertype.Location = new System.Drawing.Point(41, 4);
            this.cmbordertype.Name = "cmbordertype";
            this.cmbordertype.Size = new System.Drawing.Size(80, 23);
            this.cmbordertype.TabIndex = 1;
            this.cmbordertype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbordertype_KeyPress);
            // 
            // cmbbusinessType
            // 
            this.cmbbusinessType.Enabled = false;
            this.cmbbusinessType.Location = new System.Drawing.Point(157, 4);
            this.cmbbusinessType.Name = "cmbbusinessType";
            this.cmbbusinessType.Size = new System.Drawing.Size(80, 23);
            this.cmbbusinessType.TabIndex = 54;
            this.cmbbusinessType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbbusinessType_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(120, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.Text = "运输";
            // 
            // txtorder
            // 
            this.txtorder.Location = new System.Drawing.Point(103, 35);
            this.txtorder.Name = "txtorder";
            this.txtorder.Size = new System.Drawing.Size(100, 23);
            this.txtorder.TabIndex = 59;
            this.txtorder.GotFocus += new System.EventHandler(this.txtorder_GotFocus);
            this.txtorder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtorder_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "订单号";
            // 
            // btnkeybord
            // 
            this.btnkeybord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeybord.ForeColor = System.Drawing.Color.White;
            this.btnkeybord.Location = new System.Drawing.Point(6, 252);
            this.btnkeybord.Name = "btnkeybord";
            this.btnkeybord.Size = new System.Drawing.Size(72, 20);
            this.btnkeybord.TabIndex = 64;
            this.btnkeybord.Text = "键盘";
            this.btnkeybord.Click += new System.EventHandler(this.btnkeybord_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnkeybord);
            this.Controls.Add(this.txtorder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbbusinessType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbordertype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtorderid);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.Text = "货主";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtorderid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbordertype;
        private System.Windows.Forms.ComboBox cmbbusinessType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtorder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnkeybord;
    }
}
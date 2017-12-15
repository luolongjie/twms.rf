namespace Rf_Wms.Ot
{
    partial class frmSLSearch
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
            this.txttraycode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblbarcode = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.laberror = new System.Windows.Forms.Label();
            this.btnkeybord = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labinfo = new System.Windows.Forms.Label();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblshippername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txttraycode
            // 
            this.txttraycode.Location = new System.Drawing.Point(73, 4);
            this.txttraycode.Name = "txttraycode";
            this.txttraycode.Size = new System.Drawing.Size(140, 23);
            this.txttraycode.TabIndex = 86;
            this.txttraycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttraycode_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "货位";
            // 
            // lblbarcode
            // 
            this.lblbarcode.Location = new System.Drawing.Point(72, 207);
            this.lblbarcode.Name = "lblbarcode";
            this.lblbarcode.Size = new System.Drawing.Size(163, 16);
            this.lblbarcode.Visible = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 20);
            this.label10.Text = "商品码";
            this.label10.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.Text = "库存量";
            // 
            // laberror
            // 
            this.laberror.ForeColor = System.Drawing.Color.Red;
            this.laberror.Location = new System.Drawing.Point(5, 251);
            this.laberror.Name = "laberror";
            this.laberror.Size = new System.Drawing.Size(232, 20);
            // 
            // btnkeybord
            // 
            this.btnkeybord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeybord.ForeColor = System.Drawing.Color.White;
            this.btnkeybord.Location = new System.Drawing.Point(4, 278);
            this.btnkeybord.Name = "btnkeybord";
            this.btnkeybord.Size = new System.Drawing.Size(72, 20);
            this.btnkeybord.TabIndex = 105;
            this.btnkeybord.Text = "键盘";
            this.btnkeybord.Click += new System.EventHandler(this.btnkeybord_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(163, 278);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 104;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labinfo
            // 
            this.labinfo.Location = new System.Drawing.Point(72, 127);
            this.labinfo.Name = "labinfo";
            this.labinfo.Size = new System.Drawing.Size(163, 20);
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(5, 57);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(230, 50);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(82, 278);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 20);
            this.btnNext.TabIndex = 122;
            this.btnNext.Text = "下一个";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblshippername
            // 
            this.lblshippername.Location = new System.Drawing.Point(71, 167);
            this.lblshippername.Name = "lblshippername";
            this.lblshippername.Size = new System.Drawing.Size(163, 16);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "货主名";
            // 
            // frmSLSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.lblshippername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblbarcode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.laberror);
            this.Controls.Add(this.btnkeybord);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labinfo);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.txttraycode);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSLSearch";
            this.Text = "货位信息";
            this.Load += new System.EventHandler(this.frmSLSearch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txttraycode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblbarcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label laberror;
        private System.Windows.Forms.Button btnkeybord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labinfo;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblshippername;
        private System.Windows.Forms.Label label3;
    }
}
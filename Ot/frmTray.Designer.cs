namespace Rf_Wms.Ot
{
    partial class frmTray
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
            this.btnkeybord = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labinfo = new System.Windows.Forms.Label();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.txttraycode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labpdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labbatchno = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.laberror = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labindate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labstr = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblbarcode = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblslId = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnkeybord
            // 
            this.btnkeybord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeybord.ForeColor = System.Drawing.Color.White;
            this.btnkeybord.Location = new System.Drawing.Point(35, 275);
            this.btnkeybord.Name = "btnkeybord";
            this.btnkeybord.Size = new System.Drawing.Size(72, 20);
            this.btnkeybord.TabIndex = 86;
            this.btnkeybord.Text = "键盘";
            this.btnkeybord.Click += new System.EventHandler(this.btnkeybord_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(132, 275);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 85;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labinfo
            // 
            this.labinfo.Location = new System.Drawing.Point(72, 154);
            this.labinfo.Name = "labinfo";
            this.labinfo.Size = new System.Drawing.Size(163, 20);
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(5, 29);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(230, 50);
            // 
            // txttraycode
            // 
            this.txttraycode.Location = new System.Drawing.Point(72, 2);
            this.txttraycode.Name = "txttraycode";
            this.txttraycode.Size = new System.Drawing.Size(140, 23);
            this.txttraycode.TabIndex = 84;
            this.txttraycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttraycode_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "托盘条码";
            // 
            // labpdate
            // 
            this.labpdate.Location = new System.Drawing.Point(72, 106);
            this.labpdate.Name = "labpdate";
            this.labpdate.Size = new System.Drawing.Size(163, 16);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.Text = "生产日期";
            // 
            // labbatchno
            // 
            this.labbatchno.Location = new System.Drawing.Point(72, 130);
            this.labbatchno.Name = "labbatchno";
            this.labbatchno.Size = new System.Drawing.Size(163, 16);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "批次";
            // 
            // laberror
            // 
            this.laberror.ForeColor = System.Drawing.Color.Red;
            this.laberror.Location = new System.Drawing.Point(3, 248);
            this.laberror.Name = "laberror";
            this.laberror.Size = new System.Drawing.Size(232, 20);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.Text = "托盘数量";
            // 
            // labindate
            // 
            this.labindate.Location = new System.Drawing.Point(72, 82);
            this.labindate.Name = "labindate";
            this.labindate.Size = new System.Drawing.Size(163, 16);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.Text = "入库日期";
            // 
            // labstr
            // 
            this.labstr.Location = new System.Drawing.Point(72, 180);
            this.labstr.Name = "labstr";
            this.labstr.Size = new System.Drawing.Size(163, 16);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 20);
            this.label8.Text = "状态";
            // 
            // lblbarcode
            // 
            this.lblbarcode.Location = new System.Drawing.Point(72, 204);
            this.lblbarcode.Name = "lblbarcode";
            this.lblbarcode.Size = new System.Drawing.Size(163, 16);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 20);
            this.label10.Text = "商品码";
            // 
            // lblslId
            // 
            this.lblslId.Location = new System.Drawing.Point(72, 228);
            this.lblslId.Name = "lblslId";
            this.lblslId.Size = new System.Drawing.Size(163, 16);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(5, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.Text = "所属库位";
            // 
            // frmTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.lblslId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblbarcode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labstr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labindate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.laberror);
            this.Controls.Add(this.labbatchno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnkeybord);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labinfo);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.txttraycode);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTray";
            this.Text = "托盘信息";
            this.Load += new System.EventHandler(this.frmTray_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkeybord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labinfo;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.TextBox txttraycode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labbatchno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label laberror;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labindate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labstr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblbarcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblslId;
        private System.Windows.Forms.Label label11;
    }
}
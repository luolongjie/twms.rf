namespace Rf_Wms.Ot
{
    partial class frmcontainer
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
            this.lblqty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnList = new System.Windows.Forms.Button();
            this.lblpickTypeName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.laberror = new System.Windows.Forms.Label();
            this.btnkeybord = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblpickno = new System.Windows.Forms.Label();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.txttraycode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblcombineContent = new System.Windows.Forms.Label();
            this.lblsortingTypeName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblqty
            // 
            this.lblqty.Location = new System.Drawing.Point(73, 54);
            this.lblqty.Name = "lblqty";
            this.lblqty.Size = new System.Drawing.Size(162, 16);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "物料总量";
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnList.ForeColor = System.Drawing.Color.White;
            this.btnList.Location = new System.Drawing.Point(81, 279);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(72, 20);
            this.btnList.TabIndex = 135;
            this.btnList.Text = "列表";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // lblpickTypeName
            // 
            this.lblpickTypeName.Location = new System.Drawing.Point(2, 133);
            this.lblpickTypeName.Name = "lblpickTypeName";
            this.lblpickTypeName.Size = new System.Drawing.Size(215, 16);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.Text = "拣货单号";
            // 
            // laberror
            // 
            this.laberror.ForeColor = System.Drawing.Color.Red;
            this.laberror.Location = new System.Drawing.Point(4, 252);
            this.laberror.Name = "laberror";
            this.laberror.Size = new System.Drawing.Size(232, 20);
            // 
            // btnkeybord
            // 
            this.btnkeybord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeybord.ForeColor = System.Drawing.Color.White;
            this.btnkeybord.Location = new System.Drawing.Point(3, 279);
            this.btnkeybord.Name = "btnkeybord";
            this.btnkeybord.Size = new System.Drawing.Size(72, 20);
            this.btnkeybord.TabIndex = 134;
            this.btnkeybord.Text = "键盘";
            this.btnkeybord.Click += new System.EventHandler(this.btnkeybord_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(162, 279);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 20);
            this.btnExit.TabIndex = 133;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblpickno
            // 
            this.lblpickno.Location = new System.Drawing.Point(72, 92);
            this.lblpickno.Name = "lblpickno";
            this.lblpickno.Size = new System.Drawing.Size(162, 20);
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(4, 58);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(230, 50);
            // 
            // txttraycode
            // 
            this.txttraycode.Location = new System.Drawing.Point(72, 5);
            this.txttraycode.Name = "txttraycode";
            this.txttraycode.Size = new System.Drawing.Size(145, 23);
            this.txttraycode.TabIndex = 132;
            this.txttraycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttraycode_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.Text = "容器码";
            // 
            // lblcombineContent
            // 
            this.lblcombineContent.Location = new System.Drawing.Point(4, 167);
            this.lblcombineContent.Name = "lblcombineContent";
            this.lblcombineContent.Size = new System.Drawing.Size(230, 38);
            // 
            // lblsortingTypeName
            // 
            this.lblsortingTypeName.Location = new System.Drawing.Point(2, 217);
            this.lblsortingTypeName.Name = "lblsortingTypeName";
            this.lblsortingTypeName.Size = new System.Drawing.Size(215, 16);
            // 
            // frmcontainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.lblsortingTypeName);
            this.Controls.Add(this.lblcombineContent);
            this.Controls.Add(this.lblqty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.lblpickTypeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.laberror);
            this.Controls.Add(this.btnkeybord);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblpickno);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.txttraycode);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmcontainer";
            this.Text = "容器码查询";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblqty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Label lblpickTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label laberror;
        private System.Windows.Forms.Button btnkeybord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblpickno;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.TextBox txttraycode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblcombineContent;
        private System.Windows.Forms.Label lblsortingTypeName;
    }
}
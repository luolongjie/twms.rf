namespace Rf_Wms.Out
{
    partial class frmNStockOut
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
            this.btnExit = new System.Windows.Forms.Button();
            this.labminunit = new System.Windows.Forms.Label();
            this.txtminqty = new System.Windows.Forms.TextBox();
            this.labcommonUnit = new System.Windows.Forms.Label();
            this.txtcommonqty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labmaterialname = new System.Windows.Forms.Label();
            this.labpdata = new System.Windows.Forms.Label();
            this.btnData = new System.Windows.Forms.Button();
            this.btnkeyboard = new System.Windows.Forms.Button();
            this.labbatch = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labqty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labpickType = new System.Windows.Forms.Label();
            this.labtype = new System.Windows.Forms.Label();
            this.labstockoutno = new System.Windows.Forms.Label();
            this.labsoqty = new System.Windows.Forms.Label();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnNext1 = new System.Windows.Forms.Button();
            this.btnchange = new System.Windows.Forms.Button();
            this.lblpickno = new System.Windows.Forms.Label();
            this.lbltraycode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(171)))), ((int)(((byte)(110)))));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(181, 280);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 20);
            this.btnExit.TabIndex = 56;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labminunit
            // 
            this.labminunit.Location = new System.Drawing.Point(187, 255);
            this.labminunit.Name = "labminunit";
            this.labminunit.Size = new System.Drawing.Size(44, 20);
            this.labminunit.Text = "单位2";
            // 
            // txtminqty
            // 
            this.txtminqty.Enabled = false;
            this.txtminqty.Location = new System.Drawing.Point(138, 252);
            this.txtminqty.Name = "txtminqty";
            this.txtminqty.Size = new System.Drawing.Size(47, 23);
            this.txtminqty.TabIndex = 55;
            this.txtminqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminqty_KeyPress);
            // 
            // labcommonUnit
            // 
            this.labcommonUnit.Location = new System.Drawing.Point(99, 255);
            this.labcommonUnit.Name = "labcommonUnit";
            this.labcommonUnit.Size = new System.Drawing.Size(45, 20);
            this.labcommonUnit.Text = "单位1";
            // 
            // txtcommonqty
            // 
            this.txtcommonqty.Location = new System.Drawing.Point(47, 252);
            this.txtcommonqty.Name = "txtcommonqty";
            this.txtcommonqty.Size = new System.Drawing.Size(47, 23);
            this.txtcommonqty.TabIndex = 54;
            this.txtcommonqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcommonqty_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(3, 255);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.Text = "数量";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "托盘条码";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.Text = "拣货单号";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 16);
            this.label10.Text = "生产日期";
            // 
            // labmaterialname
            // 
            this.labmaterialname.Location = new System.Drawing.Point(3, 55);
            this.labmaterialname.Name = "labmaterialname";
            this.labmaterialname.Size = new System.Drawing.Size(230, 44);
            // 
            // labpdata
            // 
            this.labpdata.Location = new System.Drawing.Point(79, 105);
            this.labpdata.Name = "labpdata";
            this.labpdata.Size = new System.Drawing.Size(150, 16);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnData.ForeColor = System.Drawing.Color.White;
            this.btnData.Location = new System.Drawing.Point(121, 280);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(57, 20);
            this.btnData.TabIndex = 102;
            this.btnData.Text = "列表";
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnkeyboard
            // 
            this.btnkeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.btnkeyboard.ForeColor = System.Drawing.Color.White;
            this.btnkeyboard.Location = new System.Drawing.Point(1, 280);
            this.btnkeyboard.Name = "btnkeyboard";
            this.btnkeyboard.Size = new System.Drawing.Size(57, 20);
            this.btnkeyboard.TabIndex = 262;
            this.btnkeyboard.Text = "键盘";
            this.btnkeyboard.Click += new System.EventHandler(this.btnkeyboard_Click);
            // 
            // labbatch
            // 
            this.labbatch.Location = new System.Drawing.Point(79, 125);
            this.labbatch.Name = "labbatch";
            this.labbatch.Size = new System.Drawing.Size(137, 16);
            this.labbatch.Text = "2017-01-01";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.Text = "批次";
            // 
            // labqty
            // 
            this.labqty.Location = new System.Drawing.Point(79, 148);
            this.labqty.Name = "labqty";
            this.labqty.Size = new System.Drawing.Size(137, 20);
            this.labqty.Text = "3000千克0瓶 2017-01-01";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.Text = "待分拣数量";
            // 
            // labpickType
            // 
            this.labpickType.Location = new System.Drawing.Point(79, 173);
            this.labpickType.Name = "labpickType";
            this.labpickType.Size = new System.Drawing.Size(150, 20);
            // 
            // labtype
            // 
            this.labtype.Location = new System.Drawing.Point(3, 174);
            this.labtype.Name = "labtype";
            this.labtype.Size = new System.Drawing.Size(77, 20);
            this.labtype.Text = "拣货类型";
            // 
            // labstockoutno
            // 
            this.labstockoutno.Location = new System.Drawing.Point(3, 198);
            this.labstockoutno.Name = "labstockoutno";
            this.labstockoutno.Size = new System.Drawing.Size(220, 16);
            // 
            // labsoqty
            // 
            this.labsoqty.Location = new System.Drawing.Point(3, 226);
            this.labsoqty.Name = "labsoqty";
            this.labsoqty.Size = new System.Drawing.Size(147, 20);
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnnext.ForeColor = System.Drawing.Color.White;
            this.btnnext.Location = new System.Drawing.Point(162, 226);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(72, 20);
            this.btnnext.TabIndex = 272;
            this.btnnext.Text = "跳过";
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click_1);
            // 
            // btnNext1
            // 
            this.btnNext1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNext1.ForeColor = System.Drawing.Color.White;
            this.btnNext1.Location = new System.Drawing.Point(162, 125);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.Size = new System.Drawing.Size(72, 20);
            this.btnNext1.TabIndex = 290;
            this.btnNext1.Text = "跳过";
            this.btnNext1.Click += new System.EventHandler(this.btnNext1_Click);
            // 
            // btnchange
            // 
            this.btnchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.btnchange.ForeColor = System.Drawing.Color.White;
            this.btnchange.Location = new System.Drawing.Point(61, 280);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(57, 20);
            this.btnchange.TabIndex = 307;
            this.btnchange.Text = "提单";
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // lblpickno
            // 
            this.lblpickno.Location = new System.Drawing.Point(79, 10);
            this.lblpickno.Name = "lblpickno";
            this.lblpickno.Size = new System.Drawing.Size(150, 16);
            // 
            // lbltraycode
            // 
            this.lbltraycode.Location = new System.Drawing.Point(79, 34);
            this.lbltraycode.Name = "lbltraycode";
            this.lbltraycode.Size = new System.Drawing.Size(150, 16);
            // 
            // frmNStockOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(238, 305);
            this.Controls.Add(this.lbltraycode);
            this.Controls.Add(this.lblpickno);
            this.Controls.Add(this.labstockoutno);
            this.Controls.Add(this.btnchange);
            this.Controls.Add(this.btnNext1);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.labsoqty);
            this.Controls.Add(this.labpickType);
            this.Controls.Add(this.labtype);
            this.Controls.Add(this.labqty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labbatch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnkeyboard);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.labpdata);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labmaterialname);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labminunit);
            this.Controls.Add(this.txtminqty);
            this.Controls.Add(this.labcommonUnit);
            this.Controls.Add(this.txtcommonqty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNStockOut";
            this.Text = "二次拣货";
            this.Load += new System.EventHandler(this.frmStockOut_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labminunit;
        private System.Windows.Forms.TextBox txtminqty;
        private System.Windows.Forms.Label labcommonUnit;
        private System.Windows.Forms.TextBox txtcommonqty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labmaterialname;
        private System.Windows.Forms.Label labpdata;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnkeyboard;
        private System.Windows.Forms.Label labbatch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labqty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labpickType;
        private System.Windows.Forms.Label labtype;
        private System.Windows.Forms.Label labstockoutno;
        private System.Windows.Forms.Label labsoqty;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnNext1;
        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.Label lblpickno;
        private System.Windows.Forms.Label lbltraycode;
    }
}
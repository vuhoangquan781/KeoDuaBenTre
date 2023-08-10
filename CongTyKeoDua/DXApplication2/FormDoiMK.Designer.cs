namespace DXApplication2
{
    partial class FormDoiMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoiMK));
            this.lb_ThanhCong = new DevExpress.XtraEditors.LabelControl();
            this.lb_sai = new DevExpress.XtraEditors.LabelControl();
            this.lb_KhongKhop = new DevExpress.XtraEditors.LabelControl();
            this.txt_NL = new DevExpress.XtraEditors.TextEdit();
            this.txt_MKM = new DevExpress.XtraEditors.TextEdit();
            this.txt_MKC = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_CN = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MKM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MKC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_ThanhCong
            // 
            this.lb_ThanhCong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThanhCong.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lb_ThanhCong.Appearance.Options.UseFont = true;
            this.lb_ThanhCong.Appearance.Options.UseForeColor = true;
            this.lb_ThanhCong.Location = new System.Drawing.Point(128, 130);
            this.lb_ThanhCong.Name = "lb_ThanhCong";
            this.lb_ThanhCong.Size = new System.Drawing.Size(186, 19);
            this.lb_ThanhCong.TabIndex = 28;
            this.lb_ThanhCong.Text = "Đổi mật khẩu thành công!";
            this.lb_ThanhCong.Visible = false;
            // 
            // lb_sai
            // 
            this.lb_sai.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sai.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lb_sai.Appearance.Options.UseFont = true;
            this.lb_sai.Appearance.Options.UseForeColor = true;
            this.lb_sai.Location = new System.Drawing.Point(342, 16);
            this.lb_sai.Name = "lb_sai";
            this.lb_sai.Size = new System.Drawing.Size(16, 13);
            this.lb_sai.TabIndex = 26;
            this.lb_sai.Text = "Sai";
            this.lb_sai.Visible = false;
            // 
            // lb_KhongKhop
            // 
            this.lb_KhongKhop.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_KhongKhop.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lb_KhongKhop.Appearance.Options.UseFont = true;
            this.lb_KhongKhop.Appearance.Options.UseForeColor = true;
            this.lb_KhongKhop.Location = new System.Drawing.Point(342, 103);
            this.lb_KhongKhop.Name = "lb_KhongKhop";
            this.lb_KhongKhop.Size = new System.Drawing.Size(16, 13);
            this.lb_KhongKhop.TabIndex = 27;
            this.lb_KhongKhop.Text = "Sai";
            this.lb_KhongKhop.Visible = false;
            // 
            // txt_NL
            // 
            this.txt_NL.Location = new System.Drawing.Point(128, 99);
            this.txt_NL.Name = "txt_NL";
            this.txt_NL.Size = new System.Drawing.Size(183, 20);
            this.txt_NL.TabIndex = 23;
            // 
            // txt_MKM
            // 
            this.txt_MKM.Location = new System.Drawing.Point(128, 51);
            this.txt_MKM.Name = "txt_MKM";
            this.txt_MKM.Size = new System.Drawing.Size(183, 20);
            this.txt_MKM.TabIndex = 24;
            // 
            // txt_MKC
            // 
            this.txt_MKC.Location = new System.Drawing.Point(128, 9);
            this.txt_MKC.Name = "txt_MKC";
            this.txt_MKC.Size = new System.Drawing.Size(183, 20);
            this.txt_MKC.TabIndex = 25;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 106);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Nhập lại:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 21;
            this.labelControl2.Text = "Mật khẩu mới:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Mật khẩu cũ:";
            // 
            // btn_CN
            // 
            this.btn_CN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_CN.ImageOptions.Image")));
            this.btn_CN.Location = new System.Drawing.Point(153, 155);
            this.btn_CN.Name = "btn_CN";
            this.btn_CN.Size = new System.Drawing.Size(107, 36);
            this.btn_CN.TabIndex = 19;
            this.btn_CN.Text = "Chấp Nhận";
            this.btn_CN.Click += new System.EventHandler(this.btn_CN_Click);
            // 
            // FormDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 211);
            this.Controls.Add(this.lb_ThanhCong);
            this.Controls.Add(this.lb_sai);
            this.Controls.Add(this.lb_KhongKhop);
            this.Controls.Add(this.txt_NL);
            this.Controls.Add(this.txt_MKM);
            this.Controls.Add(this.txt_MKC);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_CN);
            this.Name = "FormDoiMK";
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.txt_NL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MKM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MKC.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lb_ThanhCong;
        private DevExpress.XtraEditors.LabelControl lb_sai;
        private DevExpress.XtraEditors.LabelControl lb_KhongKhop;
        private DevExpress.XtraEditors.TextEdit txt_NL;
        private DevExpress.XtraEditors.TextEdit txt_MKM;
        private DevExpress.XtraEditors.TextEdit txt_MKC;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_CN;
    }
}
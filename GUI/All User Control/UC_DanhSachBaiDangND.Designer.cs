namespace GUI.All_User_Control
{
    partial class UC_DanhSachBaiDangND
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_DanhSachBaiDangND));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.ptbBack = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlDanhSachIDND = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBack)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GradientPanel1.Controls.Add(this.ptbBack);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1135, 71);
            this.guna2GradientPanel1.TabIndex = 5;
            // 
            // ptbBack
            // 
            this.ptbBack.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ptbBack.Image = ((System.Drawing.Image)(resources.GetObject("ptbBack.Image")));
            this.ptbBack.ImageRotate = 0F;
            this.ptbBack.Location = new System.Drawing.Point(8, 26);
            this.ptbBack.Name = "ptbBack";
            this.ptbBack.Size = new System.Drawing.Size(25, 25);
            this.ptbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbBack.TabIndex = 1;
            this.ptbBack.TabStop = false;
            this.ptbBack.Click += new System.EventHandler(this.ptbBack_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Gray;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(42, 17);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(424, 51);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Danh Sách Bài Đăng";
            // 
            // pnlDanhSachIDND
            // 
            this.pnlDanhSachIDND.AutoScroll = true;
            this.pnlDanhSachIDND.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlDanhSachIDND.Location = new System.Drawing.Point(21, 94);
            this.pnlDanhSachIDND.Name = "pnlDanhSachIDND";
            this.pnlDanhSachIDND.Size = new System.Drawing.Size(1012, 427);
            this.pnlDanhSachIDND.TabIndex = 7;
            // 
            // UC_DanhSachBaiDangND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDanhSachIDND);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "UC_DanhSachBaiDangND";
            this.Size = new System.Drawing.Size(1052, 555);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox ptbBack;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel pnlDanhSachIDND;
    }
}

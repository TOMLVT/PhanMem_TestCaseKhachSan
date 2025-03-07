namespace TestCaseKhachSan
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mànHìnhChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mànHìnhPhụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoaDon1 = new TestCaseKhachSan.UserForm.HoaDon();
            this.manHinhPhu1 = new TestCaseKhachSan.UserForm.ManHinhPhu();
            this.manHinhChinh1 = new TestCaseKhachSan.UserForm.ManHinhChinh();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mànHìnhChínhToolStripMenuItem,
            this.hóaĐơnToolStripMenuItem,
            this.mànHìnhPhụToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1432, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mànHìnhChínhToolStripMenuItem
            // 
            this.mànHìnhChínhToolStripMenuItem.Name = "mànHìnhChínhToolStripMenuItem";
            this.mànHìnhChínhToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.mànHìnhChínhToolStripMenuItem.Text = "Màn hình chính";
            this.mànHìnhChínhToolStripMenuItem.Click += new System.EventHandler(this.mànHìnhChínhToolStripMenuItem_Click);
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.hóaĐơnToolStripMenuItem.Text = "Hóa đơn";
            this.hóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem_Click);
            // 
            // mànHìnhPhụToolStripMenuItem
            // 
            this.mànHìnhPhụToolStripMenuItem.Name = "mànHìnhPhụToolStripMenuItem";
            this.mànHìnhPhụToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.mànHìnhPhụToolStripMenuItem.Text = "Màn hình phụ";
            this.mànHìnhPhụToolStripMenuItem.Click += new System.EventHandler(this.mànHìnhPhụToolStripMenuItem_Click);
            // 
            // hoaDon1
            // 
            this.hoaDon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoaDon1.Location = new System.Drawing.Point(0, 30);
            this.hoaDon1.Name = "hoaDon1";
            this.hoaDon1.Size = new System.Drawing.Size(1432, 815);
            this.hoaDon1.TabIndex = 1;
            // 
            // manHinhPhu1
            // 
            this.manHinhPhu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manHinhPhu1.Location = new System.Drawing.Point(0, 30);
            this.manHinhPhu1.Name = "manHinhPhu1";
            this.manHinhPhu1.Size = new System.Drawing.Size(1432, 815);
            this.manHinhPhu1.TabIndex = 2;
            // 
            // manHinhChinh1
            // 
            this.manHinhChinh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manHinhChinh1.Location = new System.Drawing.Point(0, 30);
            this.manHinhChinh1.Name = "manHinhChinh1";
            this.manHinhChinh1.Size = new System.Drawing.Size(1432, 815);
            this.manHinhChinh1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1432, 845);
            this.Controls.Add(this.manHinhChinh1);
            this.Controls.Add(this.manHinhPhu1);
            this.Controls.Add(this.hoaDon1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mànHìnhChínhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mànHìnhPhụToolStripMenuItem;
        private UserForm.HoaDon hoaDon1;
        private UserForm.ManHinhPhu manHinhPhu1;
        private UserForm.ManHinhChinh manHinhChinh1;
    }
}


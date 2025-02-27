namespace TestCaseKhachSan
{
    partial class FormThemThietBi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.data_ThietBi = new System.Windows.Forms.DataGridView();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenThietBi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Dong = new System.Windows.Forms.Button();
            this.btn_ThemThietBi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_ThietBi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 63);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "MÀN HÌNH THÊM THIẾT BỊ CHO PHÒNG";
            // 
            // data_ThietBi
            // 
            this.data_ThietBi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_ThietBi.BackgroundColor = System.Drawing.Color.White;
            this.data_ThietBi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_ThietBi.Location = new System.Drawing.Point(12, 69);
            this.data_ThietBi.Name = "data_ThietBi";
            this.data_ThietBi.RowHeadersWidth = 51;
            this.data_ThietBi.RowTemplate.Height = 24;
            this.data_ThietBi.Size = new System.Drawing.Size(1018, 318);
            this.data_ThietBi.TabIndex = 9;
            this.data_ThietBi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_ThietBi_CellClick);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(558, 460);
            this.txtSoLuong.Multiline = true;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(331, 41);
            this.txtSoLuong.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(554, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nhập số lượng thêm";
            // 
            // txtTenThietBi
            // 
            this.txtTenThietBi.Location = new System.Drawing.Point(151, 460);
            this.txtTenThietBi.Multiline = true;
            this.txtTenThietBi.Name = "txtTenThietBi";
            this.txtTenThietBi.Size = new System.Drawing.Size(331, 41);
            this.txtTenThietBi.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên thiết bị đang chọn";
            // 
            // btn_Dong
            // 
            this.btn_Dong.BackColor = System.Drawing.Color.Black;
            this.btn_Dong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Dong.Location = new System.Drawing.Point(581, 558);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(235, 64);
            this.btn_Dong.TabIndex = 141;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.UseVisualStyleBackColor = false;
            // 
            // btn_ThemThietBi
            // 
            this.btn_ThemThietBi.BackColor = System.Drawing.Color.Green;
            this.btn_ThemThietBi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThemThietBi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemThietBi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ThemThietBi.Location = new System.Drawing.Point(201, 558);
            this.btn_ThemThietBi.Name = "btn_ThemThietBi";
            this.btn_ThemThietBi.Size = new System.Drawing.Size(374, 64);
            this.btn_ThemThietBi.TabIndex = 140;
            this.btn_ThemThietBi.Text = "Xác nhận thêm thiết bị";
            this.btn_ThemThietBi.UseVisualStyleBackColor = false;
            this.btn_ThemThietBi.Click += new System.EventHandler(this.btn_ThemThietBi_Click);
            // 
            // FormThemThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 664);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.btn_ThemThietBi);
            this.Controls.Add(this.txtTenThietBi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.data_ThietBi);
            this.Controls.Add(this.panel1);
            this.Name = "FormThemThietBi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormThemThietBi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_ThietBi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView data_ThietBi;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenThietBi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Dong;
        private System.Windows.Forms.Button btn_ThemThietBi;
    }
}
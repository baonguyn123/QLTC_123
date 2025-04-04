namespace WindowsFormsApp16
{
    partial class NV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NV));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgNV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsuaNV = new System.Windows.Forms.Button();
            this.btnxoaNV = new System.Windows.Forms.Button();
            this.btnthemNV = new System.Windows.Forms.Button();
            this.dateNS = new System.Windows.Forms.DateTimePicker();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txttaiKhoan = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txthoTen = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNV)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::WindowsFormsApp16.Properties.Resources.Ảnh_chụp_màn_hình_2025_01_07_165934;
            this.panel2.Controls.Add(this.dtgNV);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Location = new System.Drawing.Point(12, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 346);
            this.panel2.TabIndex = 2;
            // 
            // dtgNV
            // 
            this.dtgNV.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dtgNV.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtgNV.Location = new System.Drawing.Point(0, 70);
            this.dtgNV.Name = "dtgNV";
            this.dtgNV.ReadOnly = true;
            this.dtgNV.RowHeadersWidth = 51;
            this.dtgNV.RowTemplate.Height = 24;
            this.dtgNV.Size = new System.Drawing.Size(1064, 310);
            this.dtgNV.TabIndex = 2;
            this.dtgNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgNV_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID Nhân viên";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "ID";
            this.Column2.HeaderText = "Họ Tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "ID";
            this.Column3.HeaderText = "Địa chỉ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "ID";
            this.Column4.HeaderText = "Số điện thoại";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "ID";
            this.Column5.HeaderText = "Tài khoản";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "ID";
            this.Column6.HeaderText = "Mật khẩu";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "ID";
            this.Column7.HeaderText = "Ngày sinh";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label19.Location = new System.Drawing.Point(367, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(299, 32);
            this.label19.TabIndex = 1;
            this.label19.Text = "Danh sách nhân viên";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WindowsFormsApp16.Properties.Resources.Ảnh_chụp_màn_hình_2025_01_07_171438;
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnTrangChu);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnsuaNV);
            this.panel1.Controls.Add(this.btnxoaNV);
            this.panel1.Controls.Add(this.btnthemNV);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 210);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(953, 166);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 30);
            this.btnThoat.TabIndex = 37;
            this.btnThoat.Text = "Đăng xuất";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(850, 166);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 33);
            this.btnHuy.TabIndex = 36;
            this.btnHuy.Text = "Hủy tìm";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Enabled = false;
            this.btnTrangChu.Location = new System.Drawing.Point(20, 170);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(97, 26);
            this.btnTrangChu.TabIndex = 35;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(745, 165);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(84, 31);
            this.btnTimKiem.TabIndex = 34;
            this.btnTimKiem.Text = "Tìm kiếm ";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(546, 169);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(169, 22);
            this.txtTimKiem.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tìm kiếm";
            // 
            // txtIDNV
            // 
            this.txtIDNV.Location = new System.Drawing.Point(272, 120);
            this.txtIDNV.Name = "txtIDNV";
            this.txtIDNV.ReadOnly = true;
            this.txtIDNV.Size = new System.Drawing.Size(184, 22);
            this.txtIDNV.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "ID";
            // 
            // btnsuaNV
            // 
            this.btnsuaNV.Location = new System.Drawing.Point(353, 165);
            this.btnsuaNV.Name = "btnsuaNV";
            this.btnsuaNV.Size = new System.Drawing.Size(75, 34);
            this.btnsuaNV.TabIndex = 29;
            this.btnsuaNV.Text = "Sửa";
            this.btnsuaNV.UseVisualStyleBackColor = true;
            this.btnsuaNV.Click += new System.EventHandler(this.btnsuaNV_Click);
            // 
            // btnxoaNV
            // 
            this.btnxoaNV.Location = new System.Drawing.Point(247, 165);
            this.btnxoaNV.Name = "btnxoaNV";
            this.btnxoaNV.Size = new System.Drawing.Size(75, 34);
            this.btnxoaNV.TabIndex = 28;
            this.btnxoaNV.Text = "Xóa";
            this.btnxoaNV.UseVisualStyleBackColor = true;
            this.btnxoaNV.Click += new System.EventHandler(this.btnxoaNV_Click);
            // 
            // btnthemNV
            // 
            this.btnthemNV.Location = new System.Drawing.Point(141, 165);
            this.btnthemNV.Name = "btnthemNV";
            this.btnthemNV.Size = new System.Drawing.Size(75, 34);
            this.btnthemNV.TabIndex = 27;
            this.btnthemNV.Text = "Thêm";
            this.btnthemNV.UseVisualStyleBackColor = true;
            this.btnthemNV.Click += new System.EventHandler(this.btnthemNV_Click);
            // 
            // dateNS
            // 
            this.dateNS.Location = new System.Drawing.Point(513, 123);
            this.dateNS.Name = "dateNS";
            this.dateNS.Size = new System.Drawing.Size(233, 22);
            this.dateNS.TabIndex = 26;
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(763, 52);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(165, 22);
            this.txtMK.TabIndex = 25;
            // 
            // txttaiKhoan
            // 
            this.txttaiKhoan.Location = new System.Drawing.Point(513, 52);
            this.txttaiKhoan.Name = "txttaiKhoan";
            this.txttaiKhoan.Size = new System.Drawing.Size(176, 22);
            this.txttaiKhoan.TabIndex = 24;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(272, 52);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(197, 22);
            this.txtDiaChi.TabIndex = 23;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(26, 120);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(168, 22);
            this.txtSDT.TabIndex = 22;
            // 
            // txthoTen
            // 
            this.txthoTen.Location = new System.Drawing.Point(26, 52);
            this.txthoTen.Name = "txthoTen";
            this.txthoTen.Size = new System.Drawing.Size(168, 22);
            this.txthoTen.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(510, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 16);
            this.label18.TabIndex = 20;
            this.label18.Text = "Tài khoản";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(760, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 16);
            this.label17.TabIndex = 19;
            this.label17.Text = "Mật khẩu";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(510, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 16);
            this.label16.TabIndex = 18;
            this.label16.Text = "Ngày sinh";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(269, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 17;
            this.label15.Text = "Địa chỉ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 16);
            this.label14.TabIndex = 16;
            this.label14.Text = "Số điện thoại";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 15;
            this.label13.Text = "Họ tên";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Bisque;
            this.groupBox1.Controls.Add(this.txthoTen);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtIDNV);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txttaiKhoan);
            this.groupBox1.Controls.Add(this.txtMK);
            this.groupBox1.Controls.Add(this.dateNS);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 151);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // NV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 586);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NV";
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.NV_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnsuaNV;
        private System.Windows.Forms.Button btnxoaNV;
        private System.Windows.Forms.Button btnthemNV;
        private System.Windows.Forms.DateTimePicker dateNS;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txttaiKhoan;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txthoTen;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgNV;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtIDNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
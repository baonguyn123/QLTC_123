namespace WindowsFormsApp16
{
    partial class KyGoi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KyGoi));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.petNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vMNKyGoiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnHuyTim = new System.Windows.Forms.Button();
            this.btnsuaPet = new System.Windows.Forms.Button();
            this.btnxoaPet = new System.Windows.Forms.Button();
            this.btnthemPet = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThanhToanTC = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSDTChu = new System.Windows.Forms.TextBox();
            this.txtTenChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtgiaPet = new System.Windows.Forms.TextBox();
            this.txtslPet = new System.Windows.Forms.TextBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.txttenPet = new System.Windows.Forms.TextBox();
            this.lbltenPet = new System.Windows.Forms.Label();
            this.txtidPet = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoChuong = new System.Windows.Forms.TextBox();
            this.txtTim = new System.Windows.Forms.Label();
            this.txtTimKyGoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNV = new System.Windows.Forms.ComboBox();
            this.NgayVe = new System.Windows.Forms.DateTimePicker();
            this.txtTT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NgayDen = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblgiaPet = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMNKyGoiBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(1, 351);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1305, 308);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.ownerNameDataGridViewTextBoxColumn,
            this.contactDataGridViewTextBoxColumn,
            this.petNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn,
            this.cageNameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vMNKyGoiBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1299, 308);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ownerNameDataGridViewTextBoxColumn
            // 
            this.ownerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ownerNameDataGridViewTextBoxColumn.DataPropertyName = "OwnerName";
            this.ownerNameDataGridViewTextBoxColumn.HeaderText = "Tên chủ";
            this.ownerNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ownerNameDataGridViewTextBoxColumn.Name = "ownerNameDataGridViewTextBoxColumn";
            this.ownerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contactDataGridViewTextBoxColumn
            // 
            this.contactDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.contactDataGridViewTextBoxColumn.DataPropertyName = "Contact";
            this.contactDataGridViewTextBoxColumn.HeaderText = "Liên hệ";
            this.contactDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.contactDataGridViewTextBoxColumn.Name = "contactDataGridViewTextBoxColumn";
            this.contactDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // petNameDataGridViewTextBoxColumn
            // 
            this.petNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.petNameDataGridViewTextBoxColumn.DataPropertyName = "PetName";
            this.petNameDataGridViewTextBoxColumn.HeaderText = "Tên thú cưng";
            this.petNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.petNameDataGridViewTextBoxColumn.Name = "petNameDataGridViewTextBoxColumn";
            this.petNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "Ngày gửi";
            this.startDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Ngày trả";
            this.endDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Giá";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "Tổng tiền";
            this.totalPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cageNameDataGridViewTextBoxColumn
            // 
            this.cageNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cageNameDataGridViewTextBoxColumn.DataPropertyName = "CageName";
            this.cageNameDataGridViewTextBoxColumn.HeaderText = "Tên chuồng";
            this.cageNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cageNameDataGridViewTextBoxColumn.Name = "cageNameDataGridViewTextBoxColumn";
            this.cageNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Tên nhân viên";
            this.fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vMNKyGoiBindingSource
            // 
            this.vMNKyGoiBindingSource.DataSource = typeof(WindowsFormsApp16.VMNKyGoi);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WindowsFormsApp16.Properties.Resources.Ảnh_chụp_màn_hình_2025_01_07_190407;
            this.panel1.Controls.Add(this.btnTrangChu);
            this.panel1.Controls.Add(this.btnHuyTim);
            this.panel1.Controls.Add(this.btnsuaPet);
            this.panel1.Controls.Add(this.btnxoaPet);
            this.panel1.Controls.Add(this.btnthemPet);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.btnThanhToanTC);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtSDTChu);
            this.panel1.Controls.Add(this.txtTenChu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtgiaPet);
            this.panel1.Controls.Add(this.txtslPet);
            this.panel1.Controls.Add(this.lblSL);
            this.panel1.Controls.Add(this.txttenPet);
            this.panel1.Controls.Add(this.lbltenPet);
            this.panel1.Controls.Add(this.txtidPet);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1305, 342);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.Location = new System.Drawing.Point(1053, 291);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(86, 34);
            this.btnTrangChu.TabIndex = 47;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // btnHuyTim
            // 
            this.btnHuyTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyTim.Location = new System.Drawing.Point(197, 300);
            this.btnHuyTim.Name = "btnHuyTim";
            this.btnHuyTim.Size = new System.Drawing.Size(75, 23);
            this.btnHuyTim.TabIndex = 46;
            this.btnHuyTim.Text = "Hủy tìm";
            this.btnHuyTim.UseVisualStyleBackColor = true;
            this.btnHuyTim.Click += new System.EventHandler(this.btnHuyTim_Click);
            // 
            // btnsuaPet
            // 
            this.btnsuaPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsuaPet.Location = new System.Drawing.Point(683, 294);
            this.btnsuaPet.Name = "btnsuaPet";
            this.btnsuaPet.Size = new System.Drawing.Size(101, 31);
            this.btnsuaPet.TabIndex = 45;
            this.btnsuaPet.Text = "Sửa";
            this.btnsuaPet.UseVisualStyleBackColor = true;
            this.btnsuaPet.Click += new System.EventHandler(this.btnsuaPet_Click);
            // 
            // btnxoaPet
            // 
            this.btnxoaPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoaPet.Location = new System.Drawing.Point(520, 294);
            this.btnxoaPet.Name = "btnxoaPet";
            this.btnxoaPet.Size = new System.Drawing.Size(101, 31);
            this.btnxoaPet.TabIndex = 44;
            this.btnxoaPet.Text = "Xóa";
            this.btnxoaPet.UseVisualStyleBackColor = true;
            this.btnxoaPet.Click += new System.EventHandler(this.btnxoaPet_Click);
            // 
            // btnthemPet
            // 
            this.btnthemPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthemPet.Location = new System.Drawing.Point(361, 296);
            this.btnthemPet.Name = "btnthemPet";
            this.btnthemPet.Size = new System.Drawing.Size(101, 31);
            this.btnthemPet.TabIndex = 43;
            this.btnthemPet.Text = "Thêm";
            this.btnthemPet.UseVisualStyleBackColor = true;
            this.btnthemPet.Click += new System.EventHandler(this.btnthemPet_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(68, 295);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 27);
            this.btnTimKiem.TabIndex = 42;
            this.btnTimKiem.Text = "Tìm Kiếm ";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThanhToanTC
            // 
            this.btnThanhToanTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToanTC.Location = new System.Drawing.Point(865, 291);
            this.btnThanhToanTC.Name = "btnThanhToanTC";
            this.btnThanhToanTC.Size = new System.Drawing.Size(108, 36);
            this.btnThanhToanTC.TabIndex = 41;
            this.btnThanhToanTC.Text = "Thanh Toán";
            this.btnThanhToanTC.UseVisualStyleBackColor = true;
            this.btnThanhToanTC.Click += new System.EventHandler(this.btnThanhToanTC_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.PeachPuff;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "Số chuồng";
            // 
            // txtSDTChu
            // 
            this.txtSDTChu.Location = new System.Drawing.Point(581, 121);
            this.txtSDTChu.Name = "txtSDTChu";
            this.txtSDTChu.Size = new System.Drawing.Size(225, 22);
            this.txtSDTChu.TabIndex = 36;
            // 
            // txtTenChu
            // 
            this.txtTenChu.Location = new System.Drawing.Point(581, 65);
            this.txtTenChu.Name = "txtTenChu";
            this.txtTenChu.Size = new System.Drawing.Size(225, 22);
            this.txtTenChu.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PeachPuff;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(433, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Số điện thoại chủ";
            // 
            // txtgiaPet
            // 
            this.txtgiaPet.Location = new System.Drawing.Point(1044, 62);
            this.txtgiaPet.Name = "txtgiaPet";
            this.txtgiaPet.ReadOnly = true;
            this.txtgiaPet.Size = new System.Drawing.Size(114, 22);
            this.txtgiaPet.TabIndex = 24;
            // 
            // txtslPet
            // 
            this.txtslPet.Location = new System.Drawing.Point(1044, 119);
            this.txtslPet.Name = "txtslPet";
            this.txtslPet.Size = new System.Drawing.Size(114, 22);
            this.txtslPet.TabIndex = 23;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.BackColor = System.Drawing.Color.PeachPuff;
            this.lblSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSL.Location = new System.Drawing.Point(930, 123);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(82, 20);
            this.lblSL.TabIndex = 21;
            this.lblSL.Text = "Số lượng";
            // 
            // txttenPet
            // 
            this.txttenPet.Location = new System.Drawing.Point(144, 121);
            this.txttenPet.Name = "txttenPet";
            this.txttenPet.Size = new System.Drawing.Size(189, 22);
            this.txttenPet.TabIndex = 18;
            // 
            // lbltenPet
            // 
            this.lbltenPet.AutoSize = true;
            this.lbltenPet.BackColor = System.Drawing.Color.PeachPuff;
            this.lbltenPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltenPet.Location = new System.Drawing.Point(33, 121);
            this.lbltenPet.Name = "lbltenPet";
            this.lbltenPet.Size = new System.Drawing.Size(46, 20);
            this.lbltenPet.TabIndex = 17;
            this.lbltenPet.Text = "Tên ";
            // 
            // txtidPet
            // 
            this.txtidPet.Location = new System.Drawing.Point(144, 59);
            this.txtidPet.Name = "txtidPet";
            this.txtidPet.ReadOnly = true;
            this.txtidPet.Size = new System.Drawing.Size(189, 22);
            this.txtidPet.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.PeachPuff;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(34, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 20);
            this.label21.TabIndex = 15;
            this.label21.Text = "ID";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Cornsilk;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Maroon;
            this.label20.Location = new System.Drawing.Point(508, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(274, 32);
            this.label20.TabIndex = 13;
            this.label20.Text = "Đăng Ký Thông Tin";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.txtSoChuong);
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.txtTimKyGoi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbNV);
            this.groupBox1.Controls.Add(this.NgayVe);
            this.groupBox1.Controls.Add(this.txtTT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NgayDen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblgiaPet);
            this.groupBox1.Location = new System.Drawing.Point(26, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1197, 235);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // txtSoChuong
            // 
            this.txtSoChuong.Location = new System.Drawing.Point(118, 133);
            this.txtSoChuong.Name = "txtSoChuong";
            this.txtSoChuong.Size = new System.Drawing.Size(189, 22);
            this.txtSoChuong.TabIndex = 39;
            // 
            // txtTim
            // 
            this.txtTim.AutoSize = true;
            this.txtTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(9, 184);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(70, 16);
            this.txtTim.TabIndex = 33;
            this.txtTim.Text = "Tìm kiếm";
            // 
            // txtTimKyGoi
            // 
            this.txtTimKyGoi.Location = new System.Drawing.Point(118, 183);
            this.txtTimKyGoi.Name = "txtTimKyGoi";
            this.txtTimKyGoi.Size = new System.Drawing.Size(189, 22);
            this.txtTimKyGoi.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Tên chủ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(407, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Ngày đến ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Nhân viên";
            // 
            // cbNV
            // 
            this.cbNV.FormattingEnabled = true;
            this.cbNV.Location = new System.Drawing.Point(555, 175);
            this.cbNV.Name = "cbNV";
            this.cbNV.Size = new System.Drawing.Size(142, 24);
            this.cbNV.TabIndex = 40;
            // 
            // NgayVe
            // 
            this.NgayVe.Location = new System.Drawing.Point(859, 131);
            this.NgayVe.Name = "NgayVe";
            this.NgayVe.Size = new System.Drawing.Size(200, 22);
            this.NgayVe.TabIndex = 32;
            this.NgayVe.ValueChanged += new System.EventHandler(this.NgayVe_ValueChanged);
            // 
            // txtTT
            // 
            this.txtTT.Location = new System.Drawing.Point(943, 181);
            this.txtTT.Name = "txtTT";
            this.txtTT.ReadOnly = true;
            this.txtTT.Size = new System.Drawing.Size(116, 22);
            this.txtTT.TabIndex = 37;
            this.txtTT.TextChanged += new System.EventHandler(this.txtTT_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(779, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "Ngày về";
            // 
            // NgayDen
            // 
            this.NgayDen.Location = new System.Drawing.Point(556, 131);
            this.NgayDen.Name = "NgayDen";
            this.NgayDen.Size = new System.Drawing.Size(200, 22);
            this.NgayDen.TabIndex = 31;
            this.NgayDen.ValueChanged += new System.EventHandler(this.NgayDen_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(856, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tổng tiền";
            // 
            // lblgiaPet
            // 
            this.lblgiaPet.AutoSize = true;
            this.lblgiaPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgiaPet.Location = new System.Drawing.Point(887, 24);
            this.lblgiaPet.Name = "lblgiaPet";
            this.lblgiaPet.Size = new System.Drawing.Size(99, 20);
            this.lblgiaPet.TabIndex = 22;
            this.lblgiaPet.Text = "Giá combo";
            // 
            // KyGoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 671);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KyGoi";
            this.Text = "Ký Gửi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KyGoi_FormClosing);
            this.Load += new System.EventHandler(this.KyGoi_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMNKyGoiBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtgiaPet;
        private System.Windows.Forms.TextBox txtslPet;
        private System.Windows.Forms.Label lblgiaPet;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.TextBox txttenPet;
        private System.Windows.Forms.Label lbltenPet;
        private System.Windows.Forms.TextBox txtidPet;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTimKyGoi;
        private System.Windows.Forms.Label txtTim;
        private System.Windows.Forms.DateTimePicker NgayVe;
        private System.Windows.Forms.DateTimePicker NgayDen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoChuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTT;
        private System.Windows.Forms.TextBox txtSDTChu;
        private System.Windows.Forms.TextBox txtTenChu;
        private System.Windows.Forms.ComboBox cbNV;
        private System.Windows.Forms.Button btnThanhToanTC;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.BindingSource vMNKyGoiBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn petNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnsuaPet;
        private System.Windows.Forms.Button btnxoaPet;
        private System.Windows.Forms.Button btnthemPet;
        private System.Windows.Forms.Button btnHuyTim;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
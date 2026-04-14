namespace QLBanGiay.GUI
{
    partial class FrmQLKM_Voucher_NEW
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvVoucher = new System.Windows.Forms.DataGridView();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDK = new System.Windows.Forms.TextBox();
            this.txtGiam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddVoucher = new System.Windows.Forms.Button();
            this.btnUpdateVoucher = new System.Windows.Forms.Button();
            this.btnDeleteVoucher = new System.Windows.Forms.Button();
            this.btnNgung = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKM = new System.Windows.Forms.DataGridView();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.btnAddKM = new System.Windows.Forms.Button();
            this.btnUpdateKM = new System.Windows.Forms.Button();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteKM = new System.Windows.Forms.Button();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.rdoNgung = new System.Windows.Forms.RadioButton();
            this.rdoHoatDong = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.paMain = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.dsds = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).BeginInit();
            this.pnLeft.SuspendLayout();
            this.paMain.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnBatDau);
            this.groupBox1.Controls.Add(this.btnNgung);
            this.groupBox1.Controls.Add(this.btnDeleteVoucher);
            this.groupBox1.Controls.Add(this.btnUpdateVoucher);
            this.groupBox1.Controls.Add(this.btnAddVoucher);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGiam);
            this.groupBox1.Controls.Add(this.txtDK);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.dgvVoucher);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(253, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 723);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VOUCHER";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoucher.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucher.Location = new System.Drawing.Point(9, 302);
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.RowHeadersVisible = false;
            this.dgvVoucher.RowHeadersWidth = 51;
            this.dgvVoucher.RowTemplate.Height = 24;
            this.dgvVoucher.Size = new System.Drawing.Size(645, 343);
            this.dgvVoucher.TabIndex = 0;
            this.dgvVoucher.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(98, 66);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 25);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(448, 115);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(150, 25);
            this.txtGhiChu.TabIndex = 2;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(448, 63);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(150, 25);
            this.txtSoLuong.TabIndex = 3;
            // 
            // txtDK
            // 
            this.txtDK.Location = new System.Drawing.Point(98, 161);
            this.txtDK.Name = "txtDK";
            this.txtDK.Size = new System.Drawing.Size(150, 25);
            this.txtDK.TabIndex = 4;
            // 
            // txtGiam
            // 
            this.txtGiam.Location = new System.Drawing.Point(98, 112);
            this.txtGiam.Name = "txtGiam";
            this.txtGiam.Size = new System.Drawing.Size(150, 25);
            this.txtGiam.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "mã voucher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tiền giảm";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(448, 193);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 25);
            this.dateTimePicker1.TabIndex = 28;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(448, 151);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(150, 25);
            this.dateTimePicker2.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Điều kiện";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ngày kết thúc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ngày bắt đầu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ghi chú";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Số lượng";
            // 
            // btnAddVoucher
            // 
            this.btnAddVoucher.Location = new System.Drawing.Point(9, 240);
            this.btnAddVoucher.Name = "btnAddVoucher";
            this.btnAddVoucher.Size = new System.Drawing.Size(103, 29);
            this.btnAddVoucher.TabIndex = 15;
            this.btnAddVoucher.Text = "ADD";
            this.btnAddVoucher.UseVisualStyleBackColor = true;
            this.btnAddVoucher.Click += new System.EventHandler(this.btnAddVoucher_Click);
            // 
            // btnUpdateVoucher
            // 
            this.btnUpdateVoucher.Location = new System.Drawing.Point(118, 240);
            this.btnUpdateVoucher.Name = "btnUpdateVoucher";
            this.btnUpdateVoucher.Size = new System.Drawing.Size(103, 29);
            this.btnUpdateVoucher.TabIndex = 16;
            this.btnUpdateVoucher.Text = "UPDATE";
            this.btnUpdateVoucher.UseVisualStyleBackColor = true;
            this.btnUpdateVoucher.Click += new System.EventHandler(this.btnUpdateVoucher_Click);
            // 
            // btnDeleteVoucher
            // 
            this.btnDeleteVoucher.Location = new System.Drawing.Point(227, 240);
            this.btnDeleteVoucher.Name = "btnDeleteVoucher";
            this.btnDeleteVoucher.Size = new System.Drawing.Size(103, 29);
            this.btnDeleteVoucher.TabIndex = 17;
            this.btnDeleteVoucher.Text = "DELETE";
            this.btnDeleteVoucher.UseVisualStyleBackColor = true;
            this.btnDeleteVoucher.Click += new System.EventHandler(this.btnDeleteVoucher_Click);
            // 
            // btnNgung
            // 
            this.btnNgung.Location = new System.Drawing.Point(395, 240);
            this.btnNgung.Name = "btnNgung";
            this.btnNgung.Size = new System.Drawing.Size(85, 29);
            this.btnNgung.TabIndex = 18;
            this.btnNgung.Text = "STOP";
            this.btnNgung.UseVisualStyleBackColor = true;
            this.btnNgung.Click += new System.EventHandler(this.btnNgung_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(495, 240);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(85, 29);
            this.btnBatDau.TabIndex = 19;
            this.btnBatDau.Text = "START";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(199, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 17);
            this.label15.TabIndex = 29;
            this.label15.Text = "VOUCHER";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.rdoHoatDong);
            this.groupBox2.Controls.Add(this.rdoNgung);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtpKetThuc);
            this.groupBox2.Controls.Add(this.btnDeleteKM);
            this.groupBox2.Controls.Add(this.dtpBatDau);
            this.groupBox2.Controls.Add(this.btnUpdateKM);
            this.groupBox2.Controls.Add(this.btnAddKM);
            this.groupBox2.Controls.Add(this.txtGiaTri);
            this.groupBox2.Controls.Add(this.cboLoai);
            this.groupBox2.Controls.Add(this.txtTenKM);
            this.groupBox2.Controls.Add(this.dgvKM);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(1037, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 729);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KM";
            // 
            // dgvKM
            // 
            this.dgvKM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKM.BackgroundColor = System.Drawing.Color.White;
            this.dgvKM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKM.Location = new System.Drawing.Point(6, 302);
            this.dgvKM.Name = "dgvKM";
            this.dgvKM.RowHeadersVisible = false;
            this.dgvKM.RowHeadersWidth = 51;
            this.dgvKM.RowTemplate.Height = 24;
            this.dgvKM.Size = new System.Drawing.Size(681, 343);
            this.dgvKM.TabIndex = 1;
            this.dgvKM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKM_CellContentClick);
            // 
            // txtTenKM
            // 
            this.txtTenKM.Location = new System.Drawing.Point(92, 63);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(150, 25);
            this.txtTenKM.TabIndex = 21;
            // 
            // cboLoai
            // 
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(92, 115);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(150, 25);
            this.cboLoai.TabIndex = 22;
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(92, 161);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(150, 25);
            this.txtGiaTri.TabIndex = 23;
            // 
            // btnAddKM
            // 
            this.btnAddKM.Location = new System.Drawing.Point(0, 240);
            this.btnAddKM.Name = "btnAddKM";
            this.btnAddKM.Size = new System.Drawing.Size(114, 29);
            this.btnAddKM.TabIndex = 24;
            this.btnAddKM.Text = "ADD";
            this.btnAddKM.UseVisualStyleBackColor = true;
            this.btnAddKM.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdateKM
            // 
            this.btnUpdateKM.Location = new System.Drawing.Point(120, 240);
            this.btnUpdateKM.Name = "btnUpdateKM";
            this.btnUpdateKM.Size = new System.Drawing.Size(114, 29);
            this.btnUpdateKM.TabIndex = 25;
            this.btnUpdateKM.Text = "UPDATE";
            this.btnUpdateKM.UseVisualStyleBackColor = true;
            this.btnUpdateKM.Click += new System.EventHandler(this.btnUpdateKM_Click);
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.Location = new System.Drawing.Point(490, 150);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(150, 25);
            this.dtpBatDau.TabIndex = 6;
            // 
            // btnDeleteKM
            // 
            this.btnDeleteKM.Location = new System.Drawing.Point(240, 240);
            this.btnDeleteKM.Name = "btnDeleteKM";
            this.btnDeleteKM.Size = new System.Drawing.Size(114, 29);
            this.btnDeleteKM.TabIndex = 26;
            this.btnDeleteKM.Text = "DELETE";
            this.btnDeleteKM.UseVisualStyleBackColor = true;
            this.btnDeleteKM.Click += new System.EventHandler(this.btnDeleteKM_Click);
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.Location = new System.Drawing.Point(490, 193);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(150, 25);
            this.dtpKetThuc.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(370, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Ngày kết thúc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Ngày bắt đầu";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(490, 112);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(150, 25);
            this.textBox3.TabIndex = 31;
            // 
            // rdoNgung
            // 
            this.rdoNgung.AutoSize = true;
            this.rdoNgung.Location = new System.Drawing.Point(490, 86);
            this.rdoNgung.Name = "rdoNgung";
            this.rdoNgung.Size = new System.Drawing.Size(72, 21);
            this.rdoNgung.TabIndex = 32;
            this.rdoNgung.TabStop = true;
            this.rdoNgung.Text = "Ngưng";
            this.rdoNgung.UseVisualStyleBackColor = true;
            // 
            // rdoHoatDong
            // 
            this.rdoHoatDong.AutoSize = true;
            this.rdoHoatDong.Location = new System.Drawing.Point(490, 60);
            this.rdoHoatDong.Name = "rdoHoatDong";
            this.rdoHoatDong.Size = new System.Drawing.Size(95, 21);
            this.rdoHoatDong.TabIndex = 33;
            this.rdoHoatDong.TabStop = true;
            this.rdoHoatDong.Text = "Hoạt động";
            this.rdoHoatDong.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Tên KM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "Giá trị";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 17);
            this.label12.TabIndex = 36;
            this.label12.Text = "Loại";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(371, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 37;
            this.label13.Text = "Ghi chú";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(370, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 17);
            this.label14.TabIndex = 38;
            this.label14.Text = "Trạng thái";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(214, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 17);
            this.label16.TabIndex = 30;
            this.label16.Text = "KHUYẾN MÃI";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.White;
            this.pnLeft.Controls.Add(this.button1);
            this.pnLeft.Controls.Add(this.label23);
            this.pnLeft.Controls.Add(this.label22);
            this.pnLeft.Controls.Add(this.label21);
            this.pnLeft.Controls.Add(this.label20);
            this.pnLeft.Controls.Add(this.label19);
            this.pnLeft.Controls.Add(this.label18);
            this.pnLeft.Controls.Add(this.label17);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(176, 748);
            this.pnLeft.TabIndex = 4;
            this.pnLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnLeft_Paint);
            // 
            // paMain
            // 
            this.paMain.BackColor = System.Drawing.Color.White;
            this.paMain.Controls.Add(this.groupBox1);
            this.paMain.Controls.Add(this.pnTop);
            this.paMain.Controls.Add(this.pnLeft);
            this.paMain.Controls.Add(this.groupBox2);
            this.paMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paMain.Location = new System.Drawing.Point(0, 0);
            this.paMain.Name = "paMain";
            this.paMain.Size = new System.Drawing.Size(1500, 748);
            this.paMain.TabIndex = 2;
            this.paMain.Paint += new System.Windows.Forms.PaintEventHandler(this.paMain_Paint);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.dsds);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(176, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1324, 60);
            this.pnTop.TabIndex = 5;
            // 
            // dsds
            // 
            this.dsds.AutoSize = true;
            this.dsds.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsds.ForeColor = System.Drawing.Color.White;
            this.dsds.Location = new System.Drawing.Point(31, 9);
            this.dsds.Name = "dsds";
            this.dsds.Size = new System.Drawing.Size(349, 31);
            this.dsds.TabIndex = 0;
            this.dsds.Text = "HỆ THỐNG QUẢN LÝ BÁN GIÀY";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(12, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 25);
            this.label17.TabIndex = 0;
            this.label17.Text = "Trang chủ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(12, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 25);
            this.label18.TabIndex = 1;
            this.label18.Text = "Chi tiết SP";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(12, 161);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 25);
            this.label19.TabIndex = 2;
            this.label19.Text = "Khách hàng";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(12, 253);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 25);
            this.label20.TabIndex = 3;
            this.label20.Text = "Thống kê";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(12, 202);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 25);
            this.label21.TabIndex = 4;
            this.label21.Text = "Tài khoản";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(12, 119);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(117, 25);
            this.label22.TabIndex = 5;
            this.label22.Text = "Voucher-KM";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(12, 302);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(85, 25);
            this.label23.TabIndex = 6;
            this.label23.Text = "Hóa đơn";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 725);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đăng xuất";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmQLKM_Voucher_NEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1500, 748);
            this.Controls.Add(this.paMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmQLKM_Voucher_NEW";
            this.Text = "FrmQLKM_Voucher_NEW";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmQLKM_Voucher_NEW_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).EndInit();
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            this.paMain.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnNgung;
        private System.Windows.Forms.Button btnDeleteVoucher;
        private System.Windows.Forms.Button btnUpdateVoucher;
        private System.Windows.Forms.Button btnAddVoucher;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiam;
        private System.Windows.Forms.TextBox txtDK;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.DataGridView dgvVoucher;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoHoatDong;
        private System.Windows.Forms.RadioButton rdoNgung;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Button btnDeleteKM;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Button btnUpdateKM;
        private System.Windows.Forms.Button btnAddKM;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.DataGridView dgvKM;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel paMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label dsds;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
    }
}
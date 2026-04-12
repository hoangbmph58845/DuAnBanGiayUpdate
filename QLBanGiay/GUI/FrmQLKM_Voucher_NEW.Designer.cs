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
            this.dgvKM = new System.Windows.Forms.DataGridView();
            this.dgvVoucher = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rdoHoatDong = new System.Windows.Forms.RadioButton();
            this.rdoNgung = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteKM = new System.Windows.Forms.Button();
            this.btnUpdateKM = new System.Windows.Forms.Button();
            this.btnAddKM = new System.Windows.Forms.Button();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnNgung = new System.Windows.Forms.Button();
            this.btnDeleteVoucher = new System.Windows.Forms.Button();
            this.btnUpdateVoucher = new System.Windows.Forms.Button();
            this.btnAddVoucher = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.txtGiam = new System.Windows.Forms.TextBox();
            this.txtDK = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKM
            // 
            this.dgvKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKM.Location = new System.Drawing.Point(6, 341);
            this.dgvKM.Name = "dgvKM";
            this.dgvKM.RowHeadersWidth = 51;
            this.dgvKM.RowTemplate.Height = 24;
            this.dgvKM.Size = new System.Drawing.Size(505, 226);
            this.dgvKM.TabIndex = 1;
            this.dgvKM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKM_CellContentClick);
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucher.Location = new System.Drawing.Point(6, 341);
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.RowHeadersWidth = 51;
            this.dgvVoucher.RowTemplate.Height = 24;
            this.dgvVoucher.Size = new System.Drawing.Size(508, 229);
            this.dgvVoucher.TabIndex = 0;
            this.dgvVoucher.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 605);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
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
            this.groupBox2.Location = new System.Drawing.Point(538, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 590);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KM";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(262, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 16);
            this.label14.TabIndex = 38;
            this.label14.Text = "Trạng thái";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(262, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 16);
            this.label13.TabIndex = 37;
            this.label13.Text = "Ghi chú";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 16);
            this.label12.TabIndex = 36;
            this.label12.Text = "Loại";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "Giá trị";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 34;
            this.label10.Text = "Tên KM";
            // 
            // rdoHoatDong
            // 
            this.rdoHoatDong.AutoSize = true;
            this.rdoHoatDong.Location = new System.Drawing.Point(350, 60);
            this.rdoHoatDong.Name = "rdoHoatDong";
            this.rdoHoatDong.Size = new System.Drawing.Size(91, 20);
            this.rdoHoatDong.TabIndex = 33;
            this.rdoHoatDong.TabStop = true;
            this.rdoHoatDong.Text = "Hoạt động";
            this.rdoHoatDong.UseVisualStyleBackColor = true;
            // 
            // rdoNgung
            // 
            this.rdoNgung.AutoSize = true;
            this.rdoNgung.Location = new System.Drawing.Point(350, 86);
            this.rdoNgung.Name = "rdoNgung";
            this.rdoNgung.Size = new System.Drawing.Size(68, 20);
            this.rdoNgung.TabIndex = 32;
            this.rdoNgung.TabStop = true;
            this.rdoNgung.Text = "Ngưng";
            this.rdoNgung.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(350, 112);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(150, 22);
            this.textBox3.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Ngày bắt đầu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(262, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Ngày kết thúc";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(342, 194);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 22);
            this.dateTimePicker1.TabIndex = 28;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(342, 151);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(150, 22);
            this.dateTimePicker2.TabIndex = 27;
            // 
            // btnDeleteKM
            // 
            this.btnDeleteKM.Location = new System.Drawing.Point(199, 240);
            this.btnDeleteKM.Name = "btnDeleteKM";
            this.btnDeleteKM.Size = new System.Drawing.Size(85, 29);
            this.btnDeleteKM.TabIndex = 26;
            this.btnDeleteKM.Text = "DELETE";
            this.btnDeleteKM.UseVisualStyleBackColor = true;
            this.btnDeleteKM.Click += new System.EventHandler(this.btnDeleteKM_Click);
            // 
            // btnUpdateKM
            // 
            this.btnUpdateKM.Location = new System.Drawing.Point(108, 240);
            this.btnUpdateKM.Name = "btnUpdateKM";
            this.btnUpdateKM.Size = new System.Drawing.Size(85, 29);
            this.btnUpdateKM.TabIndex = 25;
            this.btnUpdateKM.Text = "UPDATE";
            this.btnUpdateKM.UseVisualStyleBackColor = true;
            this.btnUpdateKM.Click += new System.EventHandler(this.btnUpdateKM_Click);
            // 
            // btnAddKM
            // 
            this.btnAddKM.Location = new System.Drawing.Point(17, 240);
            this.btnAddKM.Name = "btnAddKM";
            this.btnAddKM.Size = new System.Drawing.Size(85, 29);
            this.btnAddKM.TabIndex = 24;
            this.btnAddKM.Text = "ADD";
            this.btnAddKM.UseVisualStyleBackColor = true;
            this.btnAddKM.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(92, 161);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(150, 22);
            this.txtGiaTri.TabIndex = 23;
            // 
            // cboLoai
            // 
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(92, 115);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(150, 24);
            this.cboLoai.TabIndex = 22;
            // 
            // txtTenKM
            // 
            this.txtTenKM.Location = new System.Drawing.Point(92, 63);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(150, 22);
            this.txtTenKM.TabIndex = 21;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 590);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VOUCHER";
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(407, 240);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(85, 29);
            this.btnBatDau.TabIndex = 19;
            this.btnBatDau.Text = "START";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnNgung
            // 
            this.btnNgung.Location = new System.Drawing.Point(307, 240);
            this.btnNgung.Name = "btnNgung";
            this.btnNgung.Size = new System.Drawing.Size(85, 29);
            this.btnNgung.TabIndex = 18;
            this.btnNgung.Text = "STOP";
            this.btnNgung.UseVisualStyleBackColor = true;
            this.btnNgung.Click += new System.EventHandler(this.btnNgung_Click);
            // 
            // btnDeleteVoucher
            // 
            this.btnDeleteVoucher.Location = new System.Drawing.Point(188, 240);
            this.btnDeleteVoucher.Name = "btnDeleteVoucher";
            this.btnDeleteVoucher.Size = new System.Drawing.Size(85, 29);
            this.btnDeleteVoucher.TabIndex = 17;
            this.btnDeleteVoucher.Text = "DELETE";
            this.btnDeleteVoucher.UseVisualStyleBackColor = true;
            this.btnDeleteVoucher.Click += new System.EventHandler(this.btnDeleteVoucher_Click);
            // 
            // btnUpdateVoucher
            // 
            this.btnUpdateVoucher.Location = new System.Drawing.Point(97, 240);
            this.btnUpdateVoucher.Name = "btnUpdateVoucher";
            this.btnUpdateVoucher.Size = new System.Drawing.Size(85, 29);
            this.btnUpdateVoucher.TabIndex = 16;
            this.btnUpdateVoucher.Text = "UPDATE";
            this.btnUpdateVoucher.UseVisualStyleBackColor = true;
            this.btnUpdateVoucher.Click += new System.EventHandler(this.btnUpdateVoucher_Click);
            // 
            // btnAddVoucher
            // 
            this.btnAddVoucher.Location = new System.Drawing.Point(6, 240);
            this.btnAddVoucher.Name = "btnAddVoucher";
            this.btnAddVoucher.Size = new System.Drawing.Size(85, 29);
            this.btnAddVoucher.TabIndex = 15;
            this.btnAddVoucher.Text = "ADD";
            this.btnAddVoucher.UseVisualStyleBackColor = true;
            this.btnAddVoucher.Click += new System.EventHandler(this.btnAddVoucher_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Số lượng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ghi chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ngày bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ngày kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Điều kiện";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tiền giảm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "mã voucher";
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.Location = new System.Drawing.Point(350, 193);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(150, 22);
            this.dtpKetThuc.TabIndex = 7;
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.Location = new System.Drawing.Point(350, 151);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(150, 22);
            this.dtpBatDau.TabIndex = 6;
            // 
            // txtGiam
            // 
            this.txtGiam.Location = new System.Drawing.Point(86, 112);
            this.txtGiam.Name = "txtGiam";
            this.txtGiam.Size = new System.Drawing.Size(150, 22);
            this.txtGiam.TabIndex = 5;
            // 
            // txtDK
            // 
            this.txtDK.Location = new System.Drawing.Point(86, 161);
            this.txtDK.Name = "txtDK";
            this.txtDK.Size = new System.Drawing.Size(150, 22);
            this.txtDK.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(342, 66);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(150, 22);
            this.txtSoLuong.TabIndex = 3;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(342, 112);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(150, 22);
            this.txtGhiChu.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(86, 66);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 22);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(199, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 16);
            this.label15.TabIndex = 29;
            this.label15.Text = "VOUCHER";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(214, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 16);
            this.label16.TabIndex = 30;
            this.label16.Text = "KHUYẾN MÃI";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmQLKM_Voucher_NEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 605);
            this.Controls.Add(this.panel1);
            this.Name = "FrmQLKM_Voucher_NEW";
            this.Text = "FrmQLKM_Voucher_NEW";
            this.Load += new System.EventHandler(this.FrmQLKM_Voucher_NEW_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvVoucher;
        private System.Windows.Forms.DataGridView dgvKM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtGiam;
        private System.Windows.Forms.TextBox txtDK;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnNgung;
        private System.Windows.Forms.Button btnDeleteVoucher;
        private System.Windows.Forms.Button btnUpdateVoucher;
        private System.Windows.Forms.Button btnAddVoucher;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Button btnDeleteKM;
        private System.Windows.Forms.Button btnUpdateKM;
        private System.Windows.Forms.Button btnAddKM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton rdoNgung;
        private System.Windows.Forms.RadioButton rdoHoatDong;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
    }
}
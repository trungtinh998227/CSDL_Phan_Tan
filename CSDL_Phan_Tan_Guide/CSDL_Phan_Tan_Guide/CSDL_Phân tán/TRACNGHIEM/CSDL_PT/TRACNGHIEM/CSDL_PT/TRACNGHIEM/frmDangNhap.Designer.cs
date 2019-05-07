namespace TRACNGHIEM
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.btndangnhap = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.cbxcoso = new System.Windows.Forms.ComboBox();
            this.spCacPhanManhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.distributionDataSet = new TRACNGHIEM.distributionDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttaikhoan = new System.Windows.Forms.TextBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbnhanvien = new System.Windows.Forms.RadioButton();
            this.rdbsinhvien = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.spCacPhanManhTableAdapter = new TRACNGHIEM.distributionDataSetTableAdapters.spCacPhanManhTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spCacPhanManhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributionDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btndangnhap
            // 
            this.btndangnhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangnhap.Image = global::TRACNGHIEM.Properties.Resources.Ok_icon;
            this.btndangnhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndangnhap.Location = new System.Drawing.Point(15, 202);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Size = new System.Drawing.Size(121, 41);
            this.btndangnhap.TabIndex = 6;
            this.btndangnhap.Text = "Đăng nhập";
            this.btndangnhap.UseVisualStyleBackColor = true;
            this.btndangnhap.Click += new System.EventHandler(this.btndangnhap_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnthoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.Image = global::TRACNGHIEM.Properties.Resources.power_icon;
            this.btnthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthoat.Location = new System.Drawing.Point(234, 202);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(121, 41);
            this.btnthoat.TabIndex = 7;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // cbxcoso
            // 
            this.cbxcoso.DataSource = this.spCacPhanManhBindingSource;
            this.cbxcoso.DisplayMember = "TenCoSo";
            this.cbxcoso.FormattingEnabled = true;
            this.cbxcoso.Location = new System.Drawing.Point(85, 36);
            this.cbxcoso.Name = "cbxcoso";
            this.cbxcoso.Size = new System.Drawing.Size(222, 24);
            this.cbxcoso.TabIndex = 0;
            this.cbxcoso.ValueMember = "ServerName";
            // 
            // spCacPhanManhBindingSource
            // 
            this.spCacPhanManhBindingSource.DataMember = "spCacPhanManh";
            this.spCacPhanManhBindingSource.DataSource = this.distributionDataSet;
            // 
            // distributionDataSet
            // 
            this.distributionDataSet.DataSetName = "distributionDataSet";
            this.distributionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn cơ sở:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu:";
            // 
            // txttaikhoan
            // 
            this.txttaikhoan.Location = new System.Drawing.Point(85, 111);
            this.txttaikhoan.Name = "txttaikhoan";
            this.txttaikhoan.Size = new System.Drawing.Size(222, 22);
            this.txttaikhoan.TabIndex = 4;
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(85, 152);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.PasswordChar = '*';
            this.txtmatkhau.Size = new System.Drawing.Size(222, 22);
            this.txtmatkhau.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.rdbnhanvien);
            this.groupBox1.Controls.Add(this.txttaikhoan);
            this.groupBox1.Controls.Add(this.rdbsinhvien);
            this.groupBox1.Controls.Add(this.txtmatkhau);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxcoso);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 184);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đăng nhập";
            // 
            // rdbnhanvien
            // 
            this.rdbnhanvien.AutoSize = true;
            this.rdbnhanvien.Location = new System.Drawing.Point(219, 75);
            this.rdbnhanvien.Name = "rdbnhanvien";
            this.rdbnhanvien.Size = new System.Drawing.Size(88, 20);
            this.rdbnhanvien.TabIndex = 11;
            this.rdbnhanvien.TabStop = true;
            this.rdbnhanvien.Text = "Nhân Viên";
            this.rdbnhanvien.UseVisualStyleBackColor = true;
            this.rdbnhanvien.CheckedChanged += new System.EventHandler(this.rdbgiaovien_CheckedChanged);
            // 
            // rdbsinhvien
            // 
            this.rdbsinhvien.AutoSize = true;
            this.rdbsinhvien.Location = new System.Drawing.Point(85, 75);
            this.rdbsinhvien.Name = "rdbsinhvien";
            this.rdbsinhvien.Size = new System.Drawing.Size(82, 20);
            this.rdbsinhvien.TabIndex = 10;
            this.rdbsinhvien.TabStop = true;
            this.rdbsinhvien.Text = "Sinh Viên";
            this.rdbsinhvien.UseVisualStyleBackColor = true;
            this.rdbsinhvien.CheckedChanged += new System.EventHandler(this.rdbsinhvien_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Image = global::TRACNGHIEM.Properties.Resources.Network_2_icon;
            this.label4.Location = new System.Drawing.Point(378, 58);
            this.label4.MaximumSize = new System.Drawing.Size(100, 100);
            this.label4.MinimumSize = new System.Drawing.Size(100, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 100);
            this.label4.TabIndex = 9;
            // 
            // spCacPhanManhTableAdapter
            // 
            this.spCacPhanManhTableAdapter.ClearBeforeFill = true;
            // 
            // frmDangNhap
            // 
            this.AcceptButton = this.btndangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnthoat;
            this.ClientSize = new System.Drawing.Size(477, 247);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btndangnhap);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDangNhap";
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spCacPhanManhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributionDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndangnhap;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.ComboBox cbxcoso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttaikhoan;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private distributionDataSet distributionDataSet;
        private System.Windows.Forms.BindingSource spCacPhanManhBindingSource;
        private distributionDataSetTableAdapters.spCacPhanManhTableAdapter spCacPhanManhTableAdapter;
        private System.Windows.Forms.RadioButton rdbsinhvien;
        private System.Windows.Forms.RadioButton rdbnhanvien;
    }
}
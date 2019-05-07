namespace TRACNGHIEM
{
    partial class frmTaoLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaoLogin));
            this.txbtenlogin = new System.Windows.Forms.TextBox();
            this.txbtentaikhoan = new System.Windows.Forms.TextBox();
            this.txbmatkhau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbnhomquyen = new System.Windows.Forms.TextBox();
            this.btntaotaikhoan = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbtenlogin
            // 
            this.txbtenlogin.Location = new System.Drawing.Point(99, 21);
            this.txbtenlogin.Name = "txbtenlogin";
            this.txbtenlogin.Size = new System.Drawing.Size(185, 22);
            this.txbtenlogin.TabIndex = 0;
            // 
            // txbtentaikhoan
            // 
            this.txbtentaikhoan.Location = new System.Drawing.Point(99, 49);
            this.txbtentaikhoan.Name = "txbtentaikhoan";
            this.txbtentaikhoan.Size = new System.Drawing.Size(185, 22);
            this.txbtentaikhoan.TabIndex = 1;
            this.txbtentaikhoan.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txbmatkhau
            // 
            this.txbmatkhau.Location = new System.Drawing.Point(99, 77);
            this.txbmatkhau.Name = "txbmatkhau";
            this.txbmatkhau.PasswordChar = '*';
            this.txbmatkhau.Size = new System.Drawing.Size(185, 22);
            this.txbmatkhau.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mật khẩu:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbnhomquyen);
            this.groupBox1.Controls.Add(this.txbtenlogin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbtentaikhoan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbmatkhau);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 141);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nhóm quyền:";
            // 
            // txbnhomquyen
            // 
            this.txbnhomquyen.Location = new System.Drawing.Point(99, 105);
            this.txbnhomquyen.Name = "txbnhomquyen";
            this.txbnhomquyen.Size = new System.Drawing.Size(185, 22);
            this.txbnhomquyen.TabIndex = 6;
            // 
            // btntaotaikhoan
            // 
            this.btntaotaikhoan.Location = new System.Drawing.Point(12, 171);
            this.btntaotaikhoan.Name = "btntaotaikhoan";
            this.btntaotaikhoan.Size = new System.Drawing.Size(122, 31);
            this.btntaotaikhoan.TabIndex = 7;
            this.btntaotaikhoan.Text = "TẠO TÀI KHOẢN";
            this.btntaotaikhoan.UseVisualStyleBackColor = true;
            this.btntaotaikhoan.Click += new System.EventHandler(this.btntaotaikhoan_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(213, 171);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(122, 31);
            this.btnthoat.TabIndex = 8;
            this.btnthoat.Text = "THOÁT";
            this.btnthoat.UseVisualStyleBackColor = true;
            // 
            // frmTaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 224);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btntaotaikhoan);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTaoLogin";
            this.Text = "Tạo Login";
            this.Load += new System.EventHandler(this.frmlogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbtenlogin;
        private System.Windows.Forms.TextBox txbtentaikhoan;
        private System.Windows.Forms.TextBox txbmatkhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btntaotaikhoan;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbnhomquyen;
    }
}
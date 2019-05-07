namespace THI_TN
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bnt_Login = new System.Windows.Forms.Button();
            this.bnt_Register = new System.Windows.Forms.Button();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.cb_COSO = new System.Windows.Forms.ComboBox();
            this.rd_SINHVIEN = new System.Windows.Forms.RadioButton();
            this.rd_NHANVIEN = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng Nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cơ sở: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "User Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Password:";
            // 
            // bnt_Login
            // 
            this.bnt_Login.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_Login.Location = new System.Drawing.Point(196, 193);
            this.bnt_Login.Name = "bnt_Login";
            this.bnt_Login.Size = new System.Drawing.Size(75, 28);
            this.bnt_Login.TabIndex = 2;
            this.bnt_Login.Text = "Login";
            this.bnt_Login.UseVisualStyleBackColor = true;
            this.bnt_Login.Click += new System.EventHandler(this.bnt_Login_Click);
            // 
            // bnt_Register
            // 
            this.bnt_Register.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_Register.Location = new System.Drawing.Point(299, 193);
            this.bnt_Register.Name = "bnt_Register";
            this.bnt_Register.Size = new System.Drawing.Size(75, 28);
            this.bnt_Register.TabIndex = 3;
            this.bnt_Register.Text = "Register";
            this.bnt_Register.UseVisualStyleBackColor = true;
            // 
            // txbUser
            // 
            this.txbUser.Location = new System.Drawing.Point(130, 110);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(175, 20);
            this.txbUser.TabIndex = 4;
            this.txbUser.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txbPass
            // 
            this.txbPass.Location = new System.Drawing.Point(130, 147);
            this.txbPass.Name = "txbPass";
            this.txbPass.PasswordChar = '*';
            this.txbPass.Size = new System.Drawing.Size(175, 20);
            this.txbPass.TabIndex = 4;
            // 
            // cb_COSO
            // 
            this.cb_COSO.FormattingEnabled = true;
            this.cb_COSO.Location = new System.Drawing.Point(130, 76);
            this.cb_COSO.Name = "cb_COSO";
            this.cb_COSO.Size = new System.Drawing.Size(175, 21);
            this.cb_COSO.TabIndex = 5;
            this.cb_COSO.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rd_SINHVIEN
            // 
            this.rd_SINHVIEN.AutoSize = true;
            this.rd_SINHVIEN.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_SINHVIEN.Location = new System.Drawing.Point(339, 85);
            this.rd_SINHVIEN.Name = "rd_SINHVIEN";
            this.rd_SINHVIEN.Size = new System.Drawing.Size(76, 19);
            this.rd_SINHVIEN.TabIndex = 6;
            this.rd_SINHVIEN.TabStop = true;
            this.rd_SINHVIEN.Text = "Sinh viên";
            this.rd_SINHVIEN.UseVisualStyleBackColor = true;
            // 
            // rd_NHANVIEN
            // 
            this.rd_NHANVIEN.AutoSize = true;
            this.rd_NHANVIEN.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_NHANVIEN.Location = new System.Drawing.Point(339, 112);
            this.rd_NHANVIEN.Name = "rd_NHANVIEN";
            this.rd_NHANVIEN.Size = new System.Drawing.Size(79, 19);
            this.rd_NHANVIEN.TabIndex = 7;
            this.rd_NHANVIEN.TabStop = true;
            this.rd_NHANVIEN.Text = "Nhân viên";
            this.rd_NHANVIEN.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 235);
            this.Controls.Add(this.rd_NHANVIEN);
            this.Controls.Add(this.rd_SINHVIEN);
            this.Controls.Add(this.cb_COSO);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.bnt_Register);
            this.Controls.Add(this.bnt_Login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bnt_Login;
        private System.Windows.Forms.Button bnt_Register;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.ComboBox cb_COSO;
        private System.Windows.Forms.RadioButton rd_SINHVIEN;
        private System.Windows.Forms.RadioButton rd_NHANVIEN;
    }
}
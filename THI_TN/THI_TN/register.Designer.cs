namespace THI_TN
{
    partial class register
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
            this.txbUser = new System.Windows.Forms.TextBox();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_COSO = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Loai = new System.Windows.Forms.ComboBox();
            this.bnt_Register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng ký";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password:";
            // 
            // txbUser
            // 
            this.txbUser.Location = new System.Drawing.Point(119, 57);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(210, 20);
            this.txbUser.TabIndex = 5;
            // 
            // txbPass
            // 
            this.txbPass.Location = new System.Drawing.Point(119, 96);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(210, 20);
            this.txbPass.TabIndex = 5;
            this.txbPass.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cơ sở:";
            // 
            // cb_COSO
            // 
            this.cb_COSO.FormattingEnabled = true;
            this.cb_COSO.Location = new System.Drawing.Point(119, 168);
            this.cb_COSO.Name = "cb_COSO";
            this.cb_COSO.Size = new System.Drawing.Size(210, 21);
            this.cb_COSO.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(59, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Loại:";
            // 
            // cb_Loai
            // 
            this.cb_Loai.FormattingEnabled = true;
            this.cb_Loai.Location = new System.Drawing.Point(119, 132);
            this.cb_Loai.Name = "cb_Loai";
            this.cb_Loai.Size = new System.Drawing.Size(210, 21);
            this.cb_Loai.TabIndex = 6;
            // 
            // bnt_Register
            // 
            this.bnt_Register.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_Register.Location = new System.Drawing.Point(157, 213);
            this.bnt_Register.Name = "bnt_Register";
            this.bnt_Register.Size = new System.Drawing.Size(75, 28);
            this.bnt_Register.TabIndex = 7;
            this.bnt_Register.Text = "Register";
            this.bnt_Register.UseVisualStyleBackColor = true;
            this.bnt_Register.Click += new System.EventHandler(this.bnt_Register_Click);
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 263);
            this.Controls.Add(this.bnt_Register);
            this.Controls.Add(this.cb_Loai);
            this.Controls.Add(this.cb_COSO);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_COSO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_Loai;
        private System.Windows.Forms.Button bnt_Register;
    }
}
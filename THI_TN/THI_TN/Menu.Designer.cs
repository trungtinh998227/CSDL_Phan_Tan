namespace THI_TN
{
    partial class Menu
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
            this.lb_LUUY = new System.Windows.Forms.Label();
            this.bnt_THI = new System.Windows.Forms.Button();
            this.bnt_Test = new System.Windows.Forms.Button();
            this.bnt_GV_Regis = new System.Windows.Forms.Button();
            this.bnt_INPUT_MON = new System.Windows.Forms.Button();
            this.bnt_INPUT_SV = new System.Windows.Forms.Button();
            this.bntRegister = new System.Windows.Forms.Button();
            this.bnt_INPUT_KHOA = new System.Windows.Forms.Button();
            this.bnt_INPUT_DE = new System.Windows.Forms.Button();
            this.bnt_INPUT_GV = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.lb_LUUY);
            this.groupBox1.Controls.Add(this.bnt_THI);
            this.groupBox1.Controls.Add(this.bnt_Test);
            this.groupBox1.Controls.Add(this.bnt_GV_Regis);
            this.groupBox1.Controls.Add(this.bnt_INPUT_MON);
            this.groupBox1.Controls.Add(this.bnt_INPUT_SV);
            this.groupBox1.Controls.Add(this.bntRegister);
            this.groupBox1.Controls.Add(this.bnt_INPUT_KHOA);
            this.groupBox1.Controls.Add(this.bnt_INPUT_DE);
            this.groupBox1.Controls.Add(this.bnt_INPUT_GV);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn phương thức";
            // 
            // lb_LUUY
            // 
            this.lb_LUUY.AutoSize = true;
            this.lb_LUUY.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_LUUY.ForeColor = System.Drawing.Color.Red;
            this.lb_LUUY.Location = new System.Drawing.Point(76, 156);
            this.lb_LUUY.Name = "lb_LUUY";
            this.lb_LUUY.Size = new System.Drawing.Size(299, 19);
            this.lb_LUUY.TabIndex = 2;
            this.lb_LUUY.Text = "Lưu ý: Sinh viên chỉ chọn phương thức thi";
            // 
            // bnt_THI
            // 
            this.bnt_THI.Location = new System.Drawing.Point(167, 112);
            this.bnt_THI.Name = "bnt_THI";
            this.bnt_THI.Size = new System.Drawing.Size(131, 31);
            this.bnt_THI.TabIndex = 1;
            this.bnt_THI.Text = "Thi";
            this.bnt_THI.UseVisualStyleBackColor = true;
            this.bnt_THI.Click += new System.EventHandler(this.bnt_THI_Click);
            // 
            // bnt_Test
            // 
            this.bnt_Test.Location = new System.Drawing.Point(318, 112);
            this.bnt_Test.Name = "bnt_Test";
            this.bnt_Test.Size = new System.Drawing.Size(97, 31);
            this.bnt_Test.TabIndex = 0;
            this.bnt_Test.Text = "Thi thử";
            this.bnt_Test.UseVisualStyleBackColor = true;
            this.bnt_Test.Click += new System.EventHandler(this.bnt_Test_Click);
            // 
            // bnt_GV_Regis
            // 
            this.bnt_GV_Regis.Location = new System.Drawing.Point(318, 67);
            this.bnt_GV_Regis.Name = "bnt_GV_Regis";
            this.bnt_GV_Regis.Size = new System.Drawing.Size(97, 31);
            this.bnt_GV_Regis.TabIndex = 0;
            this.bnt_GV_Regis.Text = "Đăng ký thi";
            this.bnt_GV_Regis.UseVisualStyleBackColor = true;
            this.bnt_GV_Regis.Click += new System.EventHandler(this.bnt_GV_Regis_Click);
            // 
            // bnt_INPUT_MON
            // 
            this.bnt_INPUT_MON.Location = new System.Drawing.Point(25, 112);
            this.bnt_INPUT_MON.Name = "bnt_INPUT_MON";
            this.bnt_INPUT_MON.Size = new System.Drawing.Size(126, 31);
            this.bnt_INPUT_MON.TabIndex = 0;
            this.bnt_INPUT_MON.Text = "Nhập môn học";
            this.bnt_INPUT_MON.UseVisualStyleBackColor = true;
            this.bnt_INPUT_MON.Click += new System.EventHandler(this.bnt_INPUT_MON_Click);
            // 
            // bnt_INPUT_SV
            // 
            this.bnt_INPUT_SV.Location = new System.Drawing.Point(25, 67);
            this.bnt_INPUT_SV.Name = "bnt_INPUT_SV";
            this.bnt_INPUT_SV.Size = new System.Drawing.Size(126, 31);
            this.bnt_INPUT_SV.TabIndex = 0;
            this.bnt_INPUT_SV.Text = "Nhập sinh viên";
            this.bnt_INPUT_SV.UseVisualStyleBackColor = true;
            this.bnt_INPUT_SV.Click += new System.EventHandler(this.bnt_INPUT_SV_Click);
            // 
            // bntRegister
            // 
            this.bntRegister.Location = new System.Drawing.Point(167, 67);
            this.bntRegister.Name = "bntRegister";
            this.bntRegister.Size = new System.Drawing.Size(131, 31);
            this.bntRegister.TabIndex = 0;
            this.bntRegister.Text = "Register";
            this.bntRegister.UseVisualStyleBackColor = true;
            this.bntRegister.Click += new System.EventHandler(this.bntRegister_Click);
            // 
            // bnt_INPUT_KHOA
            // 
            this.bnt_INPUT_KHOA.Location = new System.Drawing.Point(167, 25);
            this.bnt_INPUT_KHOA.Name = "bnt_INPUT_KHOA";
            this.bnt_INPUT_KHOA.Size = new System.Drawing.Size(131, 31);
            this.bnt_INPUT_KHOA.TabIndex = 0;
            this.bnt_INPUT_KHOA.Text = "Nhập khoa - lớp";
            this.bnt_INPUT_KHOA.UseVisualStyleBackColor = true;
            this.bnt_INPUT_KHOA.Click += new System.EventHandler(this.bnt_INPUT_KHOA_Click);
            // 
            // bnt_INPUT_DE
            // 
            this.bnt_INPUT_DE.Location = new System.Drawing.Point(318, 25);
            this.bnt_INPUT_DE.Name = "bnt_INPUT_DE";
            this.bnt_INPUT_DE.Size = new System.Drawing.Size(97, 31);
            this.bnt_INPUT_DE.TabIndex = 0;
            this.bnt_INPUT_DE.Text = "Nhập đề thi";
            this.bnt_INPUT_DE.UseVisualStyleBackColor = true;
            this.bnt_INPUT_DE.Click += new System.EventHandler(this.bnt_INPUT_DE_Click);
            // 
            // bnt_INPUT_GV
            // 
            this.bnt_INPUT_GV.Location = new System.Drawing.Point(25, 25);
            this.bnt_INPUT_GV.Name = "bnt_INPUT_GV";
            this.bnt_INPUT_GV.Size = new System.Drawing.Size(126, 31);
            this.bnt_INPUT_GV.TabIndex = 0;
            this.bnt_INPUT_GV.Text = "Nhập giáo viên";
            this.bnt_INPUT_GV.UseVisualStyleBackColor = true;
            this.bnt_INPUT_GV.Click += new System.EventHandler(this.bnt_INPUT_GV_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 210);
            this.Controls.Add(this.groupBox1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bnt_GV_Regis;
        private System.Windows.Forms.Button bnt_INPUT_SV;
        private System.Windows.Forms.Button bnt_INPUT_KHOA;
        private System.Windows.Forms.Button bnt_INPUT_DE;
        private System.Windows.Forms.Button bnt_INPUT_GV;
        private System.Windows.Forms.Button bnt_Test;
        private System.Windows.Forms.Button bnt_INPUT_MON;
        private System.Windows.Forms.Button bntRegister;
        private System.Windows.Forms.Button bnt_THI;
        private System.Windows.Forms.Label lb_LUUY;
    }
}
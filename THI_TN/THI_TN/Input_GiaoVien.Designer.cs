namespace THI_TN
{
    partial class Input_GiaoVien
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
            this.bnt_Edit = new System.Windows.Forms.Button();
            this.bnt_Del = new System.Windows.Forms.Button();
            this.bnt_Add = new System.Windows.Forms.Button();
            this.View_GIAOVIEN = new System.Windows.Forms.DataGridView();
            this.txb_HOCVI = new System.Windows.Forms.TextBox();
            this.txb_Ho = new System.Windows.Forms.TextBox();
            this.cb_MAKH = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_TEN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_MaGV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.View_GIAOVIEN)).BeginInit();
            this.SuspendLayout();
            // 
            // bnt_Edit
            // 
            this.bnt_Edit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_Edit.Location = new System.Drawing.Point(579, 149);
            this.bnt_Edit.Name = "bnt_Edit";
            this.bnt_Edit.Size = new System.Drawing.Size(87, 28);
            this.bnt_Edit.TabIndex = 18;
            this.bnt_Edit.Text = "Sửa";
            this.bnt_Edit.UseVisualStyleBackColor = true;
            this.bnt_Edit.Click += new System.EventHandler(this.bnt_Edit_Click);
            // 
            // bnt_Del
            // 
            this.bnt_Del.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_Del.Location = new System.Drawing.Point(482, 149);
            this.bnt_Del.Name = "bnt_Del";
            this.bnt_Del.Size = new System.Drawing.Size(87, 28);
            this.bnt_Del.TabIndex = 19;
            this.bnt_Del.Text = "Xóa";
            this.bnt_Del.UseVisualStyleBackColor = true;
            this.bnt_Del.Click += new System.EventHandler(this.bnt_Del_Click);
            // 
            // bnt_Add
            // 
            this.bnt_Add.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_Add.Location = new System.Drawing.Point(383, 149);
            this.bnt_Add.Name = "bnt_Add";
            this.bnt_Add.Size = new System.Drawing.Size(87, 28);
            this.bnt_Add.TabIndex = 20;
            this.bnt_Add.Text = "Thêm";
            this.bnt_Add.UseVisualStyleBackColor = true;
            this.bnt_Add.Click += new System.EventHandler(this.bnt_Add_Click);
            // 
            // View_GIAOVIEN
            // 
            this.View_GIAOVIEN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.View_GIAOVIEN.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.View_GIAOVIEN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.View_GIAOVIEN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.View_GIAOVIEN.Location = new System.Drawing.Point(33, 202);
            this.View_GIAOVIEN.Name = "View_GIAOVIEN";
            this.View_GIAOVIEN.RowHeadersVisible = false;
            this.View_GIAOVIEN.Size = new System.Drawing.Size(639, 249);
            this.View_GIAOVIEN.TabIndex = 17;
            this.View_GIAOVIEN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.View_GIAOVIEN_CellClick);
            // 
            // txb_HOCVI
            // 
            this.txb_HOCVI.Location = new System.Drawing.Point(466, 67);
            this.txb_HOCVI.Name = "txb_HOCVI";
            this.txb_HOCVI.Size = new System.Drawing.Size(200, 20);
            this.txb_HOCVI.TabIndex = 15;
            // 
            // txb_Ho
            // 
            this.txb_Ho.Location = new System.Drawing.Point(125, 99);
            this.txb_Ho.Name = "txb_Ho";
            this.txb_Ho.Size = new System.Drawing.Size(200, 20);
            this.txb_Ho.TabIndex = 16;
            // 
            // cb_MAKH
            // 
            this.cb_MAKH.FormattingEnabled = true;
            this.cb_MAKH.Location = new System.Drawing.Point(466, 100);
            this.cb_MAKH.Name = "cb_MAKH";
            this.cb_MAKH.Size = new System.Drawing.Size(200, 21);
            this.cb_MAKH.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(382, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Học vị : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Họ: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(382, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mã Khoa: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nhập Giáo Viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Thông tin giảng viên:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tên :";
            // 
            // txb_TEN
            // 
            this.txb_TEN.Location = new System.Drawing.Point(125, 134);
            this.txb_TEN.Name = "txb_TEN";
            this.txb_TEN.Size = new System.Drawing.Size(200, 20);
            this.txb_TEN.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mã GV : ";
            // 
            // txb_MaGV
            // 
            this.txb_MaGV.Location = new System.Drawing.Point(125, 67);
            this.txb_MaGV.Name = "txb_MaGV";
            this.txb_MaGV.Size = new System.Drawing.Size(200, 20);
            this.txb_MaGV.TabIndex = 16;
            // 
            // Input_GiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 463);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bnt_Edit);
            this.Controls.Add(this.bnt_Del);
            this.Controls.Add(this.bnt_Add);
            this.Controls.Add(this.View_GIAOVIEN);
            this.Controls.Add(this.txb_TEN);
            this.Controls.Add(this.txb_HOCVI);
            this.Controls.Add(this.txb_MaGV);
            this.Controls.Add(this.txb_Ho);
            this.Controls.Add(this.cb_MAKH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Input_GiaoVien";
            this.Text = "Nhập Giáo Viên";
            this.Load += new System.EventHandler(this.Input_GiaoVien_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Input_GiaoVien_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.View_GIAOVIEN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnt_Edit;
        private System.Windows.Forms.Button bnt_Del;
        private System.Windows.Forms.Button bnt_Add;
        private System.Windows.Forms.DataGridView View_GIAOVIEN;
        private System.Windows.Forms.TextBox txb_HOCVI;
        private System.Windows.Forms.TextBox txb_Ho;
        private System.Windows.Forms.ComboBox cb_MAKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_TEN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_MaGV;
    }
}
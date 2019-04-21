namespace THI_TN
{
    partial class Nhap_mon_hoc
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
            this.txb_TENMON = new System.Windows.Forms.TextBox();
            this.cb_MaMH = new System.Windows.Forms.ComboBox();
            this.bntAdd = new System.Windows.Forms.Button();
            this.bntDel = new System.Windows.Forms.Button();
            this.bntEdit = new System.Windows.Forms.Button();
            this.View_MONHOC = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.View_MONHOC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã môn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập môn học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên môn:";
            // 
            // txb_TENMON
            // 
            this.txb_TENMON.Location = new System.Drawing.Point(185, 120);
            this.txb_TENMON.Name = "txb_TENMON";
            this.txb_TENMON.Size = new System.Drawing.Size(297, 20);
            this.txb_TENMON.TabIndex = 1;
            // 
            // cb_MaMH
            // 
            this.cb_MaMH.FormattingEnabled = true;
            this.cb_MaMH.Location = new System.Drawing.Point(187, 81);
            this.cb_MaMH.Name = "cb_MaMH";
            this.cb_MaMH.Size = new System.Drawing.Size(295, 21);
            this.cb_MaMH.TabIndex = 2;
            // 
            // bntAdd
            // 
            this.bntAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAdd.Location = new System.Drawing.Point(273, 370);
            this.bntAdd.Name = "bntAdd";
            this.bntAdd.Size = new System.Drawing.Size(75, 34);
            this.bntAdd.TabIndex = 3;
            this.bntAdd.Text = "Thêm";
            this.bntAdd.UseVisualStyleBackColor = true;
            // 
            // bntDel
            // 
            this.bntDel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntDel.Location = new System.Drawing.Point(377, 370);
            this.bntDel.Name = "bntDel";
            this.bntDel.Size = new System.Drawing.Size(75, 34);
            this.bntDel.TabIndex = 3;
            this.bntDel.Text = "Xóa";
            this.bntDel.UseVisualStyleBackColor = true;
            // 
            // bntEdit
            // 
            this.bntEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntEdit.Location = new System.Drawing.Point(482, 370);
            this.bntEdit.Name = "bntEdit";
            this.bntEdit.Size = new System.Drawing.Size(75, 34);
            this.bntEdit.TabIndex = 3;
            this.bntEdit.Text = "Sửa";
            this.bntEdit.UseVisualStyleBackColor = true;
            // 
            // View_MONHOC
            // 
            this.View_MONHOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.View_MONHOC.Location = new System.Drawing.Point(38, 159);
            this.View_MONHOC.Name = "View_MONHOC";
            this.View_MONHOC.Size = new System.Drawing.Size(530, 191);
            this.View_MONHOC.TabIndex = 4;
            // 
            // Nhap_mon_hoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 430);
            this.Controls.Add(this.View_MONHOC);
            this.Controls.Add(this.bntEdit);
            this.Controls.Add(this.bntDel);
            this.Controls.Add(this.bntAdd);
            this.Controls.Add(this.cb_MaMH);
            this.Controls.Add(this.txb_TENMON);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Nhap_mon_hoc";
            this.Text = "Nhập môn học";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_MONHOC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_TENMON;
        private System.Windows.Forms.ComboBox cb_MaMH;
        private System.Windows.Forms.Button bntAdd;
        private System.Windows.Forms.Button bntDel;
        private System.Windows.Forms.Button bntEdit;
        private System.Windows.Forms.DataGridView View_MONHOC;
    }
}


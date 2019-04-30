namespace THI_TN
{
    partial class input_DeThi
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
            this.View_BODE = new System.Windows.Forms.DataGridView();
            this.cb_MAMON = new System.Windows.Forms.ComboBox();
            this.txb_MAGV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.View_BODE)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(564, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập đề";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(183, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Môn học:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(666, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Giáo viên:";
            // 
            // View_BODE
            // 
            this.View_BODE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.View_BODE.Location = new System.Drawing.Point(18, 129);
            this.View_BODE.Name = "View_BODE";
            this.View_BODE.RowHeadersVisible = false;
            this.View_BODE.Size = new System.Drawing.Size(1227, 354);
            this.View_BODE.TabIndex = 2;
            // 
            // cb_MAMON
            // 
            this.cb_MAMON.FormattingEnabled = true;
            this.cb_MAMON.Location = new System.Drawing.Point(297, 89);
            this.cb_MAMON.Name = "cb_MAMON";
            this.cb_MAMON.Size = new System.Drawing.Size(213, 21);
            this.cb_MAMON.TabIndex = 3;
            // 
            // txb_MAGV
            // 
            this.txb_MAGV.Location = new System.Drawing.Point(780, 91);
            this.txb_MAGV.Name = "txb_MAGV";
            this.txb_MAGV.Size = new System.Drawing.Size(213, 20);
            this.txb_MAGV.TabIndex = 4;
            // 
            // input_DeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 495);
            this.Controls.Add(this.txb_MAGV);
            this.Controls.Add(this.cb_MAMON);
            this.Controls.Add(this.View_BODE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "input_DeThi";
            this.Text = "Nhập đề";
            this.Load += new System.EventHandler(this.input_DeThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_BODE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView View_BODE;
        private System.Windows.Forms.ComboBox cb_MAMON;
        private System.Windows.Forms.TextBox txb_MAGV;
    }
}
namespace TRACNGHIEM
{
    partial class ketqua
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
            this.tRACNGHIEMDataSet1 = new TRACNGHIEM.TRACNGHIEMDataSet1();
            this.sp_ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReportTableAdapter = new TRACNGHIEM.TRACNGHIEMDataSet1TableAdapters.sp_ReportTableAdapter();
            this.tableAdapterManager = new TRACNGHIEM.TRACNGHIEMDataSet1TableAdapters.TableAdapterManager();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.mASVToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.mASVToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new Systeooodam.Windows.Forms.ToolStripButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cbxphanmanh = new System.Windows.Forms.ComboBox();
            this.distributionDataSet = new TRACNGHIEM.distributionDataSet();
            this.spCacPhanManhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spCacPhanManhTableAdapter = new TRACNGHIEM.distributionDataSetTableAdapters.spCacPhanManhTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tRACNGHIEMDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReportBindingSource)).BeginInit();
            this.fillToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distributionDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCacPhanManhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tRACNGHIEMDataSet1
            // 
            this.tRACNGHIEMDataSet1.DataSetName = "TRACNGHIEMDataSet1";
            this.tRACNGHIEMDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_ReportBindingSource
            // 
            this.sp_ReportBindingSource.DataMember = "sp_Report";
            this.sp_ReportBindingSource.DataSource = this.tRACNGHIEMDataSet1;
            // 
            // sp_ReportTableAdapter
            // 
            this.sp_ReportTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = TRACNGHIEM.TRACNGHIEMDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mASVToolStripLabel,
            this.mASVToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(750, 25);
            this.fillToolStrip.TabIndex = 1;
            this.fillToolStrip.Text = "fillToolStrip";
            // 
            // mASVToolStripLabel
            // 
            this.mASVToolStripLabel.Name = "mASVToolStripLabel";
            this.mASVToolStripLabel.Size = new System.Drawing.Size(42, 22);
            this.mASVToolStripLabel.Text = "MASV:";
            // 
            // mASVToolStripTextBox
            // 
            this.mASVToolStripTextBox.Name = "mASVToolStripTextBox";
            this.mASVToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(26, 22);
            this.fillToolStripButton.Text = "Fill";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 25);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(750, 301);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // cbxphanmanh
            // 
            this.cbxphanmanh.DataSource = this.spCacPhanManhBindingSource;
            this.cbxphanmanh.DisplayMember = "TenCoSo";
            this.cbxphanmanh.FormattingEnabled = true;
            this.cbxphanmanh.Location = new System.Drawing.Point(387, 4);
            this.cbxphanmanh.Name = "cbxphanmanh";
            this.cbxphanmanh.Size = new System.Drawing.Size(112, 21);
            this.cbxphanmanh.TabIndex = 3;
            this.cbxphanmanh.ValueMember = "ServerName";
            this.cbxphanmanh.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // distributionDataSet
            // 
            this.distributionDataSet.DataSetName = "distributionDataSet";
            this.distributionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spCacPhanManhBindingSource
            // 
            this.spCacPhanManhBindingSource.DataMember = "spCacPhanManh";
            this.spCacPhanManhBindingSource.DataSource = this.distributionDataSet;
            // 
            // spCacPhanManhTableAdapter
            // 
            this.spCacPhanManhTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn cơ sở:";
            // 
            // ketqua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 326);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxphanmanh);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.fillToolStrip);
            this.Name = "ketqua";
            this.Text = "ketqua";
            this.Load += new System.EventHandler(this.ketqua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tRACNGHIEMDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReportBindingSource)).EndInit();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distributionDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCacPhanManhBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TRACNGHIEMDataSet1 tRACNGHIEMDataSet1;
        private System.Windows.Forms.BindingSource sp_ReportBindingSource;
        private TRACNGHIEMDataSet1TableAdapters.sp_ReportTableAdapter sp_ReportTableAdapter;
        private TRACNGHIEMDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel mASVToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox mASVToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ComboBox cbxphanmanh;
        private distributionDataSet distributionDataSet;
        private System.Windows.Forms.BindingSource spCacPhanManhBindingSource;
        private distributionDataSetTableAdapters.spCacPhanManhTableAdapter spCacPhanManhTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}
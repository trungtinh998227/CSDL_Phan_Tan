using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TRACNGHIEM
{
    public partial class ketqua : DevExpress.XtraEditors.XtraForm
    {
        public ketqua()
        {
            InitializeComponent();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            rep.SetDataSource(tRACNGHIEMDataSet1);
            crystalReportViewer1.ReportSource = rep;
            try
            {
                                
                this.sp_ReportTableAdapter.Connection.ConnectionString = Program.connectionString;
                this.sp_ReportTableAdapter.Fill(this.tRACNGHIEMDataSet1.sp_Report, mASVToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void ketqua_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'distributionDataSet.spCacPhanManh' table. You can move, or remove it, as needed.
            this.spCacPhanManhTableAdapter.Fill(this.distributionDataSet.spCacPhanManh);
            if(Program.mGroup == "TRUONG")
            {
                this.cbxphanmanh.Show();
            }
            else
            {
                this.cbxphanmanh.Hide();
            }      
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Program.mGroup == "TRUONG")
                {
                    Program.servername = cbxphanmanh.SelectedValue.ToString().Trim() ;
                    if (this.cbxphanmanh.SelectedItem.ToString().Equals(Program.servername) == false)
                    {
                        Program.mlogin = Program.support_user;
                        Program.password = Program.support_pass;
                        
                    }
                    else
                    {
                        Program.mlogin = Program.mloginDN;
                        Program.password = Program.passwordDN;
                    }

                 

                    Program.conn = Database.KetNoi(Program.servername, Program.mlogin, Program.password);
                    MessageBox.Show(Program.connectionString);
                    if(Program.login != true)
                    {
                        MessageBox.Show("Kết nối đến CSDL thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.sp_ReportTableAdapter.Connection.ConnectionString = Program.connectionString;
                        this.sp_ReportTableAdapter.Fill(this.tRACNGHIEMDataSet1.sp_Report, mASVToolStripTextBox.Text);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
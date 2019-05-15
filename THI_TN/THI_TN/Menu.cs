using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THI_TN
{
    public partial class Menu : Form
    {
        public static bool checks = false;
        private string getID;
        private string dataSrc;
        private SqlConnection conn;
        private string LOAI;
        public Menu()
        {
            this.getID = Login.getID;
            this.dataSrc = Login.datasSrc;
            InitializeComponent();
            conn = new SqlConnection(dataSrc);
        }

        private void bntRegister_Click(object sender, EventArgs e)
        {
            register rg = new register();
            this.Hide();
            rg.ShowDialog();
            this.Show();
        }

        private void bnt_INPUT_GV_Click(object sender, EventArgs e)
        {
            if (LOAI.Equals("COSO"))
            {
                Input_GiaoVien ip = new Input_GiaoVien();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else if(LOAI.Equals("TRUONG"))
            {
                checks = true;
                Input_GiaoVien ip = new Input_GiaoVien();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void bnt_INPUT_SV_Click(object sender, EventArgs e)
        {
            if (LOAI.Equals("COSO"))
            {
                Input_SinhVien ip = new Input_SinhVien();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else if (LOAI.Equals("TRUONG"))
            {
                checks = true;
                Input_SinhVien ip = new Input_SinhVien();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void bnt_INPUT_MON_Click(object sender, EventArgs e)
        {
            if (LOAI.Equals("COSO"))
            {
                Nhap_mon_hoc ip = new Nhap_mon_hoc();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else if (LOAI.Equals("TRUONG"))
            {
                checks = true;
                Nhap_mon_hoc ip = new Nhap_mon_hoc();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void bnt_INPUT_KHOA_Click(object sender, EventArgs e)
        {
            if (LOAI.Equals("COSO"))
            {
                Input_Khoa_Lop ip = new Input_Khoa_Lop();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else if (LOAI.Equals("TRUONG"))
            {
                checks = true;
                Input_Khoa_Lop ip = new Input_Khoa_Lop();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void bnt_INPUT_DE_Click(object sender, EventArgs e)
        {
            if (LOAI.Equals("COSO")||LOAI.Equals("GIAOVIEN"))
            {
                input_DeThi ip = new input_DeThi();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else if (LOAI.Equals("TRUONG"))
            {
                checks = true;
                input_DeThi ip = new input_DeThi();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void bnt_GV_Regis_Click(object sender, EventArgs e)
        {
            if (LOAI.Equals("COSO")||LOAI.Equals("GIAOVIEN"))
            {
                GV_Register ip = new GV_Register();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else if (LOAI.Equals("TRUONG"))
            {
                checks = true;
                GV_Register ip = new GV_Register();
                this.Hide();
                ip.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void bnt_Test_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phương thức chưa hoàn thiện, vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            conn.Open();
            string getLOAI = "select LOAI from MEMBER where USERNAME='"+getID+"'";
            SqlDataReader read = new SqlCommand(getLOAI, conn).ExecuteReader();
            if (read.Read())
            {
                LOAI = read.GetValue(0).ToString().Trim();
            }
            conn.Close();
            if (LOAI.Equals("SINHVIEN"))
            {
                lb_LUUY.Visible = true;
            }
            else lb_LUUY.Visible = false;
        }

        private void bnt_THI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phương thức chưa hoàn thiện, vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}

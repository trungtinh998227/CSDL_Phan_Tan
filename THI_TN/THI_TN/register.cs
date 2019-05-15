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
    public partial class register : Form
    {
        private string dataSrc;
        private SqlConnection conn;
        string ROLE = "";
        public register()
        {
            this.dataSrc = Login.datasSrc;
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {
            cb_Loai.Items.Add("Sinh viên");
            cb_Loai.Items.Add("Giảng viên");
            cb_Loai.Items.Add("Trường");
            cb_Loai.Items.Add("Cơ sở");
            cb_COSO.Items.Add("Cơ sở 1");
            cb_COSO.Items.Add("Cơ sở 2");
        }

        private void bnt_Register_Click(object sender, EventArgs e)
        {
            if (cb_Loai.Text.Trim().Equals("Sinh viên"))
            {
                ROLE = "SINHVIEN";
            }
            else if(cb_Loai.Text.Trim().Equals("Giảng viên"))
            {
                ROLE = "GIAOVIEN";
            }
            else if (cb_Loai.Text.Trim().Equals("Trường"))
            {
                ROLE = "TRUONG";
            }
            else
            {
                ROLE = "COSO";
            }
            conn = new SqlConnection(dataSrc);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("sp_TaoLogin", conn))
            {
                MessageBox.Show(dataSrc + " "+ ROLE , "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LGNAME", txbUser.Text.Trim());
                cmd.Parameters.AddWithValue("@PASS", txbPass.Text.Trim());
                cmd.Parameters.AddWithValue("@USERNAME",txbUser.Text.Trim());
                cmd.Parameters.AddWithValue("@ROLE", ROLE);
                try
                {
                    SqlDataReader read = cmd.ExecuteReader();
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                catch (SqlException )
                {
                    MessageBox.Show("Bạn không có quyền đăng ký tài khoản", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

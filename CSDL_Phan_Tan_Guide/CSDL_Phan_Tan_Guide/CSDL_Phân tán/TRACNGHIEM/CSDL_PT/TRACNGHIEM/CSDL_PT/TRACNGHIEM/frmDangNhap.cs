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

namespace TRACNGHIEM
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            XuLiButton(false);
        }

        public void XuLiButton(bool KT)
        {
            this.txttaikhoan.Enabled = KT;
            this.txtmatkhau.Enabled = KT;
            this.btndangnhap.Enabled = KT;
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'distributionDataSet.spCacPhanManh' table. You can move, or remove it, as needed.
            this.spCacPhanManhTableAdapter.Fill(this.distributionDataSet.spCacPhanManh);
        }


        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); // kết thúc chương trình
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {

            try
            {
                String loginname = this.txttaikhoan.Text.Trim();
                String password = this.txtmatkhau.Text.Trim();

                Program.mlogin = loginname;
                Program.password = password;
                Program.mCoSo = cbxcoso.SelectedIndex;
                Program.servername = cbxcoso.SelectedValue.ToString().Trim();

                // kết nối đến CSDL
                Program.conn = Database.KetNoi(Program.servername, loginname, password);

                SqlDataReader myReader;
                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                String strLenh = "";
                if (rdbnhanvien.Checked == true)
                {
                    strLenh = "exec sp_DangNhapGiaoVien '" + Program.mlogin + "'";
                }
                else if (rdbsinhvien.Checked == true)
                {
                    strLenh = "exec sp_DangNhapSinhVien '" + Program.mlogin + "'";
                }
                myReader = Database.ExecSqlDataReader(strLenh);
                if (myReader == null)
                {
                    return;
                }
                myReader.Read();

                Program.username = myReader.GetString(0);     // Lay username
                if (Convert.IsDBNull(Program.username))
                {
                    MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username của cơ sở dữ liệu", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mHoten = myReader.GetString(1); // lấy họ tên 
                Program.mGroup = myReader.GetString(2); // lấy nhóm quyền
                myReader.Close();
                Program.conn.Close();


                this.Hide(); // đóng form hiện tại
                // mở form dexfrmMain
                dexfrmMain frmMain = new dexfrmMain();
                frmMain.Show();
                
            }
            catch
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username của cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbsinhvien_CheckedChanged(object sender, EventArgs e)
        {
            XuLiButton(true);
        }

        private void rdbgiaovien_CheckedChanged(object sender, EventArgs e)
        {
            XuLiButton(true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRACNGHIEM
{
    public partial class frmTaoLogin : Form
    {
        public frmTaoLogin()
        {
            InitializeComponent();
            if (Program.mGroup == "TRUONG")
            {
                this.txbnhomquyen.Enabled = false;
                this.txbnhomquyen.Text = "TRUONG";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // phương thức xử lí button        
        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void btntaotaikhoan_Click(object sender, EventArgs e)
        {
           


            string login = this.txbtenlogin.Text;
            string taikhoan = this.txbtentaikhoan.Text;
            string matkhau = this.txbmatkhau.Text;
            string nhomquyen = this.txbnhomquyen.Text;
            if (login.Length == 0 || taikhoan.Length == 0 || matkhau.Length == 0 || nhomquyen.Length == 0)
            {
                MessageBox.Show("Thông tin tài khoản không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (login.Length > 50)
                {
                    MessageBox.Show("Tên login tối đa 50 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (taikhoan.Length > 50)
                {
                    MessageBox.Show("Tên tài khoản tối đa 50 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (matkhau.Length > 50)
                {
                    MessageBox.Show("Mật khẩu tối đa 50 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (nhomquyen.Length > 50)
                {
                    MessageBox.Show("Nhóm quyền tối đa 50 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (this.txbnhomquyen.Text == "SINHVIEN")
                    {
                        try
                        {

                            if (Program.conn.State == ConnectionState.Closed)
                            {
                                Database.KetNoiSauXacThuc().Open();

                            }
                            String strLenh = "dbo.sp_KiemTraTonTaiSV";
                            Program.cmd = Program.conn.CreateCommand();
                            Program.cmd.CommandType = CommandType.StoredProcedure;
                            Program.cmd.CommandText = strLenh;
                            Program.cmd.Parameters.Add("@MASV", SqlDbType.VarChar).Value = this.txbtentaikhoan.Text;

                            Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                            Program.cmd.ExecuteNonQuery();
                            Program.conn.Close();
                            String Ret = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                    
                            if (Ret == "0")
                            {
                                MessageBox.Show("Tên tài khoản chưa tồn tại trong CSDL !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn muốn tạo tài khoản ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    try
                                    {

                                        if (Program.conn.State == ConnectionState.Closed)
                                        {
                                            Database.KetNoiSauXacThuc().Open();

                                        }
                                        String strLenh_1 = "dbo.sp_TaoLogin";
                                        Program.cmd = Program.conn.CreateCommand();
                                        Program.cmd.CommandType = CommandType.StoredProcedure;
                                        Program.cmd.CommandText = strLenh_1;
                                        Program.cmd.Parameters.Add("@LGNAME", SqlDbType.VarChar).Value = login;
                                        Program.cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = matkhau;
                                        Program.cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = taikhoan;
                                        Program.cmd.Parameters.Add("@ROLE", SqlDbType.VarChar).Value = nhomquyen;
                                        Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                                        Program.cmd.ExecuteNonQuery();
                                        Program.conn.Close();
                                        String Ret_1 = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                    
                                        if (Ret_1 == "1")
                                        {
                                            MessageBox.Show("Tên login đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else if (Ret_1 == "2")
                                        {
                                            MessageBox.Show("Tên tài khoản đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Tạo tài khoản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Tạo tài khoản thất bại !" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi hệ thống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {

                            if (Program.conn.State == ConnectionState.Closed)
                            {
                                Database.KetNoiSauXacThuc().Open();

                            }
                            String strLenh = "dbo.sp_KiemTraTonTaiGV";
                            Program.cmd = Program.conn.CreateCommand();
                            Program.cmd.CommandType = CommandType.StoredProcedure;
                            Program.cmd.CommandText = strLenh;
                            Program.cmd.Parameters.Add("@MAGV", SqlDbType.VarChar).Value = this.txbtentaikhoan.Text;

                            Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                            Program.cmd.ExecuteNonQuery();
                            Program.conn.Close();
                            String Ret = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                    
                            if (Ret == "0")
                            {
                                MessageBox.Show("Tên tài khoản chưa tồn tại trong CSDL !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn muốn tạo tài khoản ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    try
                                    {

                                        if (Program.conn.State == ConnectionState.Closed)
                                        {
                                            Database.KetNoiSauXacThuc().Open();

                                        }
                                        String strLenh_1 = "dbo.sp_TaoLogin";
                                        Program.cmd = Program.conn.CreateCommand();
                                        Program.cmd.CommandType = CommandType.StoredProcedure;
                                        Program.cmd.CommandText = strLenh_1;
                                        Program.cmd.Parameters.Add("@LGNAME", SqlDbType.VarChar).Value = login;
                                        Program.cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = matkhau;
                                        Program.cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = taikhoan;
                                        Program.cmd.Parameters.Add("@ROLE", SqlDbType.VarChar).Value = nhomquyen;
                                        Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                                        Program.cmd.ExecuteNonQuery();
                                        Program.conn.Close();
                                        String Ret_1 = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                    
                                        if (Ret_1 == "1")
                                        {
                                            MessageBox.Show("Tên login đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else if (Ret == "2")
                                        {
                                            MessageBox.Show("Tên tài khoản đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Tạo tài khoản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Tạo tài khoản thất bại !" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi hệ thống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
            }
        }
    }
}

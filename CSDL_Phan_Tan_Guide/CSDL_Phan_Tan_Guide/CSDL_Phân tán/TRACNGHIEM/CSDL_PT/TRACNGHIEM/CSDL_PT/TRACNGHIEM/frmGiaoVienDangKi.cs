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
    public partial class frmGiaoVienDangKi : Form
    {
        private bool kt = false;
        public frmGiaoVienDangKi()
        {
            InitializeComponent();
            this.mAGVTextEdit.Text = Program.username;            
            this.LayMaLop(); // lấy mã lớp đổ vào combobox
            this.LayMaMonHoc(); // lấy mã môn học đổ vào combobox
            this.mAGVTextEdit.Enabled = false; // không cho sửa mã giáo viên
            this.XuLiButton(true);
            this.cbxmalop.Hide();
            this.cbxmamonhoc.Hide();
            this.cbxmalop.SelectedIndex = 0;
            this.cbxmamonhoc.SelectedIndex = 0;
            //Program.connectionString = @"Data Source=THIENTAM\THIENTAM_1;Initial Catalog=TRACNGHIEM;User ID=TH123;Password=123456";
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gIAOVIEN_DANGKYBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tRACNGHIEMDataSet);

        }

        // phương thức set trạng thái button
        private void XuLiButton(bool KT)
        {
            this.btnfirst.Enabled = this.btnlast.Enabled = this.btnnext.Enabled = this.btnpre.Enabled = this.btnthem.Enabled = this.btnxoa.Enabled = this.btnsua.Enabled = KT;
            this.mAMHTextEdit.Enabled = this.mALOPTextEdit.Enabled = this.tRINHDOTextEdit.Enabled = this.nGAYTHIDateEdit.Enabled = this.lANSpinEdit.Enabled = this.sOCAUTHISpinEdit.Enabled = this.tHOIGIANSpinEdit.Enabled = !KT;
            this.btnluu.Enabled = this.btnhuy.Enabled = !KT;
        }

        private void frmGiaoVienDangKi_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "COSO")
            {
                this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connectionString;
                // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.MONHOC' table. You can move, or remove it, as needed.
                this.mONHOCTableAdapter.Fill(this.tRACNGHIEMDataSet.MONHOC);
                // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
                this.gIAOVIEN_DANGKYTableAdapter.Fill(this.tRACNGHIEMDataSet.GIAOVIEN_DANGKY);

                this.mAGVTextEdit.Text = Program.username;
            }
            else if (Program.mGroup == "GIANGVIEN")
            {
                this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connectionString;
                // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.MONHOC' table. You can move, or remove it, as needed.
                this.mONHOCTableAdapter.Fill(this.tRACNGHIEMDataSet.MONHOC);
                // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
                this.gIAOVIEN_DANGKYTableAdapter.FillMAGV(this.tRACNGHIEMDataSet.GIAOVIEN_DANGKY, Program.username);

                this.mAGVTextEdit.Text = Program.username;
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sOCAUTHISpinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tHOIGIANLabel_Click(object sender, EventArgs e)
        {

        }

        private void sOCAUTHILabel_Click(object sender, EventArgs e)
        {

        }

        private void tHOIGIANSpinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

        }

        private void txbtimkiem_TextChanged(object sender, EventArgs e)
        {
            this.gIAOVIEN_DANGKYBindingSource.Filter = "MAGV LIKE '%" + this.txbtimkiem.Text + "%'" + " OR MAMH LIKE '%" + this.txbtimkiem.Text + "%'";
        }

       

        private void btnfirst_Click(object sender, EventArgs e)
        {
            this.gIAOVIEN_DANGKYBindingSource.MoveFirst();
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            this.gIAOVIEN_DANGKYBindingSource.MovePrevious();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            this.gIAOVIEN_DANGKYBindingSource.MoveNext();
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            this.gIAOVIEN_DANGKYBindingSource.MoveLast();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {

            this.gIAOVIEN_DANGKYBindingSource.CancelEdit();
            this.XuLiButton(true);
            this.cbxmamonhoc.Hide();
            this.cbxmalop.Hide();
            this.mAMHTextEdit.Show();
            this.mALOPTextEdit.Show();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            this.gIAOVIEN_DANGKYBindingSource.AddNew();
            this.XuLiButton(false);
            this.cbxmamonhoc.Show();
            this.cbxmalop.Show();
            this.cbxmalop.Enabled = true;
            this.cbxmamonhoc.Enabled = true;
            this.cbxmalop.SelectedIndex = 0;
            this.cbxmamonhoc.SelectedIndex = 0;
            this.mAMHTextEdit.Text = this.cbxmamonhoc.SelectedItem.ToString();
            this.mALOPTextEdit.Text = this.cbxmalop.SelectedItem.ToString();
            this.mAMHTextEdit.Hide();
            this.mALOPTextEdit.Hide();
            this.mAGVTextEdit.Text = Program.username;
        }


        // phương thức lấy mã lớp bỏ vào combobox
        public void LayMaLop()
        {
            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                {
                    Database.KetNoiSauXacThuc().Open();

                }
                String strLenh = "dbo.spLayMaLop";
                Program.cmd = Program.conn.CreateCommand();
                Program.cmd.CommandType = CommandType.StoredProcedure;
                Program.cmd.CommandText = strLenh;
                SqlDataReader myReader;
                myReader = Program.cmd.ExecuteReader();


                while (myReader.Read() == true)
                {
                    this.cbxmalop.Items.Add(myReader.GetString(0));
                }
                myReader.Close();
                Program.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // phương thức lấy mã môn học bỏ vào combobox
        public void LayMaMonHoc()
        {
            try
            {
                
                if (Program.conn.State == ConnectionState.Closed)
                {
                    Database.KetNoiSauXacThuc().Open();

                }
                String strLenh = "dbo.sp_LayMaMonHoc";
                Program.cmd = Program.conn.CreateCommand();
                Program.cmd.CommandType = CommandType.StoredProcedure;
                Program.cmd.CommandText = strLenh;
                SqlDataReader myReader;
                myReader = Program.cmd.ExecuteReader();


                while (myReader.Read() == true)
                {

                    this.cbxmamonhoc.Items.Add(myReader.GetString(0));
                }
                myReader.Close();
                Program.conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.gIAOVIEN_DANGKYBindingSource.RemoveCurrent(); // xóa dòng dữ liệu hiện tại đang chọn
                this.gIAOVIEN_DANGKYTableAdapter.Update(this.tRACNGHIEMDataSet);// cập nhật dữ liệu vào database                
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            kt = true;
            this.XuLiButton(false);
            this.cbxmamonhoc.Show();
            this.cbxmalop.Show();
            this.cbxmamonhoc.SelectedItem = this.mAMHTextEdit.Text.ToString();
            this.cbxmalop.SelectedItem = this.mALOPTextEdit.Text.ToString();
            this.mAMHTextEdit.Hide();
            this.mALOPTextEdit.Hide();
            this.cbxmalop.Enabled = false;
            this.cbxmamonhoc.Enabled = false;
            this.lANSpinEdit.Enabled = false;
        }

        private void cbxmamonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mAMHTextEdit.Text = this.cbxmamonhoc.SelectedItem.ToString();

        }

        private void cbxmalop_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mALOPTextEdit.Text = this.cbxmalop.SelectedItem.ToString();

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            this.mAGVTextEdit.Text = Program.username;
            if (kt == true)
            {                                              
                kt = false;

                try
                {
                    
                    if (Program.conn.State == ConnectionState.Closed)
                    {

                        Database.KetNoiSauXacThuc().Open();

                    }
                    String strLenh = "dbo.sp_KiemTraNgayThi";
                    Program.cmd = Program.conn.CreateCommand();
                    Program.cmd.CommandType = CommandType.StoredProcedure;
                    Program.cmd.CommandText = strLenh;
                    Program.cmd.Parameters.Add("@MAMH", SqlDbType.VarChar).Value = this.mAMHTextEdit.Text.ToString();
                    Program.cmd.Parameters.Add("@MALOP", SqlDbType.VarChar).Value = this.mALOPTextEdit.Text.ToString();
                    Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = Int16.Parse(this.lANSpinEdit.Text.ToString());
                    Program.cmd.Parameters.Add("@NGAY_THI", SqlDbType.DateTime).Value = DateTime.Parse(this.nGAYTHIDateEdit.Text.ToString());
                    Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                    Program.cmd.ExecuteNonQuery();
                    Program.conn.Close();
                    String Ret = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                                                                                   
                    if (Ret == "1")
                    {
                        MessageBox.Show("Ngày thi không hợp lệ - kiểm tra lại ngày thi trước đó !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                    }
                    else 
                    {
                        try
                        {
                            // MessageBox.Show(this.mAMHTextEdit.Text + "," + this.mALOPTextEdit.Text);
                           
                            if (Program.conn.State == ConnectionState.Closed)
                            {
                                Database.KetNoiSauXacThuc().Open();

                            }
                            string strLenh_1 = "dbo.sp_KiemTraSoCauThi";
                            Program.cmd = Program.conn.CreateCommand();
                            Program.cmd.CommandType = CommandType.StoredProcedure;
                            Program.cmd.CommandText = strLenh_1;
                            Program.cmd.Parameters.Add("@SOCAUTHI", SqlDbType.SmallInt).Value = Int16.Parse(this.sOCAUTHISpinEdit.Text);
                            Program.cmd.Parameters.Add("@MAMH", SqlDbType.VarChar).Value = this.mAMHTextEdit.Text;
                            Program.cmd.Parameters.Add("@TRINHDO", SqlDbType.VarChar).Value = this.tRINHDOTextEdit.Text;
                            Program.cmd.Parameters.Add("@Ret_1", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                            Program.cmd.ExecuteNonQuery();

                            Program.conn.Close();
                            String Ret_1 = Program.cmd.Parameters["@Ret_1"].Value.ToString(); // sp sẽ trả về giá trị                    
                            if (Ret_1 == "1")
                            {
                                MessageBox.Show("Số câu thi không đủ để đăng kí- xin kiểm tra lại bộ đề !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                                
                            }
                            else
                            {
                                this.Validate();
                                this.gIAOVIEN_DANGKYBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset                                                                      
                                this.gIAOVIEN_DANGKYTableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database                                    
                                this.XuLiButton(true);
                                this.cbxmalop.Hide();
                                this.cbxmamonhoc.Hide();
                                this.mALOPTextEdit.Show();
                                this.mAMHTextEdit.Show();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                catch (Exception ex)
                {

                }

                this.gIAOVIEN_DANGKYBindingSource.CancelEdit();
                this.XuLiButton(true);
                this.cbxmamonhoc.Hide();
                this.cbxmalop.Hide();
                this.mAMHTextEdit.Show();
                this.mALOPTextEdit.Show();

            }
            else
            {
                string mamh = this.mAMHTextEdit.Text.ToString();
                string malop = this.mALOPTextEdit.Text.ToString();
                string trinhdo = this.tRINHDOTextEdit.Text.ToString();
                string ngaythi = this.nGAYTHIDateEdit.Text.ToString();
                string lan = this.lANSpinEdit.Text.ToString();
                string socauthi = this.sOCAUTHISpinEdit.Text.ToString();
                string thoigian = this.tHOIGIANSpinEdit.Text.ToString();

                if (trinhdo.Length == 0 || ngaythi.Length == 0 || lan.Length == 0 || socauthi.Length == 0 || thoigian.Length == 0)
                {
                    MessageBox.Show("Thông tin đăng kí không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (trinhdo.Length > 1)
                    {
                        MessageBox.Show("Trình độ chứa tối đa 1 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Char.Parse(trinhdo) < 65 || Char.Parse(trinhdo) > 68)
                    {
                        MessageBox.Show("Trình độ chỉ được nhập A, B, C, D !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Int16.Parse(lan) < 1)
                    {
                        MessageBox.Show("Lần thi phải lớn hơn hoặc bằng 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (Int16.Parse(thoigian) < 15)
                    {
                        MessageBox.Show("Thời gian phải lớn hơn hoặc bằng 15", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (Int16.Parse(socauthi) < 15)
                    {
                        MessageBox.Show("Số câu thi lớn hơn hoặc bằng 15", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // kiểm tra môn thi giáo viên đăng kí tồn tại


                        try
                        {
                            
                            if (Program.conn.State == ConnectionState.Closed)
                            {

                                Database.KetNoiSauXacThuc().Open();

                            }
                            String strLenh = "dbo.sp_KiemTraGiaoVienDK";
                            Program.cmd = Program.conn.CreateCommand();
                            Program.cmd.CommandType = CommandType.StoredProcedure;
                            Program.cmd.CommandText = strLenh;
                            Program.cmd.Parameters.Add("@MAMH", SqlDbType.VarChar).Value = mamh;
                            Program.cmd.Parameters.Add("@MALOP", SqlDbType.VarChar).Value = malop;
                            Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = Int16.Parse(lan);
                            Program.cmd.Parameters.Add("@NGAY_THI", SqlDbType.DateTime).Value = DateTime.Parse(ngaythi);
                            Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                            Program.cmd.ExecuteNonQuery();
                            Program.conn.Close();
                            String Ret = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                    
                            if (Ret == "1")
                            {
                                MessageBox.Show("Thông tin đăng kí đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                                
                            }
                            else if (Ret == "2")
                            {
                                MessageBox.Show("Ngày thi không hợp lệ - kiểm tra lại ngày thi trước đó !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                               

                            }
                            else
                            {
                                try
                                {
                                    // MessageBox.Show(this.mAMHTextEdit.Text + "," + this.mALOPTextEdit.Text);
                                    
                                    if (Program.conn.State == ConnectionState.Closed)
                                    {
                                        Database.KetNoiSauXacThuc().Open();

                                    }
                                    string strLenh_1 = "dbo.sp_KiemTraSoCauThi";
                                    Program.cmd = Program.conn.CreateCommand();
                                    Program.cmd.CommandType = CommandType.StoredProcedure;
                                    Program.cmd.CommandText = strLenh_1;
                                    Program.cmd.Parameters.Add("@SOCAUTHI", SqlDbType.SmallInt).Value = Int16.Parse(this.sOCAUTHISpinEdit.Text);
                                    Program.cmd.Parameters.Add("@MAMH", SqlDbType.VarChar).Value = this.mAMHTextEdit.Text;
                                    Program.cmd.Parameters.Add("@TRINHDO", SqlDbType.VarChar).Value = this.tRINHDOTextEdit.Text;
                                    Program.cmd.Parameters.Add("@Ret_1", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                                    Program.cmd.ExecuteNonQuery();

                                    Program.conn.Close();
                                    String Ret_1 = Program.cmd.Parameters["@Ret_1"].Value.ToString(); // sp sẽ trả về giá trị                    
                                    if (Ret_1 == "1")
                                    {
                                        MessageBox.Show("Số câu thi không đủ để đăng kí- xin kiểm tra lại bộ đề !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                                       
                                    }
                                    else
                                    {

                                        this.Validate();
                                        this.gIAOVIEN_DANGKYBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset                                                                      
                                        this.gIAOVIEN_DANGKYTableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database                                    
                                        this.XuLiButton(true);
                                        this.cbxmalop.Hide();
                                        this.cbxmamonhoc.Hide();
                                        this.mALOPTextEdit.Show();
                                        this.mAMHTextEdit.Show();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi hệ thống 1 !" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi hệ thống 2 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
                this.gIAOVIEN_DANGKYBindingSource.CancelEdit();
                this.XuLiButton(true);
                this.cbxmamonhoc.Hide();
                this.cbxmalop.Hide();
                this.mAMHTextEdit.Show();
                this.mALOPTextEdit.Show();
            }
        }

    }
}

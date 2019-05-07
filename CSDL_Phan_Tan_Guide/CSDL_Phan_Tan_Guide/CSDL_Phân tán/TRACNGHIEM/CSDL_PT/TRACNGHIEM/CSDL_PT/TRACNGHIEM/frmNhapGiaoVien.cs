using System;
using System.Collections;
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
    public partial class frmNhapGiaoVien : Form
    {
        private bool kt_sua = false;
        private int i = 0;
        private ArrayList makhoa = new ArrayList();

        public frmNhapGiaoVien()
        {
           // Program.connectionString = @"Data Source=THIENTAM\THIENTAM_1;Initial Catalog=TRACNGHIEM;User ID=TH123;Password=123456";
            InitializeComponent();
            this.LayMaKhoa();
            this.XuLiButton(true);
            this.mAKHComboBox.Hide();           
            
        }


        // phương thức set trạng thái button
        private void XuLiButton(bool KT)
        {
            this.btnfirst.Enabled = this.btnlast.Enabled = this.btnnext.Enabled = this.btnpre.Enabled = this.btnthem.Enabled = this.btnxoa.Enabled = this.btnsua.Enabled = KT;
            this.mAGVTextEdit.Enabled = this.hOTextEdit.Enabled = this.tENTextEdit.Enabled = this.dIACHITextEdit.Enabled = this.mAKHTextEdit.Enabled = this.hOCVITextEdit.Enabled = !KT;
            this.btnluu.Enabled = this.btnhuy.Enabled = !KT;
        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gIAOVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tRACNGHIEMDataSet);

        }

        private void frmNhapGiaoVien_Load(object sender, EventArgs e)
        {
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connectionString;
            // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Fill(this.tRACNGHIEMDataSet.GIAOVIEN);

        }

        private void txbtimkiem_TextChanged(object sender, EventArgs e)
        {
            this.gIAOVIENBindingSource.Filter = "MAGV LIKE '%" + this.txbtimkiem.Text + "%'" + " OR TEN LIKE '%" + this.txbtimkiem.Text + "%'";
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            this.gIAOVIENBindingSource.MoveFirst();
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            this.gIAOVIENBindingSource.MovePrevious();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            this.gIAOVIENBindingSource.MoveNext();
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            this.gIAOVIENBindingSource.MoveLast();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            
            this.XuLiButton(false);
            this.mAGVTextEdit.Focus();
            this.mAKHComboBox.Show();            
            this.gIAOVIENBindingSource.AddNew();            

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            bool KT = false;
            
            for (int j = 0; j < makhoa.Count ; j++)
            {               
                if (makhoa[j].Equals(this.mAKHTextEdit.Text.ToString()) == true)
                {
                    KT = true;
                    break;
                }
            }
            if (KT == true)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.gIAOVIENBindingSource.RemoveCurrent(); // xóa dòng dữ liệu hiện tại đang chọn
                    this.gIAOVIENTableAdapter.Update(this.tRACNGHIEMDataSet);// cập nhật dữ liệu vào database                
                }
            }
            else 
            {
                MessageBox.Show("Giáo viên này không được xóa ! ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
                
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.XuLiButton(true);
            this.mAKHComboBox.Hide();
            this.mAKHTextEdit.Show();
            this.gIAOVIENBindingSource.CancelEdit();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            bool KT = false;
            for (int j = 0; j < makhoa.Count; j++)
            {
                if (makhoa[j].Equals(this.mAKHTextEdit.Text) == true)
                {
                    KT = true;
                    break;
                }
            }
            if (KT == true)
            {
                this.kt_sua = true;
                this.XuLiButton(false);
                this.mAKHComboBox.Hide();
                this.mAKHTextEdit.Show();
                this.mAGVTextEdit.Enabled = false;
                this.mAKHTextEdit.Enabled = false;
                this.hOTextEdit.Focus();
            }
            else
            {
                MessageBox.Show("Thông tin giáo viên này không được sửa ! ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            
        }

        // phương thức lấy mã khoa
        private void LayMaKhoa()
        {
            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                {
                    Database.KetNoiSauXacThuc().Open();

                }
                String strLenh = "dbo.sp_LayMaKhoa";
                Program.cmd = Program.conn.CreateCommand();
                Program.cmd.CommandType = CommandType.StoredProcedure;
                Program.cmd.CommandText = strLenh;
                SqlDataReader myReader;
                myReader = Program.cmd.ExecuteReader();


                while (myReader.Read() == true)
                {

                    this.mAKHComboBox.Items.Add(myReader.GetString(0));
                    makhoa.Add(myReader.GetString(0));
                }
                myReader.Close();
                Program.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            if (this.kt_sua == true)
            {

                this.Validate();
                this.gIAOVIENBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset                                  
                this.gIAOVIENTableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database
                this.XuLiButton(true);
                this.mAKHComboBox.Hide();
                this.mAKHTextEdit.Show();
            }
            else
            {
                string ma = this.mAGVTextEdit.Text;
                string ho = this.hOTextEdit.Text;
                string ten = this.tENTextEdit.Text;
                string diachi = this.dIACHITextEdit.Text;
                string makh = this.mAKHTextEdit.Text;
               
                string hocvi = this.hOCVITextEdit.Text;

                if (ma.Length == 0 || ho.Length == 0 || ten.Length == 0 || diachi.Length == 0 || makh.Length == 0 || hocvi.Length == 0)
                {
                    MessageBox.Show("Thông tin giáo viên không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (ma.Length > 8)
                    {
                        MessageBox.Show("Mã giáo viên chứa tối đa 8 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (ho.Length > 40)
                    {
                        MessageBox.Show("Họ giáo viên chứa tối đa 40 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (ten.Length > 40)
                    {
                        MessageBox.Show("Tên giáo viên chứa tối đa 40 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (diachi.Length > 50)
                    {
                        MessageBox.Show("Địa chỉ chứa tối đa 50 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (makh.Length > 8)
                    {
                        MessageBox.Show("Mã khoa chứa tối đa 8 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (hocvi.Length > 8)
                    {
                        MessageBox.Show("Học vị chứa tối đa 8 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {

                        try
                        {
                            if (Program.conn.State == ConnectionState.Closed)
                            {
                                Database.KetNoiSauXacThuc().Open();

                            }
                            String strLenh = "dbo.sp_KiemTraGiaoVien";
                            Program.cmd = Program.conn.CreateCommand();
                            Program.cmd.CommandType = CommandType.StoredProcedure;
                            Program.cmd.CommandText = strLenh;
                            Program.cmd.Parameters.Add("@MAGV", SqlDbType.VarChar).Value = this.mAGVTextEdit.Text.ToString();
                            Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                            Program.cmd.ExecuteNonQuery();
                            Program.conn.Close();
                            String Ret = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                    
                            if (Ret == "1")
                            {
                                MessageBox.Show("Mã giáo viên đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                try
                                {

                                    this.Validate();
                                    this.gIAOVIENBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset                                  
                                    this.gIAOVIENTableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database
                                    this.XuLiButton(true);
                                    this.mAKHComboBox.Hide();
                                    this.mAKHTextEdit.Show();
                                }
                                catch
                                {

                                    this.gIAOVIENBindingSource.RemoveCurrent(); // nếu thêm không thành công thì nó vẫn thêm vào dataset - xóa trên dataset 
                                    MessageBox.Show("Mã lớp chưa tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.XuLiButton(true);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void mAKHComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mAKHTextEdit.Text = this.mAKHComboBox.SelectedItem.ToString();

        }       
    }
}

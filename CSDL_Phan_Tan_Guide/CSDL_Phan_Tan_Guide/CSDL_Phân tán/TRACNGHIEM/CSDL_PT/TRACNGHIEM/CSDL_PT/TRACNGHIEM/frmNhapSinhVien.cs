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
    public partial class frmNhapSinhVien : Form
    {
        private bool kt_sua = false;
        private int i = 0;
        public frmNhapSinhVien()
        {
            InitializeComponent();           
            this.XuLiButton(true);
            LayMaLop();  // load mã lớp từ table Lop lên combobox          
            this.cbxmalop.Hide();            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sINHVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tRACNGHIEMDataSet);

        }

        private void frmNhapSinhVien_Load(object sender, EventArgs e)
        {
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connectionString;
            // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.tRACNGHIEMDataSet.SINHVIEN);
            

        }

        // phương thức set trạng thái button
        private void XuLiButton(bool KT)
        {
            this.btnfirst.Enabled = this.btnlast.Enabled = this.btnnext.Enabled = this.btnpre.Enabled = this.btnthem.Enabled = this.btnxoa.Enabled = this.btnsua.Enabled = KT;
            this.mASVTextEdit.Enabled = this.hOTextEdit.Enabled = this.tENTextEdit.Enabled = this.nGAYSINHDateEdit.Enabled = this.dIACHITextEdit.Enabled = this.mALOPTextEdit.Enabled = !KT;
            this.btnluu.Enabled = this.btnhuy.Enabled = !KT;
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            this.sINHVIENBindingSource.MoveFirst();
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            this.sINHVIENBindingSource.MovePrevious();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            this.sINHVIENBindingSource.MoveNext();
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            this.sINHVIENBindingSource.MoveLast();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            this.cbxmalop.Show();
            this.mALOPTextEdit.Hide();
            this.XuLiButton(false);               
            //this.cbxmalop.SelectedIndex = 0;
            this.mASVTextEdit.Focus();
            this.sINHVIENBindingSource.AddNew(); // xóa dữ liệu trên các textbox <=> chuẩn bị thêm 1 thằng sinh viên vào dataset            
                      
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.sINHVIENBindingSource.RemoveCurrent(); // xóa dòng dữ liệu hiện tại đang chọn
                this.sINHVIENTableAdapter.Update(this.tRACNGHIEMDataSet);// cập nhật dữ liệu vào database                
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            this.kt_sua = true;
            this.cbxmalop.Hide();
            this.mALOPTextEdit.Show();
            this.XuLiButton(false);
            this.mASVTextEdit.Enabled = false;
            this.mALOPTextEdit.Enabled = false;
            this.hOTextEdit.Focus();          
           
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.cbxmalop.Hide();
            this.mALOPTextEdit.Show();
            this.sINHVIENBindingSource.CancelEdit(); // hủy bỏ việc hiệu chỉnh trên dòng dữ liệu
            this.XuLiButton(true);
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (this.kt_sua == true)
            {
                this.Validate();
                this.sINHVIENBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset                                  
                this.sINHVIENTableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database
                this.XuLiButton(true);
                this.cbxmalop.Hide();
                this.mALOPTextEdit.Show();
                this.kt_sua = false;
            }
            else
            {
                string masv = this.mASVTextEdit.Text;
                string ho = this.hOTextEdit.Text;
                string ten = this.tENTextEdit.Text;
                string ngaysinh = this.nGAYSINHDateEdit.Text;
                string diachi = this.dIACHITextEdit.Text;
                string malop = this.mALOPTextEdit.Text;
                string cbxmalop = this.cbxmalop.SelectedItem.ToString();

                if (masv.Length == 0 || ho.Length == 0 || ten.Length == 0 || ngaysinh.Length == 0 || diachi.Length == 0 || cbxmalop.Length == 0)
                {
                    MessageBox.Show("Thông tin sinh viên không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (masv.Length > 8)
                    {
                        MessageBox.Show("Mã sinh viên chứa tối đa 8 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (ho.Length > 40)
                    {
                        MessageBox.Show("Họ sinh viên chứa tối đa 40 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (ten.Length > 10)
                    {
                        MessageBox.Show("Tên sinh viên chứa tối đa 10 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (diachi.Length > 40)
                    {
                        MessageBox.Show("Địa chỉ chứa tối đa 40 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (malop.Length > 8)
                    {
                        MessageBox.Show("Mã lớp chứa tối đa 8 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {

                        try
                        {
                            //Program.connectionString = @"Data Source=THIENTAM\THIENTAM_1;Initial Catalog=TRACNGHIEM;User ID=TH123;Password=123456";
                            if (Program.conn.State == ConnectionState.Closed)
                            {
                                Database.KetNoiSauXacThuc().Open();

                            }
                            String strLenh = "dbo.sp_KiemTraSinhVien";
                            Program.cmd = Program.conn.CreateCommand();
                            Program.cmd.CommandType = CommandType.StoredProcedure;
                            Program.cmd.CommandText = strLenh;
                            Program.cmd.Parameters.Add("@MASV", SqlDbType.VarChar).Value = this.mASVTextEdit.Text.ToString();
                            Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                            Program.cmd.ExecuteNonQuery();
                            Program.conn.Close();
                            String Ret = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                    
                            if (Ret == "1")
                            {
                                MessageBox.Show("Mã sinh viên đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                try
                                {

                                    this.Validate();
                                    this.sINHVIENBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset                                  
                                    this.sINHVIENTableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database
                                    this.XuLiButton(true);
                                    this.cbxmalop.Hide();
                                    this.mALOPTextEdit.Show();
                                }
                                catch
                                {

                                    this.sINHVIENBindingSource.RemoveCurrent(); // nếu thêm không thành công thì nó vẫn thêm vào dataset - xóa trên dataset 
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

        private void txbtimkiem_TextChanged(object sender, EventArgs e)
        {
            this.sINHVIENBindingSource.Filter = "MASV LIKE '%" + this.txbtimkiem.Text + "%'" + " OR TEN LIKE '%" + this.txbtimkiem.Text + "%'";
        }

        // phương thức lấy mã lớp bỏ vào combobox
        public void LayMaLop() 
        {
            //Program.connectionString = @"Data Source=THIENTAM\THIENTAM_1;Initial Catalog=TRACNGHIEM;User ID=TH123;Password=123456";
            if (Program.conn.State == ConnectionState.Closed)
            {
                Database.KetNoiSauXacThuc().Open();
           
            }
            String strLenh = "dbo.spLayMaLop";
            Program.cmd = Program.conn.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = strLenh;                                   
            SqlDataReader myReader;
            myReader = Database.ExecSqlDataReader(strLenh);
          
                        
            while(myReader.Read() == true){
                 
                this.cbxmalop.Items.Add(myReader.GetString(0));
            }           
            myReader.Close();
            Program.conn.Close();
        }

        private void cbxmalop_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mALOPTextEdit.Text = this.cbxmalop.SelectedItem.ToString();
            
        }

        private void sINHVIENGridControl_Click(object sender, EventArgs e)
        {            
        }           
        
    }
}

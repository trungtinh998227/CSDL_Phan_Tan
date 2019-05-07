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
    public partial class frmNhapBoDe : Form
    {
        private bool KT = false;
        public frmNhapBoDe()
        {
            InitializeComponent();
            this.mAGVTextEdit.Enabled = false;
            this.mAGVTextEdit.Text = Program.username;            
            Load_TrinhDo_DapAn();
            LayMaMonHoc();
            XuLiButton(true);
            XuLiComboboxHide();
            this.txbcauhoi.Enabled = false;
            this.cAUHOISpinEdit.Enabled = false;
         
        }
        // phương thức set trạng thái button
        private void XuLiButton(bool KT)
        {
            this.btnfirst.Enabled = this.btnlast.Enabled = this.btnnext.Enabled = this.btnpre.Enabled = this.btnthem.Enabled = this.btnxoa.Enabled = this.btnsua.Enabled = KT;
            this.txbnoidung.Enabled =  this.aTextEdit.Enabled  = this.bTextEdit.Enabled = this.cTextEdit.Enabled = this.dTextEdit.Enabled = this.mAMHTextEdit.Enabled = this.tRINHDOTextEdit.Enabled = this.dAP_ANTextEdit.Enabled = !KT;
            this.btnluu.Enabled = this.btnhuy.Enabled = !KT;
        }
        // combpbox chứa trình độ, combobox chứa đáp án
        private void Load_TrinhDo_DapAn()
        {            
                this.cbxdapan.Items.Add("A");
                this.cbxtrinhdo.Items.Add("A");
                this.cbxdapan.Items.Add("B");
                this.cbxtrinhdo.Items.Add("B");
                this.cbxdapan.Items.Add("C");
                this.cbxtrinhdo.Items.Add("C");
                this.cbxdapan.Items.Add("D");
                this.cbxtrinhdo.Items.Add("D");            
        }

        // xử lí combobox
        private void XuLiComboboxHide()
        {
            this.cbxmamonhoc.Hide();
            this.cbxtrinhdo.Hide();
            this.cbxdapan.Hide();
            this.txbcauhoi.Hide();
        }
        private void XuLiComboboxShow()
        {
            this.cbxmamonhoc.Show();
            this.cbxtrinhdo.Show();
            this.cbxdapan.Show();
            this.txbcauhoi.Show();
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

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bODEBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tRACNGHIEMDataSet);

        }

        private void frmNhapBoDe_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "GIANGVIEN")
            {
                this.bODETableAdapter.Connection.ConnectionString = Program.connectionString;
                // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.BODE' table. You can move, or remove it, as needed.
                this.bODETableAdapter.FillGV(this.tRACNGHIEMDataSet.BODE, Program.mlogin);
                this.txbnoidung.Text = this.nOIDUNGTextEdit.Text;
            }
            else
            {
                this.bODETableAdapter.Connection.ConnectionString = Program.connectionString;
                // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.BODE' table. You can move, or remove it, as needed.
                this.bODETableAdapter.Fill(this.tRACNGHIEMDataSet.BODE);
                this.txbnoidung.Text = this.nOIDUNGTextEdit.Text;
            }
            

        }

        private void txbtimkiem_TextChanged(object sender, EventArgs e)
        {
            this.bODEBindingSource.Filter = "MAGV LIKE '%" + this.txbtimkiem.Text + "%'" + " OR MAMH LIKE '%" + this.txbtimkiem.Text + "%'";
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            this.bODEBindingSource.MoveFirst();
            this.txbnoidung.Text = this.nOIDUNGTextEdit.Text;
            
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            this.bODEBindingSource.MovePrevious();
            this.txbnoidung.Text = this.nOIDUNGTextEdit.Text;
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            this.bODEBindingSource.MoveNext();
            this.txbnoidung.Text = this.nOIDUNGTextEdit.Text;
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            this.bODEBindingSource.MoveLast();
            this.txbnoidung.Text = this.nOIDUNGTextEdit.Text;
        }

        private void mAGVTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxtrinhdo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tRINHDOTextEdit.Text = this.cbxtrinhdo.SelectedItem.ToString();
        }

        private void cbxdapan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dAP_ANTextEdit.Text = this.cbxdapan.SelectedItem.ToString();
        }

        private void cbxmamonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mAMHTextEdit.Text = this.cbxmamonhoc.SelectedItem.ToString();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.bODEBindingSource.CancelEdit();       
            XuLiComboboxHide();
            this.txbnoidung.Text = this.nOIDUNGTextEdit.Text;
            XuLiButton(true);                       
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            this.bODEBindingSource.AddNew();
            this.cAUHOISpinEdit.Enabled = true;
            this.cAUHOISpinEdit.Focus();
            this.cAUHOISpinEdit.Enabled = false;
            XuLiComboboxShow();
            XuLiButton(false);
            this.txbnoidung.Clear();           
            int index = TimMaCauHoi();
            this.txbcauhoi.Text = index.ToString();
            this.txbcauhoi.Enabled = false;            
            this.mAGVTextEdit.Text = Program.mlogin;
        }

        // phương thức tìm mã câu hỏi tiếp theo
        private int TimMaCauHoi()
        {
            try
            {

                if (Program.conn.State == ConnectionState.Closed)
                {

                    Database.KetNoiSauXacThuc().Open();
                }
                String strLenh = "dbo.sp_TimMaCauHoi";
                Program.cmd = Program.conn.CreateCommand();
                Program.cmd.CommandType = CommandType.StoredProcedure;
                Program.cmd.CommandText = strLenh;
                Program.cmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                Program.cmd.ExecuteNonQuery();
                Program.conn.Close();
                String Ret = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                                                                                   
                return Int32.Parse(Ret);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống rồi!");
            }
            return 0;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (KT == true)
            {
                KT = false;                
                string mamonhoc = this.mAMHTextEdit.Text;
                string trinhdo = this.tRINHDOTextEdit.Text;
                string dapan = this.dAP_ANTextEdit.Text;
                this.nOIDUNGTextEdit.Text = this.txbnoidung.Text;
                string noidung = this.nOIDUNGTextEdit.Text;
                string a = this.aTextEdit.Text;
                string b = this.bTextEdit.Text;
                string c = this.cTextEdit.Text;
                string d = this.dTextEdit.Text;

                if (mamonhoc.Length == 0 || trinhdo.Length == 0 || dapan.Length == 0 || noidung.Length == 0 || a.Length == 0 || b.Length == 0 || c.Length == 0 || d.Length == 0)
                {
                    MessageBox.Show("Thông tin câu hỏi không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Validate();
                    this.bODEBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset                                                                      
                    this.bODETableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database                                    
                    XuLiButton(true);
                    XuLiComboboxHide();
                }
            }
            else
            {
                this.cAUHOISpinEdit.Text = this.txbcauhoi.Text;
                this.mAMHTextEdit.Text = this.cbxmamonhoc.Text;
                string mamonhoc = this.mAMHTextEdit.Text;
                this.tRINHDOTextEdit.Text = this.cbxtrinhdo.Text;
                string trinhdo = this.tRINHDOTextEdit.Text;
                this.dAP_ANTextEdit.Text = this.cbxtrinhdo.Text;
                string dapan = this.dAP_ANTextEdit.Text;
                this.nOIDUNGTextEdit.Text = this.txbnoidung.Text;
                string noidung = this.nOIDUNGTextEdit.Text;
                this.cAUHOISpinEdit.Text = this.txbcauhoi.Text;
                string a = this.aTextEdit.Text;
                string b = this.bTextEdit.Text;
                string c = this.cTextEdit.Text;
                string d = this.dTextEdit.Text;

                if (mamonhoc.Length == 0 || trinhdo.Length == 0 || dapan.Length == 0 || noidung.Length == 0 || a.Length == 0 || b.Length == 0 || c.Length == 0 || d.Length == 0)
                {
                    MessageBox.Show("Thông tin câu hỏi không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Validate();
                    this.bODEBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset                                                                      
                    this.bODETableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database                                    
                    XuLiButton(true);
                    XuLiComboboxHide();
                }
            }
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            KT = true;
            this.cbxmamonhoc.Text = this.mAMHTextEdit.Text;
            this.cbxdapan.Text = this.dAP_ANTextEdit.Text;
            this.cbxtrinhdo.Text = this.tRINHDOTextEdit.Text;
            XuLiComboboxShow();
            this.txbcauhoi.Hide();
            XuLiButton(false);       
            this.txbnoidung.Text = this.nOIDUNGTextEdit.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.bODEBindingSource.RemoveCurrent(); // xóa dòng dữ liệu hiện tại đang chọn
                this.bODETableAdapter.Update(this.tRACNGHIEMDataSet);// cập nhật dữ liệu vào database                                
            }
        }
    }
}

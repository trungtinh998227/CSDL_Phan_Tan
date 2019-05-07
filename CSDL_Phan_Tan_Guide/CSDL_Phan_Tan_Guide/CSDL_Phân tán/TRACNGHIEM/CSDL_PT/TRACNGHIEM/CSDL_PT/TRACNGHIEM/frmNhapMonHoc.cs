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
    public partial class frmNhapMonHoc : Form
    {
        public frmNhapMonHoc()
        {
           
            InitializeComponent();
            this.XuLiButton(true);
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mONHOCBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tRACNGHIEMDataSet);

        }
        // phương thức set trạng thái button
        private void XuLiButton(bool KT) 
        {
            this.button6.Enabled = this.button7.Enabled = this.button8.Enabled = this.button9.Enabled = this.btnthem.Enabled = this.btnxoa.Enabled = this.btnsua.Enabled = KT;
            this.mAMHTextEdit.Enabled = this.tENMHTextEdit.Enabled = this.btnluu.Enabled = this.btnhuy.Enabled = !KT;
        }
        private void frmNhapMonHoc_Load(object sender, EventArgs e)
        {
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connectionString;
            // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.tRACNGHIEMDataSet.MONHOC);
            
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.mONHOCBindingSource.MoveFirst();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.mONHOCBindingSource.MovePrevious();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.mONHOCBindingSource.MoveNext();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.mONHOCBindingSource.MoveLast();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.mONHOCBindingSource.RemoveCurrent(); // xóa dòng dữ liệu hiện tại đang chọn
                this.mONHOCTableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu vào database
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            this.XuLiButton(false);
            this.mAMHTextEdit.Focus(); // cho con trỏ chuột trỏ ngay ô textbox mã môn học
            this.mONHOCBindingSource.AddNew(); // thêm 1 môn học vào dataset            
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string mamh = this.mAMHTextEdit.Text;
            string tenmh = this.tENMHTextEdit.Text;

            if (mamh.Length == 0 || tenmh.Length == 0)
            {
                MessageBox.Show("Mã hoặc tên môn học không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                if (mamh.Length > 5)
                {
                    MessageBox.Show("Mã môn học chứa tối đa 5 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (tenmh.Length > 40)
                {
                    MessageBox.Show("Tên môn học chứa tối đa 40 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try {

                        this.Validate();
                        this.mONHOCBindingSource.EndEdit(); // kết thúc quá trình hiệu chỉnh dữ liệu trên 1 dòng trong Dataset
                        this.mONHOCTableAdapter.Update(this.tRACNGHIEMDataSet); // cập nhật dữ liệu và database
                        this.XuLiButton(true);
                    }catch
                    {
                        MessageBox.Show("Mã môn học " + mamh + " đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
           
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.mONHOCBindingSource.CancelEdit(); // hủy bỏ việc hiệu chỉnh trên 1 dòng dữ liệu
            this.XuLiButton(true);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            this.XuLiButton(false);
            this.mAMHTextEdit.Focus(); // cho con trỏ chuột trỏ ngay ô textbox mã môn học
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            
        }

        private void txbtimkiem_TextChanged(object sender, EventArgs e)
        {
            this.mONHOCBindingSource.Filter = "MAMH LIKE '%" + this.txbtimkiem.Text + "%'" + " OR TENMH LIKE '%" + this.txbtimkiem.Text + "%'";
        }

        

    }
}

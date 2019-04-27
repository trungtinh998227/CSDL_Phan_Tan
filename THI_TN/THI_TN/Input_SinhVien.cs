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
    public partial class Input_SinhVien : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private int indexRow;
        string dataSrc;
        public Input_SinhVien()
        {
            InitializeComponent();
            dataSrc = Login.datasSrc;
            conn = new SqlConnection(dataSrc);
            load_SINHVIEN();
            load_cbLOP();
        }

        private void Input_SinhVien_Load(object sender, EventArgs e)
        {
            
        }
        private void load_SINHVIEN()
        {
            conn.Open();
            string view_SV = "select MASV as N'Mã SV', HO as N'Họ', TEN as N'Tên', NGAYSINH as N'Ngày sinh', DIACHI as N'Địa chỉ', MALOP AS N'Mã lớp' FROM SINHVIEN";
            adapter = new SqlDataAdapter(view_SV, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            View_SINHVIEN.DataSource = dt;
            conn.Close();
        }
        private void load_cbLOP()
        {
            cb_MALOP.Items.Clear();
            conn.Open();
            string getCb = "select MALOP from LOP";
            SqlDataReader read = new SqlCommand(getCb,conn).ExecuteReader();
            while (read.Read())
            {
                cb_MALOP.Items.Add(read.GetValue(0).ToString());
            }
            conn.Close();
        }
        private void View_SINHVIEN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bnt_Add.Enabled = false;
            bnt_Del.Enabled = true;
            bnt_Edit.Enabled = true;
            indexRow = e.RowIndex;
            cb_MALOP.Items.Clear();
            if (indexRow < 0)
            {
                MessageBox.Show("Không thể sửa nội dung này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow row = View_SINHVIEN.Rows[indexRow];
                txb_MASV.Text = row.Cells[0].Value.ToString();
                txb_Ho.Text = row.Cells[1].Value.ToString();
                txb_TEN.Text = row.Cells[2].Value.ToString();
                txb_NGAYSINH.Text = row.Cells[3].Value.ToString();
                txb_DIACHI.Text = row.Cells[4].Value.ToString();
                cb_MALOP.Text=row.Cells[5].Value.ToString();
            }
        }

        private void Input_SinhVien_MouseClick(object sender, MouseEventArgs e)
        {
            bnt_Add.Enabled = true;
            bnt_Del.Enabled = false;
            bnt_Edit.Enabled = false;
            txb_MASV.Text = "";
            txb_Ho.Text = "";
            txb_TEN.Text = "";
            txb_NGAYSINH.Text = "";
            txb_DIACHI.Text = "";
            cb_MALOP.Text = "";
            load_cbLOP();
        }

        private void bnt_Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txb_MASV.Text==""||cb_MALOP.Text=="")
            {
                MessageBox.Show("Vui lòng nhập thông tin Mã sinh viên và Mã lớp", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                check_DBExit check_MASV = new check_DBExit("MASV", txb_MASV.Text, "SINHVIEN");
                check_DBExit check_MALOP = new check_DBExit("MALOP", cb_MALOP.Text, "LOP");
                if (check_MASV.check())
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (check_MALOP.check())
                    {
                        string addvalue = "insert into SINHVIEN (MASV,HO,TEN,NGAYSINH,DIACHI,MALOP) values ('"+txb_MASV.Text+"','"+txb_Ho.Text+"','"+txb_TEN.Text+"','"+Convert.ToDateTime(txb_NGAYSINH.Text.Trim())+"','"+txb_DIACHI.Text+"','"+cb_MALOP.Text+"')";
                        adapter = new SqlDataAdapter(addvalue, conn);
                        adapter.SelectCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Mã lớp không tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            conn.Close();
            load_SINHVIEN();
        }

        private void bnt_Del_Click(object sender, EventArgs e)
        {
            conn.Open();
            string delValue = "delete from SINHVIEN where MASV='"+txb_MASV.Text.Trim()+"'";
            adapter = new SqlDataAdapter(delValue, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            conn.Close();
            load_SINHVIEN();
        }

        private void bnt_Edit_Click(object sender, EventArgs e)
        {
            conn.Open();
            check_DBExit check_Lop = new check_DBExit("MALOP", cb_MALOP.Text, "SINHVIEN");
            if (check_Lop.check())
            {
                string editValue = "update SINHVIEN set HO='"+txb_Ho.Text+"', TEN='"+txb_TEN.Text+"',NGAYSINH='"+Convert.ToDateTime(txb_NGAYSINH.Text.Trim())+"',DIACHI='"+txb_DIACHI.Text+"',MALOP='"+cb_MALOP.Text+"' where MASV='"+txb_MASV.Text+"'";
                adapter = new SqlDataAdapter(editValue, conn);
                adapter.SelectCommand.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Mã lớp hoặc Mã SV không đúng", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            conn.Close();
            load_SINHVIEN();
        }
    }
}

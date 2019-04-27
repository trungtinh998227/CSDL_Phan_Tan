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
    public partial class Input_GiaoVien : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private int indexRow;
        string dataSrc;
        public Input_GiaoVien()
        {
            InitializeComponent();
            this.dataSrc = Login.datasSrc;
            conn = new SqlConnection(dataSrc);
            load_View_GV();
            load_cbMAKH();
        }
        private void load_View_GV()
        {
            conn.Open();
            string getData = "select MAGV as N'MAGV', HO as N'Họ', TEN as N'Tên', HOCVI as N'Học vị',MAKH as N'Mã Khoa' from GIAOVIEN";
            adapter = new SqlDataAdapter(getData, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            View_GIAOVIEN.DataSource = dt;
            conn.Close();
        }
        private void load_cbMAKH()
        {
            cb_MAKH.Items.Clear();
            conn.Open();
            string getVal = "select MAKH from KHOA";
            SqlDataReader read = new SqlCommand(getVal, conn).ExecuteReader();
            while (read.Read())
            {
                cb_MAKH.Items.Add(read.GetValue(0).ToString().Trim());
            }
            conn.Close();
        }
        private void View_GIAOVIEN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            bnt_Add.Enabled = false;
            if (indexRow < 0)
            {
                MessageBox.Show("Không thể sửa thông tin này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow row = View_GIAOVIEN.Rows[indexRow];
                cb_MAKH.Text=row.Cells[4].Value.ToString();
                txb_Ho.Text = row.Cells[1].Value.ToString();
                txb_TEN.Text = row.Cells[2].Value.ToString();
                txb_HOCVI.Text = row.Cells[3].Value.ToString();
                txb_MaGV.Text = row.Cells[0].Value.ToString();
            }
        }

        private void Input_GiaoVien_Load(object sender, EventArgs e)
        {

        }

        private void bnt_Add_Click(object sender, EventArgs e)
        {
            if (txb_MaGV.Text == "" || cb_MAKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Mã GV và Mã khoa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                check_DBExit check_GV = new check_DBExit("MAGV", txb_MaGV.Text.Trim(), "GIAOVIEN");
                check_DBExit check_KH = new check_DBExit("MAKH", cb_MAKH.Text.Trim(), "KHOA");
                if (check_GV.check())
                {
                    MessageBox.Show("Giáo viên đã tồn tại!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else if(check_KH.check())
                {
                    conn.Open();
                    string addValue = "insert into GIAOVIEN (MAGV,HO,TEN,HOCVI,MAKH) values ('"+txb_MaGV.Text+"','"+txb_Ho.Text+"','"+txb_TEN.Text+"','"+txb_HOCVI.Text+"','"+cb_MAKH.Text+"')";
                    adapter = new SqlDataAdapter(addValue, conn);
                    adapter.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Khoa không tồn tại!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            load_View_GV();
        }

        private void Input_GiaoVien_MouseClick(object sender, MouseEventArgs e)
        {
            bnt_Add.Enabled = true;
            bnt_Del.Enabled = false;
            bnt_Edit.Enabled = false;
            txb_MaGV.Text = "";
            txb_Ho.Text = "";
            txb_TEN.Text = "";
            txb_HOCVI.Text = "";
            cb_MAKH.Text = "";
        }

        private void bnt_Del_Click(object sender, EventArgs e)
        {
            conn.Open();
            string delValue = "delete from GIAOVIEN where MAGV = '"+txb_MaGV.Text.Trim()+"'";
            adapter = new SqlDataAdapter(delValue, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            conn.Close();
            load_View_GV();
            txb_MaGV.Text = "";
            txb_Ho.Text = "";
            txb_TEN.Text = "";
            txb_HOCVI.Text = "";
            cb_MAKH.Text = "";
        }

        private void bnt_Edit_Click(object sender, EventArgs e)
        {
            conn.Open();
            check_DBExit check_MAKH = new check_DBExit("MAKH", cb_MAKH.Text, "KHOA");
            if (check_MAKH.check())
            {
                string editValue = "update GIAOVIEN set HO='" + txb_Ho.Text + "',TEN='" + txb_TEN.Text + "', HOCVI='" + txb_HOCVI.Text + "',MAKH='"+cb_MAKH.Text+"' where MAGV='"+txb_MaGV.Text+"'";
                adapter = new SqlDataAdapter(editValue, conn);
                adapter.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Khoa không tồn tại!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            load_View_GV();
        }
    }
}

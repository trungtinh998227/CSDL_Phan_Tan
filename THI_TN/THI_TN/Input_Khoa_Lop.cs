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
    public partial class Input_Khoa_Lop : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataTable view_KHOA;
        private DataTable view_lop;
        private int indexRow;
        string dataSrc;
        public Input_Khoa_Lop()
        {
            InitializeComponent();
            dataSrc = Login.datasSrc;
            conn = new SqlConnection(dataSrc);
        }

        private void Input_Khoa_Lop_Load(object sender, EventArgs e)
        {
            Load_Khoa();
            //Khoa
            bnt_AddKhoa.Enabled = true;
            bnt_DelKhoa.Enabled = false;
            bnt_EditKhoa.Enabled = false;
            //Lop
            bnt_AddLop.Enabled = false;
            bnt_DelLop.Enabled = false;
            bnt_EditLop.Enabled = false;

            if (THI_TN.Menu.checks)
            {
                bnt_AddKhoa.Visible = false;
                bnt_DelKhoa.Visible = false;
                bnt_EditKhoa.Visible = false;
                bnt_AddLop.Visible = false;
                bnt_DelLop.Visible = false;
                bnt_EditLop.Visible = false;
            }
            else
            {
                bnt_AddKhoa.Visible = true;
                bnt_DelKhoa.Visible = true;
                bnt_EditKhoa.Visible = true;
                bnt_AddLop.Visible = true;
                bnt_DelLop.Visible = true;
                bnt_EditLop.Visible = true;
            }
        }
        private void Load_Khoa()
        {
            conn.Open();
            string getKHOA = "SELECT MAKH AS N'Mã Khoa', TENKH AS N'Tên Khoa', MACS as N'Mã CS' FROM KHOA";
            view_KHOA = new DataTable();
            adapter = new SqlDataAdapter(getKHOA, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(view_KHOA);
            View_Khoa.DataSource = view_KHOA;
            conn.Close();
        }
        private void load_Lop()
        {
            conn.Open();
            string getLOP = "SELECT MALOP AS N'Mã lớp', TENLOP AS N'Tên lớp' FROM LOP WHERE MAKH='"+txb_MAKH.Text+"'";
            view_lop = new DataTable();
            adapter = new SqlDataAdapter(getLOP, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(view_lop);
            View_Lop.DataSource = view_lop;
            conn.Close();
        }
        private void View_Khoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            //Khoa
            bnt_AddKhoa.Enabled = false;
            bnt_DelKhoa.Enabled = true;
            bnt_EditKhoa.Enabled = true;
            //Lop
            bnt_AddLop.Enabled = true;
            bnt_DelLop.Enabled = false;
            bnt_EditLop.Enabled = false;
            if (indexRow < 0)
            {
                MessageBox.Show("Không thể sửa nội dung này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            else
            {
                DataGridViewRow row = View_Khoa.Rows[indexRow];
                txb_MAKH.Text = row.Cells[0].Value.ToString();
                txb_MACS.Text = row.Cells[2].Value.ToString();
                txb_TENKHOA.Text = row.Cells[1].Value.ToString();
                txb_MALOP.Text = "";
                txb_TENLOP.Text = "";
                load_Lop();
            }
        }

        private void View_Lop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            int index;
            index = e.RowIndex;
            //Khoa
            bnt_AddKhoa.Enabled = false;
            bnt_DelKhoa.Enabled = false;
            bnt_EditKhoa.Enabled = false;
            //Lop
            bnt_AddLop.Enabled = false;
            bnt_DelLop.Enabled = true;
            bnt_EditLop.Enabled = true;
            if (index < 0)
            {
                MessageBox.Show("Không thể sửa nội dung này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            else
            {
                DataGridViewRow row = View_Lop.Rows[index];
                txb_MALOP.Text = row.Cells[0].Value.ToString();
                txb_TENLOP.Text = row.Cells[1].Value.ToString();
                conn.Close();
            }
        }

        private void bnt_AddKhoa_Click(object sender, EventArgs e)
        {

            conn.Open();
            check_DBExit check_Khoa = new check_DBExit("MAKH", txb_MAKH.Text.Trim(), "KHOA");
            if (check_Khoa.check())
            {
                MessageBox.Show("Khoa đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                dataSrc = Login.server;
                conn = new SqlConnection(dataSrc);
                string addValue = "insert into KHOA (MAKH,TENKH,MACS) values ('"+txb_MAKH.Text+"','"+txb_TENKHOA.Text+"','"+txb_MACS.Text+"')";
                adapter = new SqlDataAdapter(addValue, conn);
                adapter.SelectCommand.ExecuteNonQuery();
                conn.Close();
                dataSrc = Login.datasSrc;
                Load_Khoa();
            }
        }

        private void bnt_AddLop_Click(object sender, EventArgs e)
        {
            conn.Open();
            check_DBExit check_Lop = new check_DBExit("MALOP", txb_MALOP.Text.Trim(), "LOP");
            if (check_Lop.check())
            {
                MessageBox.Show("Lớp đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (txb_MAKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khoa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                dataSrc = Login.server;
                conn = new SqlConnection(dataSrc);
                string addValue = "insert into LOP (MALOP,TENLOP,MAKH) values ('" +txb_MALOP.Text + "','" + txb_TENLOP.Text + "','" + txb_MAKH.Text + "')";
                adapter = new SqlDataAdapter(addValue, conn);
                adapter.SelectCommand.ExecuteNonQuery();
                conn.Close();
                dataSrc = Login.datasSrc;
                load_Lop();
            }
            txb_MALOP.Text = "";
            txb_TENLOP.Text = "";
        }

        private void bnt_DelKhoa_Click(object sender, EventArgs e)
        {
            check_DBExit check_Khoa = new check_DBExit("MAKH", txb_MAKH.Text.Trim(), "KHOA");
            if (txb_MAKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khoa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if(!check_Khoa.check())
            {
                MessageBox.Show("Khoa không tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                string delValue_Lop = "delete from LOP where MAKH='" + txb_MAKH.Text.Trim() + "'";
                string delValue_Khoa = "delete from KHOA where MAKH='" + txb_MAKH.Text.Trim() + "'";
                adapter = new SqlDataAdapter(delValue_Lop, conn);
                adapter.SelectCommand.ExecuteNonQuery();
                adapter = new SqlDataAdapter(delValue_Khoa, conn);
                adapter.SelectCommand.ExecuteNonQuery();
                conn.Close();
                Load_Khoa();
                load_Lop();
            }
        }

        private void bnt_DelLop_Click(object sender, EventArgs e)
        {
            check_DBExit check_Lop = new check_DBExit("MALOP", txb_MAKH.Text.Trim(), "LOP");
            if (txb_MAKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã lớp", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (!check_Lop.check())
            {
                MessageBox.Show("Lớp không tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                string delValue_Lop = "delete from LOP where MALOP='" + txb_MALOP.Text.Trim() + "'";
                adapter = new SqlDataAdapter(delValue_Lop, conn);
                adapter.SelectCommand.ExecuteNonQuery();
                conn.Close();
                load_Lop();
            }
        }

        private void bnt_EditKhoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updateVal = "update KHOA set TENKH='"+txb_TENKHOA.Text+"',MACS='"+txb_MACS.Text+"' where MAKH='"+txb_MAKH.Text+"'";
            adapter = new SqlDataAdapter(updateVal, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            conn.Close();
            Load_Khoa();
        }

        private void bnt_EditLop_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updateVal = "update LOP set TENLOP='" + txb_TENLOP.Text + "' where MALOP='" + txb_MALOP.Text + "'";
            adapter = new SqlDataAdapter(updateVal, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            conn.Close();
            load_Lop();
        }

        private void Input_Khoa_Lop_MouseClick(object sender, MouseEventArgs e)
        {
            //Khoa
            bnt_AddKhoa.Enabled = true;
            bnt_DelKhoa.Enabled = false;
            bnt_EditKhoa.Enabled = false;
            //Lop
            bnt_AddLop.Enabled = true;
            bnt_DelLop.Enabled = false;
            bnt_EditLop.Enabled = false;
        }
    }
}

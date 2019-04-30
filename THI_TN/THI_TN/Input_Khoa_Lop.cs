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
            }
            load_Lop();
        }

        private void bnt_Lop_Click(object sender, EventArgs e)
        {
            conn.Open();
            check_DBExit check_Lop = new check_DBExit("MALOP", txb_MALOP.Text.Trim(), "LOP");
            if (check_Lop.check())
            {
                MessageBox.Show("Lớp đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                string addValue = "";
            }
        }

        private void bnt_Khoa_Click(object sender, EventArgs e)
        {

        }

        private void View_Lop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            int index;
            index = e.RowIndex;
            if (index < 0)
            {
                MessageBox.Show("Không thể sửa nội dung này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            else
            {
                DataGridViewRow row = View_Lop.Rows[index];
                txb_MALOP.Text = row.Cells[0].Value.ToString();
                txb_TENLOP.Text = row.Cells[1].Value.ToString();
            }
            conn.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THI_TN
{
    
    public partial class Nhap_mon_hoc : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private int indexRow;

        public Nhap_mon_hoc()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-5BU4OJJ\CHRISTIAN;Initial Catalog=TRACNGHIEM;User ID=sa;Password=123456;MultipleActiveResultSets=True;Context Connection=False;ApplicationIntent=ReadWrite");
            load_DataGridView();
        }
        private void load_DataGridView()
        {
            conn.Open();
            DataTable dt = new DataTable();
            string getDt="SELECT MAMH AS N'Mã Môn', TENMH AS N'Tên Môn' FROM MONHOC";
            adapter = new SqlDataAdapter(getDt, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dt);
            View_MONHOC.DataSource=dt;
            conn.Close();
        } 
        private void bntAdd_Click(object sender, EventArgs e)
        {
            if (txb_MAMON.Text == "" || txb_TENMON.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                check_DBExit check = new check_DBExit("MAMH", txb_MAMON.Text, "MONHOC");
                if (check.check())
                {
                    MessageBox.Show("Môn học đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    conn.Open();
                    string addValue = "INSERT INTO MONHOC(MAMH,TENMH) VALUES ('" + txb_MAMON.Text.Trim() + "','" + txb_TENMON.Text.Trim() + "')";
                    adapter = new SqlDataAdapter(addValue, conn);
                    adapter.SelectCommand.ExecuteNonQuery();
                    txb_MAMON.Text = "";
                    txb_TENMON.Text = "";
                    conn.Close();
                    load_DataGridView();
                }
            }
        }

        private void View_MONHOC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            bntAdd.Enabled = false;
            bntEdit.Enabled = true;
            bntDel.Enabled = true;
            if (indexRow < 0)
            {
                MessageBox.Show("Không thể sửa nội dung này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow row = View_MONHOC.Rows[indexRow];
                txb_MAMON.Text = row.Cells[0].Value.ToString();
                txb_TENMON.Text = row.Cells[1].Value.ToString();
            }
        }

        private void Nhap_mon_hoc_Load(object sender, EventArgs e)
        {
            bntAdd.Enabled = true;
            bntDel.Enabled = false;
            bntEdit.Enabled = false;
        }

        private void Nhap_mon_hoc_Click(object sender, EventArgs e)
        {
            bntAdd.Enabled = true;
            bntDel.Enabled = false;
            bntEdit.Enabled = false;
        }

        private void bntDel_Click(object sender, EventArgs e)
        {
            conn.Open();
            string delValue = "DELETE FROM MONHOC WHERE MAMH='" + txb_MAMON.Text.Trim() + "'";
            adapter = new SqlDataAdapter(delValue, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            txb_MAMON.Text = "";
            txb_TENMON.Text = "";
            conn.Close();
            load_DataGridView();
        }

        private void bntEdit_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updateValue = "UPDATE MONHOC SET TENMH='"+txb_TENMON.Text.Trim()+"'WHERE MAMH='"+txb_MAMON.Text+"'";
            adapter = new SqlDataAdapter(updateValue, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            txb_MAMON.Text = "";
            txb_TENMON.Text = "";
            conn.Close();
            load_DataGridView();
        }
    }
}
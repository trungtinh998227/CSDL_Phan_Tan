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
    public partial class GV_Register : Form
    {
        private SqlDataAdapter adapter;
        private SqlConnection conn;
        string dataSrc;
        string getId ;
        public GV_Register()
        {
            this.dataSrc = Login.datasSrc;
            this.getId = Login.getID;
            conn = new SqlConnection(dataSrc);
            InitializeComponent();
        }
        private void load_cbLOP()
        {
            conn.Open();
            string loadCb = "select MALOP from LOP,GIAOVIEN where MAGV= '" + getId + "' and GIAOVIEN.MAKH=LOP.MAKH ";
            SqlDataReader r = new SqlCommand(loadCb, conn).ExecuteReader();
            while (r.Read())
            {
                cb_TENLOP.Items.Add(r.GetValue(0).ToString());
            }
            conn.Close();
        }
        private void load_cbMON()
        {
            conn.Open();
            string loadCb = "select distinct MONHOC.MAMH from MONHOC,BODE,GIAOVIEN where GIAOVIEN.MAGV=BODE.MAGV and BODE.MAMH=MONHOC.MAMH and GIAOVIEN.MAGV='" + getId + "'";
            SqlDataReader r = new SqlCommand(loadCb, conn).ExecuteReader();
            while (r.Read())
            {
                cb_TENMON.Items.Add(r.GetValue(0).ToString());
            }
            conn.Close();
        }
        private void load_cbLevel()
        {
            conn.Open();
            string loadCb = "select distinct TRINHDO from BODE where MAGV='" + getId + "'";
            SqlDataReader r = new SqlCommand(loadCb, conn).ExecuteReader();
            while (r.Read())
            {
                cb_TRINHDO.Items.Add(r.GetValue(0).ToString());
            }
            conn.Close();
        }
        private void GV_Register_Load(object sender, EventArgs e)
        {
            load_cbLOP();
            load_cbMON();
            load_cbLevel();
            view_DANGKY();
            bntAdd.Enabled = true;
            bnt_Del.Enabled = false;
            bnt_edit.Enabled = false;
            if (THI_TN.Menu.checks)
            {
                bntAdd.Visible = false;
                bnt_Del.Visible = false;
                bnt_edit.Visible = false;
            }
            else
            {
                bntAdd.Visible = true;
                bnt_Del.Visible = true;
                bnt_edit.Visible = true;
            }
        }
        private void view_DANGKY()
        {
            conn.Open();
            string loadView = "select MALOP as N'Mã Lớp',MAMH as N'Mã môn', TRINHDO as N'Trình độ', NGAYTHI as N'Ngày thi', LAN as N'Lần thi', SOCAUTHI as N'Số câu thi', THOIGIAN as N'Thời gian thi' from GIAOVIEN_DANGKY where MAGV='"+getId+"'";
            adapter = new SqlDataAdapter(loadView, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            View_DANGKY.DataSource = dt;
            conn.Close();
        }
        private void bntAdd_Click(object sender, EventArgs e)
        {
            dataSrc = Login.server;
            conn = new SqlConnection(dataSrc);
            if (Convert.ToInt16(txbTIME.Text)<15|| Convert.ToInt16(txbTIME.Text)>60)
            {
                MessageBox.Show("Thời gian phải nằm trong khoảng 15-60", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                string addValue = "insert into GIAOVIEN_DANGKY (MAGV,MAMH,MALOP,TRINHDO,NGAYTHI,LAN,SOCAUTHI,THOIGIAN) VALUES ('" + getId + "','" + cb_TENMON.Text.Trim().ToString() + "','" + cb_TENLOP.Text.Trim().ToString() + "','" + cb_TRINHDO.Text.Trim().ToString() + "','" + date_Picker.Value.Date + "','" + Convert.ToInt16(txb_LANTHI.Text) + "','" + Convert.ToInt16(txb_SOCAUTHI.Text) + "','" + Convert.ToInt16(txbTIME.Text) + "')";
                adapter = new SqlDataAdapter(addValue, conn);
                adapter.SelectCommand.ExecuteNonQuery();
                conn.Close();
                dataSrc = Login.datasSrc;
            }
            view_DANGKY();
        }

        private void bnt_Del_Click(object sender, EventArgs e)
        {
            conn.Open();
            string delValue = "delete from GIAOVIEN_DANGKY where MAMH='" +cb_TENMON.Text+ "'and MALOP='"+cb_TENLOP.Text.Trim()+"'and LAN='"+txb_LANTHI.Text+"'";
            adapter = new SqlDataAdapter(delValue, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            conn.Close();
            view_DANGKY();
        }

        private void bnt_edit_Click(object sender, EventArgs e)
        {
            conn.Open();
            try {
                    string editValue = "update GIAOVIEN_DANGKY set MAGV='"+getId+"', TRINHDO='" + cb_TRINHDO.Text.Trim() + "',NGAYTHI='" + date_Picker.Value.Date + "',SOCAUTHI='" + txb_SOCAUTHI.Text.Trim() + "',THOIGIAN='" + txbTIME.Text.Trim() + "' where MAMH='" + cb_TENMON.Text.Trim() + "' and MALOP='"+cb_TENLOP.Text.Trim()+"' and LAN='"+txb_LANTHI.Text+"'";
                    adapter = new SqlDataAdapter(editValue, conn);
                    adapter.SelectCommand.ExecuteNonQuery();
                         
            }catch (SqlException)
            {
                MessageBox.Show("Không thể đổi giá trị Mã môn, Mã lớp, Lần thi", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            conn.Close();
            view_DANGKY();
        }

        private void View_DANGKY_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bntAdd.Enabled = false;
            bnt_Del.Enabled = true;
            bnt_edit.Enabled = true;
            int indexRow = e.RowIndex;
            if (indexRow < 0)
            {
                MessageBox.Show("Không thể sửa nội dung này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow row = View_DANGKY.Rows[indexRow];
                cb_TENLOP.Text = row.Cells[0].Value.ToString();
                cb_TENMON.Text = row.Cells[1].Value.ToString();
                cb_TRINHDO.Text = row.Cells[2].Value.ToString();
                date_Picker.Value = Convert.ToDateTime(row.Cells[3].Value);
                txb_LANTHI.Text = row.Cells[4].Value.ToString();                
                txb_SOCAUTHI.Text = row.Cells[5].Value.ToString();
                txbTIME.Text= row.Cells[6].Value.ToString();
            }
        }

        private void GV_Register_Click(object sender, EventArgs e)
        {
            bntAdd.Enabled = true;
            bnt_Del.Enabled = false;
            bnt_edit.Enabled = false;
            cb_TENLOP.Text = "";
            cb_TENMON.Text = "";
            cb_TRINHDO.Text = "";
            txb_LANTHI.Text = "";
            txb_SOCAUTHI.Text = "";
            txbTIME.Text = "";
        }
    }
}

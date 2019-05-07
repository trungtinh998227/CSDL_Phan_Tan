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
    public partial class input_DeThi : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private string dataSrc = "";
        public input_DeThi()
        {
            this.dataSrc = Login.datasSrc;
            conn = new SqlConnection(dataSrc);
            InitializeComponent();
            load_CBMADE();
            load_BODE();
        }
        private void load_BODE()
        {
            conn.Open();
            string view_BODE = "Select CAUHOI as N'Câu hỏi', MAMH as N'Mã môn', TRINHDO as N'Trình độ', NOIDUNG as N'Nội dung',A,B,C,D, DAP_AN as 'Đáp Án' from BODE where MAMH='"+cb_MAMON.Text+"'";
            adapter = new SqlDataAdapter(view_BODE, conn);
            adapter.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            View_BODE.DataSource = dt;
            conn.Close();
        }
        private void load_CBMADE()
        {
            conn.Open();
            string getValues = "select distinct MAMH from BODE";
            SqlDataReader read = new SqlCommand(getValues, conn).ExecuteReader();
            while (read.Read())
            {
                cb_MAMON.Items.Add(read.GetValue(0).ToString());
            }
            conn.Close();
        }
        private void input_DeThi_Load(object sender, EventArgs e)
        {

        }

        private void cb_MAMON_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_BODE();
        }
    }
}

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
            string loadCb = "select TENLOP from LOP,GIAOVIEN where MAGV= '" + getId + "' and GIAOVIEN.MAKH=LOP.MAKH ";
            MessageBox.Show(loadCb, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            SqlDataReader r = new SqlCommand(loadCb, conn).ExecuteReader();
            while (r.Read())
            {
                cb_TENLOP.Items.Add(r.GetValue(0).ToString());
            }
            conn.Close();
        }
        private void GV_Register_Load(object sender, EventArgs e)
        {
            load_cbLOP();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace THI_TN
{
    public partial class Login : Form
    {
        private SqlConnection conn;
      
        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-5BU4OJJ\CHRISTIAN;Initial Catalog=TRACNGHIEM;User ID=sa;Password=123456;MultipleActiveResultSets=True;Context Connection=False;ApplicationIntent=ReadWrite");
            conn.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            String getCS = "SELECT TENCS FROM COSO";
            SqlDataReader read = new SqlCommand(getCS,conn).ExecuteReader();
            while (read.Read())
            {
                cb_COSO.Items.Add(read.GetValue(0).ToString());
            }
        }
    }
}

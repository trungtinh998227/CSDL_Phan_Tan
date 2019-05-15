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
using Microsoft.Win32;

namespace THI_TN
{
    public partial class Login : Form
    {
        private SqlConnection conn;
        public static string getID="";
        private string getPass = "";
        public static string datasSrc = "";
        private string serverName;
        public static string server = @"Data Source=DESKTOP-5BU4OJJ\CHRISTIAN;Initial Catalog=THI_TN;User ID=sa;Password=123456;Asynchronous Processing=False;ApplicationIntent=ReadWrite";
        public Login()
        {
            datasSrc = server;
            InitializeComponent();
            conn = new SqlConnection(datasSrc);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            conn.Open();
            string getcb_CS = "select TENCS from COSO";
            SqlDataReader read = new SqlCommand(getcb_CS, conn).ExecuteReader();
            while(read.Read())
            {
                cb_COSO.Items.Add(read.GetValue(0).ToString());
            }
            conn.Close();
        }

        private void bnt_Login_Click(object sender, EventArgs e)
        {
            getID = txbUser.Text.Trim().ToString();
            this.getPass = txbPass.Text.Trim();
            if (cb_COSO.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng chọn cơ sở", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if(!rd_SINHVIEN.Checked && !rd_NHANVIEN.Checked)
            {
                MessageBox.Show("Bạn là sinh viên hay nhân viên ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (cb_COSO.Text.Trim().Equals("CO SO 1"))
                {
                    serverName = "CHRISTIAN_1";
                    datasSrc = @"Data Source=DESKTOP-5BU4OJJ\" + serverName + ";Initial Catalog=THI_TN;User ID=" + getID + ";Password=" + getPass + ";Asynchronous Processing=False;ApplicationIntent=ReadWrite";
                    if (rd_SINHVIEN.Checked)
                    {
                        try
                        {
                            check_DBExit check = new check_DBExit("USERNAME", getID, "MEMBER");
                            if (check.check())
                            {
                                Menu mn = new Menu();
                                this.Hide();
                                mn.ShowDialog(this);
                                this.Show();
                            }
                        }                       
                        catch(SqlException)
                        {
                            MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        try
                        {
                            check_DBExit check = new check_DBExit("USERNAME", getID, "MEMBER");
                            if (check.check())
                            {
                                Menu mn = new Menu();
                                this.Hide();
                                mn.ShowDialog(this);
                                this.Show();
                            }
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    serverName = "CHRISTIAN_2";
                    datasSrc = @"Data Source=DESKTOP-5BU4OJJ\" + serverName + ";Initial Catalog=THI_TN;User ID=" + getID + ";Password=" + getPass + ";Asynchronous Processing=False;ApplicationIntent=ReadWrite";
                    if (rd_SINHVIEN.Checked)
                    {
                        try
                        {
                            check_DBExit check = new check_DBExit("USERNAME", getID, "MEMBER");
                            if (check.check())
                            {
                                Menu mn = new Menu();
                                this.Hide();
                                mn.ShowDialog(this);
                                this.Show();
                            }
                        }
                        catch(SqlException)
                        {
                            MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        try
                        {
                            check_DBExit check = new check_DBExit("USERNAME", getID, "MEMBER");
                            if (check.check())
                            {
                                Menu mn = new Menu();
                                this.Hide();
                                mn.ShowDialog(this);
                                this.Show();
                            }
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        private void bntCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

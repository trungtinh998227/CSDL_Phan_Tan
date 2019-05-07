﻿using System;
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
        public static string getID;
        public static string datasSrc = @"Data Source=DESKTOP-5BU4OJJ\CHRISTIAN;Initial Catalog=THI_TN;User ID=sa;Password=123456;Asynchronous Processing=False;ApplicationIntent=ReadWrite";
        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection(datasSrc);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            conn.Open();
            string getCS = "SELECT TENCS FROM COSO";
            SqlDataReader read = new SqlCommand(getCS,conn).ExecuteReader();
            while (read.Read())
            {
                cb_COSO.Items.Add(read.GetValue(0).ToString());
            }
            conn.Close();
        }

        private void bnt_Login_Click(object sender, EventArgs e)
        {
            getID = txbUser.Text.Trim();
            GV_Register fr = new GV_Register();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }
    }
}

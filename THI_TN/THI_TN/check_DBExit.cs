using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THI_TN
{
    class check_DBExit
    {
        private string primaryKey;
        private string tableName;
        private string valueKey;
        private SqlConnection conn;
        public check_DBExit(string primaryKey,string valueKey, string tableName)
        {
            this.primaryKey = primaryKey;
            this.tableName = tableName;
            this.valueKey = valueKey;
            conn = new SqlConnection(@"Data Source=DESKTOP-5BU4OJJ\CHRISTIAN;Initial Catalog=TRACNGHIEM;User ID=sa;Password=123456;MultipleActiveResultSets=True;Context Connection=False;ApplicationIntent=ReadWrite");
        }
        public Boolean check()
        {
            conn.Open();
            string getValues = "SELECT * FROM "+tableName+" WHERE "+primaryKey+"='"+valueKey+"'";
            SqlDataReader read = new SqlCommand(getValues, conn).ExecuteReader();
            while (read.Read())
            {
                return true;
            }
            return false;
        }
    }
}

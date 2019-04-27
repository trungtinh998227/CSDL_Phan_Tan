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
        string dataSrc;
        public check_DBExit(string primaryKey,string valueKey, string tableName)
        {
            this.primaryKey = primaryKey;
            this.tableName = tableName;
            this.valueKey = valueKey;
            dataSrc = Login.datasSrc;
            conn = new SqlConnection(dataSrc);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRACNGHIEM
{
    class Database
    {
        #region thuộc tính
        public static String database = "TRACNGHIEM";
        public static String SP_LOGIN = "LOGIN";
        public static String SP_GIANG_VIEN = "Giaovien";
        public static String SP_MON_HOC = "Monhoc";
        public static String SP_LOP = "Lop";
        public static String SP_SINH_VIEN = "Sinhvien";
        public static String SP_BO_DE = "BODE";
        public static String SP_GIAOVIEN_DANGKY = "Giaovien_Dangky";
        public static String SP_TAO_LOGIN = "TAO_LOGIN_GV";
        // các nhóm quyền của login
        public static int DENNY_ACCESS = 0; 
        public static int TRUONG_ACCESS = 1;
        public static int COSO_ACCESS = 2;
        public static int GIANGVIEN_ACCESS = 3;
        public static int SINHVIEN_ACCESS = 4;
        #endregion

       

        // khai báo 1 đối tượng kết nối đến CSDL
       // public static SqlConnection conn;      

        // phương thức kết nối đến CSDL cần 3 tham số: servername, loginname, password
        public static SqlConnection KetNoi(String servername, String loginname, String password)
        {
            SqlConnection conn;
            String connectionString = @"Data Source=" + servername + ";Initial Catalog=" + database + ";User ID=" + loginname + ";Password=" + password; 
            try
            {
                // tạo 1 kết nối đến CSDL thông qua chuỗi kết nối connectionString
                conn = new SqlConnection(connectionString);
                conn.Open(); // mở kết nối
                Program.connectionString = connectionString;
                Program.login = true;
            }
            catch (SqlException )
            {

                MessageBox.Show("Lỗi kết nối Server ? Tài khoản hoặc mật khẩu không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);   // hiển thị thông báo
                return null;
            }
            return conn;
        }      

        // phương thức kêt nối sau khi xác thực thông tin login
        public static SqlConnection KetNoiSauXacThuc()
        {
            
            try
            {
                Program.conn.ConnectionString = Program.connectionString;                
                Program.login = true;
            }
            catch (SqlException )
            {
                MessageBox.Show("Kết nối đến server thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return Program.conn;
        }

        // phương thức xác thực loginname thuộc người dùng nào: sinh viên hay giáo viên
        public static int XacThuc(String servername, String loginname, String password)
        {
            SqlConnection conn = new SqlConnection(); // khởi tạo đối tượng conn 
            conn = KetNoi(servername, loginname, password); // mở kết nối
           
            if (Program.login == true)
            {
                // bước 1: tạo 1 đối tượng giữ lệnh cần thực thi
                SqlCommand cmd = new SqlCommand("SP_LOGIN", conn);
                // xác định kiểu truy vấn
                cmd.CommandType = CommandType.StoredProcedure;

                // bước 2: tạo 1 đối tượng SqlParameter để định nghĩa cho parameter của câu SQL
                // mỗi SqlParameter chỉ định nghĩa cho 1 tham số trong command SQL
                SqlParameter para = new SqlParameter();
                para.ParameterName = "@TENLOGIN";
                para.Value = loginname;
                // bước 3: gán parameter vào SqlCommand
                cmd.Parameters.Add(para);
                
                var role = cmd.Parameters.Add("@PER", SqlDbType.Int);
                role.Direction = ParameterDirection.ReturnValue;  // trả về giá trị trong Store Procedure            
                //SqlDataReader reader = cmd.ExecuteReader(); // thực thi command SQL
                cmd.ExecuteNonQuery();
                conn.Close();
                int role_1 = Int32.Parse(role.Value.ToString());

                if (role_1 == 0)
                {
                    Program.connectionString = ""; // nếu như role_1 = 0 <=> nghĩa là tài khoản không tồn tại ==> cập nhật lại chuỗi kết nối
                }
                else 
                {
                    return role_1;
                }
            }
            return 0; // kết nối không thành công
        }

        public static SqlDataReader ExecSqlDataReader(String cmd)
        {
            SqlDataReader myreader;
            //Program.conn = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = Program.conn;
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed)
            {
                Program.conn.Open();
            }
            try
            {
                myreader = sqlcmd.ExecuteReader(); 
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }            
        }

        public static SqlDataReader ExecSqlDataReader_1(String cmd)
        {
            SqlDataReader myreader;
            //Program.conn = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = Program.conn;
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (Program.conn.State == ConnectionState.Closed)
            {
                Program.conn.Open();
            }
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}

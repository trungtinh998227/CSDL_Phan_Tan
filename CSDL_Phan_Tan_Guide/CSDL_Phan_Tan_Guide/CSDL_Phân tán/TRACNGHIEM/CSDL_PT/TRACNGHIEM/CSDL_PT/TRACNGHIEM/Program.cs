using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data.SqlClient;

namespace TRACNGHIEM
{
    static class Program
    {                         
        public static String servername = "";
        public static String username = "";
        public static String password = "";
        public static String passwordDN = "";
        public static String database = "TRACNGHIEM";
        public static String mlogin = "";
        public static String mloginDN = "";
        public static String mGroup = "";
        public static String mHoten = "";
        public static int mCoSo = 0;
        public static int mRet;
        public static string support_user = "HTKN";
        public static string support_pass = "123456";
        public static String connectionString;
        public static SqlConnection conn = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();
        public static bool login = false; // mặc định là kết nối chưa thành công



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new frmDangNhap());
        }

        // phương thức có tác dụng lưu lại thông tin loginname, password, servername sau khi đăng nhập thành công ==> cần dùng sau này
        public static void SuXacThuc(String _servername, String _loginname, String _password) 
        {
            servername = _servername;
            mlogin = _loginname;
            password = _password;       
        }
    }
}

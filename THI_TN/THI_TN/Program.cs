﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THI_TN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Nhap_mon_hoc());
            //Application.Run(new Input_Khoa_Lop());
            //Application.Run(new Input_SinhVien());
            //Application.Run(new Input_GiaoVien());
            //Application.Run(new input_DeThi());
            //Application.Run(new GV_Register());
            Application.Run(new Login());
        }
    }
}

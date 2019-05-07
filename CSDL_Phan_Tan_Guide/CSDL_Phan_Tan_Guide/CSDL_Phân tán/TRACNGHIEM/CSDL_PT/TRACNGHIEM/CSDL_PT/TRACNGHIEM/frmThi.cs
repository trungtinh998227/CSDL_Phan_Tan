using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRACNGHIEM
{
    public partial class frmThi : Form
    {
        private static int phut, giay;
        private static bool kt_ngay = false;
        private ArrayList dapan = new ArrayList(); // danh sách chứa đáp án lấy từ bài thi 
        private ArrayList ketqua = new ArrayList(); // danh sách chứa các câu trả lời của sinh viên
        private int vitri = 1; // thứ tự câu hỏi  
        private static char cautraloi = 'N'; // mặc định là chưa trả lời No
        public frmThi()
        {
            InitializeComponent();
            //Program.connectionString = @"Data Source=THIENTAM\THIENTAM_1;Initial Catalog=TRACNGHIEM;User ID=001;Password=123456";
            this.cbxlanthi.Enabled = false;
            //this.fillToolStrip.Hide();
            this.grbsinhvien.Enabled = false;
            this.LayThongTinSinhVien();
            this.btnthi.Enabled = false;
            this.grbthoigianthi.Hide();
            this.grbbangthi.Hide();
            //====
            //this.groupBox3.Hide();
            this.sp_Select_QuestionGridControl.Hide();
            this.fillToolStrip.Hide();
           
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.sp_Select_QuestionTableAdapter.Fill(this.tRACNGHIEMDataSet1.sp_Select_Question, new System.Nullable<int>(((int)(System.Convert.ChangeType(sOCAUTHIToolStripTextBox.Text, typeof(int))))), tRINHDOToolStripTextBox.Text, mAMHToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void frmThi_Load(object sender, EventArgs e)
        {
            
        }

        // phương thức lấy tất cả các mã môn học mà sẽ thi của ngày được chọn
        public void LayMaMonThi()
        {

            kt_ngay = false; // đang lựa chọn ngày thi khác
            try
            {
              
                if (Program.conn.State == ConnectionState.Closed)
                {
                    Database.KetNoiSauXacThuc().Open();

                }
                String strLenh = "dbo.sp_LayMaMonThi";
                Program.cmd = Program.conn.CreateCommand();
                Program.cmd.CommandType = CommandType.StoredProcedure;
                Program.cmd.CommandText = strLenh;
                Program.cmd.Parameters.Add("@NGAY_THI", SqlDbType.DateTime).Value = this.datengaythi.SelectedText;
                Program.cmd.Parameters.Add("@MA_LOP", SqlDbType.VarChar).Value = this.txbmalop.Text.ToString().Trim();

                SqlDataReader myReader;
                myReader = Program.cmd.ExecuteReader();



                while (myReader.Read() == true)
                {
                    kt_ngay = true; // ngày thi đang chọn có môn sẽ thi
                    this.cbxmonthi.Items.Add(myReader.GetString(0)); // lấy mã môn học 
                    this.cbxlanthi.Items.Add(myReader.GetInt16(1)); // lấy lần thi                   
                }
                myReader.Close();
                Program.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datengaythi_EditValueChanged(object sender, EventArgs e)
        {
            this.cbxmonthi.Items.Clear();
            this.cbxlanthi.Items.Clear();

            this.LayMaMonThi();
            if (kt_ngay == true)
            {
                this.cbxmonthi.SelectedIndex = 0;
                this.cbxlanthi.SelectedIndex = 0;
                this.btnthi.Enabled = true;
            }
            else
            {
                this.cbxmonthi.Items.Add("");
                this.cbxmonthi.SelectedIndex = 0;
                this.cbxlanthi.Items.Add("");
                this.cbxlanthi.SelectedIndex = 0;
                this.btnthi.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cbxmonthi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kt_ngay == true)
            {
                this.cbxlanthi.SelectedIndex = this.cbxmonthi.SelectedIndex;
            }
            else
            {
                this.cbxmonthi.Items.Clear();
                this.cbxlanthi.Items.Clear();
            }
        }

        // lấy thông tin sinh viên
        public void LayThongTinSinhVien()
        {

            
            try
            {
                
                if (Program.conn.State == ConnectionState.Closed)
                {
                    Database.KetNoiSauXacThuc().Open();

                }
                String strLenh = "dbo.sp_LayMaLop_TenLopSV";
                Program.cmd = Program.conn.CreateCommand();
                Program.cmd.CommandType = CommandType.StoredProcedure;
                Program.cmd.CommandText = strLenh;
                Program.cmd.Parameters.Add("@MASV", SqlDbType.VarChar).Value = Program.username;
                Program.cmd.Parameters.Add("@MA_LOP", SqlDbType.VarChar, 8).Direction = ParameterDirection.Output; // lệnh trả về giá trị của sp
                Program.cmd.Parameters.Add("@TEN_LOP", SqlDbType.VarChar, 40).Direction = ParameterDirection.Output; // lệnh trả về giá trị của sp               
                Program.cmd.ExecuteNonQuery();
                Program.conn.Close();

                this.txbmalop.Text = Program.cmd.Parameters["@MA_LOP"].Value.ToString(); // sp sẽ trả về giá trị                    
                this.txbtenlop.Text = Program.cmd.Parameters["@TEN_LOP"].Value.ToString(); // sp sẽ trả về giá trị                                    
                this.txbhoten.Text = Program.mHoten;
                this.txbmasv.Text = Program.username;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Program.mGroup == "SINHVIEN")
            {
                try
                {

                    if (Program.conn.State == ConnectionState.Closed)
                    {
                        Database.KetNoiSauXacThuc().Open();

                    }
                    String strLenh = "dbo.sp_KiemTraSinhVienThi";
                    Program.cmd = Program.conn.CreateCommand();
                    Program.cmd.CommandType = CommandType.StoredProcedure;
                    Program.cmd.CommandText = strLenh;
                    Program.cmd.Parameters.Add("@MASV", SqlDbType.VarChar).Value = this.txbmasv.Text;
                    Program.cmd.Parameters.Add("@MAMH", SqlDbType.VarChar).Value = this.cbxmonthi.SelectedItem.ToString();
                    Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = Int16.Parse(this.cbxlanthi.SelectedItem.ToString());
                    Program.cmd.Parameters.Add("@Ret", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue; // lệnh trả về giá trị của sp
                    Program.cmd.ExecuteNonQuery();
                    Program.conn.Close();
                    string Ret = Program.cmd.Parameters["@Ret"].Value.ToString(); // sp sẽ trả về giá trị                    
                    if (Ret == "1")
                    {
                        MessageBox.Show("Sinh viên không thuộc đợt thi này ! Xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {

                            if (Program.conn.State == ConnectionState.Closed)
                            {
                                Database.KetNoiSauXacThuc().Open();

                            }
                            String strLenh_1 = "dbo.sp_LayThongTinThi";
                            Program.cmd = Program.conn.CreateCommand();
                            Program.cmd.CommandType = CommandType.StoredProcedure;
                            Program.cmd.CommandText = strLenh_1;
                            Program.cmd.Parameters.Add("@MAMH", SqlDbType.VarChar).Value = this.cbxmonthi.SelectedItem.ToString();
                            Program.cmd.Parameters.Add("@MALOP", SqlDbType.VarChar).Value = this.txbmalop.Text.ToString();
                            Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = Int16.Parse(this.cbxlanthi.SelectedItem.ToString());
                            Program.cmd.Parameters.Add("@SOCAUTHI", SqlDbType.SmallInt).Direction = ParameterDirection.Output; // lệnh trả về giá trị của sp
                            Program.cmd.Parameters.Add("@TRINHDO", SqlDbType.Char, 1).Direction = ParameterDirection.Output; // lệnh trả về giá trị của sp
                            Program.cmd.Parameters.Add("@THOIGIAN", SqlDbType.SmallInt).Direction = ParameterDirection.Output; // lệnh trả về giá trị của sp
                            Program.cmd.ExecuteNonQuery();
                            Program.conn.Close();

                            string socauthi = Program.cmd.Parameters["@SOCAUTHI"].Value.ToString(); // sp sẽ trả về giá trị                    
                            string trinhdo = Program.cmd.Parameters["@TRINHDO"].Value.ToString(); // sp sẽ trả về giá trị                                    
                            string thoigian = Program.cmd.Parameters["@THOIGIAN"].Value.ToString(); // sp sẽ trả về giá trị                                                    
                            //MessageBox.Show(socauthi + "," + trinhdo + "," + this.txbmalop.Text.ToString() + "," + thoigian);
                            this.sOCAUTHIToolStripTextBox.Text = socauthi;
                            this.tRINHDOToolStripTextBox.Text = trinhdo;
                            this.mAMHToolStripTextBox.Text = this.cbxmonthi.SelectedItem.ToString();

                            this.fillToolStripButton.PerformClick(); // tự động click vào fill trên form
                            // hiển thị nội dung câu thi và đáp án
                            this.lblcauhoi.Text = "Câu hỏi: " + vitri;
                            this.txb_nd.Text = nOIDUNGTextEdit.Text;
                            this.lbl_a.Text = aTextEdit.Text;
                            this.lbl_b.Text = bTextEdit.Text;
                            this.lbl_c.Text = cTextEdit.Text;
                            this.lbl_d.Text = dTextEdit.Text;

                            // lấy ra số câu thi của bài thi
                            int n = Int32.Parse(this.sOCAUTHIToolStripTextBox.Text);
                            // BƯỚC 1. lấy tất cả các đáp án thi từ sp_Select_Question trong đăng kí thi
                            for (int i = 0; i < n; i++)
                            {
                                dapan.Add(dAP_ANTextEdit.Text.ToString()); // lấy từng đáp án bỏ vào mảng đáp án
                                ketqua.Add('N'); // mặc định tất cả các câu trả lời của sinh viên đều là 0 <=> câu hỏi đó chưa có câu trả lời
                                this.sp_Select_QuestionBindingSource.MoveNext(); // dịch chuyển sang câu hỏi kế tiếp trong gridview từ sp kéo vào
                            }

                            this.sp_Select_QuestionBindingSource.MoveFirst();


                            // lấy thời gian thi đưa vào timer
                            phut = Int32.Parse(thoigian);
                            giay = 0;
                            this.grbthoigianthi.Enabled = true;
                            this.grbbangthi.Enabled = true;
                            timer1.Start();
                            if (vitri == 1)
                            {
                                this.btnpre.Enabled = false;
                            }

                            this.grbthoigianthi.Show();
                            this.grbbangthi.Show();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi hệ thống ! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex_1)
                {
                    MessageBox.Show("Lỗi hệ thống ! " + ex_1.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                try
                {

                    if (Program.conn.State == ConnectionState.Closed)
                    {
                        Database.KetNoiSauXacThuc().Open();

                    }
                    String strLenh_1 = "dbo.sp_LayThongTinThi";
                    Program.cmd = Program.conn.CreateCommand();
                    Program.cmd.CommandType = CommandType.StoredProcedure;
                    Program.cmd.CommandText = strLenh_1;
                    Program.cmd.Parameters.Add("@MAMH", SqlDbType.VarChar).Value = this.cbxmonthi.SelectedItem.ToString();
                    Program.cmd.Parameters.Add("@MALOP", SqlDbType.VarChar).Value = this.txbmalop.Text.ToString();
                    Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = Int16.Parse(this.cbxlanthi.SelectedItem.ToString());
                    Program.cmd.Parameters.Add("@SOCAUTHI", SqlDbType.SmallInt).Direction = ParameterDirection.Output; // lệnh trả về giá trị của sp
                    Program.cmd.Parameters.Add("@TRINHDO", SqlDbType.Char, 1).Direction = ParameterDirection.Output; // lệnh trả về giá trị của sp
                    Program.cmd.Parameters.Add("@THOIGIAN", SqlDbType.SmallInt).Direction = ParameterDirection.Output; // lệnh trả về giá trị của sp
                    Program.cmd.ExecuteNonQuery();
                    Program.conn.Close();

                    string socauthi = Program.cmd.Parameters["@SOCAUTHI"].Value.ToString(); // sp sẽ trả về giá trị                    
                    string trinhdo = Program.cmd.Parameters["@TRINHDO"].Value.ToString(); // sp sẽ trả về giá trị                                    
                    string thoigian = Program.cmd.Parameters["@THOIGIAN"].Value.ToString(); // sp sẽ trả về giá trị                                                    
                    //MessageBox.Show(socauthi + "," + trinhdo + "," + this.txbmalop.Text.ToString() + "," + thoigian);
                    this.sOCAUTHIToolStripTextBox.Text = socauthi;
                    this.tRINHDOToolStripTextBox.Text = trinhdo;
                    this.mAMHToolStripTextBox.Text = this.cbxmonthi.SelectedItem.ToString();

                    this.fillToolStripButton.PerformClick(); // tự động click vào fill trên form
                    // hiển thị nội dung câu thi và đáp án
                    this.lblcauhoi.Text = "Câu hỏi: " + vitri;
                    this.txb_nd.Text = nOIDUNGTextEdit.Text;
                    this.lbl_a.Text = aTextEdit.Text;
                    this.lbl_b.Text = bTextEdit.Text;
                    this.lbl_c.Text = cTextEdit.Text;
                    this.lbl_d.Text = dTextEdit.Text;

                    // lấy ra số câu thi của bài thi
                    int n = Int32.Parse(this.sOCAUTHIToolStripTextBox.Text);
                    // BƯỚC 1. lấy tất cả các đáp án thi từ sp_Select_Question trong đăng kí thi
                    for (int i = 0; i < n; i++)
                    {
                        dapan.Add(dAP_ANTextEdit.Text.ToString()); // lấy từng đáp án bỏ vào mảng đáp án
                        ketqua.Add('N'); // mặc định tất cả các câu trả lời của sinh viên đều là 0 <=> câu hỏi đó chưa có câu trả lời
                        this.sp_Select_QuestionBindingSource.MoveNext(); // dịch chuyển sang câu hỏi kế tiếp trong gridview từ sp kéo vào
                    }

                    this.sp_Select_QuestionBindingSource.MoveFirst();


                    // lấy thời gian thi đưa vào timer
                    phut = Int32.Parse(thoigian);
                    giay = 0;
                    this.grbthoigianthi.Enabled = true;
                    this.grbbangthi.Enabled = true;
                    timer1.Start();
                    if (vitri == 1)
                    {
                        this.btnpre.Enabled = false;
                    }

                    this.grbthoigianthi.Show();
                    this.grbbangthi.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống ! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           

        }


        // phương thức xử lí các radiobutton câu trả lời
        void XuLiRadioButton(bool KT)
        {
            this.rdba.Checked = this.rdbb.Checked = this.rdbc.Checked = this.rdbd.Checked = KT;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (phut >= 0)
            {
                if (giay <= 0)
                {
                    giay = 59;
                    phut--;
                }
                else
                {
                    giay--;
                }

                if (giay < 10)
                {

                    this.lblgiay.Text = "0" + giay.ToString();
                }
                else
                {
                    this.lblgiay.Text = giay.ToString();


                }
                if (phut < 10)
                {
                    this.lblphut.Text = "0" + phut.ToString();
                }
                else
                {
                    this.lblphut.Text = phut.ToString();
                }


            }
            else
            {
                timer1.Stop();
                Tinh_Ghi_Diem();
                this.grbthoigianthi.Hide();
                this.grbbangthi.Hide();
                this.btnthi.Enabled = false;
                MessageBox.Show("Kết thúc phần thi ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sp_Select_QuestionGridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            ketqua[vitri - 1] = cautraloi;
            this.btnpre.Enabled = true;
            XuLiRadioButton(false);
            if ((vitri + 1) == Int32.Parse(sOCAUTHIToolStripTextBox.Text))
            {
                this.btnnext.Enabled = false;
            }
            this.sp_Select_QuestionBindingSource.MoveNext();

            cautraloi = 'N';
            if (ketqua[vitri].Equals('N'))
            {
                XuLiRadioButton(false);
                //    ctrloi = 'E';
            }
            else
            {
                if (ketqua[vitri].Equals('A'))
                {
                    this.rdba.Checked = true;
                }
                else if (ketqua[vitri].Equals('B'))
                {
                    this.rdbb.Checked = true;
                }
                else if (ketqua[vitri].Equals('C'))
                {
                    this.rdbc.Checked = true;
                }
                else if (ketqua[vitri].Equals('D'))
                {
                    this.rdbd.Checked = true;
                }
            }

            if (vitri < Int32.Parse(sOCAUTHIToolStripTextBox.Text))
            {
                vitri++;
            }

            // hiển thị nội dung câu thi và đáp án
            this.lblcauhoi.Text = "Câu hỏi: " + vitri;
            this.txb_nd.Text = nOIDUNGTextEdit.Text;
            this.lbl_a.Text = aTextEdit.Text;
            this.lbl_b.Text = bTextEdit.Text;
            this.lbl_c.Text = cTextEdit.Text;
            this.lbl_d.Text = dTextEdit.Text;
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            ketqua[vitri - 1] = cautraloi;
            this.btnnext.Enabled = true;
            XuLiRadioButton(false);
            this.sp_Select_QuestionBindingSource.MovePrevious();

            cautraloi = 'N';
            if (vitri > 1)
            {
                vitri--;
            }
            if (vitri == 1)
            {
                this.btnpre.Enabled = false;
            }
            int temp = vitri - 1;
            if (ketqua[temp].Equals('N'))
            {
                XuLiRadioButton(false);
                

            }
            else
            {
                if (ketqua[temp].Equals('A'))
                {
                    this.rdba.Checked = true;
                }
                else if (ketqua[temp].Equals('B'))
                {
                    this.rdbb.Checked = true;
                }
                else if (ketqua[temp].Equals('C'))
                {
                    this.rdbc.Checked = true;
                }
                else if (ketqua[temp].Equals('D'))
                {
                    this.rdbd.Checked = true;
                }
            }

            // hiển thị nội dung câu thi và đáp án
            this.lblcauhoi.Text = "Câu hỏi: " + vitri;
            this.txb_nd.Text = nOIDUNGTextEdit.Text;
            this.lbl_a.Text = aTextEdit.Text;
            this.lbl_b.Text = bTextEdit.Text;
            this.lbl_c.Text = cTextEdit.Text;
            this.lbl_d.Text = dTextEdit.Text;
        }

        private void rdba_CheckedChanged(object sender, EventArgs e)
        {
            cautraloi = 'A';
        }

        private void rdbb_CheckedChanged(object sender, EventArgs e)
        {
            cautraloi = 'B';
        }

        private void rdbc_CheckedChanged(object sender, EventArgs e)
        {
            cautraloi = 'C';
        }

        private void rdbd_CheckedChanged(object sender, EventArgs e)
        {
            cautraloi = 'D';
        }

        private void btnketthuc_Click(object sender, EventArgs e)
        {

            Tinh_Ghi_Diem();

            this.grbthoigianthi.Hide();
            this.grbbangthi.Hide();
            this.btnthi.Enabled = false;
        }
        // phương thức tính và ghi điểm vào database
        private void Tinh_Ghi_Diem()
        {
            // tính điểm bài thi 
            string baithi = null;
            ketqua[vitri - 1] = cautraloi;
            int count = 0;
            double diemf = 10.0 / (Int32.Parse(sOCAUTHIToolStripTextBox.Text));
            for (int j = 0; j < Int32.Parse(sOCAUTHIToolStripTextBox.Text); j++)
            {
                baithi += "cau: " + (j + 1) + ",da chon: " + ketqua[j] + ",dap an: " + dapan[j] + " | ";
                if (ketqua[j].ToString().Equals(dapan[j].ToString()))
                {
                    count++;
                }
            }
            double Diem = count * diemf;
            float diem = (float)(Diem);
            MessageBox.Show("Kết quả: " + count + " câu đúng ,\nĐiểm bài thi: " + diem, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Program.mGroup == "SINHVIEN")
            {                
                try
                {

                    if (Program.conn.State == ConnectionState.Closed)
                    {
                        Database.KetNoiSauXacThuc().Open();
                    }

                    String strLenh = "dbo.sp_GhiDiemSinhVien";
                    Program.cmd = Program.conn.CreateCommand();
                    Program.cmd.CommandType = CommandType.StoredProcedure;
                    Program.cmd.CommandText = strLenh;
                    Program.cmd.Parameters.Add("@MASV", SqlDbType.VarChar).Value = Program.username;
                    Program.cmd.Parameters.Add("@MAMH", SqlDbType.VarChar).Value = this.cbxmonthi.Text;
                    Program.cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = this.cbxlanthi.Text;
                    Program.cmd.Parameters.Add("@NGAYTHI", SqlDbType.DateTime).Value = this.datengaythi.Text;
                    Program.cmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = diem;
                    Program.cmd.Parameters.Add("@BAITHI", SqlDbType.NText).Value = baithi;
                    Program.cmd.Parameters.Add("@Ret", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue;
                    Program.cmd.ExecuteNonQuery();
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Thongbao");
                }        
            }
            
        }
    }
}

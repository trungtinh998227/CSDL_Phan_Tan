using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace TRACNGHIEM
{
    public partial class dexfrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static int role;
              
        public dexfrmMain()
        {    
            InitializeComponent();
            this.tsshoten.Text = "Họ tên: " + Program.mHoten;
            this.tssgroup.Text = "Nhóm quyền: " + Program.mGroup;
            this.tssuser.Text = "Username: " + Program.username;
        }        
        private void dexfrmMain_Load(object sender, EventArgs e)
        {
            if(Program.mGroup == "GIANGVIEN")
            {
                this.ribquanli.Visible = false;
                this.ribsinhvien.Visible = false;
                this.ribbaocao.Visible = false;
            }
            else if(Program.mGroup == "SINHVIEN")
            {
                this.ribquanli.Visible = false;
                this.ribgiangvien.Visible = false;
                this.ribbaocao.Visible = false;
            }
            else if(Program.mGroup == "TRUONG")
            {
                this.btnlop.Enabled = false;
                this.btnkhoa.Enabled = false;
                this.btngiangvien.Enabled = false;
                this.btnsinhvien.Enabled = false;
                this.btnmonhoc.Enabled = false;
                this.btnbangdiem.Enabled = false;
                this.ribsinhvien.Visible = false;
                this.ribbaocao.Visible = true;
                this.ribgiangvien.Visible = false;
            }
            
        }

        // kiểm tra xem form hiện tại tồn tại hay chưa - nghĩa là có mở lên lần nào hay chưa
        private Form KiemTraTonTai(Type ftype)
        {
            foreach(Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }

        private void btnmonhoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmNhapMonHoc));
            if(frm != null)
            {               
                frm.Activate();
            }
            else
            {              
                frmNhapMonHoc f = new frmNhapMonHoc();
                f.MdiParent = this;                
                f.Show();
            }
        }

        private void btnkhoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmNhapKhoa));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhapKhoa f = new frmNhapKhoa();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnlop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmNhapLop));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhapLop f = new frmNhapLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btngiangvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmNhapGiaoVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhapGiaoVien f = new frmNhapGiaoVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnsinhvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmNhapSinhVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhapSinhVien f = new frmNhapSinhVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btntaotaikhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmTaoLogin));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmTaoLogin f = new frmTaoLogin();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnthoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnbatdauthi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmThi));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmThi f = new frmThi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnbangdiem_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btncauhoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmNhapBoDe));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhapBoDe f = new frmNhapBoDe();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btndangkidethi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmGiaoVienDangKi));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmGiaoVienDangKi f = new frmGiaoVienDangKi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(ketqua));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                ketqua f = new ketqua();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void btnthithu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmThi));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmThi f = new frmThi();
                f.MdiParent = this;
                f.Show();
            }
        }
             
          
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRACNGHIEM
{
    public partial class frmNhapKhoa : Form
    {
        public frmNhapKhoa()
        {
            InitializeComponent();           
            this.tENKHTextEdit.Enabled = false;
            this.mAKHTextEdit.Enabled = false;
            this.mACSTextEdit.Enabled = false;
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kHOABindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tRACNGHIEMDataSet);

        }

        private void frmNhapKhoa_Load(object sender, EventArgs e)
        {
            this.kHOATableAdapter.Connection.ConnectionString = Program.connectionString;
            // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Fill(this.tRACNGHIEMDataSet.KHOA);

        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            this.kHOABindingSource.MoveFirst();
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            this.kHOABindingSource.MovePrevious();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            this.kHOABindingSource.MoveNext();
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            this.kHOABindingSource.MoveLast();
        }

        private void txbtimkiem_TextChanged(object sender, EventArgs e)
        {
            this.kHOABindingSource.Filter = "MAKH LIKE '%" + this.txbtimkiem.Text + "%'" + " OR TENKH LIKE '%" + this.txbtimkiem.Text + "%'";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

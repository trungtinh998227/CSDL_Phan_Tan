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
    public partial class frmNhapLop : Form
    {
        public frmNhapLop()
        {
            InitializeComponent();           
            this.mALOPTextEdit.Enabled = false;
            this.tENLOPTextEdit.Enabled = false;
            this.mAKHTextEdit.Enabled = false;
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOPBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tRACNGHIEMDataSet);

        }

        private void frmNhapLop_Load(object sender, EventArgs e)
        {
            this.lOPTableAdapter.Connection.ConnectionString = Program.connectionString;
            // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.tRACNGHIEMDataSet.LOP);

        }

        private void txbtimkiem_TextChanged(object sender, EventArgs e)
        {
            this.lOPBindingSource.Filter = "MALOP LIKE '%" + this.txbtimkiem.Text + "%'" + " OR TENLOP LIKE '%" + this.txbtimkiem.Text + "%'";
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            this.lOPBindingSource.MoveFirst();
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            this.lOPBindingSource.MovePrevious();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            this.lOPBindingSource.MoveNext();
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            this.lOPBindingSource.MoveLast();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

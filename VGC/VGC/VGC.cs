using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VGC
{
    public partial class VGC : Form
    {
        public VGC()
        {
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas frm = new frmVentas();
            frm.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            btnActualizar frm = new btnActualizar();
            frm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpDeskApplication
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnSolicitudes_Paint(object sender, PaintEventArgs e)
        {
   
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            frmCrearSolicitud FCrearColicitud = new frmCrearSolicitud();

            FCrearColicitud.MdiParent = this;

            FCrearColicitud.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSolicitudesPendientes FSolicitudesPendientes = new frmSolicitudesPendientes();
            FSolicitudesPendientes.MdiParent = this;

            FSolicitudesPendientes.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            frmMenuSecundario FMenuSecundario = new frmMenuSecundario();

            FMenuSecundario.MdiParent = this;

            FMenuSecundario.Show();

        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

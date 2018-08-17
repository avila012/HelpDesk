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

        public string Usuario { get; set; }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            tstrNombreUsuario.Text = Usuario.ToUpper();
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
            OpenedForm(new frmCrearSolicitud());
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenedForm(new frmSolicitudesPendientes());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            OpenedForm(new frmMenuSecundario());
        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void OpenedForm(Form frm)
        {
            if (Application.OpenForms[frm.Name] == null)
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            tstrFechaHora.Text = DateTime.Now.ToString();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

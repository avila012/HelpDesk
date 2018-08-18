using HelpDeskDB;
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
    public partial class frmCrearSolicitud : Form
    {
        public frmCrearSolicitud()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmCrearSolicitud_Load(object sender, EventArgs e)
        {
            try
            {
                HelpDeskDBEntities HDEntities = new HelpDeskDBEntities();

                cbDepartamentos.DataSource = HDEntities.Departamentos.ToList();
                cbDepartamentos.ValueMember = "codigo";
                cbDepartamentos.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

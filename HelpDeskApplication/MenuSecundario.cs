using System;
using HelpDeskDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpDeskApplication
{
    public partial class frmMenuSecundario : Form
    {
        public frmMenuSecundario()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmMenuSecundario_Load(object sender, EventArgs e)
        {
            HelpDeskDBEntities HDEntities = new HelpDeskDBEntities();

            if (HDEntities.Persona.Any())
            {
                txtCodigo.Text = HDEntities.Persona.FirstOrDefault().codigo.ToString();
                txtNombre.Text = HDEntities.Persona.FirstOrDefault().Nombre.ToString();
                txtCodigo.Text = HDEntities.Persona.FirstOrDefault().codigo.ToString();
                txtCodigo.Text = HDEntities.Persona.FirstOrDefault().codigo.ToString();

            }

            dataGridView1.DataSource = HDEntities.Persona.ToList();
        }
    }
}

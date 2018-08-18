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
                txtSolicitante.Text = VariablesComunes.NombrePersona;

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

        private void btnGuardarCS_Click(object sender, EventArgs e)
        {
            HelpDeskDBEntities HDEntities = new HelpDeskDBEntities();
            //procedemos a realizar la insersion   
            var solicitudes = new Solicitud()
            {

                codSolicitante = Convert.ToInt32(VariablesComunes.CodigoPersona),
                //deptoDestino = Convert.ToInt32(cbDepartamentos.SelectedText),
                deptoDestino = Convert.ToInt32(cbDepartamentos.SelectedValue),
                fechaCreacion = DateTime.Now,
                detalleSolicitud = rtxtDetalleSolicitud.Text,
                codAsignado = 0,
                fechaCierre = new DateTime(2999, 12, 31),
                estadoSolicitud = 5
            };


            HDEntities.Solicitud.Add(solicitudes);

            HDEntities.SaveChanges();

            MessageBox.Show("Su solicitud ha sido agregada correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelpDeskDB;

namespace HelpDeskApplication
{
    public partial class frmSolicitudesPendientes : Form
    {
        public frmSolicitudesPendientes()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSolicitudesPendientes_Load(object sender, EventArgs e)
        {
            HelpDeskDBEntities Entidad = new HelpDeskDBEntities();

            var solicitud = (from sol in Entidad.solicitudes_vista
                             select new { sol.Solicitud, sol.Departamento, sol.Solicitante, sol.Creacion, sol.Detalle, sol.Estado }).ToList();

            dataGridView1.DataSource = solicitud;
        }
    }
}

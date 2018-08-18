using System;
using HelpDeskDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace HelpDeskApplication
{
    public partial class frmMenuSecundario : Form
    {
        public frmMenuSecundario()
        {
            InitializeComponent();
        }

       public enum Tabs
        {
            Usuario,
            Departamento,
            Estado
        }

        public enum Accion
        {
            Insertar,
            Eliminar,
            Actualizar
        }

        public Tabs TabActual { get; set; }
        public Accion SqlAccion { get; set; }

        private async void frmMenuSecundario_Load(object sender, EventArgs e)
        {
            try
            {
                HelpDeskDBEntities HDEntities = new HelpDeskDBEntities();

                var vLoad = (from tbl in HDEntities.Persona select new { tbl.codigo, tbl.Nombre, tbl.Apellido, usuario = tbl.Usuarios.FirstOrDefault().Usuario, departamento = tbl.Departamentos.Nombre, tbl.Estados.Estado });
                dgvUsuarios.DataSource = vLoad.ToList();

                var loadDepartament = (from tbl in HDEntities.Departamentos select new { tbl.codigo, tbl.Nombre }).ToList();
                dgvDeparmento.DataSource = loadDepartament;

                var loadEstados = (from tbl in HDEntities.Estados select new { tbl.codigo, tbl.Estado }).ToList();
                dgvEstados.DataSource = loadEstados;

                cbNivel.DataSource = (from tbl in HDEntities.Perfiles select new { tbl.Codigo, tbl.Descripcion }).ToList(); ;
                cbNivel.ValueMember = "codigo";
                cbNivel.DisplayMember = "Descripcion";

                cbDepartamento.DataSource = HDEntities.Departamentos.ToList();
                cbDepartamento.ValueMember = "codigo";
                cbDepartamento.DisplayMember = "nombre";

                cbEstado.DataSource = (from tbl in HDEntities.Estados select new { tbl.codigo, tbl.Estado }).ToList();
                cbEstado.ValueMember = "codigo";
                cbEstado.DisplayMember = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                txtNombre.Text = dgvUsuarios.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtApellido.Text = dgvUsuarios.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
            }
        }

        private void cbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDepartamento.Items.Count > 0)
            {
                int lol = Convert.ToInt16(cbDepartamento.SelectedValue);
            }
        }
        
        private void sbtnNuevo_Click(object sender, EventArgs e)
        {
            sbtnEditar.Enabled = false;
            sbtnNuevo.Enabled = false;
            sbtnGuardar.Enabled = true;
            sbtnCancelar.Enabled = true;
            SqlAccion = Accion.Insertar;
        }

        private async void sbtnGuardar_Click(object sender, EventArgs e)
        {
            HelpDeskDBEntities HDEntities = new HelpDeskDBEntities();

            switch (TabActual)
            {
                case Tabs.Usuario:

                    switch (SqlAccion)
                    {
                        case Accion.Insertar:

                            Usuarios user = new Usuarios()
                            {
                                Usuario = txtUsuario.Text,
                                Pass = txtPassword.Text,
                                estado = Convert.ToInt32(cbEstado.SelectedValue)
                            };

                            Persona per = new Persona()
                            {
                                Nombre = txtNombre.Text,
                                Apellido = txtApellido.Text,
                                Departamento = Convert.ToInt32(cbDepartamento.SelectedValue),
                                Estado = Convert.ToInt32(cbEstado.SelectedValue),
                            };

                            HDEntities.Usuarios.Add(user);
                            HDEntities.Persona.Add(per);

                            await HDEntities.SaveChangesAsync();

                            break;

                        case Accion.Eliminar:

                            int cod = Convert.ToInt16(txtCodigo.Text);
                            var person = HDEntities.Persona.SingleOrDefault(x => x.codigo == cod);

                            HDEntities.Persona.Remove(person);

                            await HDEntities.SaveChangesAsync();

                            break;

                        case Accion.Actualizar:

                            int codigo = Convert.ToInt16(txtCodigo.Text);
                            var persona = HDEntities.Persona.SingleOrDefault(x => x.codigo == codigo);
                            persona.Nombre = txtNombre.Text;
                            persona.Apellido = txtApellido.Text;
                            persona.Departamento = Convert.ToInt32(cbDepartamento.SelectedValue);
                            persona.Estado = Convert.ToInt32(cbEstado.SelectedValue);

                            await HDEntities.SaveChangesAsync();

                            break;
                    }

                    var vLoad = (from tbl in HDEntities.Persona select new { tbl.codigo, tbl.Nombre, tbl.Apellido, departamento = tbl.Departamentos.Nombre, tbl.Estados.Estado });
                    dgvUsuarios.DataSource = vLoad.ToList();

                    break;

                case Tabs.Departamento:

                    break;

                case Tabs.Estado:

                    break;
            }

            sbtnEditar.Enabled = true;
            sbtnNuevo.Enabled = true;
            sbtnGuardar.Enabled = false;
            sbtnCancelar.Enabled = false;
            dgvUsuarios.Enabled = false;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Text == "Usuarios")
            {
                TabActual = Tabs.Usuario;
            }
            if (e.TabPage.Text == "Estados")
            {
                TabActual = Tabs.Estado;
            }
            if (e.TabPage.Text == "Departamentos")
            {
                TabActual = Tabs.Departamento;
            }
        }

        private void sbtnCancelar_Click(object sender, EventArgs e)
        {
            sbtnEditar.Enabled = true;
            sbtnNuevo.Enabled = true;
            sbtnGuardar.Enabled = false;
            sbtnCancelar.Enabled = false;
            dgvUsuarios.Enabled = false;
        }

        private void sbtnEditar_Click(object sender, EventArgs e)
        {
            sbtnEditar.Enabled = false;
            sbtnNuevo.Enabled = false;
            sbtnGuardar.Enabled = true;
            sbtnCancelar.Enabled = true;

            SqlAccion = Accion.Actualizar;

            dgvUsuarios.Enabled = true;
        }
    }
}

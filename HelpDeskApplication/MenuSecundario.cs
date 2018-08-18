using System;
using HelpDeskDB;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
            Actualizar,
            Cancelar
        }

        public Tabs TabActual { get; set; }
        public Accion SqlAccion { get; set; }

        private void frmMenuSecundario_Load(object sender, EventArgs e)
        {
            try
            {
                HelpDeskDBEntities HDEntities = new HelpDeskDBEntities();

                var vLoad = (from tbl in HDEntities.Persona
                             join user in HDEntities.Usuarios on tbl.codigo equals user.CodPersona
                             join depto in HDEntities.Departamentos on tbl.Departamento equals depto.codigo
                             join esta in HDEntities.Estados on tbl.Estado equals esta.codigo
                             select new { tbl.codigo, tbl.Nombre, tbl.Apellido, usuario = user.Usuario, departamento = depto.Nombre, esta.Estado});
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
                txtUsuario.Text = (dgvUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value == null) ? " " : dgvUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
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
                    }

                    var vLoad = (from tbl in HDEntities.Persona
                                 join user in HDEntities.Usuarios on tbl.codigo equals user.CodPersona
                                 join depto in HDEntities.Departamentos on tbl.Departamento equals depto.codigo
                                 join esta in HDEntities.Estados on tbl.Estado equals esta.codigo
                                 select new { tbl.codigo, tbl.Nombre, tbl.Apellido, usuario = user.Usuario, departamento = depto.Nombre, esta.Estado });

                    dgvUsuarios.DataSource = vLoad.ToList();

                    break;

                case Tabs.Departamento:

                    switch (SqlAccion)
                    {
                        case Accion.Insertar:

                            var depto = new Departamentos()
                            {
                                Nombre = textBox1.Text,
                            };

                            HDEntities.Departamentos.Add(depto);

                            await HDEntities.SaveChangesAsync();

                            break;
                    }

                    var deptoLoad = (from tbl in HDEntities.Departamentos select new { tbl.codigo, tbl.Nombre });
                    dgvUsuarios.DataSource = deptoLoad.ToList();


                    break;

                case Tabs.Estado:

                    
                    switch (SqlAccion)
                    {
                        case Accion.Insertar:

                            var estado = new Estados()
                            {
                                Estado = txtEstados.Text,
                            };

                            HDEntities.Estados.Add(estado);

                            await HDEntities.SaveChangesAsync();

                            break;                      
                    }

                    var deptoLoadGuardar = (from tbl in HDEntities.Departamentos select new { tbl.codigo, tbl.Nombre });
                    dgvUsuarios.DataSource = deptoLoadGuardar.ToList();


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
            dgvUsuarios.Enabled = true;
        }

        private void sbtnEditar_Click(object sender, EventArgs e)
        {
            sbtnEditar.Enabled = false;
            sbtnNuevo.Enabled = false;
            sbtnGuardar.Enabled = true;
            sbtnCancelar.Enabled = true;

            SqlAccion = Accion.Actualizar;

           // dgvUsuarios.Enabled = true;
        }

        private  void toolStripButton1_Click(object sender, EventArgs e)
        {
            HelpDeskDBEntities HDEntities = new HelpDeskDBEntities();

            SqlAccion = Accion.Eliminar;

            switch (TabActual)
            {
                case Tabs.Usuario:

                    switch (SqlAccion)
                    {
                        case Accion.Eliminar:

                              int cod = Convert.ToInt16(dgvUsuarios.CurrentRow.Cells[0].Value);
                              var person = HDEntities.Persona.FirstOrDefault(x => x.codigo == cod);

                              HDEntities.Persona.Remove(person);
                              

                            HDEntities.SaveChanges();

                            break;
                    }

                    var vLoad = (from tbl in HDEntities.Persona
                                 join user in HDEntities.Usuarios on tbl.codigo equals user.CodPersona
                                 join depto in HDEntities.Departamentos on tbl.Departamento equals depto.codigo
                                 join esta in HDEntities.Estados on tbl.Estado equals esta.codigo
                                 select new { tbl.codigo, tbl.Nombre, tbl.Apellido, usuario = user.Usuario, departamento = depto.Nombre, esta.Estado });
                    dgvUsuarios.DataSource = vLoad.ToList();

                    MessageBox.Show("El Registro solicitado fue eliminado", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case Tabs.Departamento:

                    switch (SqlAccion)
                    {
                        case Accion.Eliminar:

                            int cod = Convert.ToInt16(dgvDeparmento.CurrentRow.Cells[0].Value);
                            var deptoEliminar = HDEntities.Departamentos.SingleOrDefault(x => x.codigo == cod);
                            HDEntities.Departamentos.Remove(deptoEliminar);
                            HDEntities.SaveChanges();

                            break;
                    }

                    var deptoLoad = (from tbl in HDEntities.Departamentos select new { tbl.codigo, tbl.Nombre });
                    dgvDeparmento.DataSource = deptoLoad.ToList();


                    break;

                case Tabs.Estado:

                    switch (SqlAccion)
                    {
                        case Accion.Eliminar:

                            int cod = Convert.ToInt16(dgvEstados.CurrentRow.Cells[0].Value);
                            var estadosEliminar = HDEntities.Estados.SingleOrDefault(x => x.codigo == cod);
                            HDEntities.Estados.Remove(estadosEliminar);
                            HDEntities.SaveChanges();

                            break;
                    }

                    var estadoLoad = (from tbl in HDEntities.Estados select new { tbl.codigo, tbl.Estado });
                    dgvEstados.DataSource = estadoLoad.ToList();

                    break;

            }

            sbtnEditar.Enabled = true;
            sbtnNuevo.Enabled = true;
            sbtnGuardar.Enabled = false;
            sbtnCancelar.Enabled = false;
            dgvUsuarios.Enabled = true;
        }
    }
}

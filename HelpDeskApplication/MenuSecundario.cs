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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void frmMenuSecundario_Load(object sender, EventArgs e)
        {
            try
            {
               var vLoad = await load();
                dataGridView1.DataSource = vLoad;

                cbDepartamento.DataSource = await loadDepartamentos();
                cbDepartamento.ValueMember = "codigo";
                cbDepartamento.DisplayMember = "nombre";

                //HelpDeskDBEntities HDEntities = new HelpDeskDBEntities();

                //if (HDEntities.Persona.Any())
                //{
                //    txtCodigo.Text = HDEntities.Persona.FirstOrDefault().codigo.ToString();
                //    txtNombre.Text = HDEntities.Persona.FirstOrDefault().Nombre.ToString();
                //    txtCodigo.Text = HDEntities.Persona.FirstOrDefault().codigo.ToString();
                //    txtCodigo.Text = HDEntities.Persona.FirstOrDefault().codigo.ToString();

                //}

                dataGridView1.DataSource = await load();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private async Task<DataTable> load()
        {
            try
            {
                DataTable nombre = new DataTable();

                using (var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    await conex.OpenAsync();

                    using (var cmd = conex.CreateCommand())
                    {
                        cmd.CommandText = "select * from persona;";
                        cmd.CommandType = CommandType.Text;

                        var reader = await cmd.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            nombre.Load(reader);
                        }

                        return nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<DataTable> loadDepartamentos()
        {
            try
            {
                DataTable nombre = new DataTable();

                using (var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    await conex.OpenAsync();

                    using (var cmd = conex.CreateCommand())
                    {
                        cmd.CommandText = "select codigo, nombre from Departamentos;";
                        cmd.CommandType = CommandType.Text;

                        var reader = await cmd.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            nombre.Load(reader);
                        }

                        return nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                txtNombre.Text = dataGridView1.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtApellido.Text = dataGridView1.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
            }
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private async void sbtnGuardar_Click(object sender, EventArgs e)
        {
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

                            HelpDeskDBEntities hd = new HelpDeskDBEntities();
                            hd.Usuarios.Add(user);
                            hd.Persona.Add(per);

                            await hd.SaveChangesAsync();

                            break;

                        case Accion.Eliminar:
                            break;

                        case Accion.Actualizar:
                            break;
                    }
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
        }

        private void sbtnEditar_Click(object sender, EventArgs e)
        {
            sbtnEditar.Enabled = false;
            sbtnNuevo.Enabled = false;
            sbtnGuardar.Enabled = true;
            sbtnCancelar.Enabled = true;
            SqlAccion = Accion.Actualizar;
        }
    }
}

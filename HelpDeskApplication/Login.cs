using System;
using HelpDeskDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace HelpDeskApplication
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                if (await Login(txtUsuario.Text,txtPass.Text))
                {
                    frmMenuPrincipal MenuPrincipal = new frmMenuPrincipal();
                    MenuPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrecto", "Mensaje Revision", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                }
            }
            catch (Exception errM)
            {

                MessageBox.Show("Se ha presentado un error: " + errM.Message, "Erro no Manejado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Metodo para iniciar sesion en la aplicacion
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<bool> Login(string usuario, string password)
        {
            using (var conex = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                await conex.OpenAsync();

                using (var cmd = conex.CreateCommand())
                {
                    cmd.CommandText = "prValidaUsuario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    cmd.Parameters.Add("@result", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    await cmd.ExecuteNonQueryAsync();

                    var result = Convert.ToBoolean(cmd.Parameters["@result"].Value);
                    return result;
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}


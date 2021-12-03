using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace InfEq
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (database.sw_actualizado == false)
            {
                if (database.sw_actualizado_error == true)
                {
                    MessageBox.Show("No puedes iniciar sesión porque no hay conexión a internet.\nReinicia el programa para volver a realizar la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("¡No puedes iniciar sesión porque existe una nueva version del programa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Close();
                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Boolean conexionlogin = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    String sql = "SELECT * FROM " + database.tablausuarios + " WHERE Nombre='" + @user.Text + "' AND Password ='" + database.EncriptarPass(database.EncriptarPass(pass.Text)) + "'";
                    SqlCommand comm = new SqlCommand(sql, conexion);
                    SqlDataReader nwReader;
                    nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        conexionlogin = true;
                        /*
                        if (nwReader["version"].ToString() != database.versioninfeq)
                        {
                            MessageBox.Show("Hola " + nwReader["NombreCompleto"] + ", no puedes usar esta funcion debido a que tu aplicacion no esta actualizada.\n\nVersion actual: " + nwReader["version"] + "\nVersion usada: " + database.versioninfeq, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                            break;
                        }
                        */
                        if (nwReader["Estatus"].ToString() == "B")
                        {
                            MessageBox.Show("Hola " + nwReader["NombreCompleto"] + ".\nNo puedes acceder ya que tu usuario esta desactivado.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            break;
                        }
                        database.logueado = true;
                        database.userlogin = nwReader["NombreCompleto"].ToString();
                        database.useruid = (int)nwReader["uid"];
                        if (database.ventanalogin == 1)
                        {
                            if ((int)nwReader["Privilegios"] == 1)
                            {
                                database.privilegios = true;
                            }
                            Buscar Buscar = new Buscar();
                            Buscar.Show();
                        }
                        if (database.ventanalogin == 2)
                        {
                            if ((int)nwReader["Privilegios"] == 1)
                            {
                                database.privilegios = true;
                            }
                            MessageBox.Show("Bienvenido " + nwReader["NombreCompleto"] + ".\nVuelve a intentar cargar la información.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (database.ventanalogin == 3)
                        {
                            if ((int)nwReader["Privilegios"] == 1)
                            {
                                database.privilegios = true;
                            }
                            MessageBox.Show("Bienvenido " + nwReader["NombreCompleto"] + ".", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (database.ventanalogin == 0)
                        {
                            if ((int)nwReader["Privilegios"] == 1)
                            {
                                database.privilegios = true;
                                Usuario usuario = new Usuario();
                                usuario.Show();
                            }
                            else
                            {
                                MessageBox.Show("Bienvenido " + nwReader["NombreCompleto"], "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        this.Close();
                    }
                    if (!conexionlogin)
                    {
                        MessageBox.Show("Error en usuario o contraseña.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión.\n\nMensaje: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void User_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }
    }
}

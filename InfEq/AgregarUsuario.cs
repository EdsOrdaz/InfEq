using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfEq
{
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //String nombresqlexpress = "server=" + servidor + "; database=" + basededatos + " ; integrated security = true ; MultipleActiveResultSets=True";
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    string sqlIns = "INSERT INTO " + database.tablausuarios + " (Nombre, Password, Privilegios, NombreCompleto, Estatus, Version)" +
                            " VALUES (@user, @pass, @privilegios, @nombre, @estatus, @version)";
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conexion);

                    cmdIns.Parameters.Add("@user", usuario.Text);
                    cmdIns.Parameters.Add("@pass", database.EncriptarPass(database.EncriptarPass(password.Text)));
                    cmdIns.Parameters.Add("@privilegios", 1);
                    cmdIns.Parameters.Add("@nombre", nombre.Text);
                    cmdIns.Parameters.Add("@estatus", "A");
                    cmdIns.Parameters.Add("@version", database.versioninfeq);
                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();
                    cmdIns.CommandText = "SELECT @@IDENTITY";
                    cmdIns.ExecuteScalar();

                    cmdIns.Dispose();
                    cmdIns = null;
                    MessageBox.Show("Usuario creado correctamente.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información. \n\nMensaje: " + ex.Message, "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}

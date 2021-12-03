using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InfEq
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }


        private void Inicio_Load(object sender, EventArgs e)
        {
            if(database.pruebas == true)
            {
                MessageBox.Show("Esta activado el ambiente de pruebas.\n\nTodos los cambios " +
                    "se guardan en la DB del equipo local.", "Ambiente de pruebas activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*
            Console.WriteLine(database.EncriptarPass(database.EncriptarPass("edy")));
            */
            this.TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;
            this.Opacity = 0.1;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.045;
            }
            else
            {
                timer1.Stop();

                try
                {
                    using (SqlConnection conexion2 = new SqlConnection(database.nombresqlexpress))
                    {
                        conexion2.Open();
                        String sql2 = "SELECT * FROM "+database.view_configuracion;
                        SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                        SqlDataReader nwReader2 = comm2.ExecuteReader();
                        if (nwReader2.Read())
                        {
                            if (nwReader2["hash"].ToString() != database.versioninfeq_hash)
                            {
                                MessageBox.Show("Debes actualizar la aplicacion para almacenar los datos.\n\nNueva Version: " + nwReader2["version"].ToString() + "\nVersion actual: " + database.versioninfeq+"\n\nEl programa continuara sin acceso a internet.", "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                database.sw_actualizado = false;
                            }
                            else
                            {
                                //cargar datos de configuracion
                                database.view_conf_correo_af = nwReader2["correo_af"].ToString();
                                database.view_conf_correo_ti = nwReader2["correo_ti"].ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puedo verificar la version del programa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            database.sw_actualizado = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    database.sw_actualizado = false;
                    database.sw_actualizado_error = true;
                    MessageBox.Show("Error en validar la version del programa\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Orden orden = new Orden();
                orden.Show();
                this.Hide();
            }
        }
    }
}

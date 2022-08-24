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
    public partial class EditarUsuario : Form
    {
        public EditarUsuario()
        {
            InitializeComponent();
        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    String sql = "SELECT * FROM " + database.tablausuarios + " WHERE uid='" + Listausuarios.UID + "'";
                    SqlCommand comm = new SqlCommand(sql, conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        uid.Text = nwReader["uid"].ToString();
                        usuario.Text = nwReader["Nombre"].ToString();
                        nombre.Text = nwReader["NombreCompleto"].ToString();
                        //password.Text = nwReader["Password"].ToString();

                        if((int)nwReader["Privilegios"]==1)
                        {
                            privilegios.SelectedIndex = 0;
                        }
                        else if((int)nwReader["Privilegios"]==2)
                        {
                            privilegios.SelectedIndex = 1;
                        }
                        else
                        {
                            privilegios.SelectedIndex = 2;
                        }

                        estatus.SelectedIndex = (nwReader["Estatus"].ToString() == "A") ? 0 : 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexion a la base de datos.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Listausuarios);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                Listausuarios listausuarios = new Listausuarios();
                listausuarios.Show();
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    string ingpass = "";
                    if(!string.IsNullOrEmpty(password.Text))
                    {
                        ingpass = "Password=@pass,";
                    }
                    string sqlIns = "UPDATE " + database.tablausuarios + " SET Nombre=@usuario,"+ ingpass + "NombreCompleto=@nombre,Privilegios=@privilegios,Estatus=@estatus WHERE UID=@uid";
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conexion);

                    String Estatus = (estatus.Text == "Activo") ? "A" : "B";
                    //No permite desactivar Administrador de sistema
                    Estatus = (uid.Text == "1") ? "A" : Estatus;

                    if(Convert.ToInt32(uid.Text) == database.useruid && Estatus == "B")
                    {
                        MessageBox.Show("No puedes desactivar tu usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int Privilegios = 0;
                    if (privilegios.Text == "Administrador")
                    {
                        Privilegios = 1;
                    }
                    else if (privilegios.Text == "Usuario")
                    {
                        Privilegios = 2;
                    }
                    else
                    {
                        Privilegios = 3;
                    }

                    //No quitar Permisos a Administrador de sistema
                    Privilegios = (uid.Text == "1") ? 1 : Privilegios;

                    cmdIns.Parameters.Add("@uid", Convert.ToInt32(uid.Text));
                    cmdIns.Parameters.Add("@usuario", usuario.Text);
                    cmdIns.Parameters.Add("@nombre", nombre.Text);
                    cmdIns.Parameters.Add("@pass", database.EncriptarPass(database.EncriptarPass(password.Text)));
                    cmdIns.Parameters.Add("@privilegios", Privilegios);
                    cmdIns.Parameters.Add("@estatus", Estatus);

                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();
                    cmdIns.CommandText = "SELECT @@IDENTITY";

                    cmdIns.Dispose();
                    cmdIns = null;

                    Listausuarios listausuarios = new Listausuarios();
                    listausuarios.Show();

                    if (Convert.ToInt32(uid.Text) == database.useruid && Privilegios == 2)
                    {
                        MessageBox.Show("Se cerrara la aplicación para guardar cambios.", "Actualizando Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    MessageBox.Show("Usuario Actualizado", "Editar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información. \n\nMensaje: " + ex.Message, "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
    public partial class Listausuarios : Form
    {
        public static int UID = 0;
        public Listausuarios()
        {
            InitializeComponent();
        }

        private void Listausuarios_Load(object sender, EventArgs e)
        {
            usuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            usuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;
            usuarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(usuarios.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);


            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    String sql = "SELECT * FROM " + database.tablausuarios;
                    SqlCommand comm = new SqlCommand(sql, conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    int celda = 0;
                    String Privilegios = "";
                    String Estatus = "";
                    while (nwReader.Read())
                    {
                        Privilegios = (Convert.ToInt32(nwReader["privilegios"]) == 1) ? "Administrador" : "Usuario";
                        Estatus = (nwReader["estatus"].ToString() == "A") ? "Activo" : "Desactivado";
                        usuarios.Rows.Add(nwReader["uid"], nwReader["Nombre"], nwReader["NombreCompleto"], Privilegios, Estatus);
                        if (nwReader["estatus"].ToString() == "B")
                        {
                            usuarios.Rows[celda].DefaultCellStyle.BackColor = Color.Silver;
                        }
                        celda++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en conexion con la base de datos.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.usuarios.Columns["id"].Index && e.RowIndex != -1)
            {
                UID = (int)usuarios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                EditarUsuario editarusuario = new EditarUsuario();
                editarusuario.Show();
                this.Close();
            }
        }
    }
}

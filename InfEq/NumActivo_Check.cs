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
    public partial class NumActivo_Check : Form
    {
        public static String no_activo = "";
        public static Boolean Click;
        public NumActivo_Check()
        {
            InitializeComponent();
        }

        private void NumActivo_Check_Load(object sender, EventArgs e)
        {
            Click = false;
            no_activo = "";
            activo.Text = "";
            label1.Text = "";
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(database.nsqlExSirac))
                {
                    conexion2.Open();
                    String sql2 = "SELECT * FROM [bd_SiRAc].[dbo].[LNJ_Equipos_Gilberto] where [No. Serie]='" + Buscar.NoSerie + "'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        no_activo = nwReader2["No. Activo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la busqueda\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            label1.Text = no_activo;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String num = (string.IsNullOrEmpty(activo.Text)) ? "S/N" : activo.Text;
            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    string sqlIns = "UPDATE " + database.tablabase + " SET noactivo=@NumActivo WHERE XID=@xid";
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conexion);
                    cmdIns.Parameters.Add("@xid", database.MAC_XID);
                    cmdIns.Parameters.Add("@NumActivo", num);
                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();
                    cmdIns.CommandText = "SELECT @@IDENTITY";

                    cmdIns.Dispose();
                    cmdIns = null;
                    MessageBox.Show("Número Economico actualizado", "Num de Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    no_activo = num;
                    Click = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información. \n\nMensaje: " + ex.Message, "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Activo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void GroupBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            activo.Text = no_activo;
        }

        private void Label1_MouseClick(object sender, MouseEventArgs e)
        {
            activo.Text = no_activo;
        }
    }
}

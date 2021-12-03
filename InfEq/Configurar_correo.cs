using javax.xml.crypto;
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
    public partial class Configurar_correo : Form
    {
        public Configurar_correo()
        {
            InitializeComponent();
        }

        private void Configurar_correo_Load(object sender, EventArgs e)
        {
            correoaf.Text = database.view_conf_correo_af;
            correoti.Text = database.view_conf_correo_ti;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    string sqlIns = "UPDATE "+database.tablaconfiguracion+" SET valor=@correoaf WHERE nombre='InfEq_correo_activos'";
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conexion);

                    cmdIns.Parameters.Add("@correoaf", correoaf.Text);

                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();
                    cmdIns.Dispose();
                    cmdIns = null;

                    string sqlIns_ti = "UPDATE "+database.tablaconfiguracion+ " SET valor=@correoti WHERE nombre='InfEq_correo_cc_ti'";
                    SqlCommand cmdIns_ti = new SqlCommand(sqlIns_ti, conexion);

                    cmdIns_ti.Parameters.Add("@correoti", correoti.Text);
                    cmdIns_ti.ExecuteNonQuery();
                    cmdIns_ti.Parameters.Clear();
                    cmdIns_ti.Dispose();
                    cmdIns_ti = null;

                    database.view_conf_correo_ti = correoti.Text;
                    database.view_conf_correo_af = correoaf.Text;

                    MessageBox.Show("Correos actualizados", "Editar Correos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

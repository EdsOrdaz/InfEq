using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfEq
{
    public partial class CargandoEmpleados : Form
    {
        public CargandoEmpleados()
        {
            InitializeComponent();
        }

        private void CargandoEmpleados_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;

            if(backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Buscar_Correo.conexionsql))
                {
                    conexion.Open();
                    SqlCommand comm = new SqlCommand(Buscar_Correo.select, conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        String[] n = new String[9];
                        n[0] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nwReader["nombre"].ToString().ToLower());
                        n[1] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nwReader["paterno"].ToString().ToLower());
                        n[2] = (string.IsNullOrEmpty(nwReader["materno"].ToString())) ? "" : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nwReader["materno"].ToString().ToLower());
                        n[3] = n[0] + " " + n[1] + " " + n[2];
                        char nom = n[0][0];
                        String id;
                        if (string.IsNullOrEmpty(nwReader["materno"].ToString()))
                        {
                            id = nom.ToString() + n[1];
                        }
                        else
                        {
                            char a = n[2][0];
                            id = nom.ToString() + n[1] + a.ToString();
                        }
                        n[4] = id.ToLower();
                        n[5] = n[3].ToUpper();
                        n[6] = nwReader["email"].ToString();
                        n[7] = nwReader["ubicacion"].ToString();
                        n[8] = nwReader["cc"].ToString();
                        Buscar_Correo.empleados.Add(n);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error en la busqueda en nomina\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}

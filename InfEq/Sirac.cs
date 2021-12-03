using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace InfEq
{
    public partial class Sirac : Form
    {
        public Sirac()
        {
            InitializeComponent();
        }

        List<String[]> listasirac = new List<String[]>();
        Prueba pp = new Prueba();
        private void Buscardetalle_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                buscar.Enabled = false;
                regresar.Enabled = false;
                equipos.Rows.Clear();
                listasirac.Clear();
                progressBar1.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        #region PRESS ENTER
        private void Numerodeactivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar.PerformClick();
            }
        }

        private void Marca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar.PerformClick();
            }
        }

        private void Modelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar.PerformClick();
            }
        }

        private void Serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar.PerformClick();
            }
        }

        private void Nomusuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar.PerformClick();
            }
        }

        private void Ubicacion1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar.PerformClick();
            }
        }

        private void Pedcompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar.PerformClick();
            }
        }

        private void Empres1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar.PerformClick();
            }
        }
        #endregion

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sirac_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(5);
            String cadena = "";
            String whereand = "";
            String numactivo = (String.IsNullOrEmpty(numerodeactivo.Text.Trim())) ? "" : "WHERE [g].[No. Activo] LIKE '%" + numerodeactivo.Text.Trim() + "%'";
            cadena = numactivo;

            whereand = (String.IsNullOrEmpty(numactivo)) ? " WHERE " : " AND ";
            String marc = (String.IsNullOrEmpty(marca.Text.Trim())) ? "" : whereand + "[g].[marca] LIKE '%" + marca.Text.Trim() + "%'";
            cadena += marc;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String model = (String.IsNullOrEmpty(modelo.Text.Trim())) ? "" : whereand + "[g].[modelo] LIKE '%" + modelo.Text.Trim() + "%'";
            cadena += model;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String numserie = (String.IsNullOrEmpty(serialnumber.Text.Trim())) ? "" : whereand + "[g].[No. Serie] LIKE '%" + serialnumber.Text.Trim() + "%'";
            cadena += numserie;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String nombrusuario = (String.IsNullOrEmpty(nomusuario.Text.Trim())) ? "" : whereand + "[g].[Nombre de Resguardatario] LIKE '%" + nomusuario.Text.Trim() + "%'";
            cadena += nombrusuario;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String ubicacion = (String.IsNullOrEmpty(ubicacion1.Text.Trim())) ? "" : whereand + "[g].[Ubicación] LIKE '%" + ubicacion1.Text.Trim() + "%'";
            cadena += ubicacion;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String pedidocom = (String.IsNullOrEmpty(pedcompra.Text.Trim())) ? "" : whereand + "[g].[Pedido Compra] LIKE '%" + pedcompra.Text.Trim() + "%'";
            cadena += pedidocom;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String empresaa = (String.IsNullOrEmpty(empres1.Text.Trim())) ? "" : whereand + "[g].[Empresa] LIKE '%" + empres1.Text.Trim() + "%'";
            cadena += empresaa;

            backgroundWorker1.ReportProgress(10);

            if (!String.IsNullOrEmpty(cadena))
            {
                try
                {
                    double ii = 20;
                    double i;
                    i = ii;
                    backgroundWorker1.ReportProgress(15);
                    using (SqlConnection conexion2 = new SqlConnection(database.nsqlExSirac))
                    {
                        conexion2.Open();
                        String sql2 = "SELECT count(*) as c FROM [bd_SiRAc].[dbo].[LNJ_Equipos_Gilberto] g INNER JOIN [bd_SiRAc].[dbo].[LNJ_Equipos] e ON [g].[No. Activo] = [e].[No. Activo] " + cadena + "";
                        SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                        SqlDataReader nwReader2 = comm2.ExecuteReader();
                        if (nwReader2.Read())
                        {
                            ii = 80 / Convert.ToDouble(nwReader2["c"]);
                        }
                    }
                    backgroundWorker1.ReportProgress(20);

                    using (SqlConnection conexion = new SqlConnection(database.nsqlExSirac))
                    {
                        conexion.Open();
                        String sql = "SELECT *  FROM [bd_SiRAc].[dbo].[LNJ_Equipos_Gilberto] g INNER JOIN [bd_SiRAc].[dbo].[LNJ_Equipos] e ON [g].[No. Activo] = [e].[No. Activo] " + cadena + "";
                        SqlCommand comm = new SqlCommand(sql, conexion);
                        SqlDataReader nwReader = comm.ExecuteReader();
                        backgroundWorker1.ReportProgress(20);
                        while (nwReader.Read())
                        {
                            String[] newdato = new String[12];
                            newdato[0] = nwReader["No. Activo"].ToString();
                            newdato[1] = nwReader["Subcategoría"].ToString();
                            newdato[2] = nwReader["marca"].ToString();
                            newdato[3] = nwReader["modelo"].ToString();
                            newdato[4] = nwReader["No. Serie"].ToString();
                            newdato[5] = nwReader["Nombre de Resguardatario"].ToString();
                            newdato[6] = nwReader["Ubicación"].ToString();
                            newdato[7] = nwReader["Empresa"].ToString();
                            newdato[8] = nwReader["Centro de Costo"].ToString();
                            newdato[9] = nwReader["Fecha Asignación"].ToString();
                            newdato[10] = nwReader["Pedido Compra"].ToString();
                            newdato[11] = nwReader["Observaciones"].ToString();
                            listasirac.Add(newdato);
                            backgroundWorker1.ReportProgress(Convert.ToInt32(i));
                            i = i + ii;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la busqueda\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (listasirac.Any())
            {
                foreach(String[] row in listasirac)
                {
                    equipos.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11]);
                }
            }
            progressBar1.Hide();
            progressBar1.Value = 0;
            buscar.Enabled = true;
            regresar.Enabled = true;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            Thread.Sleep(10);
        }
    }
}

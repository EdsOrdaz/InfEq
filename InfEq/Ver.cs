using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace InfEq
{
    public partial class Ver : Form
    {
        public Ver()
        {
            InitializeComponent();
        }


        private void Ver_Load(object sender, EventArgs e)
        {
            equipos.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            equipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;
            equipos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(equipos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            tooltipbuscar.SetToolTip(buscardetalle, "Buscar un equipo");
            tooltipexcel.SetToolTip(exportarexcel, "Exportar lista a archivo de Excel");
            tooltipregresar.SetToolTip(regresar, "Volver a ventana principal");

            progressBar1.Hide();

            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    String sql = "SELECT * FROM " + database.tablabase + " ORDER BY XID DESC";
                    SqlCommand comm = new SqlCommand(sql, conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        equipos.Rows.Add(nwReader["XID"], nwReader["nombreequipo"], nwReader["marca"], nwReader["modelo"], nwReader["tipo"], nwReader["ram"]+" MB", 
                            nwReader["ddtotal"]+" GB", nwReader["ddlibre"]+" GB", nwReader["so"], nwReader["licenciaso"], nwReader["procesador"], nwReader["arquitectura"],
                            nwReader["numeroserie"], nwReader["empresa"], nwReader["departamento"], nwReader["base"], nwReader["nombre"],
                            nwReader["fechainicio"], nwReader["fechatermino"], nwReader["horainicio"], nwReader["horatermino"], nwReader["fecha"],
                            nwReader["hora"], nwReader["mes"], nwReader["year"], nwReader["observaciones"], "Ver MacAddress");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en conexion con la base de datos.\n\nMensaje: "+ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Exportarexcel_Click(object sender, EventArgs e)
        {
            equipos.Hide();
            progressBar1.Show();
            progressBar1.Value = 10;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.Title = "Guardar archivo";
                fichero.FileName = "InfEq";
                progressBar1.Value = 20;
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    progressBar1.Value = 40;

                    for (int i = 1; i < equipos.Columns.Count + 1; i++)
                    {
                        if (equipos.Columns[i - 1].HeaderText != "Mac Address11")
                        {
                            hoja_trabajo.Cells[1, i].Borders.LineStyle = XlLineStyle.xlContinuous;
                            hoja_trabajo.Cells[1, i].interior.color = Color.Gray;
                            hoja_trabajo.Cells[1, i].font.color = Color.White;
                            hoja_trabajo.Cells[1, i].EntireRow.Font.Bold = true;
                            hoja_trabajo.Cells[1, i] = equipos.Columns[i - 1].HeaderText;
                        }
                    }

                    String macs = "";
                    progressBar1.Value = 60;
                    // Valores
                    for (int i = 0; i < equipos.Rows.Count; i++)
                    {
                        for (int j = 0; j < equipos.Columns.Count; j++)
                        {
                            if (equipos.Rows[i].Cells[j].Value.ToString() != "Ver MacAddress")
                            {
                                hoja_trabajo.Cells[i + 2, j + 1].Borders.LineStyle = XlLineStyle.xlContinuous;
                                hoja_trabajo.Cells[i + 2, j + 1] = equipos.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                hoja_trabajo.Cells[i + 2, j + 1].Borders.LineStyle = XlLineStyle.xlContinuous;
                                //hoja_trabajo.Cells[i + 2, j + 1] = equipos.Rows[i].Cells[0].Value.ToString();
                                /*
                                 *  OBTENER MAC ADDRESS PARA INSERTAR EN EXCEL
                                 */
                                macs = "";
                                try
                                {
                                    using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                                    {
                                        conexion.Open();
                                        String sql = "SELECT * FROM " + database.tablabasemacs + " WHERE xid="+Convert.ToInt32(equipos.Rows[i].Cells[0].Value.ToString());
                                        SqlCommand comm = new SqlCommand(sql, conexion);
                                        SqlDataReader nwReader = comm.ExecuteReader();
                                        while (nwReader.Read())
                                        {
                                            macs += nwReader["Nombre"] + "=" + nwReader["Address"] + "\n";
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error en conexion con la base de datos.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Close();
                                }
                                hoja_trabajo.Cells[i + 2, j + 1] = macs;
                            }
                        }
                    }

                    progressBar1.Value = 90;

                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();

                    progressBar1.Value = 100;

                    MessageBox.Show("Archivo generado correctamente", "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                progressBar1.Value = 90;
                MessageBox.Show("Se a producido un error al generar el archivo de excel.\n\nError: "+ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
            progressBar1.Value = 100;
            progressBar1.Hide();
            equipos.Show();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buscardetalle_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Buscar);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                Buscar buscar = new Buscar();
                buscar.Show();
            }
            this.Close();
        }

        private void Equipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.equipos.Columns["macaddress"].Index && e.RowIndex != -1)
            {
                database.MAC_XID = (int)equipos.Rows[e.RowIndex].Cells["id"].Value;
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MacAddress);
                if (frm != null)
                {
                    frm.Close();
                }
                MacAddress macs = new MacAddress();
                macs.Show();
            }
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

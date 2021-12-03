using Microsoft.Office.Interop.Excel;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfEq
{
    public partial class ReporteMensual : Form
    {
        public ReporteMensual()
        {
            InitializeComponent();
        }

        private void ReporteMensual_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
            label3.Hide();
            tooltipgenerar.SetToolTip(botongenerar, "Generar programa");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            botongenerar.Hide();
            mes.Hide();
            year.Hide();
            label1.Hide();
            label2.Hide();
            label3.Show();
            progressBar1.Show();
            progressBar1.Value = 10;

            if (mes.SelectedIndex==-1)
            {
                progressBar1.Value = 100;
                MessageBox.Show("Debes seleccionar un mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                botongenerar.Show();
                mes.Show();
                year.Show();
                label1.Show();
                label2.Show();
                label3.Hide();
                progressBar1.Hide();
                return;
            }
            if (year.SelectedIndex==-1)
            {
                progressBar1.Value = 100;
                MessageBox.Show("Debes seleccionar un año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                botongenerar.Show();
                mes.Show();
                year.Show();
                label1.Show();
                label2.Show();
                label3.Hide();
                progressBar1.Hide();
                return;
            }
            int mess = mes.SelectedIndex + 1;

            int contar = 0;
            using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
            {
                conexion.Open();
                String sql = "SELECT * FROM " + database.tablabase + " WHERE mes=" + mess + " and year=" + year.Text+ " and mantenimiento=2";
                SqlCommand comm = new SqlCommand(sql, conexion);
                SqlDataReader nwReader = comm.ExecuteReader();
                while (nwReader.Read())
                {
                    contar++;
                }
            }
            if(contar==0)
            {
                progressBar1.Value = 100;
                MessageBox.Show("No existen mantenimientos preventivos en "+mes.Text+" de "+year.Text, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                botongenerar.Show();
                mes.Show();
                year.Show();
                label1.Show();
                label2.Show();
                label3.Hide();
                progressBar1.Hide();
                return;
            }
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.Title = "Guardar archivo";
                fichero.FileName = "Programa de mantenimiento Preventivo ("+mes.Text+" "+year.Text+")";
                progressBar1.Value = 30;
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    String sem = "1sem";
                    if(mess > 6)
                    {
                        sem = "2sem";
                    }
                    hoja_trabajo.get_Range("a4", "f4").Merge();
                    hoja_trabajo.get_Range("a4", "f4").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    hoja_trabajo.Cells[4, 1].EntireRow.Font.Bold = true;
                    hoja_trabajo.Cells[4, 1] = "PROGRAMA DE MANTENIMENTO "+year.Text+" ("+sem+")";

                    hoja_trabajo.Cells[6, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    hoja_trabajo.Cells[6, 2] = "Fecha:";

                    hoja_trabajo.Cells[6, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    hoja_trabajo.Cells[6, 3] = mes.Text+" "+year.Text;


                    progressBar1.Value = 50;

                    hoja_trabajo.get_Range("e1", "e3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    hoja_trabajo.get_Range("e1", "e3").Style.Font.Size = 10;
                    hoja_trabajo.get_Range("e1", "e3").Style.Font.Name = "Arial";
                    hoja_trabajo.Cells[1, 6] = "Clave: 13.1.1-D1";
                    hoja_trabajo.Cells[2, 6] = "Versión: 2.0";
                    hoja_trabajo.Cells[3, 6] = "Fecha: 30-08-12";


                    hoja_trabajo.get_Range("a7", "f7").Borders.LineStyle = XlLineStyle.xlContinuous;
                    hoja_trabajo.get_Range("a7", "f7").EntireRow.Font.Bold = true;
                    hoja_trabajo.Cells[7, 1] = "No.";
                    hoja_trabajo.Cells[7, 1].ColumnWidth = 6;
                    hoja_trabajo.Cells[7, 2] = "División";
                    hoja_trabajo.Cells[7, 2].ColumnWidth = 16;
                    hoja_trabajo.Cells[7, 3] = "Área";
                    hoja_trabajo.Cells[7, 3].ColumnWidth = 36;
                    hoja_trabajo.Cells[7, 4] = "Asignado";
                    hoja_trabajo.Cells[7, 4].ColumnWidth = 41;
                    hoja_trabajo.Cells[7, 5] = "Economico";
                    hoja_trabajo.Cells[7, 5].ColumnWidth = 14;
                    hoja_trabajo.Cells[7, 5].RowHeight = 26;
                    hoja_trabajo.Cells[7, 6] = "N/S";
                    hoja_trabajo.Cells[7, 6].ColumnWidth = 14;
                    hoja_trabajo.Cells[7, 6].RowHeight = 26;



                    progressBar1.Value = 70;



                    int idrow = 8;
                    int idshow = 1;
                    try
                    {
                        using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                        {
                            conexion.Open();
                            String sql = "SELECT * FROM " + database.tablabase + " WHERE mes="+mess+" and year="+year.Text+ " and mantenimiento=2";
                            SqlCommand comm = new SqlCommand(sql, conexion);
                            SqlDataReader nwReader = comm.ExecuteReader();
                            while (nwReader.Read())
                            {
                                hoja_trabajo.get_Range("a"+idrow, "f" + idrow).Borders.LineStyle = XlLineStyle.xlContinuous;
                                hoja_trabajo.Cells[idrow, 1] = idshow.ToString();
                                hoja_trabajo.Cells[idrow, 1].ColumnWidth = 3.3;
                                hoja_trabajo.Cells[idrow, 2] = nwReader["empresa"].ToString();
                                hoja_trabajo.Cells[idrow, 2].ColumnWidth = 10.5;
                                hoja_trabajo.Cells[idrow, 3] = nwReader["departamento"].ToString();
                                hoja_trabajo.Cells[idrow, 3].ColumnWidth = 30;
                                hoja_trabajo.Cells[idrow, 4] = nwReader["nombre"].ToString();
                                hoja_trabajo.Cells[idrow, 4].ColumnWidth = 40;
                                hoja_trabajo.Cells[idrow, 5] = nwReader["noactivo"].ToString();
                                hoja_trabajo.Cells[idrow, 5].ColumnWidth = 14;
                                hoja_trabajo.Cells[idrow, 5].RowHeight = 15;
                                hoja_trabajo.Cells[idrow, 6] = nwReader["numeroserie"].ToString();
                                hoja_trabajo.Cells[idrow, 6].ColumnWidth = 14;
                                hoja_trabajo.Cells[idrow, 6].RowHeight = 15;
                                idrow++;
                                idshow++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error en la busqueda\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    progressBar1.Value = 80;

                    int newidrow = idrow + 4;
                    hoja_trabajo.get_Range("c" + newidrow, "e" + newidrow).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    hoja_trabajo.get_Range("c" + newidrow, "e" + newidrow).Merge();
                    hoja_trabajo.get_Range("a" + newidrow, "f" + newidrow).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    hoja_trabajo.Cells[newidrow, 3] = "OCTAVIO PASCUAL ALVAREZ CISNEROS";
                    int newidrow2 = newidrow + 1;
                    hoja_trabajo.get_Range("c" + newidrow2, "e" + newidrow2).Merge();
                    hoja_trabajo.get_Range("a" + newidrow2, "f" + newidrow2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    hoja_trabajo.Cells[newidrow2, 3] = "Gerencia de TI";


                    //imagen
                    System.Drawing.Bitmap pic = Properties.Resources.logoprograma;
                    System.Windows.Forms.Clipboard.SetImage(pic);
                    Range position = (Range)hoja_trabajo.Cells[1, 1];
                    hoja_trabajo.Paste(position);

                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();


                    progressBar1.Value = 100;

                    MessageBox.Show("Programa generado correctamente", "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se a producido un error al generar el archivo de excel.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            botongenerar.Show();
            mes.Show();
            year.Show();
            label1.Show();
            label2.Show();
            label3.Hide();
            progressBar1.Hide();
        }
    }
}

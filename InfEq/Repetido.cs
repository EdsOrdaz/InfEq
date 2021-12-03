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

namespace InfEq
{
    public partial class Repetido : Form
    {
        public static String usuario_inicio;
        public static String NM2;
        public static String marca2;
        public static String Modelo2;
        public static String Tipo2;
        public static String Ram2;
        public static String ddt2;
        public static String ddl2;
        public static String so2;
        public static String procesador2;
        public static String arquitectura2;
        public static String numserie2;
        public static String Depa2;
        public static String localidad2;
        public static String Usuario2;
        public static String licenciaso2;
        public static String empresa2;
        public static String fechainicio2;
        public static String fechatermino2;
        public static String horainicio2;
        public static String horatermino2;
        public static String observaciones2;
        public static int tipo_mantenimiento;

        public static Boolean paneladmin = false;
        public Repetido()
        {
            InitializeComponent();
        }

        private void Repetido_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
            toolexportar.SetToolTip(exportar, "Exportar a Excel");
            toolguardar.SetToolTip(guardar, "Guardar información del equipo");
            toolregresar.SetToolTip(regresar, "Regresar");

            String xids = String.Join(",", database.xids);
            equipos.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            equipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;
            equipos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(equipos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    String sql = "SELECT * FROM " + database.tablabase + " where xid IN ("+@xids+") ORDER BY XID DESC";
                    SqlCommand comm = new SqlCommand(sql, conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        equipos.Rows.Add(nwReader["xid"], nwReader["nombreequipo"], nwReader["marca"], nwReader["modelo"], nwReader["usuario"], nwReader["tipo"], nwReader["ram"] + " Mb",
                                   nwReader["ddtotal"] + " Gb", nwReader["ddlibre"] + " Gb", nwReader["so"], nwReader["licenciaso"], nwReader["procesador"], nwReader["arquitectura"],
                                   nwReader["numeroserie"], nwReader["empresa"], nwReader["base"], nwReader["departamento"], nwReader["nombre"], nwReader["fechainicio"],
                                   nwReader["horainicio"], nwReader["fechatermino"], nwReader["horatermino"], nwReader["observaciones"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en conexion con la base de datos.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            database.Cargar(NM2, marca2, Modelo2, Tipo2, Ram2, ddt2, ddl2, so2, procesador2,
                            arquitectura2, numserie2, Depa2, localidad2, Usuario2, licenciaso2, empresa2,
                            fechainicio2, fechatermino2, horainicio2, horatermino2, observaciones2, tipo_mantenimiento);
            this.Close();
        }

        public void cargardatos(String NM, String Marca, String Modelo, String Tipo, String Ram, String ddt, String ddl, String so, String procesador,
                                     String arquitectura, String numserie, String Depa, String localidad, String Usuario, String licenciaso, String empresa,
                                     String fechainicio, String fechatermino, String horainicio, String horatermino, String observaciones, int mantenimiento)
        {
            NM2=NM;
            marca2=Marca;
            Modelo2=Modelo;
            Tipo2=Tipo;
            Ram2=Ram;
            ddt2=ddt;
            ddl2=ddl;
            so2=so;
            procesador2=procesador;
            arquitectura2=arquitectura;
            numserie2=numserie;
            Depa2=Depa;
            localidad2=localidad;
            Usuario2=Usuario;
            licenciaso2=licenciaso;
            empresa2=empresa;
            fechainicio2=fechainicio;
            fechatermino2=fechatermino;
            horainicio2=horainicio;
            horatermino2=horatermino;
            observaciones2=observaciones;
            observaciones2=observaciones;
            tipo_mantenimiento = mantenimiento;
        }

        public void cargardatos_PanelAdmin(String NM, String Marca, String Modelo, String Userlogin, String Tipo, String Ram, String ddt, String ddl, String so, String licenciaso,
                                    String procesador, String arquitectura, String numserie, String empresa, String Depa, String localidad, String Usuario,
                                    String fechainicio, String fechatermino, String horainicio, String horatermino, String fecha, String hora,
                                    String mes, String year, String observaciones, String idmac)
        {

            database.usuario_en_xml = true;
            database.usuario_en_xml_nombre = Userlogin;

            usuario_inicio = Userlogin;
            NM2 =NM;
            marca2=Marca;
            Modelo2=Modelo;
            Tipo2=Tipo;
            Ram2=Ram;
            ddt2=ddt;
            ddl2=ddl;
            so2=so;
            procesador2=procesador;
            arquitectura2=arquitectura;
            numserie2=numserie;
            Depa2=Depa;
            localidad2=localidad;
            Usuario2=Usuario;
            licenciaso2=licenciaso;
            empresa2=empresa;
            fechainicio2=fechainicio;
            fechatermino2=fechatermino;
            horainicio2=horainicio;
            horatermino2=horatermino;
            observaciones2=observaciones;
        }

        private void Exportar_Click(object sender, EventArgs e)
        {
            equipos.Hide();
            progressBar1.Show();
            progressBar1.Value = 10;
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
                        hoja_trabajo.Cells[1, i].Borders.LineStyle = XlLineStyle.xlContinuous;
                        hoja_trabajo.Cells[1, i].interior.color = Color.Gray;
                        hoja_trabajo.Cells[1, i].font.color = Color.White;
                        hoja_trabajo.Cells[1, i].EntireRow.Font.Bold = true;
                        hoja_trabajo.Cells[1, i] = equipos.Columns[i - 1].HeaderText;
                    }

                    progressBar1.Value = 60;
                    // Valores
                    for (int i = 0; i < equipos.Rows.Count; i++)
                    {
                        for (int j = 0; j < equipos.Columns.Count; j++)
                        {
                            hoja_trabajo.Cells[i + 2, j + 1].Borders.LineStyle = XlLineStyle.xlContinuous;
                            hoja_trabajo.Cells[i + 2, j + 1] = equipos.Rows[i].Cells[j].Value.ToString();
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
            catch (Exception ex)
            {
                MessageBox.Show("Se a producido un error al generar el archivo de excel.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 90;
            }
            progressBar1.Hide();
            equipos.Show();
        }
    }
}

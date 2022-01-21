using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace InfEq
{
    public partial class Buscar : Form
    {
        public static String cadena = "";
        public static int ID;
        public static String NoSerie;
        public static Boolean bporid;

        //Datos correo
        public static String nombrecorreo;
        public static String activocorreo;
        public static String marcaactivo;
        public static String modeloactivo;
        public static String nserieactivo;
        public static String tipoactivo;

        //cargar formulario
        public static String topdies;

        public static SaveFileDialog fichero = new SaveFileDialog();

        public Buscar()
        {
            InitializeComponent();
        }

        public static int buscarporid;
        public static List<String[]> lista = new List<String[]>();
        public void BuscarporId(int id)
        {
            bporid = true;
            buscarporid = id;
            buscardetalle.PerformClick();
        }

        private void Buscardetalle_Click(object sender, EventArgs e)
        {
            int xid = 0;
            cadena = "";
            String whereand = "";
            equipos.Rows.Clear();
            lista.Clear();

            progressBar1.Show();
            progressBar1.Value = 5;

            #region WHERE
            String nomequipo = (String.IsNullOrEmpty(namemachine.Text.Trim())) ? "" : "WHERE nombreequipo LIKE '%" + namemachine.Text.Trim() + "%'";
            cadena = nomequipo;

            whereand = (String.IsNullOrEmpty(nomequipo)) ? " WHERE " : " AND ";
            String marc = (String.IsNullOrEmpty(marca.Text.Trim())) ? "" : whereand + "marca LIKE '%" + marca.Text.Trim() + "%'";
            cadena += marc;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String model = (String.IsNullOrEmpty(modelo.Text.Trim())) ? "" : whereand + "modelo LIKE '%" + modelo.Text.Trim() + "%'";
            cadena += model;
            
            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String tip = (tipo.Text == "NINGUNO" || String.IsNullOrEmpty(tipo.Text)) ? "" : whereand + "tipo='" + tipo.Text.Trim() + "'";
            cadena += tip;
            
            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String sisop = (String.IsNullOrEmpty(so.Text.Trim())) ? "" : whereand + "so LIKE '%" + so.Text.Trim() + "%'";
            cadena += sisop;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String procesado = (String.IsNullOrEmpty(procesador.Text.Trim())) ? "" : whereand + "procesador LIKE '%" + procesador.Text.Trim() + "%'";
            cadena += procesado;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String numerodeactivo = (String.IsNullOrEmpty(activo.Text.Trim())) ? "" : whereand + "noactivo LIKE '%" + activo.Text.Trim() + "%'";
            cadena += numerodeactivo;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String numeroseri = (String.IsNullOrEmpty(serialnumber.Text.Trim())) ? "" : whereand + "numeroserie LIKE '%" + serialnumber.Text.Trim() + "%'";
            cadena += numeroseri;

            
            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String empres = (empresa.Text == "NINGUNA" || String.IsNullOrEmpty(empresa.Text)) ? "" : whereand + "empresa='" + empresa.Text.Trim() + "'";
            cadena += empres;
            

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String departament = (String.IsNullOrEmpty(depa.Text.Trim())) ? "" : whereand + "departamento LIKE '%" + depa.Text.Trim() + "%'";
            cadena += departament;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String bas = (String.IsNullOrEmpty(localidad.Text.Trim())) ? "" : whereand + "base LIKE '%" + localidad.Text.Trim() + "%'";
            cadena += bas;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String usuari = (String.IsNullOrEmpty(usuario.Text.Trim())) ? "" : whereand + "nombre LIKE '%" + usuario.Text.Trim() + "%'";
            cadena += usuari;

            
            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String yearr = (year.Text == "NINGUNO" || String.IsNullOrEmpty(year.Text)) ? "" : whereand + "year='" + year.Text.Trim() + "'";
            cadena += yearr;


            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String Dirmac = (String.IsNullOrEmpty(mac.Text.Trim())) ? "" : whereand + "[Direcciones Mac] LIKE '%" + mac.Text.Trim() + "%'";
            cadena += Dirmac;


            String mesid = "0";
            switch (mes.Text)
            {
                case "NINGUNO":
                    mesid = "0";
                    break;

                case "ENERO":
                    mesid = "01";
                    break;

                case "FEBRERO":
                    mesid = "02";
                    break;

                case "MARZO":
                    mesid = "03";
                    break;

                case "ABRIL":
                    mesid = "04";
                    break;

                case "MAYO":
                    mesid = "05";
                    break;

                case "JUNIO":
                    mesid = "06";
                    break;

                case "JULIO":
                    mesid = "07";
                    break;

                case "AGOSTO":
                    mesid = "08";
                    break;

                case "SEPTIEMBRE":
                    mesid = "09";
                    break;

                case "OCTUBRE":
                    mesid = "10";
                    break;

                case "NOVIEMBRE":
                    mesid = "11";
                    break;

                case "DICIEMBRE":
                    mesid = "12";
                    break;

            }

            String mttoid = "0";
            switch(mtto2.Text)
            {
                case "NINGUNO":
                    mttoid = "0";
                    break;

                case "CORRECTIVO":
                    mttoid = "1";
                    break;

                case "PREVENTIVO":
                    mttoid = "2";
                    break;

                case "EQUIPO NUEVO":
                    mttoid = "3";
                    break;

                case "CAMBIO DE EQUIPO":
                    mttoid = "4";
                    break;
            }


            if (bporid == true)
            {
                xid = buscarporid;
                cadena = " WHERE XID=" + xid;
            }


            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String mttowhere = (mttoid == "0") ? "" : whereand + "mantenimiento=" + mttoid + "";
            cadena += mttowhere;

            whereand = (String.IsNullOrEmpty(cadena)) ? " WHERE " : " AND ";
            String mess = (mesid == "0") ? "" : whereand + "mes='" + mesid + "'";
            cadena += mess;
            #endregion
            progressBar1.Value = 10;

            if (backgroundWorker1.IsBusy != true)
            {
                buscardetalle.Enabled = false;
                exportarexcel.Enabled = false;
                reset.Enabled = false;
                regresar.Enabled = false;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            label12.Hide();
            pictureBox1.Hide();

            equipos.Rows.Clear();

            progressBar1.Hide();
            bporid = false;
            buscarporid = 0;
            equipos.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            equipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;
            equipos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(equipos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            tooldetalle.SetToolTip(buscardetalle, "Buscar equipo");
            toolexportar.SetToolTip(exportarexcel, "Exportar información encontrada a Excel");
            toolregresar.SetToolTip(regresar, "Regresar a ventana principal");
            toolreset.SetToolTip(reset, "Resetear campos de busqueda");

            topdies = "TOP 10 ";
            buscardetalle.PerformClick();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            equipos.Rows.Clear();
            namemachine.Text = "";
            so.Text = "";
            procesador.Text = "";
            activo.Text = "";
            serialnumber.Text = "";
            modelo.Text = "";
            marca.Text = "";
            tipo.Text = "";
            usuario.Text = "";
            depa.Text = "";
            empresa.SelectedIndex = 0;
            tipo.SelectedIndex = 0;
            mes.SelectedIndex = 0;
            year.SelectedIndex = 0;
        }

        private void Exportarexcel_Click(object sender, EventArgs e)
        {
            if(bwexcel.IsBusy != true)
            {
                try
                {
                    fichero.Filter = "Excel (*.xls)|*.xls";
                    fichero.Title = "Guardar archivo";
                    fichero.FileName = "InfEq";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        buscardetalle.Enabled = false;
                        exportarexcel.Enabled = false;
                        reset.Enabled = false;
                        regresar.Enabled = false;
                        pictureBox1.Show();
                        progressBar1.Show();
                        progressBar1.Value = 0;
                        equipos.Hide();

                        label12.Text = "Recuperando información...";
                        label12.Show();
                        bwexcel.RunWorkerAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se a producido un error al generar el archivo de excel.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        #region ENTER_PRESS
        private void Activo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }
        private void Namemachine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Marca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Modelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Arch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void So_TextChanged(object sender, EventArgs e)
        {

        }

        private void So_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Procesador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Depa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Localidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Empresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Tipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Mes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }

        private void Year_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }
        private void Mac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscardetalle.PerformClick();
            }
        }
        #endregion



        private void Namemachine_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.equipos.Columns["macaddress"].Index && e.RowIndex != -1)
            {
                database.MAC_XID = Convert.ToInt32(equipos.Rows[e.RowIndex].Cells["ids"].Value);
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MacAddress);
                if (frm != null)
                {
                    frm.Close();
                }
                MacAddress macs = new MacAddress();
                macs.ShowDialog();
            }
            if (e.ColumnIndex == this.equipos.Columns["ids"].Index && e.RowIndex != -1)
            {
                ID = Convert.ToInt32(equipos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                nombrecorreo = equipos.Rows[e.RowIndex].Cells[19].Value.ToString();
                activocorreo = equipos.Rows[e.RowIndex].Cells[1].Value.ToString();
                marcaactivo = equipos.Rows[e.RowIndex].Cells[3].Value.ToString();
                modeloactivo = equipos.Rows[e.RowIndex].Cells[4].Value.ToString();
                nserieactivo = equipos.Rows[e.RowIndex].Cells[15].Value.ToString();
                tipoactivo = equipos.Rows[e.RowIndex].Cells[7].Value.ToString();

                Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Buscar_Correo);
                if (frm1 != null)
                {
                    frm1.Close();
                }
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Buscar_Correo);
                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    Buscar_Correo Buscar_Correo = new Buscar_Correo();
                    Buscar_Correo.Show();
                }
            }
            if (e.ColumnIndex == this.equipos.Columns["noactivo"].Index && e.RowIndex != -1)
            {
                database.MAC_XID = Convert.ToInt32(equipos.Rows[e.RowIndex].Cells["ids"].Value);
                NoSerie = equipos.Rows[e.RowIndex].Cells[15].Value.ToString();
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is NumActivo_Check);
                if (frm != null)
                {
                    frm.Close();
                }
                NumActivo_Check NumActivo_Check = new NumActivo_Check();
                NumActivo_Check.ShowDialog();
                if (NumActivo_Check.Click == true)
                {
                    activo.Text = NumActivo_Check.no_activo;
                    buscardetalle.PerformClick();
                }
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!String.IsNullOrEmpty(cadena) || !String.IsNullOrEmpty(topdies))
            {
                try
                {
                    double i = 0;
                    int prog = 10;
                    using (SqlConnection conexion2 = new SqlConnection(database.nombresqlexpress))
                    {
                        conexion2.Open();
                        String sql2 = "SELECT count(*) as c FROM " + database.tablabaseview + " " + cadena + "";
                        SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                        SqlDataReader nwReader2 = comm2.ExecuteReader();
                        if(nwReader2.Read())
                        {
                            i = 90 / Convert.ToDouble(nwReader2["c"]);
                        }
                    }
                    using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                    {
                        conexion.Open();
                        String sql = "SELECT "+ topdies + "* FROM " + database.tablabaseview + " " + cadena + " ORDER BY XID DESC";
                        SqlCommand comm = new SqlCommand(sql, conexion);
                        SqlDataReader nwReader = comm.ExecuteReader();
                        while (nwReader.Read())
                        {
                            String tipomtto="";
                            tipomtto = (Convert.ToInt32(nwReader["mantenimiento"]) == 1) ? "Correctivo" : tipomtto;
                            tipomtto = (Convert.ToInt32(nwReader["mantenimiento"]) == 2) ? "Preventivo" : tipomtto;
                            tipomtto = (Convert.ToInt32(nwReader["mantenimiento"]) == 3) ? "Equipo Nuevo" : tipomtto;
                            tipomtto = (Convert.ToInt32(nwReader["mantenimiento"]) == 4) ? "Cambio de Equipo" : tipomtto;

                            String[] dato = new String[27];
                            dato[0] = nwReader["xid"].ToString();
                            dato[1] = nwReader["noactivo"].ToString();
                            dato[2] = nwReader["nombreequipo"].ToString();
                            dato[3] = nwReader["marca"].ToString();
                            dato[4] = nwReader["modelo"].ToString();
                            dato[5] = nwReader["usuario"].ToString();
                            dato[6] = tipomtto;
                            dato[7] = nwReader["tipo"].ToString();
                            dato[8] = nwReader["ram"].ToString();
                            dato[9] = nwReader["ddtotal"].ToString();
                            dato[10] = nwReader["ddlibre"].ToString();
                            dato[11] = nwReader["so"].ToString();
                            dato[12] = nwReader["licenciaso"].ToString();
                            dato[13] = nwReader["procesador"].ToString();
                            dato[14] = nwReader["arquitectura"].ToString();
                            dato[15] = nwReader["numeroserie"].ToString();
                            dato[16] = nwReader["empresa"].ToString();
                            dato[17] = nwReader["base"].ToString();
                            dato[18] = nwReader["departamento"].ToString();
                            dato[19] = nwReader["nombre"].ToString();
                            dato[20] = nwReader["fechainicio"].ToString();
                            dato[21] = nwReader["horainicio"].ToString();
                            dato[22] = nwReader["fechatermino"].ToString();
                            dato[23] = nwReader["horatermino"].ToString();
                            dato[24] = nwReader["observaciones"].ToString();
                            dato[25] = "Ver MacAddress";
                            dato[26] = nwReader["Direcciones Mac"].ToString();

                            lista.Add(dato);
                            prog += Convert.ToInt32(i);
                            backgroundWorker1.ReportProgress(prog);
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
            if(lista.Any())
            {
                foreach(String[] dat in lista)
                {
                    equipos.Rows.Add(dat[0], dat[1], dat[2], dat[3], dat[4], dat[5], dat[6], dat[7], dat[8], dat[9], dat[10], dat[11], dat[12], dat[13], dat[14], dat[15], dat[16], dat[17], dat[18], dat[19], dat[20], dat[21], dat[22], dat[23], dat[24], dat[25], dat[26]);
                }
            }
            progressBar1.Hide();
            buscardetalle.Enabled = true;
            exportarexcel.Enabled = true;
            reset.Enabled = true;
            regresar.Enabled = true;

            topdies = "";
            cadena = "";
            lista.Clear();
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Thread.Sleep(10);
            if (e.ProgressPercentage > 100)
            {
                progressBar1.Value = 100;
            }
            else
            {
                progressBar1.Value = e.ProgressPercentage;
            }
        }


        public static int suma;
        private void Bwexcel_DoWork(object sender, DoWorkEventArgs e)
        {
            suma = 1;
            Double bar = 100;
            Double cont = Convert.ToDouble(equipos.Rows.Count);
            Double progreso = (bar / cont);
            Double cuenta = progreso;

            Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
            Workbook librosTrabajo = aplicacion.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet hojaTrabajo = (Worksheet)librosTrabajo.Worksheets.get_Item(1);
            int iCol = 1;
            foreach (DataGridViewColumn column in equipos.Columns)
            {
                if (column.Visible)
                {
                    hojaTrabajo.Cells[1, iCol] = column.HeaderText;
                    hojaTrabajo.Cells[1, iCol].Borders.LineStyle = XlLineStyle.xlContinuous;
                    //hojaTrabajo.Cells[1, iCol].interior.color = Color.Gray;
                    //hojaTrabajo.Cells[1, iCol].font.color = Color.White;
                    hojaTrabajo.Cells[1, iCol].EntireRow.Font.Bold = true;
                    ++iCol;
                }
            }

            for (int i = 0; i < equipos.Rows.Count; i++)
            {
                bwexcel.ReportProgress(Convert.ToInt32(cuenta));
                for (int j = 0; j < equipos.Columns.Count; j++)
                {
                    if (j == 26)
                    {
                        continue;
                    }
                    hojaTrabajo.Cells[i + 2, j + 1].Borders.LineStyle = XlLineStyle.xlContinuous;
                    hojaTrabajo.Cells[i + 2, j + 1].RowHeight = 15;
                    if (j == 8)
                    {
                        hojaTrabajo.Cells[i + 2, j + 1] = equipos.Rows[i].Cells[j].Value.ToString()+" MB";
                    }
                    else if (j == 9 || j == 10)
                    {
                        hojaTrabajo.Cells[i + 2, j + 1] = equipos.Rows[i].Cells[j].Value.ToString()+" GB";
                    }
                    else if (j == 20 || j == 22)
                    {
                        Console.WriteLine(equipos.Rows[i].Cells[j].Value);
                        hojaTrabajo.Cells[i + 2, j + 1].NumberFormat = "dd/mm/aaaa";
                        //hojaTrabajo.Cells[i + 2, j + 1].NumberFormat = "@";
                        DateTime fecha_insertar = Convert.ToDateTime(equipos.Rows[i].Cells[j].Value);
                        hojaTrabajo.Cells[i + 2, j + 1] = fecha_insertar;
                    }
                    else if (j == 25)
                    {
                        hojaTrabajo.Cells[i + 2, j + 1] = equipos.Rows[i].Cells[j+1].Value.ToString();
                    }
                    else
                    {
                        if (equipos.Rows[i].Cells[j].Value is null)
                        {
                            hojaTrabajo.Cells[i + 2, j + 1] = "";
                        }
                        else
                        {
                            hojaTrabajo.Cells[i + 2, j + 1] = equipos.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                cuenta += progreso;
            }
            aplicacion.ActiveWindow.DisplayGridlines= false;
            librosTrabajo.SaveAs(fichero.FileName, XlFileFormat.xlWorkbookNormal);
            librosTrabajo.Close(true);
            aplicacion.Quit();
        }

        private void Bwexcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label12.Text = "Insertando " + suma + " de " + equipos.Rows.Count + " registros";
            if (e.ProgressPercentage > 100)
            {
                progressBar1.Value = 100;
            }
            else
            {
                progressBar1.Value = e.ProgressPercentage;
            }
            suma++;
        }

        private void Bwexcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Archivo generado correctamente", "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            buscardetalle.Enabled = true;
            exportarexcel.Enabled = true;
            reset.Enabled = true;
            regresar.Enabled = true;
            label12.Hide();
            equipos.Show();
            pictureBox1.Hide();
            progressBar1.Hide();
        }

    }
}

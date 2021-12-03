using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfEq
{
    public partial class SubirArchivos : Form
    {
        //ID para ver macsaddress
        public static int mac_id = 0;
        public static Boolean macver = false;

        public SubirArchivos()
        {
            InitializeComponent();
        }

        private void SubirArchivos_Load(object sender, EventArgs e)
        {

            equipos.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            equipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;
            equipos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(equipos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            
            try
            {
                int cont = 0;
                foreach (List<String> nwReader in SubirXML.lista_archivos)
                {
                    equipos.Rows.Add(cont, nwReader[0], nwReader[1], nwReader[2], nwReader[3], nwReader[30], nwReader[4], nwReader[5], nwReader[13], nwReader[14], nwReader[6], nwReader[7], nwReader[8],
                    nwReader[9], nwReader[10], nwReader[23], nwReader[20], nwReader[21], nwReader[22], nwReader[15], nwReader[17], nwReader[16], nwReader[18],
                    nwReader[26], nwReader[27], nwReader[28], nwReader[29], nwReader[19], "Ver MacAddress");
                    cont++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en conexion con la base de datos.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Equipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            if (e.ColumnIndex == this.equipos.Columns["macaddress"].Index && e.RowIndex != -1)
            {
                mac_id = (int)equipos.Rows[e.RowIndex].Cells["id"].Value;
                macver = true;
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MacAddress);
                if (frm != null)
                {
                    frm.Close();
                }
                MacAddress macs = new MacAddress();
                macs.Show();
            }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cargar_Click(object sender, EventArgs e)
        {
            List<List<String>> lista = new List<List<String>>();
            String[] valor = new String[31];

            // Valores
            for (int i = 0; i < equipos.Rows.Count; i++)
            {
                for (int j = 0; j < equipos.Columns.Count; j++)
                {
                    valor[j] = equipos.Rows[i].Cells[j].Value.ToString();
                }
                /*
                lista.Add(new List<String>() {
                        valor[0],
                        valor[1],
                        valor[2],
                        valor[3],
                        valor[4],
                        valor[5],
                        valor[6],
                        valor[7],
                        valor[8],
                        valor[9],
                        valor[10],
                        valor[11],
                        valor[12],
                        valor[13],
                        valor[14],
                        valor[15],
                        valor[16],
                        valor[17],
                        valor[18],
                        valor[19],
                        valor[20],
                        valor[21],
                        valor[22],
                        valor[23],
                        valor[24],
                        valor[25],
                        valor[26]
                 });
                 */
                //valor[0] es ID para obtener mac

                try
                {
                    database.xids.Clear();
                    using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                    {
                        conexion.Open();
                        String sql = "SELECT * FROM " + database.tablabase + " WHERE numeroserie='" + valor[13] + "'";
                        SqlCommand comm = new SqlCommand(sql, conexion);
                        SqlDataReader nwReader = comm.ExecuteReader();

                        Boolean repetidos = false;
                        int repe = 0;
                        while (nwReader.Read())
                        {
                            repe++;
                            repetidos = true;
                            database.xids.Add(nwReader["xid"].ToString());
                        }

                        if (repetidos == true)
                        {
                            MessageBox.Show("Se detectaron " + repe + " registros anteriores del equipo "+valor[1], "Información del Equipo", MessageBoxButtons.OK);
                            Repetido.paneladmin = true;

                            Repetido ventanarepetido = new Repetido();
                            ventanarepetido.cargardatos_PanelAdmin(valor[1], valor[2], valor[3], valor[4], valor[5], valor[6], valor[7], valor[8], valor[9],
                                    valor[10], valor[11], valor[12], valor[13], valor[14], valor[15], valor[16], valor[17], valor[18],
                                    valor[19], valor[20], valor[21], valor[22], valor[23], valor[24], valor[25], valor[26], valor[0]);
                            ventanarepetido.Show();

                        }
                        else
                        {
                            /*
                             * Valor: 0: 0
                                Valor: 1: CHERNANDEZG
                                Valor: 2: Dell Inc.
                                Valor: 3: Vostro 3400
                                Valor: 4: CHERNANDEZG\UNNE
                                Valor: 5: 2
                                Valor: 6: LAPTOP
                                Valor: 7: 7918
                                Valor: 8: 219
                                Valor: 9: 174
                                Valor: 10: Microsoft Windows 10 Pro
                                Valor: 11: NV27M-M8WMQ-RV84F-JGV3R-8B49C
                                Valor: 12: 11th Gen Intel(R) Core(TM) i5-1135G7 @ 2.40GHz
                                Valor: 13: 64 bits
                                Valor: 14: JLZDLB3
                                Valor: 15: TRACSA
                                Valor: 16: VERACRUZ
                                Valor: 17: VERACRUZ
                                Valor: 18: CANDELARIA HERNANDEZ GOMEZ
                                Valor: 19: 07/09/2021
                                Valor: 20: 07/09/2021
                                Valor: 21: 09:54 a. m.
                                Valor: 22: 10:09 a. m.
                                Valor: 23: 08/09/2021
                                Valor: 24: 10:24 PM
                                Valor: 25: 09
                                Valor: 26: 2021
                                Valor: 27: Sin Observaciones
                                Valor: 28: Ver MacAddress
                            */

                            database.CargarPanelAdmin(valor[1], valor[2], valor[3], valor[4], valor[6], valor[7], valor[8], valor[9],
                                    valor[10], valor[11], valor[12], valor[13], valor[14], valor[15], valor[16], valor[17], valor[18],
                                    valor[19], valor[20], valor[21], valor[22], valor[23], valor[24], valor[25], valor[26], valor[27], valor[0], valor[5]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cccconectar con la base de datos.\n\nMensaje: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }
    }
}

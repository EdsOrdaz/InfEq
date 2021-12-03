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
    public partial class MacAddress : Form
    {
        public MacAddress()
        {
            InitializeComponent();
        }

        private void MacAddress_Load(object sender, EventArgs e)
        {
            macstabla.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            macstabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;
            macstabla.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(macstabla.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            if (SubirArchivos.macver == false)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                    {
                        conexion.Open();
                        String sql = "SELECT * FROM " + database.tablabasemacs + " WHERE xid=" + database.MAC_XID;
                        SqlCommand comm = new SqlCommand(sql, conexion);
                        SqlDataReader nwReader = comm.ExecuteReader();
                        while (nwReader.Read())
                        {
                            macstabla.Rows.Add(nwReader["Nombre"], nwReader["Address"], "Copiar");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar macs\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                int i = 1;
                do
                {
                    macstabla.Rows.Add(SubirXML.maqs[SubirArchivos.mac_id, i, 0], SubirXML.maqs[SubirArchivos.mac_id, i, 1], "Copiar");
                    i++;
                } while (i <= Convert.ToInt32(SubirXML.maqs[SubirArchivos.mac_id, 0, 0]));
                SubirArchivos.macver = false;
            }
        }

        private void Macstabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.macstabla.Columns["copiar"].Index && e.RowIndex != -1)
            {
                String texto = macstabla.Rows[e.RowIndex].Cells["interfase"].Value.ToString();
                MessageBox.Show("¡MacAddress de la interfase\n"+texto+"\ncopiada!", "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetText(macstabla.Rows[e.RowIndex].Cells["mac"].Value.ToString());
            }
        }

        private void MacAddress_Deactivate(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}

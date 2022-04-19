using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace InfEq
{
    public partial class VerMacs_boton : Form
    {
        public VerMacs_boton()
        {
            InitializeComponent();
        }

        private void VerMacs_boton_Load(object sender, EventArgs e)
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            int i = 0;
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                String mac = string.Join(":", (from z in adapter.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());

                mac = string.IsNullOrEmpty(mac) ? "Sin Datos" : mac;

                dataGridView1.Rows.Add(adapter.Description.ToString(), mac);

                System.Windows.Forms.DataGridViewCellStyle boldStyle = new System.Windows.Forms.DataGridViewCellStyle();
                boldStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);

                dataGridView1.Rows[i].Cells[0].Style = boldStyle;
                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Silver;
                this.dataGridView1.ClearSelection();
                i++;
            }
        }
    }
}

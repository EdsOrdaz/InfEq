using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace InfEq
{
    public partial class NombrePC : Form
    {
        public NombrePC()
        {
            InitializeComponent();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool SetMachineName(string newName)
        {
            RegistryKey key = Registry.LocalMachine;

            string activeComputerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
            RegistryKey activeCmpName = key.CreateSubKey(activeComputerName);
            activeCmpName.SetValue("ComputerName", newName);
            activeCmpName.Close();
            string computerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName";
            RegistryKey cmpName = key.CreateSubKey(computerName);
            cmpName.SetValue("ComputerName", newName);
            cmpName.Close();
            string _hostName = "SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters\\";
            RegistryKey hostName = key.CreateSubKey(_hostName);
            hostName.SetValue("Hostname", newName);
            hostName.SetValue("NV Hostname", newName);
            hostName.Close();
            return true;
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                foreach (String[] empleado in Buscar_Correo.empleados)
                {
                    if (empleado[5].Contains(textBox1.Text.ToUpper()))
                    {
                        dataGridView1.Rows.Add(empleado[3], empleado[4].ToUpper(), empleado[6]);
                    }
                }
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    queryObj["Description"] = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    queryObj.Put();
                }

                Orden.namepc_2 = dataGridView1.CurrentRow.Cells[1].Value.ToString().ToUpper();

                DialogResult msj = MessageBox.Show("Quieres cambiar los datos en el equipo?", "InfEq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(msj == DialogResult.Yes)
                {
                    SetMachineName(dataGridView1.CurrentRow.Cells[1].Value.ToString().ToUpper());
                    MessageBox.Show("Nombre del equipo cambiado", "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debes seleccionar una linea para enviar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NombrePC_Load(object sender, EventArgs e)
        {

        }
    }
}

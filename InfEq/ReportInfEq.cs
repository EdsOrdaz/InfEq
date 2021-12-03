using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace InfEq
{
    public partial class ReportInfEq : Form
    {
        public ReportInfEq()
        {
            InitializeComponent();
        }

        private void Instalar_Click(object sender, EventArgs e)
        {
            if(Instalar_programa.IsBusy != true)
            {
                /*
                this.FormBorderStyle = FormBorderStyle.None;
                this.TransparencyKey = Color.Gray;
                this.BackColor = Color.Gray;
                */
                pictureBox1.Visible = true;
                pictureBox1.BringToFront();
                Instalar_programa.RunWorkerAsync();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detener_Click(object sender, EventArgs e)
        {
            if(detener_programa.IsBusy != true)
            {
                /*
                this.FormBorderStyle = FormBorderStyle.None;
                this.TransparencyKey = Color.Gray;
                this.BackColor = Color.Gray;
                */
                pictureBox1.Visible = true;
                pictureBox1.BringToFront();
                detener_programa.RunWorkerAsync();
            }
        }

        private void ReportInfEq_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            toolTip1.SetToolTip(instalar, "Instalar ReportInfEq");
            toolTip1.SetToolTip(detener, "Detener y Eliminar ReportInfEq");
            toolTip1.SetToolTip(reporte, "Ver Reporte de Equipos");
            toolTip1.SetToolTip(button4, "Regresar");
        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En Construccion");
        }

        private void Instalar_programa_DoWork(object sender, DoWorkEventArgs e)
        {
            String programdata = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\ReportInfEq.exe";
            if (!System.IO.File.Exists(programdata))
            {
                if (System.IO.File.Exists("ReportInfEq.exe"))
                {
                    System.IO.File.Copy("ReportInfEq.exe", programdata);
                    System.Diagnostics.Process.Start(programdata);
                    MessageBox.Show("Reporte de equipo instalado", "Reporte de Equipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encuentra el programa a instalar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult borrar = MessageBox.Show("Ya existe el programa\n¿Desea remplazarlo?", "Reporte de Equipos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (borrar == DialogResult.Yes)
                {
                    try
                    {
                        Process[] procesos = Process.GetProcessesByName("ReportInfEq");
                        if (procesos.Length > 0)
                        {
                            procesos[0].Kill();
                            Thread.Sleep(2000);
                        }
                        System.IO.File.Delete(programdata);
                        System.IO.File.Copy("ReportInfEq.exe", programdata);
                        System.Diagnostics.Process.Start(programdata);
                        MessageBox.Show("Reporte de equipo instalado", "Reporte de Equipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Instalar_programa_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.TransparencyKey = BackColor;
            this.BackColor = SystemColors.Control;
            */
            pictureBox1.Visible = false;
        }

        private void Detener_programa_DoWork(object sender, DoWorkEventArgs e)
        {
            String programdata = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\ReportInfEq.exe";
            try
            {
                Process[] procesos = Process.GetProcessesByName("ReportInfEq");
                if (procesos.Length > 0)
                {
                    procesos[0].Kill();
                    Thread.Sleep(2000);
                    System.IO.File.Delete(programdata);
                    MessageBox.Show("Reporte de equipo detenido", "Reporte de Equipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No esta abierto el proceso", "Reporte de Equipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Detener_programa_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.TransparencyKey = BackColor;
            this.BackColor = SystemColors.Control;
            */
            pictureBox1.Visible = false;
        }
    }
}

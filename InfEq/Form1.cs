﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WinProdKeyFind;
using static InfEq.Datos;


namespace InfEq
{
    public partial class Orden : Form
    {
        public static String namepc_2 = Environment.MachineName.ToString();
        public static String empresa2;
        public static String base2;
        public static String depa2;
        public static String fecha_inicio;
        public static String fecha_termino;
        public static String hora_inicio;
        public static String hora_termino;
        public static String observaciones2;
        public static String Usuario;
        public static String Tipo;
        public static String Marca;
        public static String Modelo;
        public static String NumerodeSerie;
        public static String correoelectronico;
        public static Boolean errorcorreo;
        public static Boolean enviarorden=false;


        public Orden()
        {
            InitializeComponent();
        }
        public static string EncriptarPass(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tooltipgenerarxml.SetToolTip(crearxml, "Generar archivo XML");
            tooltiporden.SetToolTip(crearorden, "Generar orden del mantenimiento");
            tooltipsubir.SetToolTip(subirinfor, "Guardar la información del equipo en la base de datos");
            tooltipvertabla.SetToolTip(vertabla, "Ver informacion de los equipos");
            tooltiprestablecer.SetToolTip(restablecer, "Restablecer campos");
            tooltiplogin.SetToolTip(loginimagen, "Iniciar Sesión");

            depa.Focus();

            //depa.Text = EncriptarPass(EncriptarPass("1234"));

            namemachine.Text = namepc_2;
            ram.Text = Data.GetRamTotal().ToString();
            ddtotal.Text = Data.DiscoDuro(1);
            ddlibre.Text = Data.DiscoDuro(2).ToString();
            so.Text = Data.SistemaOperativo();
            procesador.Text = Data.Procesador();
            arch.Text = Data.Arquitectura();
            serialnumber.Text = Data.NumSerie();
            modelo.Text = Data.Modelo();
            marca.Text = Data.Marca();
            tipo.Text = Data.Tipo();
            usuario.Text = Data.Descripcion();
            licenciaso.Text = KeyDecoder.GetWindowsProductKeyFromRegistry();
            fechainicio.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            fechatermino.Text= DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            horatermino.Text= DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            double mint = -15;
            horainicio.Text = DateTime.Now.AddMinutes(mint).ToString("hh:mm tt", CultureInfo.InvariantCulture);
            empresa.SelectedIndex = 0;
            observaciones.Text = "Sin Observaciones";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            crearxml.Enabled = false;
            crearorden.Enabled = false;
            restablecer.Enabled = false;
            subirinfor.Enabled = false;
            vertabla.Enabled = false;
            int error = 0;
            _ = string.IsNullOrEmpty(namemachine.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(ram.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(ddtotal.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(ddlibre.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(so.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(procesador.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(arch.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(serialnumber.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(modelo.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(marca.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(tipo.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(depa.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(localidad.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(usuario.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(fechainicio.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(fechatermino.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(horainicio.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(horatermino.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(correo.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(observaciones.Text) ? error++ : 0;


            int mantenimiento = 0;
            mantenimiento = (mttocorr.Checked == true) ? 1 : mantenimiento;
            mantenimiento = (mttoprev.Checked == true) ? 2 : mantenimiento;
            mantenimiento = (eqnuevo.Checked == true) ? 3 : mantenimiento;
            mantenimiento = (cambioeq.Checked == true) ? 4 : mantenimiento;


            if (error > 0)
            {
                MessageBox.Show("No debe haber campos vacíos", "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (mttocorr.Checked == false && mttoprev.Checked == false && eqnuevo.Checked == false && cambioeq.Checked == false)
                {
                    MessageBox.Show("Debes seleccionar un tipo de mantenimiento.", "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    xml.generar(namemachine.Text, marca.Text, modelo.Text, tipo.Text, ram.Text, ddtotal.Text, ddlibre.Text, so.Text, procesador.Text, 
                    arch.Text, serialnumber.Text, depa.Text, localidad.Text, usuario.Text, licenciaso.Text,empresa.Text, fechainicio.Text, fechatermino.Text,
                    horainicio.Text, horatermino.Text, observaciones.Text, mantenimiento);
                }
            }
            restablecer.Enabled = true;
            crearorden.Enabled = true;
            crearxml.Enabled = true;
            vertabla.Enabled = true;
            subirinfor.Enabled = (database.botoncargar == true) ? true : false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            crearxml.Enabled = false;
            crearorden.Enabled = false;
            restablecer.Enabled = false;
            subirinfor.Enabled = false;
            vertabla.Enabled = false;


            namemachine.Text = namepc_2;
            ram.Text = Data.GetRamTotal().ToString();
            ddtotal.Text = Data.DiscoDuro(1);
            ddlibre.Text = Data.DiscoDuro(2).ToString();

            so.Text = Data.SistemaOperativo();
            procesador.Text = Data.Procesador();
            arch.Text = Data.Arquitectura();
            serialnumber.Text = Data.NumSerie();

            modelo.Text = Data.Modelo();
            marca.Text = Data.Marca();
            tipo.Text = Data.Tipo();

            usuario.Text = Data.Descripcion();
            licenciaso.Text = KeyDecoder.GetWindowsProductKeyFromRegistry();
            fechainicio.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            fechatermino.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            horatermino.Text = DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            double mint = -90;
            horainicio.Text = DateTime.Now.AddMinutes(mint).ToString("hh:mm tt", CultureInfo.InvariantCulture);

            empresa.SelectedIndex = 0;
            restablecer.Enabled = true;
            crearorden.Enabled = true;
            crearxml.Enabled = true;
            vertabla.Enabled = true;
            subirinfor.Enabled = (database.botoncargar == true) ? true : false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            String Mensaje = "";
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                Mensaje = Mensaje+adapter.Description.ToString()+"\n";
                String mac = string.Join(":", (from z in adapter.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());

                mac = string.IsNullOrEmpty(mac) ? "Sin Datos" : mac;

                Mensaje = Mensaje + "Mac Address: "+mac+"\n\n";
            }
            MessageBox.Show(Mensaje, "Interfaces", MessageBoxButtons.OK);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            //MessageBox.Show("2019 © Edson Ordaz\n\nCorporativo UNNE\nTecnologías de la Informacón\nTodos los derechos reservados", "InfEq", MessageBoxButtons.OK);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int error = 0;
            errorcorreo = false;
            _ = string.IsNullOrEmpty(namemachine.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(ram.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(ddtotal.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(ddlibre.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(so.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(procesador.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(arch.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(serialnumber.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(modelo.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(marca.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(tipo.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(depa.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(localidad.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(usuario.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(fechainicio.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(fechatermino.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(horainicio.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(horatermino.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(observaciones.Text) ? error++ : 0;
            _ = string.IsNullOrEmpty(correo.Text) ? error++ : 0;

            if(string.IsNullOrEmpty(correo.Text))
            {
                MessageBox.Show("Debes ingresar un correo electronico.", "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorcorreo = true;
                return;
            }
            if (error > 0)
            {
                MessageBox.Show("No debe haber campos vacíos", "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorcorreo = true;
            }
            else
            {
                crearxml.Enabled = false;
                crearorden.Enabled = false;
                restablecer.Enabled = false;
                subirinfor.Enabled = false;
                vertabla.Enabled = false;

                empresa2 = empresa.Text;
                base2 = localidad.Text;
                depa2 = depa.Text;
                fecha_inicio = fechainicio.Text;
                fecha_termino = fechatermino.Text;
                hora_inicio = horainicio.Text;
                hora_termino = horatermino.Text;
                observaciones2 = observaciones.Text;
                correoelectronico = correo.Text;
                Usuario = usuario.Text;
                Tipo = tipo.Text;
                Marca = marca.Text;
                Modelo = modelo.Text;
                NumerodeSerie = serialnumber.Text;

                this.Enabled = false;

                CrearPDF.archivo = Data.Tipo() + "_" + Environment.MachineName.ToString() + "_" + Data.NumSerie() + ".pdf";
                CrearPDF imprimir = new CrearPDF();
                imprimir.ShowDialog();
                if (enviarorden == false)
                {
                    restablecer.Enabled = true;
                    crearorden.Enabled = true;
                    crearxml.Enabled = true;
                    vertabla.Enabled = true;
                    subirinfor.Enabled = (database.botoncargar == true) ? true : false;
                }
                this.Enabled = true;
            }
        }

        private void Horainicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //horatermino.Value = horainicio.Value.AddMinutes(90);
        }

        private void Horainicio_KeyUp(object sender, KeyEventArgs e)
        {
            //horatermino.Value = horainicio.Value.AddMinutes(90);
        }

        public void Button5_Click(object sender, EventArgs e)
        {
            if (database.logueado == false)
            {
                login ventanalogin = new login();
                database.ventanalogin = 2;
                ventanalogin.Show();
            }
            else
            {
                crearxml.Enabled = false;
                crearorden.Enabled = false;
                restablecer.Enabled = false;
                subirinfor.Enabled = false;
                vertabla.Enabled = false;

                int error = 0;
                _ = string.IsNullOrEmpty(namemachine.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(ram.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(ddtotal.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(ddlibre.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(so.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(procesador.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(arch.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(serialnumber.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(modelo.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(marca.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(tipo.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(depa.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(localidad.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(usuario.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(fechainicio.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(fechatermino.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(horainicio.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(horatermino.Text) ? error++ : 0;
                _ = string.IsNullOrEmpty(observaciones.Text) ? error++ : 0;

                String errormostrar = "No debe haber campos vacíos";

                if (mttocorr.Checked == false && mttoprev.Checked == false && eqnuevo.Checked == false && cambioeq.Checked == false)
                {
                    error++;
                    errormostrar = "Debes seleccionar el tipo de mantenimiento";
                }

                if (error > 0)
                {
                    MessageBox.Show(errormostrar, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult enviarcorreo = MessageBox.Show("Quieres enviar la orden por correo?", "InfEq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (enviarcorreo == DialogResult.Yes)
                    {
                        enviarorden = true;
                        Button4_Click(sender,e);
                        if(errorcorreo == true)
                        {
                            restablecer.Enabled = true;
                            crearorden.Enabled = true;
                            crearxml.Enabled = true;
                            vertabla.Enabled = true;
                            subirinfor.Enabled = (database.botoncargar == true) ? true : false;
                            return;
                        }
                        enviarorden = false;
                    }
                    this.Enabled = false;
                    CargandoDatos_a_BD CargandoDatos_a_BD = new CargandoDatos_a_BD();
                    CargandoDatos_a_BD.Show();
                    try
                    {
                        database.xids.Clear();
                        using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                        {
                            conexion.Open();
                            String sql = "SELECT * FROM " + database.tablabase + " WHERE numeroserie='" + serialnumber.Text + "'";
                            SqlCommand comm = new SqlCommand(sql, conexion);
                            SqlDataReader nwReader = comm.ExecuteReader();

                            Boolean repetidos = false;
                            Repetido.paneladmin = false;
                            int repe = 0;
                            while (nwReader.Read())
                            {
                                repe++;
                                repetidos = true;
                                database.xids.Add(nwReader["xid"].ToString());
                                //MessageBox.Show("ID encontrado " + nwReader["xid"], "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                            //Validacion del tipo de mantenimiento (Corr:1, Prev:2 y EqNuevo:3
                            int mantenimiento = 0;
                            mantenimiento = (mttocorr.Checked == true) ? 1 : mantenimiento;
                            mantenimiento = (mttoprev.Checked == true) ? 2 : mantenimiento;
                            mantenimiento = (eqnuevo.Checked == true) ? 3 : mantenimiento;
                            mantenimiento = (cambioeq.Checked == true) ? 4 : mantenimiento;

                            if (repetidos==true)
                            {
                                MessageBox.Show("Se detectaron "+repe+" registros anteriores de este equipo.", "Información del Equipo", MessageBoxButtons.OK);
                                Repetido ventanarepetido = new Repetido();
                                ventanarepetido.cargardatos(namemachine.Text, marca.Text, modelo.Text, tipo.Text, ram.Text, ddtotal.Text, ddlibre.Text, so.Text, procesador.Text,
                                    arch.Text, serialnumber.Text, depa.Text, localidad.Text, usuario.Text, licenciaso.Text, empresa.Text, fechainicio.Text, fechatermino.Text,
                                    horainicio.Text, horatermino.Text, observaciones.Text, mantenimiento);
                                ventanarepetido.Show();
                            }
                            else
                            {
                                database.Cargar(namemachine.Text, marca.Text, modelo.Text, tipo.Text, ram.Text, ddtotal.Text, ddlibre.Text, so.Text, procesador.Text,
                                    arch.Text, serialnumber.Text, depa.Text, localidad.Text, usuario.Text, licenciaso.Text, empresa.Text, fechainicio.Text, fechatermino.Text,
                                    horainicio.Text, horatermino.Text, observaciones.Text, mantenimiento);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cccconectar con la base de datos.\n\nMensaje: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CargandoDatos_a_BD.Close();
                    this.Enabled = true;
                }
            }
            restablecer.Enabled = true;
            crearorden.Enabled = true;
            crearxml.Enabled = true;
            vertabla.Enabled = true;
            subirinfor.Enabled = (database.botoncargar == true) ? true : false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            crearxml.Enabled = false;
            crearorden.Enabled = false;
            restablecer.Enabled = false;
            subirinfor.Enabled = false;
            vertabla.Enabled = false;
            if (database.logueado == false)
            {
                login ventanalogin = new login();
                database.ventanalogin = 1;
                ventanalogin.Show();
            }
            else
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Buscar);
                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    Buscar Buscar = new Buscar();
                    Buscar.Show();
                }
            }
            restablecer.Enabled = true;
            crearorden.Enabled = true;
            crearxml.Enabled = true;
            vertabla.Enabled = true;
            subirinfor.Enabled = (database.botoncargar == true) ? true : false;
        }

        private void Loginimagen_Click(object sender, EventArgs e)
        {
            if (database.logueado == true && database.privilegios==false)
            {
                if (MessageBox.Show("¿Quieres cerrar sesión?", "Cerrar Sesion", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Cerraste sesión correctamente \n" + database.userlogin, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    database.logueado = false;
                }
            }
            else if (database.logueado == true && database.privilegios == true)
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Usuario);
                if (frm != null)
                {
                    frm.BringToFront();
                    return;
                }
                else
                {
                    Usuario usuario = new Usuario();
                    usuario.Show();
                }

            }
            else
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is login);
                if (frm != null)
                {
                    frm.BringToFront();
                    return;
                }
                else
                {
                    database.ventanalogin = 0;
                    login ventanalogin = new login();
                    ventanalogin.Show();
                }
            }
        }

        private void Orden_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Traer informacion de NOM
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (database.logueado == false)
            {
                login ventanalogin = new login();
                database.ventanalogin = 3;
                ventanalogin.ShowDialog();
                if(database.logueado == true) { PictureBox2_Click(sender, e); }
            }
            else
            {
                if (!Buscar_Correo.empleados.Any())
                {
                    this.Enabled = false;
                    CargandoEmpleados CargandoEmpleados = new CargandoEmpleados();
                    CargandoEmpleados.ShowDialog();
                    this.Enabled = true;
                }

                Boolean ExisteDato = false;
                foreach (String[] emp in Buscar_Correo.empleados)
                {
                    if (emp[3].ToUpper() == usuario.Text.ToUpper())
                    {
                        depa.Text = emp[8];
                        localidad.Text = emp[7];
                        correo.Text = emp[6];
                        namemachine.Text = emp[4].ToUpper();
                        ExisteDato = true;
                    }
                }
                if (!ExisteDato)
                {
                    MessageBox.Show("No se encontro ningun usuario con el nombre " + usuario.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Pic_pc_Click(object sender, EventArgs e)
        {
            if (database.EsAdministrador())
            {
                if (database.logueado == false)
                {
                    login ventanalogin = new login();
                    database.ventanalogin = 3;
                    ventanalogin.ShowDialog();
                    if (database.logueado == true)
                    {
                        Pic_pc_Click(sender, e);
                    }
                }
                else
                {
                    this.Enabled = false;
                    if (!Buscar_Correo.empleados.Any())
                    {
                        CargandoEmpleados CargandoEmpleados = new CargandoEmpleados();
                        CargandoEmpleados.ShowDialog();
                    }

                    NombrePC nombrepcfrm = new NombrePC();
                    nombrepcfrm.ShowDialog();

                    this.Enabled = true;
                    restablecer.PerformClick();
                    PictureBox2_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Debes ejecutar el programa en modo administrador para cambiar el nombre de la PC", "No Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void correo_DoubleClick(object sender, EventArgs e)
        {
            correo.Text = "edson.ordaz@unne.com.mx";
        }

        private void eqnuevo_Click(object sender, EventArgs e)
        {
            double mint = -90;
            horainicio.Text = DateTime.Now.AddMinutes(mint).ToString("hh:mm tt", CultureInfo.InvariantCulture);
        }

        private void cambioeq_Click(object sender, EventArgs e)
        {
            double mint = -120;
            horainicio.Text = DateTime.Now.AddMinutes(mint).ToString("hh:mm tt", CultureInfo.InvariantCulture);
        }

        private void mttocorr_Click(object sender, EventArgs e)
        {
            double mint = -90;
            horainicio.Text = DateTime.Now.AddMinutes(mint).ToString("hh:mm tt", CultureInfo.InvariantCulture);
        }

        private void mttoprev_Click(object sender, EventArgs e)
        {
            double mint = -15;
            horainicio.Text = DateTime.Now.AddMinutes(mint).ToString("hh:mm tt", CultureInfo.InvariantCulture);
        }
    }
}

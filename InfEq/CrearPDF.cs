using InfEq.Properties;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using static InfEq.Datos;

namespace InfEq
{
    public partial class CrearPDF : Form
    {
        private PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();
        public CrearPDF()
        {
            InitializeComponent();
        }

        public static iTextSharp.text.Font GetCalibri()
        {
            var fontName = "Calibri";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\Calibri.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 11);
            //return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }
        public static iTextSharp.text.Font GetArial()
        {
            var fontName = "Arial";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\Arial.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 10, new BaseColor(176, 176, 176));
            //return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }
        public static iTextSharp.text.Font GetVerdana()
        {
            var fontName = "Verdana";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\Verdana.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 7, new BaseColor(176, 176, 176));
            //return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }

        public static String archivo;
        public static String guardardocumento;
        //public static String archivo = Data.Tipo() + "_" + Environment.MachineName.ToString() + "_" + Data.NumSerie() + ".pdf";


        public Stream GetStreamFile(string filePath)
        {
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                MemoryStream memStream = new MemoryStream();
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

                return memStream;
            }
        }

        private void CrearPDF_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;

            if(enviandopdf.IsBusy != true)
            {
                enviandopdf.RunWorkerAsync();
            }
        }

        private void Enviandopdf_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = archivo;
            sfd.Filter = "Pdf File |*.pdf";
            string temparchivo = Path.GetTempPath();

            String no_activo = database.Buscar_economico(Orden.NumerodeSerie);


            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(temparchivo + archivo, FileMode.Create));
            Console.WriteLine(temparchivo);
            //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("InfEq");
            doc.AddCreator("Edson Ordaz");

            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _FontCalibriUnerline = GetCalibri();
            iTextSharp.text.Font _FontCalibri = GetCalibri();
            iTextSharp.text.Font _FontArial = GetArial();
            iTextSharp.text.Font _FontVerdana = GetVerdana();


            #region Tabla de Encabezado
            // TABLA UNNE LOGO
            PdfPTable tbllogo = new PdfPTable(3);
            tbllogo.WidthPercentage = 90;
            tbllogo.SetWidths(new float[] { 2f, 8f, 2f });

            iTextSharp.text.Image img8 = iTextSharp.text.Image.GetInstance(Resources.unnelogo, System.Drawing.Imaging.ImageFormat.Jpeg);
            img8.ScaleAbsolute(45f, 45f);
            PdfPCell cllogo = new PdfPCell();
            cllogo.AddElement(img8);
            cllogo.BorderWidth = 0;
            cllogo.PaddingBottom = 30;
            tbllogo.AddCell(cllogo);

            PdfPCell clorden = new PdfPCell(new Phrase("Orden de Servicio Preventivo", _FontArial));
            clorden.BorderWidth = 0;
            clorden.HorizontalAlignment = Element.ALIGN_CENTER;
            clorden.VerticalAlignment = Element.ALIGN_CENTER;

            PdfPCell clclave = new PdfPCell(new Phrase("Clave: Fr 13.1.1-F1\nVersión: 3\nFecha: 16-03-2018", _FontVerdana));
            clclave.BorderWidth = 0;
            clclave.HorizontalAlignment = Element.ALIGN_LEFT;
            clclave.VerticalAlignment = Element.ALIGN_CENTER;

            // Añadimos las celdas a la tabla
            tbllogo.AddCell(clorden);
            tbllogo.AddCell(clclave);
            doc.Add(tbllogo);
            #endregion


            /*
                * 
                *      TABLA PRINCIPAL
                *      
                */
            #region Tabla Principal
            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(2);
            tblPrueba.WidthPercentage = 80;
            tblPrueba.SetWidths(new float[] { 3f, 10f });


            // Configuramos el título de las columnas de la tabla
            PdfPCell clesponsaledemtto = new PdfPCell(new Phrase("Responsable del Mtto.", _FontCalibri));
            clesponsaledemtto.BorderWidth = 0.5f;
            clesponsaledemtto.FixedHeight = 30f;
            clesponsaledemtto.HorizontalAlignment = Element.ALIGN_CENTER;
            clesponsaledemtto.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clesponsaledemtto);

            PdfPCell cledsonordaz = new PdfPCell(new Phrase("EDSON EDUARDO ORDAZ SANCHEZ", _FontCalibri));
            cledsonordaz.BorderWidth = 0.5f;
            cledsonordaz.HorizontalAlignment = Element.ALIGN_CENTER;
            cledsonordaz.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(cledsonordaz);

            PdfPCell clnombreusuario = new PdfPCell(new Phrase("Nombre de Usuario", _FontCalibri));
            clnombreusuario.BorderWidth = 0.5f;
            clnombreusuario.FixedHeight = 30f;
            clnombreusuario.HorizontalAlignment = Element.ALIGN_CENTER;
            clnombreusuario.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clnombreusuario);

            PdfPCell clnm = new PdfPCell(new Phrase(Orden.Usuario, _FontCalibri));
            clnm.BorderWidth = 0.5f;
            clnm.FixedHeight = 30f;
            clnm.HorizontalAlignment = Element.ALIGN_CENTER;
            clnm.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clnm);

            PdfPCell clemp = new PdfPCell(new Phrase("Empresa", _FontCalibri));
            clemp.BorderWidth = 0.5f;
            clemp.FixedHeight = 30f;
            clemp.HorizontalAlignment = Element.ALIGN_CENTER;
            clemp.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clemp);

            PdfPCell clempre = new PdfPCell(new Phrase(Orden.empresa2, _FontCalibri));
            clempre.BorderWidth = 0.5f;
            clempre.FixedHeight = 30f;
            clempre.HorizontalAlignment = Element.ALIGN_CENTER;
            clempre.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clempre);

            PdfPCell clbase = new PdfPCell(new Phrase("Base", _FontCalibri));
            clbase.BorderWidth = 0.5f;
            clbase.FixedHeight = 30f;
            clbase.HorizontalAlignment = Element.ALIGN_CENTER;
            clbase.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clbase);

            PdfPCell clba = new PdfPCell(new Phrase(Orden.base2, _FontCalibri));
            clba.BorderWidth = 0.5f;
            clba.FixedHeight = 30f;
            clba.HorizontalAlignment = Element.ALIGN_CENTER;
            clba.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clba);

            PdfPCell cldepar = new PdfPCell(new Phrase("Departamento", _FontCalibri));
            cldepar.BorderWidth = 0.5f;
            cldepar.FixedHeight = 30f;
            cldepar.HorizontalAlignment = Element.ALIGN_CENTER;
            cldepar.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(cldepar);

            PdfPCell clde = new PdfPCell(new Phrase(Orden.depa2, _FontCalibri));
            clde.BorderWidth = 0.5f;
            clde.FixedHeight = 30f;
            clde.HorizontalAlignment = Element.ALIGN_CENTER;
            clde.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clde);

            PdfPCell clequi = new PdfPCell(new Phrase("Equipo", _FontCalibri));
            clequi.BorderWidth = 0.5f;
            clequi.FixedHeight = 30f;
            clequi.HorizontalAlignment = Element.ALIGN_CENTER;
            clequi.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clequi);

            PdfPCell clequ = new PdfPCell(new Phrase(Orden.Tipo, _FontCalibri));
            clequ.BorderWidth = 0.5f;
            clequ.FixedHeight = 30f;
            clequ.HorizontalAlignment = Element.ALIGN_CENTER;
            clequ.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clequ);

            PdfPCell clmarca = new PdfPCell(new Phrase("Marca", _FontCalibri));
            clmarca.BorderWidth = 0.5f;
            clmarca.FixedHeight = 30f;
            clmarca.HorizontalAlignment = Element.ALIGN_CENTER;
            clmarca.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clmarca);

            PdfPCell clmar = new PdfPCell(new Phrase(Orden.Marca, _FontCalibri));
            clmar.BorderWidth = 0.5f;
            clmar.FixedHeight = 30f;
            clmar.HorizontalAlignment = Element.ALIGN_CENTER;
            clmar.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clmar);

            PdfPCell clmodelo = new PdfPCell(new Phrase("Modelo", _FontCalibri));
            clmodelo.BorderWidth = 0.5f;
            clmodelo.FixedHeight = 30f;
            clmodelo.HorizontalAlignment = Element.ALIGN_CENTER;
            clmodelo.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clmodelo);

            PdfPCell clmod = new PdfPCell(new Phrase(Orden.Modelo, _FontCalibri));
            clmod.BorderWidth = 0.5f;
            clmod.FixedHeight = 30f;
            clmod.HorizontalAlignment = Element.ALIGN_CENTER;
            clmod.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clmod);

            PdfPCell clserie = new PdfPCell(new Phrase("Número de serie", _FontCalibri));
            clserie.BorderWidth = 0.5f;
            clserie.FixedHeight = 30f;
            clserie.HorizontalAlignment = Element.ALIGN_CENTER;
            clserie.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clserie);

            PdfPCell clser = new PdfPCell(new Phrase(Orden.NumerodeSerie, _FontCalibri));
            clser.BorderWidth = 0.5f;
            clser.FixedHeight = 30f;
            clser.HorizontalAlignment = Element.ALIGN_CENTER;
            clser.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clser);

            PdfPCell clactivo = new PdfPCell(new Phrase("Número de activo", _FontCalibri));
            clactivo.BorderWidth = 0.5f;
            clactivo.FixedHeight = 30f;
            clactivo.HorizontalAlignment = Element.ALIGN_CENTER;
            clactivo.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clactivo);

            PdfPCell clsact = new PdfPCell(new Phrase(no_activo, _FontCalibri));
            clsact.BorderWidth = 0.5f;
            clsact.FixedHeight = 30f;
            clsact.HorizontalAlignment = Element.ALIGN_CENTER;
            clsact.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblPrueba.AddCell(clsact);

            doc.Add(tblPrueba);
            #endregion

            /*
                * 
                *          TABLA SOFTWARE
                *          
                */
            #region Tabla de Fechas y Horas
            doc.Add(new Paragraph("\n"));

            PdfPTable tblswhw = new PdfPTable(4);
            tblswhw.WidthPercentage = 80;
            tblswhw.SetWidths(new float[] { 3f, 3f, 3f, 3f });


            // Configuramos el título de las columnas de la tabla
            PdfPCell clsoftware = new PdfPCell(new Phrase("Software", _FontCalibri));
            clsoftware.BorderWidth = 0.5f;
            clsoftware.FixedHeight = 30f;
            clsoftware.Colspan = 2;
            clsoftware.HorizontalAlignment = Element.ALIGN_CENTER;
            clsoftware.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clsoftware);


            PdfPCell clhardware = new PdfPCell(new Phrase("Hardware", _FontCalibri));
            clhardware.BorderWidth = 0.5f;
            clhardware.FixedHeight = 30f;
            clhardware.Colspan = 2;
            clhardware.HorizontalAlignment = Element.ALIGN_CENTER;
            clhardware.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clhardware);


            PdfPCell clfhims = new PdfPCell(new Phrase("Fecha y hora de\ninicio de\nMantenimiento", _FontCalibri));
            clfhims.BorderWidth = 0.5f;
            clfhims.FixedHeight = 50f;
            clfhims.HorizontalAlignment = Element.ALIGN_CENTER;
            clfhims.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clfhims);


            PdfPCell clfhims2 = new PdfPCell(new Phrase(Orden.fecha_inicio + "\n" + Orden.hora_inicio, _FontCalibri));
            clfhims2.BorderWidth = 0.5f;
            clfhims2.FixedHeight = 50f;
            clfhims2.HorizontalAlignment = Element.ALIGN_CENTER;
            clfhims2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clfhims2);


            PdfPCell clfhimh = new PdfPCell(new Phrase("Fecha y hora de \ninicio de\nMantenimiento", _FontCalibri));
            clfhimh.BorderWidth = 0.5f;
            clfhimh.FixedHeight = 50f;
            clfhimh.HorizontalAlignment = Element.ALIGN_CENTER;
            clfhimh.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clfhimh);


            PdfPCell clfhimh2 = new PdfPCell(new Phrase(Orden.fecha_inicio + "\n" + Orden.hora_inicio, _FontCalibri));
            clfhimh2.BorderWidth = 0.5f;
            clfhimh2.FixedHeight = 50f;
            clfhimh2.HorizontalAlignment = Element.ALIGN_CENTER;
            clfhimh2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clfhimh2);


            PdfPCell clfhfms = new PdfPCell(new Phrase("Fecha y hora de\ntermino de\nMantenimiento", _FontCalibri));
            clfhfms.BorderWidth = 0.5f;
            clfhfms.FixedHeight = 50f;
            clfhfms.HorizontalAlignment = Element.ALIGN_CENTER;
            clfhfms.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clfhfms);


            PdfPCell clfhfms2 = new PdfPCell(new Phrase(Orden.fecha_termino + "\n" + Orden.hora_termino, _FontCalibri));
            clfhfms2.BorderWidth = 0.5f;
            clfhfms2.FixedHeight = 50f;
            clfhfms2.HorizontalAlignment = Element.ALIGN_CENTER;
            clfhfms2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clfhfms2);


            PdfPCell clfhfmh = new PdfPCell(new Phrase("Fecha y hora de\ntermino de\nMantenimiento", _FontCalibri));
            clfhfmh.BorderWidth = 0.5f;
            clfhfmh.FixedHeight = 50f;
            clfhfmh.HorizontalAlignment = Element.ALIGN_CENTER;
            clfhfmh.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clfhfmh);


            PdfPCell clfhfmh2 = new PdfPCell(new Phrase(Orden.fecha_termino + "\n" + Orden.hora_termino, _FontCalibri));
            clfhfmh2.BorderWidth = 0.5f;
            clfhfmh2.FixedHeight = 50f;
            clfhfmh2.HorizontalAlignment = Element.ALIGN_CENTER;
            clfhfmh2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clfhfmh2);


            PdfPCell clobservaciones = new PdfPCell(new Phrase("Observaciones", _FontCalibri));
            clobservaciones.BorderWidth = 0.5f;
            clobservaciones.FixedHeight = 40f;
            clobservaciones.HorizontalAlignment = Element.ALIGN_CENTER;
            clobservaciones.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clobservaciones);


            PdfPCell clobservaciones2 = new PdfPCell(new Phrase(Orden.observaciones2, _FontCalibri));
            clobservaciones2.BorderWidth = 0.5f;
            clobservaciones2.FixedHeight = 40f;
            clobservaciones2.Colspan = 3;
            clobservaciones2.HorizontalAlignment = Element.ALIGN_CENTER;
            clobservaciones2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblswhw.AddCell(clobservaciones2);

            doc.Add(tblswhw);
            #endregion

            /*
                * 
                *     TABLA DE FIRMA
                *     
                */

            #region Tabla Firma
            //doc.Add(new Paragraph("\n"));


            PdfPTable tblfirma = new PdfPTable(2);
            tblfirma.WidthPercentage = 80;
            tblfirma.SetWidths(new float[] { 5f, 5f });






            iTextSharp.text.Image img9 = iTextSharp.text.Image.GetInstance(Resources.firma2, System.Drawing.Imaging.ImageFormat.Png);
            img9.ScalePercent(20f);
            PdfPCell clfirma = new PdfPCell();
            clfirma.AddElement(img9);
            clfirma.BorderWidth = 0;
            //clfirma.PaddingLeft = 105;
            clfirma.PaddingLeft = 0;
            clfirma.PaddingBottom = 0;
            clfirma.HorizontalAlignment = Element.ALIGN_CENTER;
            clfirma.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblfirma.AddCell(clfirma);

            _FontCalibriUnerline.SetStyle(4);
            PdfPCell clfirmatecnico55 = new PdfPCell(new Phrase(" ", _FontCalibriUnerline));
            //clsoftware.FixedHeight = 30f;
            clfirmatecnico55.PaddingTop = 0;
            clfirmatecnico55.BorderWidth = 0;
            clfirmatecnico55.HorizontalAlignment = Element.ALIGN_CENTER;
            clfirmatecnico55.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblfirma.AddCell(clfirmatecnico55);

            _FontCalibriUnerline.SetStyle(4);
            PdfPCell clfirmatecnico = new PdfPCell(new Phrase("EDSON EDUARDO ORDAZ SANCHEZ", _FontCalibriUnerline));
            //clsoftware.FixedHeight = 30f;
            clfirmatecnico.PaddingTop = 0;
            clfirmatecnico.BorderWidth = 0;
            clfirmatecnico.HorizontalAlignment = Element.ALIGN_CENTER;
            clfirmatecnico.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblfirma.AddCell(clfirmatecnico);

            _FontCalibriUnerline.SetStyle(4);
            PdfPCell clfirmatecnico2 = new PdfPCell(new Phrase(Orden.Usuario, _FontCalibriUnerline));
            //clsoftware.FixedHeight = 30f;
            clfirmatecnico2.PaddingTop = 0;
            clfirmatecnico2.BorderWidth = 0;
            clfirmatecnico2.HorizontalAlignment = Element.ALIGN_CENTER;
            clfirmatecnico2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblfirma.AddCell(clfirmatecnico2);


            PdfPCell clfirmatecnicolin = new PdfPCell(new Phrase("NOMBRE Y FIRMA DEL TECNICO", _FontCalibri));
            //clsoftware.FixedHeight = 30f;
            clfirmatecnicolin.BorderWidth = 0;
            clfirmatecnicolin.HorizontalAlignment = Element.ALIGN_CENTER;
            clfirmatecnicolin.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblfirma.AddCell(clfirmatecnicolin);

            PdfPCell clfirmatecnicolin2 = new PdfPCell(new Phrase("NOMBRE Y FIRMA DEL USUARIO", _FontCalibri));
            //clsoftware.FixedHeight = 30f;
            clfirmatecnicolin2.BorderWidth = 0;
            clfirmatecnicolin2.HorizontalAlignment = Element.ALIGN_CENTER;
            clfirmatecnicolin2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblfirma.AddCell(clfirmatecnicolin2);


            doc.Add(tblfirma);
            #endregion

            doc.Close();
            writer.Close();


            if (Buscar_Correo.descargar == true)
            {
                try
                {
                    File.Copy(temparchivo + archivo, guardardocumento);
                    MessageBox.Show("Orden de trabajo descargada", "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Error al descargar orden de trabajo\n\nMensaje: " + ex.Message, "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                #region EnvioDeCorreoElectronico
                /*
                * 
                *      ENVIO DE CORREO ELECTRONICO
                *      
                */

                
                int NoDigits = 4;
                Random rnd = new Random();
                String nip = rnd.Next((int)Math.Pow(10, (NoDigits - 1)), (int)Math.Pow(10, NoDigits) - 1).ToString();
                int mid = 0;
                int xid = database.xid_nip;

                try
                {
                    using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                    {
                        conexion.Open();
                        string sqlIns = "INSERT INTO " + database.tabla_mantenimientosprev + " (xid, nip, fecha_alta, estatus, tecnico, correo)" +
                                " VALUES (@xid, @nip, @fecha_alta, @estatus, @tecnico, @correo)";
                        SqlCommand cmdIns = new SqlCommand(sqlIns, conexion);
                        cmdIns.Parameters.Add("@xid", xid);
                        cmdIns.Parameters.Add("@nip", nip);
                        cmdIns.Parameters.Add("@fecha_alta", DateTime.Now);
                        cmdIns.Parameters.Add("@estatus", "0");
                        cmdIns.Parameters.Add("@tecnico", database.useruid);
                        cmdIns.Parameters.Add("@correo", Orden.correoelectronico);

                        cmdIns.ExecuteNonQuery();
                        cmdIns.Parameters.Clear();
                        cmdIns.CommandText = "SELECT @@IDENTITY";

                        mid = Convert.ToInt32(cmdIns.ExecuteScalar());

                        cmdIns.Dispose();
                        cmdIns = null;
                    }
                }
                catch(Exception error)
                {
                    MessageBox.Show("Error al guardar mantenimiento en la base de datos.\n\nMensaje: " + error.Message, "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
                MailMessage mailMessage = new MailMessage();
                MailAddressCollection to = mailMessage.To;
                object[] obj = new object[1] { Orden.correoelectronico };
                object[] array = obj;
                bool[] obj2 = new bool[1] { true };
                bool[] array2 = obj2;
                NewLateBinding.LateCall(to, null, "Add", obj, null, null, obj2, IgnoreReturn: true);
                mailMessage.Bcc.Add("mantenimento.preventivo@unne.com.mx");
                mailMessage.From = new MailAddress("mantenimento.preventivo@unne.com.mx");
                mailMessage.Subject = "Mantenimiento Preventivo";
                mailMessage.Body = "<span style=\"font-family:Verdana; font-size: 10pt;\">Mantenimiento preventivo realizado" +
                            "<br>Favor de ingresar a la siguiente liga para validar el mantenimiento realizado en su equipo de cómputo.<br>" +
                            "<br><b>URL:</b> <a href=\"http://148.223.153.37:8086/" + mid + "/" + nip + "\">http://148.223.153.37:8086/" + mid + "</a>" +
                            "<br><b>NIP:</b> " + nip +
                            "</span><br><b>" +
                            "<span style=\"font-family: Verdana; font-size: 9pt; color: #FF0000; \"><br><br> <b>Nota: Favor de <u>no</u> contestar a este correo</b></span>";
                mailMessage.Attachments.Add(new Attachment(GetStreamFile(temparchivo + archivo), Path.GetFileName(temparchivo + archivo), "application/pdf"));
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "189.254.9.189";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("mpreventivo", "Corpame*2013");
                try
                {
                    smtpClient.Send(mailMessage);
                    MessageBox.Show("Orden de trabajo enviada", "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show("Error al enviar orden de trabajo\n\nMensaje: " + ex.Message, "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*
                *  fin de envio
                */
                #endregion
          
            }

            File.Delete(temparchivo + archivo);
        }

        private void Enviandopdf_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}

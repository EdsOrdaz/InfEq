using System;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static InfEq.Datos;

namespace InfEq
{
    class xml
    {
        public static string generar(String NM,String Marca, String Modelo, String Tipo, String Ram, String ddt, String ddl, String so, String procesador, 
                                     String arquitectura, String numserie, String Depa, String localidad, String Usuario, String licenciaso, String empresa,
                                     String fechainicio, String fechatermino, String horainicio, String horatermino, String observaciones, int mantenimiento)
        {
            String archivo = Data.Tipo() + "_" + NM + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss", CultureInfo.InvariantCulture) + ".xml";


            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "XML-File | *.xml";
            save.FileName = archivo;
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    XmlTextWriter writer;

                    writer = new XmlTextWriter(save.FileName, Encoding.UTF8);
                    //writer = new XmlTextWriter(archivo, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartDocument();

                    writer.WriteStartElement("InfEq");


                    writer.WriteStartElement("DatosPC");
                    writer.WriteElementString("Version", database.versionxml);
                    writer.WriteElementString("NombreEquipo", NM);
                    writer.WriteElementString("Marca", Marca);
                    writer.WriteElementString("Modelo", Modelo);
                    writer.WriteElementString("Usuario", Data.funcion_wmi("Win32_ComputerSystem", "UserName"));
                    writer.WriteElementString("Tipo", Tipo);
                    writer.WriteElementString("RAM", Ram);

                    writer.WriteStartElement("DiscoDuro");
                    writer.WriteElementString("DDTotal", ddt);
                    writer.WriteElementString("DDLibre", ddl);
                    writer.WriteEndElement();

                    writer.WriteElementString("SistemaOperativo", so);
                    writer.WriteElementString("LicenciaSO", licenciaso);
                    writer.WriteElementString("Procesador", procesador);
                    writer.WriteElementString("Arquitectura", arquitectura);
                    writer.WriteElementString("NumerodeSerie", numserie);


                    writer.WriteStartElement("DatosUser");
                    writer.WriteElementString("Empresa", empresa);
                    writer.WriteElementString("Departamento", Depa);
                    writer.WriteElementString("Base", localidad);
                    writer.WriteElementString("Usuario", Usuario);
                    writer.WriteEndElement();

                    writer.WriteStartElement("MacAddress");

                    IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface adapter in nics)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        writer.WriteStartElement("Interfase");
                        writer.WriteElementString("Nombre", adapter.Description.ToString());
                        String mac = string.Join(":", (from z in adapter.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                        mac = string.IsNullOrEmpty(mac) ? "Sin Datos" : mac;
                        writer.WriteElementString("Mac", mac);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();


                    writer.WriteElementString("FechaInicio", fechainicio);
                    writer.WriteElementString("HoraInicio", horainicio);
                    writer.WriteElementString("FechaTermino", fechatermino); 
                    writer.WriteElementString("HoraTermino", horatermino);

                    writer.WriteElementString("Fecha", DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    writer.WriteElementString("Hora", DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture));

                    writer.WriteElementString("Observaciones", observaciones);
                    writer.WriteElementString("Mantenimiento", mantenimiento.ToString());

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();


                    writer.Flush();
                    writer.Close();
                    MessageBox.Show("XML Generado", "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error el generar XML. \n\nError: " + ex.Message, "Error al guardar");
                }
            }
            return "";
        }
    }
}

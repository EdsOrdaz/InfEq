using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace InfEq
{
    class SubirXML
    {
        public static List<List<String>> lista_archivos = new List<List<String>>();
        public static List<List<String>> lista_macs = new List<List<String>>();

        public static List<String> errorfile = new List<String>();
        public static int numarchivos = 0;

        public static String[,,] maqs = new String[11,11,2];

        //contador de los xml
        public static int contar = 0;

        public static void verificarxml(String path)
        {
            String empresa = "";
            String departamento = "";
            String bbase = "";
            String nombreusuario = "";
            String version = "";
            String filename = path.Split('\\').Last();
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);

                XmlNodeList personas = xDoc.GetElementsByTagName("InfEq");
                XmlNodeList lista = ((XmlElement)personas[0]).GetElementsByTagName("DatosPC");

                foreach (XmlElement nodo in lista)
                {
                    XmlNodeList nDatosUser = nodo.GetElementsByTagName("DatosUser");
                    foreach (XmlElement usuariodatos in nDatosUser)
                    {
                        XmlNodeList nEmpresa = usuariodatos.GetElementsByTagName("Empresa");
                        XmlNodeList nNombreUser = usuariodatos.GetElementsByTagName("Usuario");
                        XmlNodeList nDepartamento = usuariodatos.GetElementsByTagName("Departamento");
                        XmlNodeList nBase = usuariodatos.GetElementsByTagName("Base");
                        departamento = nDepartamento[0].InnerText;
                        bbase = nBase[0].InnerText;
                        nombreusuario = nNombreUser[0].InnerText;
                        empresa = nEmpresa[0].InnerText;
                    }
                    XmlNodeList nNombre = nodo.GetElementsByTagName("NombreEquipo");
                    XmlNodeList nMarca = nodo.GetElementsByTagName("Marca");
                    XmlNodeList nModelo = nodo.GetElementsByTagName("Modelo");
                    XmlNodeList nUsuario = nodo.GetElementsByTagName("Usuario");
                    XmlNodeList nTipo = nodo.GetElementsByTagName("Tipo");
                    XmlNodeList nRam = nodo.GetElementsByTagName("RAM");
                    XmlNodeList nSo = nodo.GetElementsByTagName("SistemaOperativo");
                    XmlNodeList nlicenciaso = nodo.GetElementsByTagName("LicenciaSO");
                    XmlNodeList nprocesador = nodo.GetElementsByTagName("Procesador");
                    XmlNodeList nArquitectura = nodo.GetElementsByTagName("Arquitectura");
                    XmlNodeList nNumserie = nodo.GetElementsByTagName("NumerodeSerie");
                    XmlNodeList nFecha = nodo.GetElementsByTagName("Fecha");
                    XmlNodeList nHora = nodo.GetElementsByTagName("Hora");
                    XmlNodeList nDdtotal = nodo.GetElementsByTagName("DDTotal");
                    XmlNodeList nDdlibre = nodo.GetElementsByTagName("DDLibre");
                    XmlNodeList nFechainicio = nodo.GetElementsByTagName("FechaInicio");
                    XmlNodeList nHorainicio = nodo.GetElementsByTagName("HoraInicio");
                    XmlNodeList nFechatermino = nodo.GetElementsByTagName("FechaTermino");
                    XmlNodeList nHoratermino = nodo.GetElementsByTagName("HoraTermino");
                    XmlNodeList nObservaciones = nodo.GetElementsByTagName("Observaciones");
                    XmlNodeList nMantenimiento = nodo.GetElementsByTagName("Mantenimiento");
                    try
                    {
                        XmlNodeList nVersion = nodo.GetElementsByTagName("Version");
                        version = nVersion[0].InnerText;
                    }
                    catch (Exception)
                    {
                        errorfile.Add(filename);
                        MessageBox.Show("El archivo "+filename+" no cuenta con una version registrada.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if(version != database.versionxml)
                    {
                        errorfile.Add(filename);
                        MessageBox.Show("El archivo " + filename + " cuenta con una version diferente\n\nVersion del archivo: "+version+"\nVersion actual: "+database.versionxml, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int nummacs = 1;
                    int contma = 1;
                    //macs
                    XmlNodeList macs = nodo.GetElementsByTagName("MacAddress");
                    foreach (XmlElement nodomac in macs)
                    {
                        XmlNodeList nMac = nodomac.GetElementsByTagName("Interfase");
                        foreach (XmlElement nodointerfase in nMac)
                        {
                            XmlNodeList nInterfase = nodointerfase.GetElementsByTagName("Nombre");
                            XmlNodeList nMacAddress = nodointerfase.GetElementsByTagName("Mac");

                            String[] nn = new String[2];
                            nn[0] = nInterfase[0].InnerText;
                            nn[1] = nMacAddress[0].InnerText;

                            maqs[contar,0,0] = nummacs.ToString();
                            maqs[contar,0,1] = nummacs.ToString();
                            maqs[contar,contma,0] = nInterfase[0].InnerText;
                            maqs[contar,contma,1] = nMacAddress[0].InnerText;

                            nummacs++;
                            contma++;
                        }
                    }

                    string[] words = nFechainicio[0].InnerText.Split('/');

                    lista_archivos.Add(new List<String>() {
                        nNombre[0].InnerText, 	//0
                        nMarca[0].InnerText,	//1
                        nModelo[0].InnerText,	//2
                        nUsuario[0].InnerText,	//3
                        nTipo[0].InnerText,	//4
                        nRam[0].InnerText,	//5
                        nSo[0].InnerText,	//6
                        nlicenciaso[0].InnerText,	//7
                        nprocesador[0].InnerText,	//8
                        nArquitectura[0].InnerText,	//9
                        nNumserie[0].InnerText,	//10
                        nFecha[0].InnerText,	//11
                        nHora[0].InnerText,	//12
                        nDdtotal[0].InnerText,	//13
                        nDdlibre[0].InnerText,	//14
                        nFechainicio[0].InnerText,	//15
                        nHorainicio[0].InnerText,	//16
                        nFechatermino[0].InnerText,	//17
                        nHoratermino[0].InnerText,	//18
                        nObservaciones[0].InnerText,	//19
                        departamento,	//20
                        bbase,	//21
                        nombreusuario,	//22
                        empresa,     //23
                        version,     //24
                        database.useruid.ToString(),    //25
                        DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),  //26 FECHA
                        DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture),  //27 HORA
                        DateTime.Now.ToString(words[1], CultureInfo.InvariantCulture),  //28 MES
                        DateTime.Now.ToString(words[2], CultureInfo.InvariantCulture),  //29 AÑO
                        nMantenimiento[0].InnerText	//30 Tipo de mantenimiento
                    });
                    contar++;
                }
            }
            catch(Exception ex)
            {
                errorfile.Add(filename);
                MessageBox.Show("Error al cargar el archivo\n"+filename+"\n\nMensaje de error: " + ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            numarchivos++;
        }

        public static void leer()
        {

            foreach (String uu in maqs)
            {
                String dee = uu;
            }
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is SubirArchivos);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is SubirArchivos);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                SubirArchivos subirarchivos = new SubirArchivos();
                subirarchivos.Show();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace InfEq
{
    class Datos
    {
        //Obtener Memoria RAM
        public static String PathInf = "InfEq";
        public static String PathOrden = "InfEq/orden";
        public static String Pathimg = "logo.jpg";
        public static class Data
        {

            [DllImport("psapi.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetPerformanceInfo([Out] out InformacionRendimiento PerformanceInformation, [In] int Size);

            /// Estructura que nos sera regresada por el metodo GetPerformanceInfo
            [StructLayout(LayoutKind.Sequential)]
            public struct InformacionRendimiento
            {
                public int Size;
                public IntPtr CommitTotal;
                public IntPtr CommitLimit;
                public IntPtr CommitPeak;
                public IntPtr PhysicalTotal;
                public IntPtr PhysicalAvailable;
                public IntPtr SystemCache;
                public IntPtr KernelTotal;
                public IntPtr KernelPaged;
                public IntPtr KernelNonPaged;
                public IntPtr PageSize;
                public int HandlesCount;
                public int ProcessCount;
                public int ThreadCount;
            }

            #region HELPERS

            public static Int64 GetRamTotal()
            {
                InformacionRendimiento pi = new InformacionRendimiento();
                if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                {
                    return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
                }
                else
                {
                    return -1;
                }

            }

            #endregion


            //Obtener Disco Duro
            public static string DiscoDuro(int n = 1)
            {
                long EspacioTotal = 0, EspacioDisponible = 0;
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady && drive.Name == "C:\\")
                    {
                        EspacioDisponible = ((drive.AvailableFreeSpace / 1024) / 1024) / 1024;
                        EspacioTotal = ((drive.TotalSize / 1024) / 1024) / 1024;
                    }
                }
                if (n == 1)
                {
                    return EspacioTotal.ToString();
                }
                else
                {
                    return EspacioDisponible.ToString();
                }
            }

            public static string funcion_wmi(String database, String dato)
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;


                ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName.ToString() + "\\root\\cimv2", options);
                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM "+database);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                String cadena="";
                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    cadena = m[dato].ToString();
                }
                dato = null;
                database = null;
                if(cadena.Equals(null))
                {
                    return "Error";
                }
                return cadena;
            }

            //Obtener SO
            public static string SistemaOperativo()
            {
                String[] data = new string[] {
                    "Win32_OperatingSystem",
                    "caption",
                    "Sin SO"
                };
                return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
            }

            //Obtener Procesador
            public static string Procesador()
            {
                 String[] data = new string[] {
                    "Win32_Processor",
                    "Name",
                    "Sin Resultado"
                };
                return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
            }

            //Obtener Arquitectura
            public static string Arquitectura()
            {
                 String[] data = new string[] {
                    "Win32_OperatingSystem",
                    "OSArchitecture",
                    "Sin Resultado"
                };
                return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
            }

            //Numero de Serie
            public static String NumSerie()
            {
                String[] data = new string[] {
                   "Win32_BIOS",
                    "SerialNumber",
                    "Sin Resultado"
                };
                return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
            }

            //Modelo del equipo
            public static string Modelo()
            {
                String[] data = new string[] {
                    "Win32_ComputerSystem",
                    "Model",
                    "Sin Resultado"
                };
                return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
            }

            //Marca del equipo
            public static string Marca()
            {
                String[] data = new string[] {
                    "Win32_ComputerSystem",
                    "Manufacturer",
                    "Sin Resultado"
                };
                return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
            }

            //Familia del equipo
            public static string Familia()
            {
                String[] data = new string[] {
                    "Win32_ComputerSystem",
                    "SystemFamily",
                    "Sin Resultado"
                };
                return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
            }
            public static string Descripcion()
            {
                String[] data = new string[] {
                    "Win32_OperatingSystem",
                    "Description",
                    "Sin Resultado"
                };
                return (funcion_wmi(data[0], data[1]) == "") ? data[2] : funcion_wmi(data[0], data[1]);
            }

            //TIPO
            public static String Tipo()
            {
                return (SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.NoSystemBattery) ? "CPU" : "LAPTOP";
            }
        }
    }
}

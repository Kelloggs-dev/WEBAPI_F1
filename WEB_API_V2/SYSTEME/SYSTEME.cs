using Microsoft.Win32;
using System.Management;
using System.Net;

#nullable disable

namespace WEB_API_V2.SYSTEME
{
    public static class SYSTEME
    {
        public static string Get_Date()
        {
            return DateTime.Now.ToString();
        }


        // Les fonctions suivante c'etait juste pour m'amuser
        public static string Get_Ip()
        {
            string Host = Dns.GetHostName();

            string Ip = Dns.GetHostEntry(Host).AddressList[3].ToString();

            return $"{Host}\r\n{Ip}";
        }
        public static List<string> Get_Info_OS()
        {
#pragma warning disable CA1416 // Valider la compatibilité de la plateforme
            List<string> Info_OS = new();

            ManagementObjectSearcher OS = new("select * from Win32_OperatingSystem");
            OperatingSystem OS_V = Environment.OSVersion;
            Version ver = Environment.Version;

            foreach (var Information in OS.Get())
            {

                Info_OS.Add(Information["Caption"].ToString());

                Info_OS.Add(Information["OSArchitecture"].ToString());

            }

            Info_OS.Add(OS_V.ToString());
            Info_OS.Add(ver.ToString());

            return Info_OS;
#pragma warning restore CA1416 // Valider la compatibilité de la plateforme
        }
        public static string Get_Info_CPU()
        {
#pragma warning disable CA1416 // Valider la compatibilité de la plateforme
            var CPU_Name = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);



            return CPU_Name.GetValue("ProcessorNameString").ToString();
#pragma warning restore CA1416 // Valider la compatibilité de la plateforme
        }

    }
}

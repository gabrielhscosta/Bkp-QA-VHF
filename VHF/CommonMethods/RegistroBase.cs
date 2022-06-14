using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHF.CommonMethods
{
    public class RegistroBase
    {
        public RegistroBase()
        {

        }
        public static void RegistraBaseHomologacaoVhf(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\FrontOffice";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoVhfCaixa(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\VHFCaixa";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao_Login.CommonMethods
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

        public static void RegistraBaseHomologacaoCentralReservas(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\CentralReservas";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoEvento(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\Evento";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoFrontTurismo(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\FrontTurismo";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoGlobalCM(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\Global";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoSpa(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\SPA";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoSsd(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\SSD";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoTelefonia(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\Telefonia";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoTimeSharing(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\TimeSharing";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }
    }
}

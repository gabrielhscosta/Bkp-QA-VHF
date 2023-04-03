using Validacao_Login.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using Validacao_Login.TestCase.ST00_ValidaLoginModulos;

namespace Validacao_Login.Main
{
    [TestClass]
    public class SessaoMain : RegistroBase
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Diretorio aplicacao

        protected const string WinAppDriverUrl = "http://127.0.0.1:4723";
        protected const string dirAplicacaoVHF = @"C:\Totvs\Hoteis\VHF.exe";
        protected const string dirAplicacaoVHFCaixa = @"C:\Totvs\Hoteis\VHFCaixa.exe";
        protected const string dirAplicacaoCentralReservas = @"C:\Totvs\Hoteis\CentralReservas.exe";
        protected const string dirAplicacaoEvento = @"C:\Totvs\Hoteis\Evento.exe";
        protected const string dirAplicacaoFrontTurismo = @"C:\Totvs\Hoteis\FrontTurismo.exe";
        protected const string dirAplicacaoGlobal = @"C:\Totvs\Hoteis\GlobalCM.exe";
        protected const string dirAplicacaoSpa = @"C:\Totvs\Hoteis\SPA.exe";
        protected const string dirAplicacaoSsd = @"C:\Totvs\Hoteis\SSD.exe";
        protected const string dirAplicacaoTelefonia = @"C:\Totvs\Hoteis\Telefonia.exe";
        protected const string dirAplicacaoTimeSharing = @"C:\Totvs\Hoteis\TimeSharing.exe";

        #endregion

        public static WindowsDriver<WindowsElement> sessionVHF;
        public static WindowsDriver<WindowsElement> sessionVHFCaixa;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            #region Parametro base de dados

            RegistraBaseHomologacaoCentralReservas("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoEvento("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoFrontTurismo("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoGlobalCM("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoSpa("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoSsd("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoTelefonia("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoTimeSharing("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoVhf("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoVhfCaixa("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");

            #endregion

            //AppiumServiceBuilder appiumLocalService = new AppiumServiceBuilder();
            //appiumLocalService.UsingPort(4723).Build().Start();

            // *** Inicialização do módulo ***
        }

        [ClassCleanup]
        public static void TearDown()
        {
            if (sessionVHF != null)
            {
                sessionVHF.Close();
                sessionVHF.Quit();
                sessionVHF = null;
            }
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_Central_Reservas()
        {
            LoginCentralReservas loginCentral = new LoginCentralReservas();
            loginCentral.ValidaLoginCentralReservas();
            loginCentral.LoginCentralRTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_Evento()
        {
            LoginEvento loginEvento = new LoginEvento();
            loginEvento.ValidaLoginEvento();
            loginEvento.LoginEventoTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_Front_Turismo()
        {
            LoginFrontTurismo loginFrontTurismo = new LoginFrontTurismo();
            loginFrontTurismo.ValidaLoginFrontTurismo();
            loginFrontTurismo.LoginFrontTurismoTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_GlobalCM()
        {
            LoginGlobal loginGlobal = new LoginGlobal();
            loginGlobal.ValidaLoginGlobal();
            loginGlobal.LoginGlobalTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_Spa()
        {
            LoginSpa loginSpa = new LoginSpa();
            loginSpa.ValidaLoginSpa();
            loginSpa.LoginSpaTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_Ssd()
        {
            LoginSsd loginSsd = new LoginSsd();
            loginSsd.ValidaLoginSsd();
            loginSsd.LoginSsdTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_Telefonia()
        {
            LoginTelefonia loginTelefonia = new LoginTelefonia();
            loginTelefonia.ValidaLoginTelefonia();
            loginTelefonia.LoginTelefoniaTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_TimeSharing()
        {
            LoginTimeSharing loginTimeSharing = new LoginTimeSharing();
            loginTimeSharing.ValidaLoginTimeSharing();
            loginTimeSharing.LoginTsTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_VHF()
        {
            LoginVHF login = new LoginVHF();
            login.ValidaLoginVHF();
            login.LoginVHFTearDown();
        }

        [TestMethod, TestCategory("0 - Validar Login Modulos")]

        public void Login_VHF_Caixa()
        {
            LoginVHFCaixa loginCaixa = new LoginVHFCaixa();
            loginCaixa.ValidaLoginVHFCaixa();
        }
    }
}
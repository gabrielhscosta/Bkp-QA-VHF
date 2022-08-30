using VHF.CommonMethods;
using VHF.TestCase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHF.TestCase.ST00_ValidaLoginModulos;
using VHF.TestCase.ST01_ReservaIndividual;

namespace VHF.Main
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

        protected const string WinAppDriverUrl = "http://127.0.0.1:4723";
        private const string dirAplicacaoVHF = @"C:\Totvs\Hoteis\VHF.exe";
        protected const string dirAplicacaoVHFCaixa = @"C:\Totvs\Hoteis\VHFCaixa.exe";


        public static WindowsDriver<WindowsElement> sessionVHF;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            RegistraBaseHomologacaoVhf("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoVhfCaixa("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");

            //AppiumServiceBuilder appiumLocalService = new AppiumServiceBuilder();
            //appiumLocalService.UsingPort(4723).Build().Start();
           
            if (sessionVHF == null)
            {
                AppiumOptions options1 = new AppiumOptions();
                options1.AddAdditionalCapability("app", dirAplicacaoVHF);
                //sessionVHF = new WindowsDriver<WindowsElement>(appiumLocalService, options1);
                sessionVHF = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl), options1);
            }
        }

        [ClassCleanup]
        public static void TearDown()
        {
            if (sessionVHF != null)
            {
                //sessionVHF.Quit();
                //sessionVHF = null;
            }

        }

        [TestMethod, TestCategory("0 - Realizar Login")]

        public void Login_VHF()
        {
            LoginVHF login = new LoginVHF();
            login.ValidaLoginVHF();
        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN001_Reserva_Individual()
        {
       
            LoginVHF login = new LoginVHF();
            CN001 reserva = new CN001();
            login.ValidaLoginVHF();
            reserva.ReservaIndividual();

        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN003_ReservaIndividual_Com_Cliente_Contrato()
        {

            LoginVHF login = new LoginVHF();
            CN003 reserva = new CN003();
            login.ValidaLoginVHF();
            reserva.ReservaIndividual_Com_Cliente_Contrato();

        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN005_Reserva_Individual_Com_Hospede_Uso_Da_Casa()
        {
            LoginVHF login = new LoginVHF();
            CN005 reserva = new CN005();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualComHospedeUsoDaCasa();

        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN011_Reserva_Individual_Mais_De_Um_Hospede()
        {
            LoginVHF login = new LoginVHF();
            CN011 reserva = new CN011();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualMaisDeUmHospede();

        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN012_Reserva_Individual_Mais_De_Um_Hospede_Com_Crianca()
        {
            LoginVHF login = new LoginVHF();
            CN012 reserva = new CN012();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualMaisDeUmHospedeComCrianca();

        }

    }
}

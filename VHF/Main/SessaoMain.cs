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
using VHF.TestCase.ST02_OrcamentoReserva;

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
        protected const string dirAplicacaoVHF = @"C:\Totvs\Hoteis\VHF.exe";
        protected const string dirAplicacaoVHFCaixa = @"C:\Totvs\Hoteis\VHFCaixa.exe";


        public static WindowsDriver<WindowsElement> sessionVHF;
        public static WindowsDriver<WindowsElement> sessionVHFCaixa;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            RegistraBaseHomologacaoVhf("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoVhfCaixa("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");

            //AppiumServiceBuilder appiumLocalService = new AppiumServiceBuilder();
            //appiumLocalService.UsingPort(4723).Build().Start();

            // *** Inicialização do módulo ***

            AppiumOptions options1 = new AppiumOptions();
            options1.AddAdditionalCapability("app", dirAplicacaoVHF);
            //sessionVHF = new WindowsDriver<WindowsElement>(appiumLocalService, options1);
            sessionVHF = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl), options1);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            if (sessionVHF != null)
            {
                //sessionVHF.Close();
                //sessionVHF.Quit();
                sessionVHF = null;
            }

            if (sessionVHFCaixa != null)
            {
                //sessionVHFCaixa.Close();
                //sessionVHFCaixa.Quit();
                //sessionVHFCaixa = null;
            }

        }

        [TestMethod, TestCategory("0 - Realizar Login")]

        public void Login_VHF()
        {
            LoginVHF login = new LoginVHF();
            login.ValidaLoginVHF();
        }

        [TestMethod, TestCategory("0 - Realizar Login")]

        public void Login_VHF_Caixa()
        {
            LoginVHFCaixa loginCaixa = new LoginVHFCaixa();
            loginCaixa.ValidaLoginVHFCaixa();
        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN001_Reserva_Individual()
        {
       
            //LoginVHF login = new LoginVHF();
            CN001 reserva = new CN001();
            //login.ValidaLoginVHF();
            reserva.ReservaIndividual();
        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN002_ReservaIndividual_Com_Cliente_Contrato_Sem_Contrato()
        {

            //LoginVHF login = new LoginVHF();
            CN002 reserva = new CN002();
            //login.ValidaLoginVHF();
            reserva.ReservaIndividualComClienteSemContrato();
        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN003_ReservaIndividual_Com_Cliente_Contrato()
        {

            LoginVHF login = new LoginVHF();
            CN003 reserva = new CN003();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualComClienteContrato();
        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN004_Reserva_Individual_Com_Hospede_Cortesia()
        {

            LoginVHF login = new LoginVHF();
            CN004 reserva = new CN004();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualComHospedeCortesia();
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

        public void CN007_Reserva_Individual_Pelo_Grid_De_Disponibilidade()
        {
            LoginVHF login = new LoginVHF();
            CN007 reserva = new CN007();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualPeloGridDeDisponibilidade();
        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN008_Reserva_Individual_Pelo_Grid_De_Disponibilidade_Utilizando_Sugestao_Tarifaria()
        {
            LoginVHF login = new LoginVHF();
            CN008 reserva = new CN008();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualPeloGridDeDisponibilidadeUtilizandoSugestaoTarifaria();
        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN009_Reserva_Individual_Com_Direcionamento_De_Despesas()
        {
            LoginVHF login = new LoginVHF();
            CN009 reserva = new CN009();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualComDirecionamentoDeDespesas();
        }

        [TestMethod, TestCategory("1 - Reserva Individual")]

        public void CN010_Reserva_Individual_Validando_Slip()
        {
            LoginVHF login = new LoginVHF();
            CN010 reserva = new CN010();
            login.ValidaLoginVHF();
            reserva.ReservaIndividualValidandoSlip();
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

        [TestMethod, TestCategory("2 - Orçamento Reserva")]

        public void CN020_Alterar_Quantidade_De_Dias_Na_Reserva()
        {
            LoginVHF login = new LoginVHF();
            CN020 alterar = new CN020();
            login.ValidaLoginVHF();
            alterar.AlterarQuantidadeDiasReserva();

        }

        [TestMethod, TestCategory("2 - Orçamento Reserva")]

        public void CN021_Alterar_Quantidade_De_Hospesdes_Na_Reserva()
        {
            LoginVHF login = new LoginVHF();
            CN021 alterar = new CN021();
            login.ValidaLoginVHF();
            alterar.AlterarQuantidadeDeHospedes();

        }

        [TestMethod, TestCategory("2 - Orçamento Reserva")]
        public void CN022_Alterar_Tipo_De_UH_Na_Reserva()
        {
            LoginVHF login = new LoginVHF();
            CN022 alterar = new CN022();
            login.ValidaLoginVHF();
            alterar.AlterarTipoDeUHReserva();

        }

        [TestMethod, TestCategory("2 - Orçamento Reserva")]
        public void CN026_Entrada_De_Hospede()
        {
            LoginVHF login = new LoginVHF();
            CN026 alterar = new CN026();
            login.ValidaLoginVHF();
            alterar.EntradaDeHospede();
        }

        [TestMethod, TestCategory("2 - Orçamento Reserva")]
        public void CN027_Usar_Botao_Repetir_Da_Tela_De_Situacao_De_Reserva()
        {
            LoginVHF login = new LoginVHF();
            CN027 alterar = new CN027();
            login.ValidaLoginVHF();
            alterar.UsarBotaoRepetirDaTelaDeSituacaoDeReserva();
        }

        [TestMethod, TestCategory("2 - Orçamento Reserva")]
        public void CN029_Validar_Orcamento_Pela_Tela_De_Consulta_Geral_E_VHFCaixa()
        {
            LoginVHF login = new LoginVHF();
            CN029 alterar = new CN029();
            login.ValidaLoginVHF();
            alterar.ValidarOrcamentoPelaTelaDeConsultaGeralEVHFCaixa();
        }

        [TestMethod, TestCategory("2 - Orçamento Reserva")]
        public void CN210_Validar_EventoReserva_E_EventoHospede()
        {
            LoginVHF login = new LoginVHF();
            CN210 alterar = new CN210();
            login.ValidaLoginVHF();
            alterar.ValidarEventoReservaEEventoHospede();
        }

        [TestMethod, TestCategory("3 - Reserva Grupo")]
        public void CN030_Reserva_Grupo_Com_Conta_Master()
        {
            LoginVHF login = new LoginVHF();
            CN030 alterar = new CN030();
            login.ValidaLoginVHF();
            alterar.ReservaGrupoComContaMaster();
        }

        [TestMethod, TestCategory("3 - Reserva Grupo")]
        public void CN031_Reserva_Grupo_Com_Direcionamento_De_Despesas()
        {
            LoginVHF login = new LoginVHF();
            CN031 alterar = new CN031();
            login.ValidaLoginVHF();
            alterar.ReservaGrupoComDirecionamentoDeDespesas();
        }

        [TestMethod, TestCategory("3 - Reserva Grupo")]
        public void CN032_Validar_Anexo_Na_Reserva_De_Grupo()
        {
            LoginVHF login = new LoginVHF();
            CN032 alterar = new CN032();
            login.ValidaLoginVHF();
            alterar.ValidarAnexoNaReservaDeGrupo();
        }

        [TestMethod, TestCategory("3 - Reserva Grupo")]
        public void CN033_Validar_Slip_Na_Reserva_De_Grupo()
        {
            LoginVHF login = new LoginVHF();
            CN033 alterar = new CN033();
            login.ValidaLoginVHF();
            alterar.ValidarSlipNaReservaDeGrupo();
        }
        

    }
}

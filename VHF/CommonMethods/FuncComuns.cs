using System;
using System.Collections.Generic;
using VHF.Main;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VHF.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using OpenQA.Selenium.Appium;
using System.Threading;
using OpenQA.Selenium.Appium.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace VHF.CommonMethods
{
    public class FuncComuns : SessaoMain
    {
        public FuncComuns()
        {

        }

        AppObjects appObjects = new AppObjects();

        public static AppiumWebElement numRes;
        public static AppiumWebElement idRes;
        public static AppiumWebElement numResGrp;

        public void ChamarAtalho(string tecla1, string tecla2, string tecla3 = null, string tecla4 = null)
       {
            if (tecla4 != null)
            {
                Elementos.EncontraElementoTagName(sessionVHF, appObjects.tagMenuItem).SendKeys(Keys.Alt + tecla1 + tecla2 + tecla3 + tecla4);
            } 
            else if (tecla3 != null)
            {
                Elementos.EncontraElementoTagName(sessionVHF, appObjects.tagMenuItem).SendKeys(Keys.Alt + tecla1 + tecla2 + tecla3);
            }
            else
            {
                Elementos.EncontraElementoTagName(sessionVHF, appObjects.tagMenuItem);
                Elementos.EncontraElementoTagName(sessionVHF, appObjects.tagMenuItem).SendKeys(Keys.Alt + tecla1 + tecla2);
            }
       }

        public void InserirNumNoites(string qtdNoites)
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(9).SendKeys(qtdNoites);
        }

        public void InserirDatasEstada(string dataIni, string dataFim)
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDateTimePicker).ElementAt(2).SendKeys(dataIni);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDateTimePicker).ElementAt(1).SendKeys(dataFim);
        }

        public void PreencherUh(string botao,string UH)
        {
            Elementos.EncontraElementoName(sessionVHF, botao).Click();
            if (botao == "ocupado")
            {
                Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhEstadia);
                Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(UH);
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            }
            else if (botao == "cobrado")
            {
                Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhTarifa);
                Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(UH);
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            }
            else if (botao == "numero")
            {
                Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhQuarto);
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnSim).Click();
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            }
        }

        public void PreencherNumUh(string botao, string tipoUh)
        {
            Elementos.EncontraElementoName(sessionVHF, botao).Click();
            
            if (botao == "ocupado")
            {
                Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhEstadia);
                Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(tipoUh);
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            }
            else if (botao == "cobrado")
            {
                Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhTarifa);
                Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(tipoUh);
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            }

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnUhNumero).Click();
            
            Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhQuarto);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(9).SendKeys(appObjects.categUhStnd);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();
              
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            
        }

        public void InserirDadosHosp(string faixaEtaria = "adulto", string tipoDeHospede = "Particular")
        {
            var dadosHosp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(46).Click();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(19).SendKeys(dadosHosp.NomeFaker);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(20).SendKeys(dadosHosp.SobrenomeFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(18).SendKeys(dadosHosp.EmailFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(1).SendKeys(dadosHosp.TratamentoHosp);

            if (faixaEtaria == "crianca")
            {
                Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(0).Clear();
                Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(0).SendKeys("Crianca 1");
                Elementos.EncontraElementoName(sessionVHF, "Menor ou incapaz").Click();
                Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDateTimePicker).ElementAt(3).SendKeys("20/06/2020");
            }
            else
            {
                Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDateTimePicker).ElementAt(3).SendKeys(dadosHosp.DtNascFaker);

            }

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(2).Clear();
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(2).SendKeys(tipoDeHospede);

            if (tipoDeHospede == "Uso da Casa")
            {
                Elementos.EncontraElementoName(sessionVHF, "funcionario").Click();
                Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(0).SendKeys("CAMAREIRA 1");
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            }

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnCidade).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winSelecCidade);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(6).SendKeys(dadosHosp.CidadeFaker);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnIdioma).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winIdiomaHosp);
            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.idiomaHosp);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            var tmp = Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(46).Click();

            //Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).Last().Click();

        }

        public void InserirDadosHospDaReservaPeloGrid()
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(55).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.winDadosPrincipais);

            var dadosHosp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(19).SendKeys(dadosHosp.NomeFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(20).SendKeys(dadosHosp.SobrenomeFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(18).SendKeys(dadosHosp.EmailFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(1).SendKeys(dadosHosp.TratamentoHosp);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDateTimePicker).ElementAt(4).SendKeys(dadosHosp.DtNascFaker);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnCidade).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winSelecCidade);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(6).SendKeys(dadosHosp.CidadeFaker);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnIdioma).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winIdiomaHosp);
            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.idiomaHosp);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(55).Click();
        }

        public void SelecionarEmpresa()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.winDadosPrincipais);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(44).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.winSelecCliente);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(10).SendKeys(appObjects.docCliente);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
        }

        public void SelecionarContrato()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.winDadosPrincipais);

            Elementos.EncontraElementosName(sessionVHF, appObjects.btnContrato).ElementAt(2).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.winContratoCliente);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnOK).Click();
        }

        public void BuscarHospComHistoricoEstada()
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(46).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnDocHosp).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winSelecDocHosp);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(2).SendKeys(appObjects.docHospEstada);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(46).Click();

        }

        public void InserirSegmentoHospede(string tipoDeSegmento)
        {
            Elementos.EncontraElementoName(sessionVHF, "segmento").Click();
            Elementos.EncontraElementoName(sessionVHF, tipoDeSegmento).Click();
        }

        public void InserirMotivoDeDesconto()
        {
            Elementos.EncontraElementoName(sessionVHF, "Dados complementares").Click();
            Elementos.EncontraElementoName(sessionVHF, "motivo").Click();
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(0).SendKeys("AUTORIZADO PELA GERENCIA");
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            Elementos.EncontraElementoName(sessionVHF, "Dados principais").Click();
        }

        public void InserirMaisHospedes(string adulto, string cri1, string cri2)
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TDBEdit).ElementAt(2).SendKeys(adulto);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TDBEdit).ElementAt(1).SendKeys(cri1);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TDBEdit).ElementAt(0).SendKeys(cri2);

            Elementos.EncontraElementoName(sessionVHF, "Confirmação");
            Elementos.EncontraElementoName(sessionVHF, "Sim").Click();
        }

        public void InserirDocConfirmacao()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.winDocConfirmacaoRes);

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.docEmail);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            var emailConfirRes = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBEdit).ElementAt(7).SendKeys(emailConfirRes.EmailFaker);
        }

        public void InserirDocConfirmacaoDaReservaPeloGrid()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.winDocConfirmacaoRes);

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.docEmail);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            var emailConfirRes = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBEdit).ElementAt(9).SendKeys(emailConfirRes.EmailFaker);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
        }

        public void VisualizarOrcamentoRes()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.txtVisualOrcamento).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
        }

        public void VisualizarParteInferiorOrcamentoRes()
        {
            var oReserva = sessionVHF.FindElementByClassName(appObjects.scrTelaReservaIndiv);

            new Actions(sessionVHF).MoveToElement(oReserva, 808, 68).Click().Perform();

            Thread.Sleep(1000);

            new Actions(sessionVHF).MoveToElement(oReserva, 886, 268).Click().Perform();

            //"TfrmDadosOrcamento"
            //"frmDadosOrcamento"

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
        }

        public void AlertCartaoConsumo()
        {
            Thread.Sleep(3000);

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaMsgAtencao);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnNao).Click();
        }

        public void ValidarSituacaoRes()
        {

            Thread.Sleep(9000);

            Elementos.EncontraElementoName(sessionVHF, appObjects.winSitReserva);

            Debug.WriteLine($"*** Identificar janelas {sessionVHF.WindowHandles}");

            var winSitRes = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            winSitRes.Title.ToString();

            var sitRes = sessionVHF.FindElementByName(appObjects.winSitReserva);

            var editSitRes = sitRes.FindElementsByClassName(appObjects.TEdit);

            numRes = editSitRes.ElementAt(8);
            new Actions(sessionVHF).MoveToElement(numRes).DoubleClick().Perform();
            numRes.SendKeys(Keys.Control + "c");
            numRes.SendKeys(Keys.Control + "v");

            Console.WriteLine("Numero de Reserva Gerado: " + numRes.Text);
        }

        public void ValidarTelaPrincipalVhf()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSair).Click();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaPrincipal);
        }

        public void AbrirTelaConsultaGeral()
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(6).Click();

        }

        public void ConultarReserva()
        {
            Thread.Sleep(3000);

            Elementos.EncontraElementoName(sessionVHF, appObjects.winConsultaGeral);

            var editRes = sessionVHF.FindElementsByClassName(appObjects.TEdit);
            idRes = editRes.ElementAt(9);
            idRes.SendKeys(Keys.Control + "v");

            new Actions(sessionVHF).MoveToElement(idRes).DoubleClick().Perform();
            idRes.SendKeys(Keys.Control + "c");
                        
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();
        }
        
        public void AcessarReserva(string reserva)
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.winConsultaGeral);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(9).SendKeys(reserva);
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnEditar).Click();
        }

        public void InserirResGridDispo()
        {
            var gridDisp = sessionVHF.FindElementByClassName(appObjects.scrTelaPrincipal);

            var resDisp = gridDisp.FindElementByClassName(appObjects.scrTelaResDisp);

            var selecPeriodo = resDisp.FindElementByClassName(appObjects.scrTelaGridDisp);

            new Actions(sessionVHF).MoveToElement(selecPeriodo, 134, 105).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecPeriodo, 329, 105).Click().Perform();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaSugereTarifa);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSair).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnReservarGrid).Click();
        }

        public void InserirResGridDispoUtilizandoSugestaoTarifaria()
        {
            var gridDisp = sessionVHF.FindElementByClassName(appObjects.scrTelaPrincipal);

            var resDisp = gridDisp.FindElementByClassName(appObjects.scrTelaResDisp);

            var selecPeriodo = resDisp.FindElementByClassName(appObjects.scrTelaGridDisp);

            new Actions(sessionVHF).MoveToElement(selecPeriodo, 134, 105).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecPeriodo, 329, 105).Click().Perform();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaSugereTarifa);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnReservarGrid).Click();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaMsgAtencao);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnOK).Click();
        }

        public void InserirDirecioamentoDeDespesas()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnContaDirec).Click();

            Debug.WriteLine($"*** Identificar janelas {sessionVHF.WindowHandles}");

            var winDirecDesp = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            winDirecDesp.Manage().Window.Maximize();

            var selecDirecDesp = sessionVHF.FindElementByName(appObjects.winDirecDespesas);

            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 100).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 170).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 196).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 220).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 246).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 270).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 320).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 346).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 370).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 396).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 420).Click().Perform();
            
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 350, 280).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 396, 176).Click().Perform();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
        }

        public void VisualizarSlipDeReserva()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSlip).Click();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.winSlipReserva);

            Elementos.EncontraElementoName(sessionVHF, appObjects.rbExterno).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnVisualizar).Click();
        }

        public void EntradaHospede()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnEntradaHosp).Click();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaEntradaHosp);

            var dadosHosp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(6).SendKeys(dadosHosp.SobrenomeFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(5).SendKeys(dadosHosp.NomeFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(3).SendKeys(appObjects.tipoHospPart);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(1).SendKeys(dadosHosp.TratamentoHosp);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(2).SendKeys(appObjects.idiomaHosp);

            Elementos.EncontraElementoName(sessionVHF, appObjects.rbCompartilhar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaMsgAtencao);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSim).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnOK).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnOK).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSair).Click();
        }

        public void MaximizarTelaConsultaGeral()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.winConsultaGeral);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnMaximizar).Click();
        }

        public void RepetirReserva()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnRepetir).Click();
        }

        public void VisualizarOrcamentoConsultaGeral()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnOrcReservas).Click();

            Debug.WriteLine($"*** Identificar janelas {sessionVHF.WindowHandles}");

            var winOrcReservaConsultaGeral = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            
            var titleScreenOrcReserva = sessionVHF.FindElementByClassName(appObjects.scrTelaOrcReserva);

            bool screenOrcReserva = false;
            WindowsElement titleValidado = null;

            if (titleScreenOrcReserva.Text.Equals(appObjects.winOrcReservas))
            {
                screenOrcReserva = true;
                titleValidado = titleScreenOrcReserva;
                Console.WriteLine("\nTela do orçamento reserva inicializada pela Consulta Geral.");
            }

            Assert.IsTrue(screenOrcReserva, "Tela do orçamento reserva NÃO inicializada.");

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSair).Click();
        }


        public void VisualizarOrcamentoCaixa()
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(23).Click();

            sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.First());
            var winSelec = sessionVHF.FindElementByClassName(appObjects.scrMontaSelect);

            var btnRight = sessionVHF.FindElementsByClassName(appObjects.TEdit).ElementAt(0);
            new Actions(sessionVHF).ContextClick(btnRight).Perform();

            Thread.Sleep(1000);

            new Actions(sessionVHF).MoveToElement(winSelec, 464, 218).Click().Perform();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Thread.Sleep(5000);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnOrcReservas).Click();

            Debug.WriteLine($"*** Identificar janelas {sessionVHF.WindowHandles}");

            var winOrcReservaCaixa = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));

            var titleScreenOrcReserva = sessionVHF.FindElementByClassName(appObjects.winOrcReservas);

            bool screenOrcReserva = false;
            WindowsElement titleValidado = null;

            if (titleScreenOrcReserva.Text.Equals(appObjects.scrTelaOrcReserva))
            {
                screenOrcReserva = true;
                titleValidado = titleScreenOrcReserva;
                Console.WriteLine("\nTela do orçamento reserva inicializada pelo VHF Caixa.");
            }

            Assert.IsTrue(screenOrcReserva, "Tela do orçamento reserva NÃO inicializada.");

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();    
        }

        public void SairTelaVHFCaixa()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSair).Click();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaMsgAtencao);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSim).Click();
        }

        public void InserirNomeGrupo()
        {
            var dadosEmp = GeradorDadosFakes.ListaDadosFakerEmpresa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBEdit).ElementAt(7).SendKeys(dadosEmp.PrefixoCompany);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBEdit).ElementAt(7).SendKeys(dadosEmp.NomeCompany);
        }

        public void InserirNumNoitesResGrupo(string qtdNoites)
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(2).SendKeys(qtdNoites);
        }

        public void SelecionarEmpresaResGrupo()
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(35).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.winSelecCliente);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(10).SendKeys(appObjects.docCliente);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
        }

        public void SelecionarContratoResGrupo()
        {
            Elementos.EncontraElementosName(sessionVHF, appObjects.btnContrato).ElementAt(2).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.winContratoCliente);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnOK).Click();

            Elementos.EncontraElementosName(sessionVHF, appObjects.btnContrato).ElementAt(0).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.winContatosCliente);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
        }

        public void InserirDocConfirmacaoResGrupo()
        {
            Elementos.EncontraElementoName(sessionVHF, "Reserva de Grupo");

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(4).SendKeys(appObjects.docEmail);

            var emailConfirResGrp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBEdit).ElementAt(1).SendKeys(emailConfirResGrp.EmailFaker);

            Elementos.EncontraElementoName(sessionVHF, "Abre Master").Click();
        }

        public void InserirAcomodacoes()
        {
            Elementos.EncontraElementoName(sessionVHF, "Incluir").Click();

            //var allTwwDBEdit = sessionVHF.FindElementsByClassName(appObjects.TwwDBEdit);
            //Debug.WriteLine($"*** Identificar os campos edit reserva grupo {allTwwDBEdit.Count}");

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBEdit).ElementAt(8).SendKeys("2");

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(8).SendKeys(appObjects.categUhStnd);

            sessionVHF.FindElementsByClassName(appObjects.TCMDBLookupCombo).ElementAt(8).SendKeys(Keys.Tab);

            sessionVHF.FindElementsByClassName(appObjects.TCMDBLookupCombo).ElementAt(7).SendKeys(Keys.Tab);

            Elementos.EncontraElementosName(sessionVHF, appObjects.btnConfirmar).ElementAt(1).Click();

            Elementos.EncontraElementosName(sessionVHF, appObjects.btnConfirmar).ElementAt(0).Click();
        }

        public void ValidarSituacaoResGrupo()
        {
            Thread.Sleep(5000);

            sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));

            var sitResGrp = sessionVHF.FindElementByName(appObjects.winSitReserva);

            Debug.WriteLine($"*** Identificar janelas {sessionVHF.WindowHandles}");

            var winSitResGrp = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));

            var editSitResGrp = sitResGrp.FindElementsByClassName(appObjects.TEdit);

            numResGrp = editSitResGrp.ElementAt(4);
            new Actions(sessionVHF).MoveToElement(numResGrp).DoubleClick().Perform();
            numResGrp.SendKeys(Keys.Control + "c");
            numResGrp.SendKeys(Keys.Control + "v");

            Console.WriteLine("Numero de Reserva Gerado: " + numResGrp.Text);
        }

        public void InserirDirecioamentoDeDespesasResGrupo()
        {
            Thread.Sleep(3000);

            Elementos.EncontraElementoName(sessionVHF, appObjects.winSitReserva);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnContaDirec).Click();

            Debug.WriteLine($"*** Identificar janelas {sessionVHF.WindowHandles}");

            var winDirecDesp = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            winDirecDesp.Manage().Window.Maximize();

            var selecDirecDesp = sessionVHF.FindElementByName(appObjects.winDirecDespesasGrp);

            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 140).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 170).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 196).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 220).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 246).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 284).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 320).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 346).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 370).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 396).Click().Perform();
            //new Actions(sessionVHF).MoveToElement(selecDirecDesp, 112, 420).Click().Perform();

            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 350, 280).Click().Perform();
            new Actions(sessionVHF).MoveToElement(selecDirecDesp, 396, 176).Click().Perform();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.scrTelaMsgAtencao);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnOK).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnSair).Click();
        }
    }
}

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

namespace VHF.CommonMethods
{
    public class FuncComuns : SessaoMain
    {
        public FuncComuns()
        {

        }

        AppObjects appObjects = new AppObjects();

        public static AppiumWebElement numRes;

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

        public void PreencherUh(string botao)
        {
            Elementos.EncontraElementoName(sessionVHF, botao).Click();
            if (botao == "ocupado")
            {
                Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhEstadia);
                Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.categUhStnd);
                Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
            }
            else if (botao == "cobrado")
            {
                Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhTarifa);
                Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.categUhStnd);
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

        public void InserirDadosHosp()
        {
            var dadosHosp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(46).Click();
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(19).SendKeys(dadosHosp.NomeFaker);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(20).SendKeys(dadosHosp.SobrenomeFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(18).SendKeys(dadosHosp.EmailFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDBLookupCombo).ElementAt(1).SendKeys(dadosHosp.TratamentoHosp);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDateTimePicker).ElementAt(3).SendKeys(dadosHosp.DtNascFaker);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnCidade).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winSelecCidade);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(6).SendKeys(dadosHosp.CidadeFaker);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnIdioma).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winIdiomaHosp);
            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.idiomaHosp);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(46).Click();
        }

        public void InserirDocConfirmacao()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.winDocConfirmacaoRes);

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.docEmail);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            var emailConfirRes = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBEdit).ElementAt(7).SendKeys(emailConfirRes.EmailFaker);
        }

        public void VisualizarOrcamentoRes()
        {
            Elementos.EncontraElementoName(sessionVHF, appObjects.txtVisualOrcamento).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();
        }

        public void ValidarSituacaoRes()
        {           
            Debug.WriteLine($"*** Identificar janelas {sessionVHF.WindowHandles}");

            var winSitRes = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            winSitRes.Title.ToString();

            var sitRes = sessionVHF.FindElementByName("Situação da Reserva");

            var editSitRes = sitRes.FindElementsByClassName("TEdit");

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
    }
}

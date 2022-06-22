using System;
using System.Collections.Generic;
using VHF.Main;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VHF.PageObjects;
using OpenQA.Selenium.Interactions;

namespace VHF.CommonMethods
{
    public class FuncComuns : SessaoMain
    {
        public FuncComuns()
        {

        }

        AppObjects appObjects = new AppObjects();

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

        public void InserirNumNoites()
        {
            var anexEstd = sessionVHF.FindElementByName(appObjects.winEstada);

            var editNoites = anexEstd.FindElementsByClassName(appObjects.TEdit);

            var noitesEstd = editNoites.ElementAt(0);
            new Actions(sessionVHF).MoveToElement(noitesEstd).DoubleClick().Perform();
            noitesEstd.Clear();
            noitesEstd.SendKeys(appObjects.numNoites);
        }

        public void PreencherDatasEstada()
        {
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDateTimePicker).ElementAt(2).SendKeys("01/07/2022");
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TCMDateTimePicker).ElementAt(1).SendKeys("05/07/2022");
        }

       public void CriaReserva()
       {
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnUhOcupado).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhEstadia);
            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.categUhSuite);
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();


            Elementos.EncontraElementoName(sessionVHF, appObjects.btnUhCobrado).Click();
            Elementos.EncontraElementoName(sessionVHF, appObjects.winTipoUhTarifa);
            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.categUhSuite);
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            /* Elementos.EncontraElementoName(sessionVHF, "numero").Click();
             Elementos.EncontraElementoName(sessionVHF, "Seleciona UH");
             //var tmp = Elementos.EncontraElementosClassName(sessionVHF, "TEdit");
             Elementos.EncontraElementoName(sessionVHF, "Procurar").Click();
             Elementos.EncontraElementoName(sessionVHF, "Sim").Click();
             Elementos.EncontraElementoName(sessionVHF, "Confirmar").Click();*/

            var dadosHosp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(46).Click();
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(19).SendKeys(dadosHosp.NomeFaker);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(20).SendKeys(dadosHosp.SobrenomeFaker);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TBitBtn).ElementAt(47).Click();
            
            Elementos.EncontraElementoName(sessionVHF, appObjects.winDocConfirmacao);

            Elementos.EncontraElementoClassname(sessionVHF, appObjects.TEdit).SendKeys(appObjects.docEmail);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBEdit).ElementAt(7).SendKeys(dadosHosp.EmailFaker);

            //Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            //Elementos.EncontraElementoName(sessionVHF, appObjects.btnSair).Click();

       }

    }
}

using System;
using System.Collections.Generic;
using VHF.Main;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace VHF.CommonMethods
{
    public class FuncComuns : SessaoMain
    {
        public FuncComuns()
        {

        }

       public void ChamarAtalho(string tecla1, string tecla2, string tecla3 = null, string tecla4 = null)
       {
            if (tecla4 != null)
            {
                Elementos.EncontraElementoTagName(sessionVHF, "MenuItem").SendKeys(Keys.Alt + tecla1 + tecla2 + tecla3 + tecla4);
            } 
            else if (tecla3 != null)
            {
                Elementos.EncontraElementoTagName(sessionVHF, "MenuItem").SendKeys(Keys.Alt + tecla1 + tecla2 + tecla3);
            }
            else
            {
                Elementos.EncontraElementoTagName(sessionVHF, "MenuItem");
                Elementos.EncontraElementoTagName(sessionVHF, "MenuItem").SendKeys(Keys.Alt + tecla1 + tecla2);
            }
       }

       public void CriaReserva()
       {

            Elementos.EncontraElementosClassName(sessionVHF, "TCMDateTimePicker").ElementAt(2).SendKeys("18/03/2022");
            Elementos.EncontraElementosClassName(sessionVHF, "TCMDateTimePicker").ElementAt(1).SendKeys("22/03/2022");

            Elementos.EncontraElementoName(sessionVHF, "ocupado").Click();
            Elementos.EncontraElementoName(sessionVHF, "Tipo de UH Estadia");
            Elementos.EncontraElementoClassname(sessionVHF, "TEdit").SendKeys("SUITE MASTER");
            Elementos.EncontraElementoName(sessionVHF, "Confirmar").Click();


            Elementos.EncontraElementoName(sessionVHF, "cobrado").Click();
            Elementos.EncontraElementoName(sessionVHF, "Tipo de UH Tarifa");
            Elementos.EncontraElementoClassname(sessionVHF, "TEdit").SendKeys("SUITE MASTER");
            Elementos.EncontraElementoName(sessionVHF, "Confirmar").Click();

            /* Elementos.EncontraElementoName(sessionVHF, "numero").Click();
             Elementos.EncontraElementoName(sessionVHF, "Seleciona UH");
             //var tmp = Elementos.EncontraElementosClassName(sessionVHF, "TEdit");
             Elementos.EncontraElementoName(sessionVHF, "Procurar").Click();
             Elementos.EncontraElementoName(sessionVHF, "Sim").Click();
             Elementos.EncontraElementoName(sessionVHF, "Confirmar").Click();*/
            

            Elementos.EncontraElementosClassName(sessionVHF, "TBitBtn").ElementAt(46).Click();
            Elementos.EncontraElementosClassName(sessionVHF, "TEdit").ElementAt(19).SendKeys("TEST");
            Elementos.EncontraElementosClassName(sessionVHF, "TEdit").ElementAt(20).SendKeys("DOIS");

            Elementos.EncontraElementosClassName(sessionVHF, "TBitBtn").ElementAt(47).Click();
            
            Elementos.EncontraElementoName(sessionVHF, "Documento de Confirmação");

            Elementos.EncontraElementoClassname(sessionVHF, "TEdit").SendKeys("EMAIL");

            Elementos.EncontraElementoName(sessionVHF, "Confirmar").Click();

            Elementos.EncontraElementosClassName(sessionVHF, "TwwDBEdit").ElementAt(7).SendKeys("teste@gmail.com");

           // Elementos.EncontraElementoName(sessionVHF, "Confirmar").Click();

           // Elementos.EncontraElementoName(sessionVHF, "Sair").Click();

       }

    }
}

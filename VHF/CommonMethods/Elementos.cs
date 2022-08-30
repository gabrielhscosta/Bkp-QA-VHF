using System;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace VHF.CommonMethods
{
    public static class Elementos
    {
        public static WindowsElement EncontraElementoTagName(
            this WindowsDriver<WindowsElement> sessionVHF,
            string Identificador,
            int nTryCount = 3)
        {
            WindowsElement uiTarget = null;
            System.Threading.Thread.Sleep(2000);
            while (nTryCount-- > 0)
            {
                try
                {
                    sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.First());
                    System.Threading.Thread.Sleep(500);
                    uiTarget = sessionVHF.FindElementByTagName(Identificador);
                }
                catch
                {
                }
                if (uiTarget != null)
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            return uiTarget;
        }
        public static WindowsElement EncontraElementoName(
            this WindowsDriver<WindowsElement> sessionPDV,
            string Name,
            int nTryCount = 3)
        {
            WindowsElement uiTarget = null;
            System.Threading.Thread.Sleep(2000);
            while (nTryCount-- > 0)
            {
                try
                {
                    sessionPDV.SwitchTo().Window(sessionPDV.WindowHandles.First());
                    System.Threading.Thread.Sleep(500);
                    uiTarget = sessionPDV.FindElementByName(Name);
                }
                catch
                {
                }
                if (uiTarget != null)
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            return uiTarget;
        }

        public static IReadOnlyCollection<WindowsElement> EncontraElementosName(
           this WindowsDriver<WindowsElement> acessarModulo,
           string name)
        {
            IReadOnlyCollection<WindowsElement> elementos = null;
            WebDriverWait waitForMe = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(120));
            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());
            elementos = acessarModulo.FindElementsByName(name);
            waitForMe.Until(pred => elementos.Count() != 0);
            return elementos;
        }

        public static WindowsElement EncontraElementoClassname(
           this WindowsDriver<WindowsElement> sessionFiscallFlex,
           string className)
        {
            WindowsElement elemento = null;
            WebDriverWait waitForMe = new WebDriverWait(sessionFiscallFlex, TimeSpan.FromSeconds(120));
            sessionFiscallFlex.SwitchTo().Window(sessionFiscallFlex.WindowHandles.First());
            elemento = sessionFiscallFlex.FindElementByClassName(className);
            waitForMe.Until(pred => elemento.Displayed);
            return elemento;
        }

        public static IReadOnlyCollection<WindowsElement> EncontraElementosClassName(
           this WindowsDriver<WindowsElement> sessionVHF,
           string className)
        {
            IReadOnlyCollection<WindowsElement> elementos = null;
            WebDriverWait waitForMe = new WebDriverWait(sessionVHF, TimeSpan.FromSeconds(60));
            sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.First());
            elementos = sessionVHF.FindElementsByClassName(className);
            waitForMe.Until(pred => elementos.Count() != 0);
            return elementos;
        }


    }
}

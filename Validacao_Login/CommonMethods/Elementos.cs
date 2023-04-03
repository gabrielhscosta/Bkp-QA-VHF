﻿using System;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Validacao_Login.CommonMethods
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
            this WindowsDriver<WindowsElement> sessionVHF,
            string Name,
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
                    uiTarget = sessionVHF.FindElementByName(Name);
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
           this WindowsDriver<WindowsElement> sessionVHF,
           string name)
        {
            IReadOnlyCollection<WindowsElement> elementos = null;
            WebDriverWait waitForMe = new WebDriverWait(sessionVHF, TimeSpan.FromSeconds(120));
            sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.First());
            elementos = sessionVHF.FindElementsByName(name);
            waitForMe.Until(pred => elementos.Count() != 0);
            return elementos;
        }

        public static WindowsElement EncontraElementoClassName(
           this WindowsDriver<WindowsElement> sessionVHF,
           string className)
        {
            WindowsElement elemento = null;
            WebDriverWait waitForMe = new WebDriverWait(sessionVHF, TimeSpan.FromSeconds(120));
            sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.First());
            elemento = sessionVHF.FindElementByClassName(className);
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

        public static WindowsElement EncontraElementoAutomationId(
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
                    uiTarget = sessionVHF.FindElementByAccessibilityId(Identificador);
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
    }
}

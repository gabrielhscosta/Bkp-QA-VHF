﻿using Validacao_Login.Main;
using Validacao_Login.CommonMethods;
using System.Linq;
using Validacao_Login.PageObjects;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using OpenQA.Selenium;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace Validacao_Login.TestCase.ST00_ValidaLoginModulos
{

    public class LoginGlobal : SessaoMain
    {

        public LoginGlobal()
        {

        }

        public void ValidaLoginGlobal()
        {
            AppObjects appObjects = new AppObjects();


            // *** Inicialização do módulo ***

            #region Inicialização do módulo GlobalCM
            AppiumOptions session3 = new AppiumOptions();
            session3.AddAdditionalCapability("app", dirAplicacaoGlobal);
            sessionVHF = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl), session3);

            #endregion



            #region Usuário e Pass Sistema

            Debug.WriteLine($"*** Identificador da janela: {sessionVHF.WindowHandles}");

            var anexLogin = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjects.titleTelaLogin);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(0).SendKeys(appObjects.userSys);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TEdit).ElementAt(1).SendKeys(appObjects.passSys);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            #endregion



            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(sessionVHF, appObjects.TwwDBLookupCombo);

            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBLookupCombo).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBLookupCombo).ElementAt(0).SendKeys(appObjects.empresaSys);
            Elementos.EncontraElementosClassName(sessionVHF, appObjects.TwwDBLookupCombo).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(sessionVHF, appObjects.btnConfirmar).Click();

            #endregion



            #region Janela Registro de versão

            Thread.Sleep(5000);

            Elementos.EncontraElementoName(sessionVHF, appObjects.txtAlertLicenca);
            Elementos.EncontraElementoName(sessionVHF, appObjects.btnContinuar).Click();

            #endregion



            #region Conferência Tela Principal do Global

            Thread.Sleep(1000);

            Debug.WriteLine($"*** Identificador da janela: {sessionVHF.WindowHandles}");

            var anexFt = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            anexFt.Title.ToString();

            var titleScreenGlobal = sessionVHF.FindElementByClassName(appObjects.scrTelaPrincipal);

            bool screenGlobal = false;
            WindowsElement titleValidado = null;

            if (titleScreenGlobal.Text.StartsWith(appObjects.titleTelaPrincGlobal))
            {
                screenGlobal = true;
                titleValidado = titleScreenGlobal;
                Debug.WriteLine("Tela Principal do Global CM inicializada com sucesso.");
            }

            Assert.IsTrue(screenGlobal, "Tela Principal do Global CM não inicializada.");

            #endregion


        }

        public void LoginGlobalTearDown()
        {
            if (sessionVHF != null)
            {
                sessionVHF.Close();
                sessionVHF.Quit();
                sessionVHF = null;
            }
        }
    }
}
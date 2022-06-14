using VHF.Main;
using VHF.PageObjects;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace VHF.TestCase.ST00_ValidaLoginModulos
{
    public class LoginVHFCaixa : SessaoMain
    {
        public LoginVHFCaixa()
        {

        }

        public void ValidaLoginVHFCaixa()
        {

            AppObjects appObjectsVhfCaixa = new AppObjects();

            #region Usuário e Senha Sistema

            var anexLogin = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjectsVhfCaixa.titleTelaLogin);

            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhfCaixa.TEdit).ElementAt(0).SendKeys(appObjectsVhfCaixa.userSys);
            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhfCaixa.TEdit).ElementAt(1).SendKeys(appObjectsVhfCaixa.passSys);

            Elementos.EncontraElementoName(sessionVHF, appObjectsVhfCaixa.btnConfirmar).Click();

            #endregion

            #region Seleciona Empresa

            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhfCaixa.TwwDBLookupCombo).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhfCaixa.TwwDBLookupCombo).ElementAt(0).SendKeys(appObjectsVhfCaixa.empresaSys);
            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhfCaixa.TwwDBLookupCombo).ElementAt(0).SendKeys(Keys.Tab);
            Elementos.EncontraElementoName(sessionVHF, appObjectsVhfCaixa.btnConfirmar).Click();

            #endregion

            #region Conferência Tela Principal VHF Caixa

            bool screenOpeCaixa = false;

            if (sessionVHF.FindElementByClassName(appObjectsVhfCaixa.scrTelaPrincipalCAIXA).Text.Equals(appObjectsVhfCaixa.titleTelaPrincVHFCaixa))
            {
                screenOpeCaixa = true;
                Debug.WriteLine("Tela Principal do VHF Caixa inicializada com sucesso.");

            }

            Assert.IsTrue(screenOpeCaixa, "Tela Principal do VHF Caixa não inicializada");

            #endregion
        }

    }
}

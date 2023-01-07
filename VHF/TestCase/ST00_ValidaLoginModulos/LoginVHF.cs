using VHF.Main;
using VHF.PageObjects;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace VHF.TestCase.ST00_ValidaLoginModulos
{
    public class LoginVHF : SessaoMain
    {

        public LoginVHF()
        {

        }

        public void ValidaLoginVHF()
        {

            AppObjects appObjectsVhf = new AppObjects();

            #region Usuário e Senha Sistema

            var anexLogin = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Equals(appObjectsVhf.titleTelaLogin);

            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhf.TEdit).ElementAt(0).SendKeys(appObjectsVhf.userSys);
            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhf.TEdit).ElementAt(1).SendKeys(appObjectsVhf.passSys);

            Elementos.EncontraElementoName(sessionVHF, appObjectsVhf.btnConfirmar).Click();

            #endregion

            #region Seleciona Empresa


            Thread.Sleep(50000);
            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhf.TwwDBLookupCombo).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhf.TwwDBLookupCombo).ElementAt(0).SendKeys(appObjectsVhf.empresaSys);
            Elementos.EncontraElementosClassName(sessionVHF, appObjectsVhf.TwwDBLookupCombo).ElementAt(0).SendKeys(Keys.Tab);
            Elementos.EncontraElementoName(sessionVHF, appObjectsVhf.btnConfirmar).Click();

            #endregion


            #region Janela Atenção

            Thread.Sleep(90000);
            Elementos.EncontraElementoName(sessionVHF, appObjectsVhf.txtAlertAtencao);
            Elementos.EncontraElementoName(sessionVHF, appObjectsVhf.btnOK).Click();

            #endregion
            

            #region Conferência Tela Principal VHF

            bool screenPrincipal = false;

            if (sessionVHF.FindElementByClassName(appObjectsVhf.scrTelaPrincipal).Text.StartsWith(appObjectsVhf.titleTelaPrincipalVHF))
            {
                screenPrincipal = true;
                Debug.WriteLine("Tela Principal do VHF inicializada com sucesso.");
            }

//            Assert.IsTrue(screenPrincipal, "Tela Principal do VHF não inicializada.");

            #endregion
        }

    }
}

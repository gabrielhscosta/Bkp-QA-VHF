using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHF.DadosYaml;
using VHF.Main;
using VHF.PageObjects;

namespace VHF.CommonMethods
{
    // classe para criar as validacao juntamente com os asserts
    public class Validacoes : SessaoMain
    {
        public Validacoes()
        {

        }

        AppObjects appObjetcs = new AppObjects();
        RealizaConsultas realizaConsultas = new RealizaConsultas();

        public void ValidaReservaGerada()
        {
            string numReserva = realizaConsultas.SelectValidarReservaGerada();
            Assert.AreEqual(FuncComuns.numRes.Text + ",00", numReserva);
   
        }

        public void ValidaNumeroLinhaDoOrc(int qtdNoites)
        {
            int linhasOrc = realizaConsultas.SelectValidarNumeroLinhasOrcamento();
            Assert.AreEqual(qtdNoites, linhasOrc);
        }

        public void ValidaOrcamento(string UH, int qtdPaxAdulto, int qtdPaxCriancaUm, int qtdPaxCriancaDois, string tarifa = "BALCAO 2021-60")
        {
            List<TarifaConsulta> lista = realizaConsultas.SelectValidarValorOrcamento();

            DeserializedObject dadosYaml = ImportaYaml.Deserialize(@"..\..\DadosYaml\tarifa.yml");

            int indice = dadosYaml.tarifa.FindIndex(tmp => tmp.descricao.Equals(tarifa));

            float soma = 0;
            switch (qtdPaxAdulto)
            {
                case 1:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorUmPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 2:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorDoisPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 3:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorTresPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 4:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorQuatroPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 5:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorCincoPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
            }

            foreach (TarifaConsulta t in lista)
            {
                Assert.AreEqual(dadosYaml.tarifa[indice].descricao,t.Descricao);
                Assert.AreEqual(soma, t.Valor);
                Assert.AreEqual(soma, t.ValorTarifa);
            }

        }

        public void ValidaOrcamentoCortesiaUsoDaCasa(string tarifa = "BALCAO 2021-60")
        {
            List<TarifaConsulta> lista = realizaConsultas.SelectValidarValorOrcamento();

            DeserializedObject dadosYaml = ImportaYaml.Deserialize(@"..\..\DadosYaml\tarifa.yml");

            int indice = dadosYaml.tarifa.FindIndex(tmp => tmp.descricao.Equals(tarifa));

            foreach (TarifaConsulta t in lista)
            {
                Assert.AreEqual(dadosYaml.tarifa[indice].descricao, t.Descricao);
                Assert.AreEqual(0, t.Valor);
            }

        }

        public void ValidaDirecionamentoDespesas(int qtdDespesas)
        {
            int linhasDirec = realizaConsultas.SelectValidaDirecionamentoDespesas();
            Assert.AreEqual(qtdDespesas, linhasDirec);
        }

        public void ValidaSlipDeReserva()
        {
            Debug.WriteLine($"*** Identificar janelas {sessionVHF.WindowHandles}");

            var winVisualSlip = sessionVHF.SwitchTo().Window(sessionVHF.WindowHandles.ElementAt(0));
            //winVisualSlip.Manage().Window.Maximize();

            var validaImpSlip = sessionVHF.FindElementByName("Visualizando impressão");

            validaImpSlip.FindElementByName(appObjetcs.btnFechar).Click();

            Elementos.EncontraElementoName(sessionVHF, appObjetcs.btnSair).Click();
        }

        public void ValidaNumeroHospedes(int qtdAdultos)
        {
            int linhaAdultos = realizaConsultas.SelectValidarNumeroHospedes();
            Assert.AreEqual(qtdAdultos, linhaAdultos);
        }

        public void ValidaOrcamentoComAlteracao(string UH, int qtdPaxAdulto, int qtdPaxCriancaUm, int qtdPaxCriancaDois, string tarifa = "BALCAO 2021-60")
        {
            List<TarifaConsulta> lista = realizaConsultas.SelectValidarValorOrcamentoComAlteracao();

            DeserializedObject dadosYaml = ImportaYaml.Deserialize(@"..\..\DadosYaml\tarifa.yml");

            int indice = dadosYaml.tarifa.FindIndex(tmp => tmp.descricao.Equals(tarifa));

            float soma = 0;
            switch (qtdPaxAdulto)
            {
                case 1:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorUmPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 2:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorDoisPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 3:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorTresPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 4:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorQuatroPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 5:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorCincoPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
            }

            foreach (TarifaConsulta t in lista)
            {
                Assert.AreEqual(dadosYaml.tarifa[indice].descricao, t.Descricao);
                Assert.AreEqual(soma, t.Valor);
                Assert.AreEqual(soma, t.ValorTarifa);
            }
        }

        public void ValidaReservaGrpGerada()
        {
            string numReservaGrp = realizaConsultas.SelectValidarReservaGrpGerada();
            Assert.AreEqual(FuncComuns.numResGrp.Text + ",00", numReservaGrp);

        }

        public void ValidaContaMasterReservaGrp(string abreMaster)
        {
            string contaMasterGrp = realizaConsultas.SelectValidarContaMasterReservaGrp();
            Assert.AreEqual(abreMaster, contaMasterGrp);
        }

        public void ValidaNumeroLinhaDoOrcGrp(int qtdNoites)
        {
            int linhasOrcGrp = realizaConsultas.SelectValidarNumeroLinhasOrcamentoGrp();
            Assert.AreEqual(qtdNoites, linhasOrcGrp);
        }

        public void ValidaOrcamentoGrp(string UH, int qtdPaxAdulto, int qtdPaxCriancaUm, int qtdPaxCriancaDois, string tarifa = "BALCAO 2021-60")
        {
            List<TarifaConsulta> lista = realizaConsultas.SelectValidarValorOrcamentoGrp();

            DeserializedObject dadosYaml = ImportaYaml.Deserialize(@"..\..\DadosYaml\tarifa.yml");

            int indice = dadosYaml.tarifa.FindIndex(tmp => tmp.descricao.Equals(tarifa));

            float soma = 0;
            switch (qtdPaxAdulto)
            {
                case 1:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorUmPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 2:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorDoisPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 3:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorTresPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 4:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorQuatroPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 5:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorCincoPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
            }

            foreach (TarifaConsulta t in lista)
            {
                Assert.AreEqual(dadosYaml.tarifa[indice].descricao, t.Descricao);
                Assert.AreEqual(soma, t.Valor);
                Assert.AreEqual(soma, t.ValorTarifa);
            }
        }

        public void ValidaDirecionamentoDespesasGrp(int qtdDespesas)
        {
            int linhasDirecGrp = realizaConsultas.SelectValidaDirecionamentoDespesasGrp();
            Assert.AreEqual(qtdDespesas, linhasDirecGrp);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHF.DadosYaml;

namespace VHF.CommonMethods
{
    // classe para criar as validacao juntamente com os asserts
    public class Validacoes
    {
        public Validacoes()
        {

        }

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

    }
}

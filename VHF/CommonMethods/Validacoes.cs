using Microsoft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Console.WriteLine("\nGet da reserva no sistema (Tela Situação da reserva): {0}\r\nResultado da consulta no banco de dados: {1}", FuncComuns.numRes.Text + ",00", numReserva);
        }

        public void ValidaNumeroLinhaDoOrc(int qtdNoites)
        {
            int linhasOrc = realizaConsultas.SelectValidarNumeroLinhasOrcamento();
            Assert.AreEqual(qtdNoites, linhasOrc);

            Console.WriteLine("\nQtd noites da reserva: {0}\r\nLinhas orçamento: {1}", qtdNoites, linhasOrc);
        }

        public void ValidaOrcamento(string UH, int qtdPax)
        {
            List<TarifaConsulta> lista = realizaConsultas.SelectValidarValorOrcamento();

            DeserializedObject dadosYaml = ImportaYaml.Deserialize(@"..\..\DadosYaml\tarifa.yml");

            foreach (TarifaConsulta t in lista)
            {
                Assert.AreEqual(dadosYaml.tarifa[0].descricao,t.Descricao);                
                Assert.AreEqual(dadosYaml.tarifa[0].valorUHs[0].valorUmPax, t.Valor);
                Assert.AreEqual(dadosYaml.tarifa[0].valorUHs[0].valorUmPax, t.ValorTarifa);
            }

            Console.WriteLine("\nValor da tarifa para 1 pax na categoria STDN: {0}\r\nValor do orçamento no banco de dados: {1}", dadosYaml.tarifa[0].valorUHs[0].valorUmPax, lista[0].Valor);
        }

    }
}

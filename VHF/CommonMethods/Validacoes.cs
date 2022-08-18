using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ValidaOrcamento(string UH, int qtdPax)
        {
            List<TarifaConsulta> lista = realizaConsultas.SelectValidarValorOrcamento();

            foreach (TarifaConsulta t in lista)
            {
               // Assert.AreEqual(,t.Descricao);
               // Assert.AreEqual(, t.Valor);
               // Assert.AreEqual(, t.ValorTarifa);
            }
            
        }

    }
}

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


        public void ValidaOrcamento(string UH, int qtdPax)
        {
            List<Dictionary<string, object>> lista = realizaConsultas.SelectValidarValorOrcamento();

        }

    }
}

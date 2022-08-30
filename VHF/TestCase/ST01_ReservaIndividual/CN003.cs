using VHF.Main;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHF.TestCase.ST01_ReservaIndividual
{
    public class CN003 : SessaoMain
    {
        public CN003()
        {

        }

        public void ReservaIndividual_Com_Cliente_Contrato()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();


            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("7");

            funcComuns.PreencherUh("ocupado");

            funcComuns.SelecionarEmpresa();

            funcComuns.SelecionarContrato();

            funcComuns.BuscarHospComHistoricoEstada();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(7);

            validacoes.ValidaOrcamento("stnd", 1, 0, 0, "AUTO NET 2022-60");

            funcComuns.ValidarTelaPrincipalVhf();

        }

    }
}

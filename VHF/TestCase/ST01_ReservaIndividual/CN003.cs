using VHF.Main;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHF.PageObjects;

namespace VHF.TestCase.ST01_ReservaIndividual
{
    public class CN003 : SessaoMain
    {
        public CN003()
        {

        }

        public void ReservaIndividualComClienteContrato()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("7");

            funcComuns.PreencherUh(appObjects.btnUhOcupado, appObjects.categUhStnd);

            funcComuns.SelecionarEmpresa();

            funcComuns.SelecionarContrato();

            funcComuns.BuscarHospComHistoricoEstada();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(7);

            validacoes.ValidaOrcamento("stnd", 1, 0, 0, "AUTO ACORDO 2022-60");

            funcComuns.ValidarTelaPrincipalVhf();
        }

    }
}

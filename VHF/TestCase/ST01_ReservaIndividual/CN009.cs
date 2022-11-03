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
    public class CN009 : SessaoMain
    {
        public CN009()
        {

        }

        public void ReservaIndividualComDirecionamentoDeDespesas()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("7");

            funcComuns.PreencherUh(appObjects.btnUhOcupado, appObjects.categUhStnd);

            funcComuns.SelecionarEmpresa();

            funcComuns.SelecionarContrato();

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.InserirDirecioamentoDeDespesas();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaDirecionamentoDespesas(10);

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(7);

            validacoes.ValidaOrcamento("stnd", 1, 0, 0, "AUTO NET 2022-60");

            funcComuns.ValidarTelaPrincipalVhf();

        }

    }
}

using VHF.Main;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using VHF.PageObjects;
using System.Text;
using System.Threading.Tasks;

namespace VHF.TestCase.ST02_OrcamentoReserva
{
    public class CN022 : SessaoMain
    {
        public CN022()
        {

        }

        public void AlterarTipoDeUHReserva()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("7");

            funcComuns.PreencherUh("ocupado", appObjects.categUhSuite);

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(7);

            validacoes.ValidaOrcamento("suit", 1, 0, 0);

            funcComuns.ValidarTelaPrincipalVhf();

            funcComuns.AbrirTelaConsultaGeral();

            funcComuns.AcessarReserva(FuncComuns.numRes.Text);

            funcComuns.PreencherUh("ocupado", appObjects.categUhStnd);

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(5);

            validacoes.ValidaOrcamento("stnd", 1, 0, 0);

            funcComuns.ValidarTelaPrincipalVhf();
        }


    }
}

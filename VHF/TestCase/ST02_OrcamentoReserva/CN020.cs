using VHF.Main;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using VHF.PageObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHF.TestCase.ST02_OrcamentoReserva
{
    public class CN020 : SessaoMain
    {
        public CN020()
        {

        }

        public void AlterarQuantidadeDiasReserva()
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

            funcComuns.InserirNumNoites("5");

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(5);

            validacoes.ValidaOrcamento("suit", 1, 0, 0);

            funcComuns.ValidarTelaPrincipalVhf();

        }
    }
}

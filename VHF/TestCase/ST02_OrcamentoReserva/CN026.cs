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
    public class CN026 : SessaoMain
    {
        public CN026()
        {

        }

        public void EntradaDeHospede()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            funcComuns.ChamarAtalho("p", "w");

            funcComuns.InserirNumNoites("7");

            funcComuns.PreencherNumUh("ocupado", appObjects.categUhStnd);

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.AlertCartaoConsumo();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(7);

            validacoes.ValidaOrcamento("stnd", 1, 0, 0);

            funcComuns.ValidarTelaPrincipalVhf();

            funcComuns.AbrirTelaConsultaGeral();

            funcComuns.ConultarReserva();

            funcComuns.EntradaHospede();

            validacoes.ValidaNumeroHospedes(2);

            validacoes.ValidaOrcamentoComAlteracao("stnd", 2, 0, 0);

            funcComuns.SairTelaConsultaGeral();

            funcComuns.ValidarTelaPrincipalVhf();
            
        }
    }
}

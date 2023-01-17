using VHF.Main;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using VHF.PageObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHF.TestCase.ST00_ValidaLoginModulos;

namespace VHF.TestCase.ST02_OrcamentoReserva
{
    public class CN210 : SessaoMain
    {
        public CN210()
        {

        }

        public void ValidarEventoReservaEEventoHospede()
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

            funcComuns.VisualizarParteInferiorOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(7);

            validacoes.ValidaOrcamento("stnd", 1, 0, 0, "AUTO ACORDO 2022-60");

            funcComuns.ValidarTelaPrincipalVhf();
        }
    }
}

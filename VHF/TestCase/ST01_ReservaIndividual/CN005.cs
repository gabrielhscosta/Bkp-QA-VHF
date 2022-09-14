using VHF.Main;
using VHF.CommonMethods;
using VHF.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHF.TestCase.ST01_ReservaIndividual
{
    public class CN005 : SessaoMain
    {
        public CN005()
        {

        }

        public void ReservaIndividualComHospedeUsoDaCasa()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("5");

            funcComuns.PreencherUh("ocupado", appObjects.categUhSuite);

            funcComuns.InserirDadosHosp(tipoDeHospede:"Uso da Casa");

            funcComuns.InserirDocConfirmacao();

            funcComuns.InserirSegmentoHospede("01.04 - Particular Uso da Casa");

            funcComuns.InserirMotivoDeDesconto();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(5);

            validacoes.ValidaOrcamentoCortesiaUsoDaCasa();

            funcComuns.ValidarTelaPrincipalVhf();
        }

    }
}

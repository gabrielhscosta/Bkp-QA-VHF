using VHF.Main;
using VHF.CommonMethods;
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


            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("5");

            funcComuns.PreencherUh("ocupado");

            funcComuns.InserirDadosHosp(tipoDeHospede:"Uso da Casa");

            funcComuns.InserirDocConfirmacao();

            funcComuns.InserirSegmentoHospede();

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

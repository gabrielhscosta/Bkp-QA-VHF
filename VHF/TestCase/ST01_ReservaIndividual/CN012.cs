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
    public class CN012 : SessaoMain
    {
        public CN012()
        {

        }

        public void ReservaIndividualMaisDeUmHospedeComCrianca()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("5");

            funcComuns.PreencherUh("ocupado", appObjects.categUhSuite);

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            funcComuns.InserirMaisHospedes("2", "0", "0");

            funcComuns.InserirDadosHosp();

            funcComuns.InserirMaisHospedes("2", "1", "0");

            funcComuns.InserirDadosHosp("crianca");

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(5);

            validacoes.ValidaOrcamento("suit", 2,1,0);

            funcComuns.ValidarTelaPrincipalVhf();

        }
    }
}

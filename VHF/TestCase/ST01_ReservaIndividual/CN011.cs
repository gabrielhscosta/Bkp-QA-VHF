using VHF.Main;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHF.TestCase.ST01_ReservaIndividual
{
    public class CN011 : SessaoMain
    {

        public CN011()
        {

        }

        public void ReservaIndividualMaisDeUmHospede()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();

            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("5");

            funcComuns.PreencherUh("ocupado");

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            funcComuns.InserirMaisHospedes("2", "0", "0");

            funcComuns.InserirDadosHosp();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(5);

            validacoes.ValidaOrcamento("stnd", 2, 0, 0);

        }
    }
}

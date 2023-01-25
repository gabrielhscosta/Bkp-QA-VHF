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
    public class CN007 : SessaoMain
    {
        public CN007()
        {

        }

        public void ReservaIndividualPeloGridDeDisponibilidade()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            funcComuns.ChamarAtalho("c", "t", "d");

            funcComuns.InserirResGridDispo();

            funcComuns.InserirDadosHospDaReservaPeloGrid();

            funcComuns.InserirDocConfirmacaoDaReservaPeloGrid();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(5);

            funcComuns.ValidarTelaPrincipalVhf();

            funcComuns.ValidarTelaPrincipalVhf();
        }

    }
}

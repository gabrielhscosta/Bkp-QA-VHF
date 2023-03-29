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
    public class CN013 : SessaoMain
    {
        public CN013()
        {
            
        }

        public void VincularReservaIndividualAUmaReservaDeGrupo()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            CN030_Reserva_Grupo_Com_Conta_Master();

            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("6");

            funcComuns.PreencherUh(appObjects.btnUhOcupado, appObjects.categUhStnd);

            funcComuns.SelecionarEmpresa();

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(6);

            validacoes.ValidaOrcamento("stnd", 1, 0, 0);

            funcComuns.ValidarTelaPrincipalVhf();

            funcComuns.AbrirTelaConsultaGeral();

            funcComuns.ConultarReserva();

            funcComuns.VincularIndividualnaResGrupo();

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaRoomListGerado();

            funcComuns.SairTela();

            funcComuns.ValidarTelaPrincipalVhf();
        }

    }
}
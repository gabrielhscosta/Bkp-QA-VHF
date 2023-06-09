﻿using VHF.Main;
using VHF.CommonMethods;
using VHF.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHF.TestCase.ST01_ReservaIndividual
{
    public class CN031 : SessaoMain
    {
        public CN031()
        {

        }

        public void ReservaGrupoComDirecionamentoDeDespesas()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();

            funcComuns.ChamarAtalho("e", "g", "i");

            funcComuns.InserirNomeGrupo();

            funcComuns.InserirNumNoitesResGrupo("7");

            funcComuns.SelecionarEmpresaResGrupo();

            funcComuns.SelecionarContratoResGrupo();

            funcComuns.InserirDocConfirmacaoResGrupo();

            funcComuns.SelecionarAbreMasterResGrupo();

            funcComuns.InserirAcomodacoes();

            funcComuns.InserirDirecioamentoDeDespesasResGrupo();

            funcComuns.ValidarSituacaoResGrupo();

            validacoes.ValidaDirecionamentoDespesasGrp(10);

            validacoes.ValidaReservaGrpGerada();

            validacoes.ValidaContaMasterReservaGrp("S");

            validacoes.ValidaNumeroLinhaDoOrcGrp(7);

            validacoes.ValidaOrcamentoGrp("stnd", 1, 0, 0, "AUTO ACORDO 2022-60");

            funcComuns.ValidarTelaPrincipalVhf();
        }

    }
}

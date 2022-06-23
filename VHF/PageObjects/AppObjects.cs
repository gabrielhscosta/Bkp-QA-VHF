using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHF.PageObjects
{
    public class AppObjects
    {
        #region Dados de Login
        public string userSys = ("QAFRONT");
        public string passSys = ("QAFRONT123");
        public string empresaSys = ("1-AUTOMACAO DE TESTES");
        public string userSysOracle = ("CM");
        public string passSysOracle = ("CMSOL123");
        public string empresaSysOracle = ("KHOTEL - BASE TESTE SUPORTE");
        
        #endregion


        #region Button
        public string btnProcurar = ("Procurar");
        public string btnConfirmar = ("Confirmar");
        public string btnOK = ("OK");
        public string btnCancelar = ("Cancelar");
        public string btnSair = ("Sair");
        public string btnSim = ("Sim");
        public string btnNao = ("Não");
        public string btnEditar = ("Editar");
        public string btnVoltar = ("Voltar");
        public string btnFechar = ("Fechar");
        public string btnUhOcupado = ("ocupado");
        public string btnUhCobrado = ("cobrado");
        #endregion


        #region Componentes

        public string TEdit = ("TEdit");
        public string TDBEdit = ("TDBEdit");
        public string TwwDBEdit = ("TwwDBEdit");
        public string TDBMemo = ("TDBMemo");
        public string TCMDateTimePicker = ("TCMDateTimePicker");
        public string TwwDBGrid = ("TwwDBGrid");
        public string TRealEdit = ("TRealEdit");
        public string TMemo = ("TMemo");
        public string TDBRealEdit = ("TDBRealEdit");
        public string TwwDBDateTimePicker = ("TwwDBDateTimePicker");
        public string TwwDBLookupCombo = ("TwwDBLookupCombo");
        public string TwwDBComboBox = ("TwwDBComboBox");
        public string TComboBox = ("TComboBox");
        public string TCMDBLookupCombo = ("TCMDBLookupCombo");
        public string TBitBtn = ("TBitBtn");
        
        #endregion


        #region Screen
        public string scrTelaLogin = ("TfrmLogin");
        public string scrTelaPrincipal = ("TfrmPrincipal");
        public string scrTelaPrincipalCAIXA = ("TfrmPrincipalCAIXA");
        public string scrSelecGeral = ("TfrmSelecaoGeral");
        public string scrMontaSelect = ("TfrmMontaSelect");

        #endregion


        #region  Window

        public string winEstada = ("Estada");
        public string winTipoUhEstadia = ("Tipo de UH Estadia");
        public string winTipoUhTarifa = ("Tipo de UH Tarifa");
        public string winTipoUhQuarto = ("Seleciona UH");
        public string winDocConfirmacao = ("Documento de Confirmação");

        #endregion


        #region Text
        public string txtParamConexao = ("Parâmetros para conexão com o banco");
        public string txtConfig = ("Configurações");
        public string txtSQLServer = ("SQL Server");
        public string txtOracle = ("ORACLE");
        public string txtAlertAtencao = ("Atenção");
        public string titleTelaLogin = ("Login");
        public string titleTelaPrincipalVHF = ("Visual Hotal FrontOffice");
        public string titleTelaPrincVHFCaixa = ("Visual Hotal FrontOffice - CAIXA");
        public string titleTelaPrincCentralRes = ("CentralSUPER");
        public string titleTelaPrincEvento = ("Evento");
        public string titleTelaPrincFrontTurismo = ("FrontTurismo");
        public string titleTelaPrincGlobal = ("Global CM");
        public string titleTelaPrincipalSPA = ("SPA");
        public string titleTelaPrincipalSSD = ("SSD - Sistema de Segurança de Dados");
        public string titleTelaPrincTelefonia = ("Telefonia");
        public string titleTelaPrincipalTS = ("TimeSharing e Multipropriedade");

        #endregion


        #region Dados Reserva

        public string numNoites = ("3");
        public string categUhStnd = ("STND");
        public string categUhSuite = ("SUITE MASTER");
        public string idiomaHosp = ("Portugues");
        public string docEmail = ("EM");

        #endregion


        #region Tags

        public string tagMenuItem = ("MenuItem");

        #endregion



    }
}

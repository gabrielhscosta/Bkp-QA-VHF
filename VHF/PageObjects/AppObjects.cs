﻿using System;
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
        public string btnUhNumero = ("numeroxxxxxxxxxxxx");
        public string btnCidade = ("cidade");
        public string btnIdioma = ("idioma");
        public string btnDocHosp = ("documentohospede");
        public string btnContrato = ("contrato");
        public string btnReservarGrid = ("Reservar");
        public string btnContaDirec = ("Conta");
        public string btnSlip = ("Slip");
        public string btnVisualizar = ("Visualizar");
        public string btnEntradaHosp = ("Entrada Hósp.");
        public string btnMaximizar = ("Maximizar");
        public string btnRepetir = ("Repetir");
        public string btnOrcReservas = ("Orçamento reservas");
        public string btnContinuar = ("Continuar");

        #endregion


        #region RadioButton
        public string rbExterno = ("Externo");
        public string rbCompartilhar = ("Compartilhar");

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
        public string scrTelaResDisp = ("TfrmReservaDisp");
        public string scrTelaGridDisp = ("TStringGrid");
        public string scrTelaSugereTarifa = ("TfrmSugereTarifa");
        public string scrTelaMsgAtencao = ("TMessageForm");
        public string scrTelaDirecDespesas = ("TfrmCxDirecionaDesp");
        public string scrTelaEntradaHosp = ("TfrmEntradaHosp");
        public string scrTelaReservaIndiv = ("TfrmReserva");
        public string scrTelaOrcReserva = ("TfrmVisualizarOrcamentRes");


        #endregion


        #region  Window

        public string winEstada = ("Estada");
        public string winTipoUhEstadia = ("Tipo de UH Estadia");
        public string winTipoUhTarifa = ("Tipo de UH Tarifa");
        public string winTipoUhQuarto = ("Seleciona UH");
        public string winDadosPrincipais = ("Dados principais");
        public string winDocConfirmacao = ("Documento de Confirmação");
        public string winSelecCidade = ("Seleciona cidade");
        public string winIdiomaHosp = ("Idioma do Hóspede");
        public string winDocConfirmacaoRes = ("Documento de Confirmação");
        public string winSelecDocHosp = ("Seleciona documento do hóspede");
        public string winSitReserva = ("Situação da Reserva");
        public string winSelecCliente = ("Seleciona");
        public string winContratoCliente = ("Contratos da Empresa");
        public string winContatosCliente = ("Contatos");
        public string winDirecDespesas = ("Direcionamento de Despesas");
        public string winDirecDespesasGrp = ("Direcionamento de Despesas de Grupo");
        public string winSlipReserva = ("TfrmSlipDlg");
        public string winConsultaGeral = ("Consulta Geral");
        public string winOrcReservas = ("Orçamento Reservas");
        
        
        #endregion


        #region Text
        public string txtParamConexao = ("Parâmetros para conexão com o banco");
        public string txtConfig = ("Configurações");
        public string txtSQLServer = ("SQL Server");
        public string txtOracle = ("ORACLE");
        public string txtAlertAtencao = ("Atenção");
        public string txtAlertLicenca = ("Registro de Versões");
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
        public string txtVisualOrcamento = ("Clique para atualizar os valores do período");

        #endregion


        #region Dados Reserva

        public string numNoites = ("3");
        public string categUhStnd = ("STND");
        public string categUhSuite = ("SUITE MASTER");
        public string idiomaHosp = ("Portugues");
        public string docEmail = ("EM");
        public string docCliente = ("77048338000148");
        public string docHospEstada = ("88180094600");
        public string tipoHospPart = ("Particular");

        #endregion


        #region Tags

        public string tagMenuItem = ("MenuItem");

        #endregion


        #region Diretorios

        public string direcAnexo = @"C:\Users\gabriel.dacosta\Source\Repos\QA-VHF\VHF\DocAnexo\logo_totvs.jpg";
        
        #endregion





    }
}

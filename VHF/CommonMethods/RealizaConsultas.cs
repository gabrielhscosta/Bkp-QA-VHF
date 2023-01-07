﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VHF.PageObjects;

namespace VHF.CommonMethods
{
    public class RealizaConsultas
    {
        //Classe para desenvoler as queries a vir usar para validação

        public RealizaConsultas()
        {

        }

        ConexaoBD conexaoBd = new ConexaoBD();

        AppObjects appObject = new AppObjects();

        public string SelectValidarReservaGerada()
        {
            SqlCommand cmd = new SqlCommand();

            string getReserva = null;

            cmd.CommandText = "select numReserva" +
                        " from reservasfront" +
                        " where idHotel = 1" +
                        " and numReserva = " + FuncComuns.numRes.Text +
                        " order by numReserva desc";
            //" and  statusReserva = 1" +

            try
            {
                cmd.Connection = conexaoBd.conectar();
                getReserva = (cmd.ExecuteScalar()).ToString();
                conexaoBd.desconectar();
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            return getReserva;
        }

        public int SelectValidarNumeroLinhasOrcamento()
        {
            SqlCommand cmd1 = new SqlCommand();

            int lineOrc = 0;

            cmd1.CommandText = "select COUNT(*) from reservasfront r, ORCAMENTORESERVA oc " +
                "where r.idhotel = 1 and r.numreserva =  " + FuncComuns.numRes.Text +
                "and r.idhotel = oc.idhotel " +
                "and r.idreservasfront = oc.idreservasfront";

            try
            {
                cmd1.Connection = conexaoBd.conectar();
                lineOrc = (int)(cmd1.ExecuteScalar());
                conexaoBd.desconectar();
            }

            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            return lineOrc;
        }

        public List<TarifaConsulta> SelectValidarValorOrcamento()
        {
            SqlCommand cmd2 = new SqlCommand();

            SqlDataReader reader = null;

            List<TarifaConsulta> lista = null;

            cmd2.CommandText = "select t.Descricao, oc.VALOR, oc.VALORTARIFA from RESERVASFRONT r, ORCAMENTORESERVA oc, TARIFAHOTEL t where r.idhotel = 1 and r.numreserva = " + FuncComuns.numRes.Text + " and r.idhotel = oc.idhotel and r.idreservasfront = oc.idreservasfront and oc.IdHotel = t.IdHotel and oc.idTarifa = t.idTarifa order by data asc";

            try
            {
                cmd2.Connection = conexaoBd.conectar();
                reader = (cmd2.ExecuteReader());
                lista = new List<TarifaConsulta>();


                while (reader.Read())
                {
                    var tmp = new TarifaConsulta();
                    tmp.Descricao = reader["Descricao"].ToString();
                    tmp.Valor = Convert.ToInt32(reader["VALOR"]);
                    tmp.ValorTarifa = Convert.ToInt32(reader["VALORTARIFA"]);
                    lista.Add(tmp);

                }
                conexaoBd.desconectar();

            }

            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            return lista;
        }

        public int SelectValidaDirecionamentoDespesas()
        {
            SqlCommand cmd3 = new SqlCommand();

            int lineDirec = 0;

            cmd3.CommandText = "select count (*) from direcdespesas d, TipoDebCredHotel t, reservasfront r, contasfront c" +
                        " where d.idhotel = 1" +
                        " and r.numreserva = " + FuncComuns.numRes.Text +
                        " and d.idconta = c.idconta" +
                        " and r.IdReservasFront = c.IdReservasFront" +
                        " and d.idhotel = t.idhotel" +
                        " and d.idtipodebcred = t.idtipodebcred" +
                        " order by 1 desc";

            try
            {
                cmd3.Connection = conexaoBd.conectar();
                lineDirec = (int)(cmd3.ExecuteScalar());
                conexaoBd.desconectar();
            }

            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            return lineDirec;
        }

        public int SelectValidarNumeroHospedes()
        {
            SqlCommand cmd4 = new SqlCommand();

            int lineAdultos = 0;

            cmd4.CommandText = "select adultos from reservasfront " +
                "where idhotel = 1 and numReserva = " + FuncComuns.idRes.Text + 
                " order by numReserva desc";

            try
            {
                cmd4.Connection = conexaoBd.conectar();
                lineAdultos = (int)(cmd4.ExecuteScalar());
                conexaoBd.desconectar();
            }

            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            return lineAdultos;

        }

        public List<TarifaConsulta> SelectValidarValorOrcamentoComAlteracao()
        {
            SqlCommand cmd5 = new SqlCommand();

            SqlDataReader reader = null;

            List<TarifaConsulta> lista = null;

            cmd5.CommandText = "select t.Descricao, oc.VALOR, oc.VALORTARIFA from RESERVASFRONT r, ORCAMENTORESERVA oc, TARIFAHOTEL t where r.idhotel = 1 and r.numreserva = " + FuncComuns.idRes.Text + " and r.idhotel = oc.idhotel and r.idreservasfront = oc.idreservasfront and oc.IdHotel = t.IdHotel and oc.idTarifa = t.idTarifa order by data asc";

            try
            {
                cmd5.Connection = conexaoBd.conectar();
                reader = (cmd5.ExecuteReader());
                lista = new List<TarifaConsulta>();


                while (reader.Read())
                {
                    var tmp = new TarifaConsulta();
                    tmp.Descricao = reader["Descricao"].ToString();
                    tmp.Valor = Convert.ToInt32(reader["VALOR"]);
                    tmp.ValorTarifa = Convert.ToInt32(reader["VALORTARIFA"]);
                    lista.Add(tmp);

                }
                conexaoBd.desconectar();

            }

            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            return lista;
        }
    }

    public class TarifaConsulta
    {
        public string Descricao { get; set; }
        public int Valor { get; set; }
        public int ValorTarifa { get; set; }
    }
}

using System;
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
                " from RESERVASFRONT" +
                " where statusReserva = 1" +
                " and idHotel = 1" +
                " and numReserva = " + FuncComuns.numRes.Text +
                " order by numReserva desc";

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

            if (getReserva != null)
            {
                Assert.AreEqual(getReserva, FuncComuns.numRes.Text + ",00");

                Console.WriteLine("\nReserva " + FuncComuns.numRes.Text + " validada no BD com sucesso");
            }

            return getReserva;
        }

        public int SelectValidarNumeroLinhasOrcamento(int qtdNoites)
        {
            SqlCommand cmd1 = new SqlCommand();

            int lineOrc = 0;
            
            cmd1.CommandText = "select COUNT(*) from reservasfront r, ORCAMENTORESERVA oc where r.idhotel = 1 and r.numreserva = " + FuncComuns.numRes.Text + " and r.idhotel = oc.idhotel and r.idreservasfront = oc.idreservasfront";
                
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

            if (lineOrc == qtdNoites)
            {
                Console.WriteLine("\nOrçamento gerado de acordo com a quantidade de Pernoites da Reserva");
            }

            else
            {
                throw new AccessViolationException("\nErro na formação do Orçamento Reserva.");
            }

            return lineOrc;
        }
    }
}

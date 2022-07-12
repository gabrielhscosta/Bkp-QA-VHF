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

                Console.WriteLine("Reserva " + FuncComuns.numRes.Text + " validada no BD com sucesso");
            }

            return getReserva;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Validacao_Login.CommonMethods
{
    public class ConexaoBD
    {

        SqlConnection conn = new SqlConnection();

        public ConexaoBD()
        {
            conn.ConnectionString = "Data Source=RJOSRVDBODEV001;Initial Catalog=QA_FRONT;Persist Security Info=True;User ID=cm;Password=cmsol";
        }

        public SqlConnection conectar()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void desconectar()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertaMensalistaMotoboy
{
    class ConexaoDb
    {
        public SqlConnection getConexao()
        {
            SqlConnection conexao = new SqlConnection(@"Server = ; Database = BDALERTA; User Id = sa;Password = 75395146;");

            try
            {
                conexao.Open();
                return conexao;


            }catch(SqlException e)

            {
                 e.ToString();
                return conexao;

            }
        }

        public SqlCommand getComando(SqlConnection conexao)
        {
            SqlCommand comando = conexao.CreateCommand();
            return comando;

        }

        public SqlDataReader getReader(SqlCommand comando)
        {
            SqlDataReader reader = comando.ExecuteReader();
            return reader;

        }
    }
}

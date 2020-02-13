using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class alc
    {
        //define string de conexao e cria a conexao
        public static MySqlConnection conn = new MySqlConnection("Server=localhost;Database=dbfuncionarios;Uid=root;Pwd=123456");
        MySqlCommand comand = null;

        public DataTable consultar_tabela(string sql)
        {
            try
            {
                comand = new MySqlCommand(sql, conn);
                // comand.CommandTimeout = 5;
                conn.Open();
                comand.CommandType = CommandType.Text;
                MySqlDataAdapter dtadapter = new MySqlDataAdapter(comand);
                DataTable dt = new DataTable();
                dtadapter.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                throw ex;
            }
        }

        public string consultar_string(string sql)
        {
            try
            {
                comand = new MySqlCommand(sql, conn);
                // comand.CommandTimeout = 5;
                conn.Open();
                comand.CommandType = CommandType.Text;
                string resultado = Convert.ToString(comand.ExecuteScalar());
                conn.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                throw ex;
            }
        }

        public void comando(string sql)
        {
            try
            {
                comand = new MySqlCommand(sql, conn);
                // comand.CommandTimeout = 5;
                conn.Open();
                comand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                throw ex;
            }
        }
    }
}

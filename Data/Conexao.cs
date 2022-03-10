using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ControleTarefas.Data
{
    public class AcessoConexao : IDisposable
    {

        public SqlConnection Conexao { get; set; }
        private List<SqlParameter> Parametros { get; set; }
        public SqlCommand Comando { get; set; }



        public AcessoConexao()
        {
            Parametros = new List<SqlParameter>();
            Comando = new SqlCommand();
        }


        public bool Conectar(string ChaveConexao = "Conexao")
        {
            string stringConexao = Helper.CnnVal();

            try
            {
                if (stringConexao != "")
                {
                    Conexao = new SqlConnection(stringConexao);

                    Conexao.Open();

                    if (Conexao.State == System.Data.ConnectionState.Open)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AdicionarParametros(string paramName, object value, SqlDbType sqlType)
        {
            try
            {
                SqlParameter param = new SqlParameter();

                param.ParameterName = paramName;
                param.Value = value;
                param.SqlDbType = sqlType;

                this.Parametros.Add(param);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public SqlDataReader EfetuarPesquisa()
        {
            try
            {
                Comando.Connection = Conexao;
                Comando.CommandType = CommandType.Text;

                if (Parametros.Count > 0)
                {
                    Comando.Parameters.AddRange(Parametros.ToArray<SqlParameter>());
                }

                return Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ExecutarComando()
        {
            try
            {
                Comando.Connection = Conexao;
                Comando.CommandType = CommandType.Text;

                if (Parametros.Count > 0)
                {
                    Comando.Parameters.AddRange(Parametros.ToArray<SqlParameter>());
                }

                int rows = Comando.ExecuteNonQuery();

                if (rows == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void LimparParametros()
        {
            Parametros.Clear();
            Comando.Parameters.Clear();
        }


        public void Dispose()
        {
            if (Conexao != null)
            {
                if (Conexao.State != ConnectionState.Closed)
                {
                    Conexao.Close();
                }
                Conexao.Dispose();
                Conexao = null;
            }

            Parametros = null;
            Comando = null;

        }


    }
}